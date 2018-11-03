using Common.Attribute;
using Kinta.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ConsoleApp
{
    class TestGetAttribute
    {
        public static Dictionary<string, string> GetDbFieldNames()
        {
            Dictionary<string, string> _dict = new Dictionary<string, string>();

            PropertyInfo[] props = typeof(CategoryModel).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    DbFieldNameAttribute fieldName = attr as DbFieldNameAttribute;
                    if (fieldName != null)
                    {
                        _dict.Add(prop.Name, fieldName.FieldName);
                    }
                }
            }

            return _dict;
        }
    }
}
