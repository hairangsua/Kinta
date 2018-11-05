using Common.Attribute;
using Common.Constant;
using Common.Helper;
using Kinta.Common;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Linq;
using Dapper;
using SqlKata.Compilers;
using SqlKata;
using SqlKata.Execution;

namespace Common.Base
{

    public abstract class DataRepository<TEntity, TComplier> where TComplier : new()
                                                             where TEntity : new()
    {
        private TComplier _Complier { get { return new TComplier(); } }

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
                Dictionary<string, string> _dict = new Dictionary<string, string>();

                PropertyInfo[] props = typeof(TEntity).GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    object[] attrs = prop.GetCustomAttributes(true);
                    foreach (object attr in attrs)
                    {
                        DbColumnAttribute fieldName = attr as DbColumnAttribute;
                        if (fieldName != null)
                        {
                            _dict.Add(fieldName.FieldName, prop.Name);
                        }
                    }
                }

                return _dict;
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

        private string GetUpdateFieldsQuery(List<string> updateFields)
        {
            string value = "";

            foreach (var fldName in updateFields)
            {
                if (value.IsNotEmpty())
                {
                    value += ", ";
                }
                value += $"{fldName} = @{fldName}";
            }
            return $"UPDATE dbo.{_TableName} SET {value} ,updated_time = @updated_time"
                    + $"WHERE id = @id";

        }

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
                        command.Parameters.AddWithValue(param, entity.GetPropValue(propName));
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

        public bool UpdateFields(TEntity entity, params string[] propNames)
        {
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

                var query = GetUpdateFieldsQuery(fieldUpdates);
                using (SqlConnection connection = new SqlConnection(_ConnectionString))
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", entity.GetPropValue("Id"));
                        foreach (var param in fieldUpdates)
                        {
                            var propName = _DicDbColumn[param.Trim('@')];
                            command.Parameters.AddWithValue(param, entity.GetPropValue(propName));
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

                throw new Exception("" + ex);
            }

        }

        public List<TEntity> FindAll()
        {
            using (SqlConnection connection = new SqlConnection(_ConnectionString))
            {
                try
                {
                    var db = new QueryFactory(connection, _Complier as Compiler);

                    var dynRs = db.Query(_TableName).Get();

                    var rs = new List<TEntity>();
                    foreach (var item in dynRs)
                    {
                        var obj = new TEntity();
                        foreach (var key in _DicDbColumn.Keys)
                        {
                            var b = item.GetType().GetProperty(key).GetValue(item, null);
                            var propName = _DicDbColumn[key];
                            obj.SetPropValue(propName, item.GetPropValue(key) as object);
                        }
                        rs.Add(obj);
                    }

                    return rs;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    throw new Exception("" + ex);
                }
            }

        }
    }
}
