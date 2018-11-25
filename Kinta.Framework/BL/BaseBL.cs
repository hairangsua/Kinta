using Kinta.Framework.Data;
using Kinta.Framework.Exceptions;
using Kinta.Framework.Helper;
using Kinta.Framework.Repository;
using System;
using System.Collections.Generic;
using System.Data;

namespace Kinta.Framework.Bussiness
{
    public abstract class BaseBL<TEntity, TRepo> where TEntity : BaseModel, new() where TRepo : BaseRepository<TEntity>
    {
        public TRepo Repo
        {
            get
            {
                return (TRepo)Activator.CreateInstance(typeof(TRepo));
            }
        }

        public Error Create(List<TEntity> entities, IDbTransaction ts = null)
        {
            if (entities.IsNullOrEmpty())
            {
                return new Error(new ArgumentNullException(nameof(entities)));
            }
            try
            {
                var err = ValidateDataBeforeCreate(entities);
                if (err.IsNotOk())
                {
                    return err;
                }

                PrepareDataBeforeCreate(ref entities);

                foreach (var item in entities)
                {
                    item.SetGuid();
                    item.SetCreatedTime();
                    item.SetUpdatedTime();
                }

                using (ts = ts ?? Repo.Connection.BeginTransaction())
                {
                    Repo.BulkInsert(entities);
                    AfterSaveData(entities, ts);
                    ts.Commit();
                }

                return Error.OK;
            }
            catch (Exception)
            {
                ts.Rollback();
                throw;
            }

        }

        public virtual Error ValidateDataBeforeCreate(List<TEntity> entities)
        {
            return Error.OK;
        }

        public virtual void PrepareDataBeforeCreate(ref List<TEntity> entities)
        {
            return;
        }

        public Error Update(List<TEntity> entities, IDbTransaction ts = null)
        {
            if (entities.IsNullOrEmpty())
            {
                return new Error(new ArgumentNullException(nameof(entities)));
            }
            try
            {
                var err = ValidateDataBeforeUpdate(entities);
                if (err.IsNotOk())
                {
                    return err;
                }

                PrepareDataBeforeUpdate(ref entities);
                foreach (var item in entities)
                {
                    item.SetUpdatedTime();
                }

                using (ts = ts ?? Repo.Connection.BeginTransaction())
                {
                    Repo.BulkUpdate(entities);
                    AfterSaveData(entities, ts);
                    ts.Commit();
                }

                AfterSaveDataWithoutTransaction(entities);
                return Error.OK;
            }
            catch (Exception)
            {
                ts.Rollback();
                throw;
            }
        }

        public virtual void AfterSaveData(List<TEntity> entities, IDbTransaction ts)
        {

        }

        public virtual void AfterSaveDataWithoutTransaction(List<TEntity> entities)
        {

        }

        public virtual Error ValidateDataBeforeUpdate(List<TEntity> entities)
        {
            return Error.OK;
        }

        public virtual void PrepareDataBeforeUpdate(ref List<TEntity> entity)
        {
            return;
        }

        public Error Delete(TEntity entity, IDbTransaction ts = null)
        {
            if (entity == null)
            {
                return new Error(new ArgumentNullException(nameof(entity)));
            }

            var err = ValidateDataBeforeDelete(entity);
            if (err.IsNotOk())
            {
                return err;
            }

            Repo.Delete(entity);

            return Error.OK;
        }

        public virtual Error ValidateDataBeforeDelete(TEntity entity)
        {
            return Error.OK;
        }
    }
}
