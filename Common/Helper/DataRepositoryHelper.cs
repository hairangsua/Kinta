using Common.Attribute;
using Kinta.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Common.Helper
{
    public static partial class DataRepositoryHelper
    {
        public static Dictionary<string, string> GetDicDbColumnName<TEntity>()
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

            if (_dict.IsNullOrEmpty())
            {
                throw new Exception(nameof(_dict));
            }

            return _dict;
        }

        public static string GetUpdateFieldsQuery(List<string> updateFields, string tableName)
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
            return $"UPDATE dbo.{tableName} SET {value} ,updated_time = @updated_time"
                    + $"WHERE id = @id";

        }

        public static string[] GetColumnWithAlias(List<string> propNames, Dictionary<string, string> dicDbColumn)
        {
            var lstColWithAlias = new List<string>();

            foreach (var key in dicDbColumn.Keys)
            {
                if (propNames.Contains(dicDbColumn[key]))
                {
                    lstColWithAlias.Add($"{key} as {dicDbColumn[key]}");
                }
            }

            return lstColWithAlias.ToArray();
        }
    }
}
