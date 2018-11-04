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

namespace Common.Base
{

    public abstract class DataBaseRepository<TEntity>
    {
        protected virtual string DbName { get { return DbConstant.KintaDb; } }

        private string ConnectionString
        {
            get
            {
                return DbConstant.SetConnectionString(DbName);
            }
        }

        private string TableName
        {
            get
            {
                return typeof(TEntity).GetAttributeValue((TableNameAttribute tbn) => tbn.TableName);
            }
        }

        private Dictionary<string, string> DbFieldNames
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
                        DbFieldNameAttribute fieldName = attr as DbFieldNameAttribute;
                        if (fieldName != null)
                        {
                            _dict.Add(fieldName.FieldName, prop.Name);
                        }
                    }
                }

                return _dict;
            }
        }

        private List<string> QueryParameter
        {
            get
            {
                var rs = new List<string>();

                foreach (var value in DbFieldNames.Keys)
                {
                    rs.Add($"@{value}");
                }

                return rs;
            }
        }

        private string InsertQuery
        {
            get
            {
                return $"INSERT INTO dbo.{TableName} ({string.Join(",", DbFieldNames.Keys)})"
                      + $"VALUES ({string.Join(", ", QueryParameter)})";
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
            return $"UPDATE dbo.{TableName} SET {value} ,updated_time = @updated_time"
                    + $"WHERE id = @id";

        }

        public bool Insert(TEntity entity)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(InsertQuery, connection);
                    foreach (var param in QueryParameter)
                    {
                        var propName = DbFieldNames[param.Trim('@')];
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
                    fieldUpdates.Add(DbFieldNames.FirstOrDefault(x => x.Value == propName).Key);
                }

                var query = GetUpdateFieldsQuery(fieldUpdates);
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    try
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@id", entity.GetPropValue("Id"));
                        foreach (var param in fieldUpdates)
                        {
                            var propName = DbFieldNames[param.Trim('@')];
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
    }
}
