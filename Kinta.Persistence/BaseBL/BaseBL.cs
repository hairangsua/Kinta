using Kinta.Common.Helper;
using Kinta.Domain.Errors;
using Kinta.Models;
using Kinta.Persistence.Repositories;
using MySql.Data.MySqlClient;
using StackExchange.Profiling;
using System;
using System.Collections.Generic;

namespace Kinta.Persistence.BaseBL
{
    public abstract class BaseBL<TEntity, TRepo> where TEntity : BaseModel, new() where TRepo : BaseRepository<TEntity>
    {
        protected virtual string DbName { get; set; }

        public TRepo Repo
        {
            get
            {
                if (DbName.IsEmpty())
                {
                    throw new NullReferenceException(nameof(DbName));
                }
                var connectionInfo = ConnectionStringInfo.GetConnectionByName(DbName);
                if (connectionInfo == null)
                {
                    throw new Exception("Can not get connection info");
                }
                using (var connection = new MySqlConnection(connectionInfo.Value))
                using (var uow = new UnitOfWork(connection))
                {
                    //uow.Commit();
                    return (TRepo)Activator.CreateInstance(typeof(TRepo), uow);
                }
            }
        }

        public Error Create(List<TEntity> entities)
        {
            if (entities.IsNullOrEmpty())
            {
                return new Error(new ArgumentNullException(nameof(entities)));
            }

            var err = ValidateDataBeforeCreate(entities);
            if (err.IsNotOK())
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

            Repo.BulkInsert(entities);

            return Error.OK;
        }

        public virtual Error ValidateDataBeforeCreate(List<TEntity> entities)
        {
            return Error.OK;
        }

        public virtual void PrepareDataBeforeCreate(ref List<TEntity> entities)
        {
            return;
        }

        public Error Update(List<TEntity> entities)
        {
            if (entities.IsNullOrEmpty())
            {
                return new Error(new ArgumentNullException(nameof(entities)));
            }

            var err = ValidateDataBeforeUpdate(entities);
            if (err.IsNotOK())
            {
                return err;
            }

            PrepareDataBeforeUpdate(ref entities);
            foreach (var item in entities)
            {
                item.SetUpdatedTime();
            }

            Repo.BulkUpdate(entities);

            return Error.OK;
        }

        public virtual Error ValidateDataBeforeUpdate(List<TEntity> entities)
        {
            return Error.OK;
        }

        public virtual void PrepareDataBeforeUpdate(ref List<TEntity> entity)
        {
            return;
        }

        public Error Delete(TEntity entity)
        {
            if (entity == null)
            {
                return new Error(new ArgumentNullException(nameof(entity)));
            }

            var err = ValidateDataBeforeDelete(entity);
            if (err.IsNotOK())
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
