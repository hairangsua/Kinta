using Common.Attribute;
using Kinta.Common;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConsoleApp
{
    public class ConvertToNewDynamicObject<TEntity>
    {
        private static Dictionary<string, string> DbColumns
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
                        DbColumnAttribute dbCol = attr as DbColumnAttribute;
                        if (dbCol != null)
                        {
                            _dict.Add(dbCol.FieldName, prop.Name);
                        }
                    }
                }

                return _dict;
            }
        }

        public static object ConvertToDbNameObject(TEntity entity)
        {
            dynamic newObj = new { };
            foreach (var key in DbColumns.Keys)
            {
                var propName = DbColumns[key];
                newObj.SetPropValue(key, entity.GetPropValue(propName));
            }
            return newObj;
        }
    }
}
