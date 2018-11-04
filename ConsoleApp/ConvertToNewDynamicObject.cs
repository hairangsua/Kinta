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
        private static Dictionary<string, string> DbFieldNames
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

        public static object ConvertToDbNameObject(TEntity entity)
        {
            dynamic newObj = new { };
            foreach (var key in DbFieldNames.Keys)
            {
                var propName = DbFieldNames[key];
                newObj.SetPropValue(key, entity.GetPropValue(propName));
            }
            return newObj;
        }
    }
}
