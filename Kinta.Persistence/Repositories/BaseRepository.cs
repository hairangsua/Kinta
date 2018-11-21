using Common.SqlBuilder;
using Dapper;
using Kinta.Common.Helper;
using Kinta.Models;
using Kinta.Persistence.Common;
using MySql.Data.MySqlClient;
using SqlKata;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Kinta.Persistence.Repositories
{
    public class BaseRepository<TEntity> where TEntity : BaseModel, new()
    {
        /*
         * - Không sử dụng try catch vì sẽ sử dụng try catch bên ngoài (cụ thể: handler) để tránh làm giảm hiệu năng khi sử dụng quá nhiều try catch lồng nhau
         * - _traction được truyền từ bên ngoài nên k cần using(transaction)
         */

        public ConnectionStringInfo ConnectionInfo { get { return _connectionInfo; } }
        private ConnectionStringInfo _connectionInfo;

        public MySqlConnection Connection { get { return _connection; } }
        private MySqlConnection _connection;

        //private IDbTransaction _transaction;

        public BaseRepository(string dbName)
        {
            _entityInfo = EntityInfo<TEntity>.Create();

            if (dbName.IsEmpty())
            {
                throw new Exception(nameof(dbName));
            }
            _connectionInfo = ConnectionStringInfo.GetConnectionByName(dbName);
            if (_connectionInfo == null)
            {
                throw new Exception("Can not get connection info");
            }

            _connection = new MySqlConnection(_connectionInfo.Value);
            _connection.EnsureOpen();
            //_transaction = _connection.BeginTransaction();
        }

        private EntityInfo<TEntity> _entityInfo;

        public int BulkInsert(List<TEntity> instances, IDbTransaction ts = null)
        {
            using (_connection)
            {
                if (_entityInfo == null)
                {
                    _entityInfo = EntityInfo<TEntity>.Create();
                }

                var command = CommandBuilder.CreateInsertCommand(_entityInfo);

                var insertObjs = new List<object>();
                foreach (var obj in instances)
                {
                    object dynamicObj = RepositoryHelper.DefineDynamicObject(obj, _entityInfo.PropertyInfos);
                    insertObjs.Add(dynamicObj);
                }

                int count = _connection.Execute(command, insertObjs, ts);

                return count;
            }
        }

        public int BulkUpdate(List<TEntity> instances, IDbTransaction ts = null)
        {
            if (_entityInfo == null)
            {
                _entityInfo = EntityInfo<TEntity>.Create();
            }

            return BulkUpdateWithFields(instances, _entityInfo.PropertyInfos.Where(x => !x.IsKey).Select(x => x.ColumnName).ToArray(), ts);
        }

        public int BulkUpdateWithFields(List<TEntity> instances, string[] fields, IDbTransaction ts = null)
        {
            var sql = CommandBuilder.CreateUpdateCommand(_entityInfo, fields);

            var updateObjs = new List<dynamic>();
            foreach (var obj in instances)
            {
                object dynamicObj = RepositoryHelper.DefineDynamicObject(obj, _entityInfo.PropertyInfos);
                updateObjs.Add(dynamicObj);
            }

            var count = _connection.Execute(sql, updateObjs, ts);
            return count;
        }

        public bool Delete(TEntity instance)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> FindAll(IDbTransaction ts = null)
        {
            using (_connection)
            {
                var query = new StringBuilder(CommandBuilder.CreateSelectCommand(_entityInfo));
                return _connection.Query<TEntity>(query.ToString(), ts).ToList();
            }
        }

        public bool Insert(TEntity entity, IDbTransaction ts = null)
        {
            using (_connection)
            {
                if (_entityInfo == null)
                {
                    _entityInfo = EntityInfo<TEntity>.Create();
                }

                var sql = CommandBuilder.CreateInsertCommand(_entityInfo);

                object dynamicObj = RepositoryHelper.DefineDynamicObject(entity, _entityInfo.PropertyInfos);

                _connection.Execute(sql, dynamicObj);
            }

            return true;
        }

        public bool Update(TEntity instance, IDbTransaction ts = null)
        {
            if (_entityInfo == null)
            {
                _entityInfo = EntityInfo<TEntity>.Create();
            }

            return UpdateFields(instance, _entityInfo.PropertyInfos.Where(x => !x.IsKey).Select(x => x.ColumnName).ToArray(), ts);
        }

        public bool UpdateFields(TEntity instance, string[] fields, IDbTransaction ts = null)
        {
            using (_connection)
            {
                var sql = CommandBuilder.CreateUpdateCommand(_entityInfo, fields);

                var dynamicObj = RepositoryHelper.DefineDynamicObject(instance, _entityInfo.PropertyInfos);

                _connection.Execute(sql, dynamicObj as object);
            }

            return true;
        }

        public bool UpdateFields(TEntity instance, IDbTransaction ts = null, params Expression<Func<TEntity, string>>[] expressions)
        {
            var propNames = new List<string>();
            if (expressions.HasItem())
            {
                foreach (var e in expressions)
                {
                    MemberExpression memberExpression = (MemberExpression)e.Body;
                    propNames.Add((string)memberExpression.GetPropValue(nameof(MemberExpression.Member)).GetPropValue("Name"));
                }
            }

            return UpdateFields(instance, propNames.ToArray(), ts);
        }

        public bool UpdateWhere(TEntity instance, Expression<Func<TEntity, string>> expressions, IDbTransaction ts = null)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> Find(Expression<Func<TEntity, bool>> expression, IDbTransaction ts = null)
        {
            using (_connection)
            {
                //build ra câu select
                var query = new StringBuilder(CommandBuilder.CreateSelectCommand(_entityInfo));

                //lấy expression để build ra câu where
                var builder = new WhereBuilder<TEntity>();
                var wherePart = builder.ToSql(expression);
                if (wherePart.Parameters == null)
                {
                    throw new Exception("Can not find any parameter in where part.");
                }

                query.Append($" WHERE {wherePart.RawSql}");

                DynamicParameters parameter = new DynamicParameters();
                parameter.AddDynamicParams(wherePart.Parameters);

                return _connection.Query<TEntity>(query.Append(";").ToString(), parameter, ts).ToList();
            }
        }

        public TEntity Single(Expression<Func<TEntity, bool>> expression, IDbTransaction ts = null)
        {
            using (_connection)
            {
                //build ra câu select
                var query = new StringBuilder(CommandBuilder.CreateSelectCommand(_entityInfo));

                //lấy expression để build ra câu where
                var builder = new WhereBuilder<TEntity>();
                var wherePart = builder.ToSql(expression);
                if (wherePart.Parameters == null)
                {
                    throw new Exception("Can not find any parameter in where part.");
                }

                query.Append($" WHERE {wherePart.RawSql}");

                DynamicParameters parameter = new DynamicParameters();
                parameter.AddDynamicParams(wherePart.Parameters);
                return _connection.QuerySingle<TEntity>(query.ToString(), parameter, ts);
            }
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression, IDbTransaction ts = null)
        {
            using (_connection)
            {
                //build ra câu select
                var query = new StringBuilder(CommandBuilder.CreateSelectCommand(_entityInfo));

                //lấy expression để build ra câu where
                var builder = new WhereBuilder<TEntity>();
                var wherePart = builder.ToSql(expression);
                if (wherePart.Parameters == null)
                {
                    throw new Exception("Can not find any parameter in where part.");
                }

                query.Append($"WHERE {wherePart.RawSql}");

                DynamicParameters parameter = new DynamicParameters();
                parameter.AddDynamicParams(wherePart.Parameters);

                return _connection.QuerySingleOrDefault<TEntity>(query.ToString(), parameter, ts);
            }
        }

        public int Commit(List<TEntity> entities, IDbTransaction ts = null)
        {
            var deleteObjs = entities.FindAll(x => x.ModelState == ModelState.Deleted);
            if (deleteObjs.HasItem())
            {
                throw new NotSupportedException("Unsupported Delete with ModelState");
            }

            int count = 0;
            var addedObjs = entities.FindAll(x => x.ModelState == ModelState.Added);
            var modifiedObjs = entities.FindAll(x => x.ModelState == ModelState.Modified);

            if (addedObjs.HasItem())
            {
                count += BulkInsert(addedObjs, ts);
            }

            if (modifiedObjs.HasItem())
            {
                count += BulkUpdate(modifiedObjs, ts);
            }

            return count;
        }
    }
}
