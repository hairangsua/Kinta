using Dapper;
using SqlKata;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Kinta.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : new()
    {
        private IUnitOfWork _uow;

        public BaseRepository()
        {

        }
        private EntityInfo<TEntity> _entityInfo;
        private QueryFactory _queryFactory;
        public BaseRepository(IUnitOfWork uow)
        {
            _uow = uow;
            _entityInfo = EntityInfo<TEntity>.Create();
        }

        public void BulkInsert(List<TEntity> instances)
        {
            if (_entityInfo == null)
            {
                _entityInfo = EntityInfo<TEntity>.Create();
            }

            var sql = CommandBuilder.CreateInsertCommand(_entityInfo);

            var insertObjs = new List<dynamic>();
            foreach (var obj in instances)
            {
                object dynamicObj = RepositoryHelper.DefineDynamicObject(obj, _entityInfo.PropertyInfos);
                insertObjs.Add(dynamicObj);
            }

            using (SqlConnection connection = new SqlConnection(_uow.Connection.ConnectionString))
            {
                try
                {
                    connection.Execute(sql, insertObjs);
                }
                catch (Exception ex)
                {
                    throw new Exception("" + ex);
                }
            }
        }

        public void BulkUpdate(List<TEntity> instances)
        {
            if (_entityInfo == null)
            {
                _entityInfo = EntityInfo<TEntity>.Create();
            }

            BulkUpdateWithFields(instances, _entityInfo.PropertyInfos.Where(x => !x.IsKey).Select(x => x.ColumnName).ToArray());
        }

        public void BulkUpdateWithFields(List<TEntity> instances, string[] fields)
        {
            var sql = CommandBuilder.CreateUpdateCommand(_entityInfo, fields);

            var updateObjs = new List<dynamic>();
            foreach (var obj in instances)
            {
                object dynamicObj = RepositoryHelper.DefineDynamicObject(obj, _entityInfo.PropertyInfos);
                updateObjs.Add(dynamicObj);
            }

            using (SqlConnection connection = new SqlConnection(_uow.Connection.ConnectionString))
            {
                try
                {
                    connection.Execute(sql, updateObjs as object);
                }
                catch (Exception ex)
                {
                    throw new Exception("" + ex);
                }
            }

        }

        public bool Delete(TEntity instance)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> Find(Query query)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> FindAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(TEntity entity)
        {
            if (_entityInfo == null)
            {
                _entityInfo = EntityInfo<TEntity>.Create();
            }

            var sql = CommandBuilder.CreateInsertCommand(_entityInfo);

            object dynamicObj = RepositoryHelper.DefineDynamicObject(entity, _entityInfo.PropertyInfos);

            using (SqlConnection connection = new SqlConnection(_uow.Connection.ConnectionString))
            {
                try
                {
                    connection.Execute(sql, dynamicObj);
                }
                catch (Exception ex)
                {
                    throw new Exception("" + ex);
                }
            }
            return true;
        }

        public TEntity Single(Query query)
        {
            throw new NotImplementedException();
        }

        public TEntity SingleOrDefault(Query query)
        {
            throw new NotImplementedException();
        }

        public bool Update(TEntity instance)
        {
            if (_entityInfo == null)
            {
                _entityInfo = EntityInfo<TEntity>.Create();
            }

            return UpdateFields(instance, _entityInfo.PropertyInfos.Where(x => !x.IsKey).Select(x => x.ColumnName).ToArray());
        }

        public bool UpdateFields(TEntity instance, string[] fields)
        {
            var sql = CommandBuilder.CreateUpdateCommand(_entityInfo, fields);

            var dynamicObj = RepositoryHelper.DefineDynamicObject(instance, _entityInfo.PropertyInfos);

            using (SqlConnection connection = new SqlConnection(_uow.Connection.ConnectionString))
            {
                try
                {
                    connection.Execute(sql, dynamicObj as object);
                }
                catch (Exception ex)
                {
                    throw new Exception("" + ex);
                }
            }

            return true;
        }

        public bool UpdateWhere(TEntity instance, Query query)
        {
            throw new NotImplementedException();
        }
    }
}
