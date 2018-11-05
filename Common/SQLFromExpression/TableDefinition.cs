using Common.Attribute;
using Common.Helper;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Common.SQLFromExpression
{
    public class TableDefinition<TEntity>
    {
        public string TableName { get; set; }
        public string GetColumnNameFor(string name)
        {
            return DbColumns.FirstOrDefault(x => x.Value == name).Key;
        }

        public TableDefinition()
        {
            TableName = typeof(TEntity).GetAttributeValue((DbNameAttribute tbn) => tbn.Name);
        }

        private Dictionary<string, string> DbColumns
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

    }
}