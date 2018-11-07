using Common.Attribute;
using Common.Constant;
using Common.Helper;
using Common.Models;
using Kinta.Common;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
namespace Common.Base
{

    public abstract class DataRepository<TEntity, TComplier>
                                                             where TComplier : new()
                                                             where TEntity : new()
    {
        #region properties

        private TComplier _Complier { get { return new TComplier(); } }

        public Query QueryInstance
        {
            get
            {
                return new Query(_TableName);
            }
        }

        protected virtual string _DbName { get { return DbConstant.KintaDb; } }

        private string _ConnectionString
        {
            get
            {
                return DbConstant.SetConnectionString(_DbName);
            }
        }

        private string _TableName
        {
            get
            {
                return typeof(TEntity).GetAttributeValue((DbNameAttribute tbn) => tbn.Name);
            }
        }

        private Dictionary<string, string> _DicDbColumn
        {
            get
            {
                return DataRepositoryHelper.GetDicDbColumnName<TEntity>();
            }
        }

        private List<string> _QueryParameter
        {
            get
            {
                var rs = new List<string>();

                foreach (var value in _DicDbColumn.Keys)
                {
                    rs.Add($"@{value}");
                }

                return rs;
            }
        }

        private string _InsertQuery
        {
            get
            {
                return $"INSERT INTO dbo.{_TableName} ({string.Join(",", _DicDbColumn.Keys)})"
                      + $"VALUES ({string.Join(", ", _QueryParameter)})";
            }
        }

        private SqlConnection _Connection
        {
            get { return new SqlConnection(_ConnectionString); }
        }

        #endregion

        public bool Insert(TEntity entity)
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(_InsertQuery, connection);
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

        public bool UpdateFields(TEntity entity, string[] propNames)
        {
            if (propNames.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(propNames));
            }
            try
            {
                if (propNames.IsNullOrEmpty())
                {
                    throw new ArgumentNullException(nameof(propNames));
                }

                List<string> fieldUpdates = new List<string>();
                foreach (var propName in propNames)
                {
                    fieldUpdates.Add(_DicDbColumn.FirstOrDefault(x => x.Value == propName).Key);
                }

                var query = DataRepositoryHelper.GetUpdateFieldsQuery(fieldUpdates, _TableName);
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", entity.GetPropValue("Id"));
                        foreach (var param in fieldUpdates)
                        {
                            var propName = _DicDbColumn[param.Trim('@')];
                            if (propName == nameof(IEditTime.UpdatedTime))
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
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public bool UpdateFields(TEntity entity, params Expression<Func<TEntity, string>>[] expresstions)
        {
            var propNames = new List<string>();
            foreach (var e in expresstions)
            {
                MemberExpression memberExpression = (MemberExpression)e.Body;
                propNames.Add((string)memberExpression.GetPropValue(nameof(MemberExpression.Member)).GetPropValue("Name"));
            }
            return UpdateFields(entity, propNames.ToArray());
        }

        private List<TEntity> FindAllWithSpecifyPropName(params string[] propNames)
        {
            if (propNames.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(propNames));
            }
            try
            {
                var queryFactory = new QueryFactory(_Connection, _Complier as Compiler);
                return queryFactory.Get<TEntity>(QueryInstance.Select(DataRepositoryHelper.GetColumnWithAlias(propNames.ToList(), _DicDbColumn))).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<TEntity> FindAll()
        {
            return FindAllWithSpecifyPropName(_DicDbColumn.Values.ToArray());
        }

        public List<TEntity> FindAllWithSpecifyColumnByExps(params Expression<Func<TEntity, string>>[] expresstions)
        {
            var propNames = new List<string>();
            foreach (var e in expresstions)
            {
                MemberExpression memberExpression = (MemberExpression)e.Body;
                propNames.Add((string)memberExpression.GetPropValue(nameof(MemberExpression.Member)).GetPropValue("Name"));
            }
            return FindAllWithSpecifyPropName(propNames.ToArray());
        }

        public List<TEntity> Find(Query query)
        {
            try
            {
                var db = new QueryFactory(_Connection, _Complier as Compiler);

                return db.Get<TEntity>(query).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("" + ex);
            }

            //using (SqlConnection connection = new SqlConnection(_ConnectionString))
            //{

            //}
        }
    }
}
