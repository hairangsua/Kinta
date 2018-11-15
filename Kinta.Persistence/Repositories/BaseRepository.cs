using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Kinta.Common.Helper;
using Kinta.Domain.Attributes;
using SqlKata;
using SqlKata.Execution;

namespace Kinta.Persistence.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : new()
    {
        private IUnitOfWork _uow;

        public BaseRepository()
        {

        }
        private Dictionary<string, string> _dicColumnName;
        private string _tableName;
        private QueryFactory _queryFactory;
        public BaseRepository(IUnitOfWork uow)
        {
            _uow = uow;
            _dicColumnName = DataRepositoryHelper.GetDicDbColumnName<TEntity>();
            _tableName = typeof(TEntity).GetAttributeValue((DbNameAttribute tbn) => tbn.Name);
        }

        public int BulkInsert(List<TEntity> intances)
        {
            throw new NotImplementedException();
        }

        public int BulkUpdate(List<TEntity> instances)
        {
            throw new NotImplementedException();
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
            using (SqlConnection connection = new SqlConnection(_uow.Connection.ConnectionString))
            {
                try
                {
                    SqlBuilder command = new SqlBuilder(_InsertQuery, connection);
                    foreach (var param in _QueryParameter)
                    {
                        var propName = _DicDbColumn[param.Trim('@')];
                        if (propName == nameof(IEditTime.CreatedTime) || propName == nameof(IEditTime.UpdatedTime))
                        {
                            command.Parameters.AddWithValue(param, DateTime.Now);
                        }
                        else
                        {
                            command.Parameters.AddWithValue(param, entity.GetPropValue(propName));
                        }
                    }

                    connection.Open();

                    command.ExecuteNonQuery();

                    connection.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
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
            throw new NotImplementedException();
        }

        public bool UpdateFields(TEntity instance, string[] fields)
        {
            throw new NotImplementedException();
        }

        public bool UpdateWhere(TEntity instance, Query query)
        {
            throw new NotImplementedException();
        }
    }
}
