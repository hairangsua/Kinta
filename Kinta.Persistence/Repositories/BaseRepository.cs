﻿using Common.SqlBuilder;
using Dapper;
using Kinta.Common.Helper;
using MySql.Data.MySqlClient;
using SqlKata;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Kinta.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : new()
    {
        private IUnitOfWork _uow;

        public BaseRepository()
        {
            _entityInfo = EntityInfo<TEntity>.Create();
        }

        private EntityInfo<TEntity> _entityInfo;

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

            using (MySqlConnection connection = new MySqlConnection(_uow.Connection.ConnectionString))
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

            using (MySqlConnection connection = new MySqlConnection(_uow.Connection.ConnectionString))
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

        public List<TEntity> FindAll()
        {
            var query = new StringBuilder(CommandBuilder.CreateSelectCommand(_entityInfo));

            var rs = new List<TEntity>();

            using (MySqlConnection connection = new MySqlConnection(_uow.Connection.ConnectionString))
            {
                try
                {
                    rs = connection.Query<TEntity>(query.ToString()).ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception("" + ex);
                }
            }

            return rs;
        }

        public bool Insert(TEntity entity)
        {
            if (_entityInfo == null)
            {
                _entityInfo = EntityInfo<TEntity>.Create();
            }

            var sql = CommandBuilder.CreateInsertCommand(_entityInfo);

            object dynamicObj = RepositoryHelper.DefineDynamicObject(entity, _entityInfo.PropertyInfos);

            using (_uow.Connection)
            {
                try
                {
                    _uow.Connection.Execute(sql, dynamicObj);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return true;
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

            using (MySqlConnection connection = new MySqlConnection(_uow.Connection.ConnectionString))
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

        public bool UpdateFields(TEntity instance, params Expression<Func<TEntity, string>>[] expressions)
        {
            var propNames = new List<string>();
            foreach (var e in expressions)
            {
                MemberExpression memberExpression = (MemberExpression)e.Body;
                propNames.Add((string)memberExpression.GetPropValue(nameof(MemberExpression.Member)).GetPropValue("Name"));
            }
            return UpdateFields(instance, propNames.ToArray());
        }

        public bool UpdateWhere(TEntity instance, Query query)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> Find(Expression<Func<TEntity, bool>> expression)
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
            //foreach (var param in wherePart.Parameters.Keys)
            //{
            //    parameter.Add($"@{param}", wherePart.Parameters[param]);
            //}
            var rs = new List<TEntity>();

            using (MySqlConnection connection = new MySqlConnection(_uow.Connection.ConnectionString))
            {
                try
                {
                    connection.Open();
                    var a = query.Append(";").ToString();
                    rs = connection.Query<TEntity>(query.Append(";").ToString(), parameter).ToList();
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("" + ex);
                }
            }

            return rs;
        }

        public TEntity Single(Expression<Func<TEntity, bool>> expression)
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
            foreach (var param in wherePart.Parameters.Keys)
            {
                parameter.Add($"@{param}", wherePart.Parameters[param]);
            }
            var rs = new TEntity();

            using (MySqlConnection connection = new MySqlConnection(_uow.Connection.ConnectionString))
            {
                try
                {
                    connection.Open();
                    rs = connection.QuerySingle<TEntity>(query.ToString(), parameter);
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("" + ex);
                }
            }

            return rs;
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> expression)
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
            foreach (var param in wherePart.Parameters.Keys)
            {
                parameter.Add($"@{param}", wherePart.Parameters[param]);
            }
            var rs = new TEntity();

            using (MySqlConnection connection = new MySqlConnection(_uow.Connection.ConnectionString))
            {
                try
                {
                    connection.Open();
                    rs = connection.QuerySingleOrDefault<TEntity>(query.ToString(), parameter);
                    connection.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("" + ex);
                }
            }

            return rs;
        }
    }
}
