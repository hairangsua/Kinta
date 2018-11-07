using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace Common.Helper
{
    public static partial class AttributeHelper
    {
        public static TValue GetAttributeValue<TAttribute, TValue>(
            this Type type,
            Func<TAttribute, TValue> valueSelector)
            where TAttribute : System.Attribute
        {
            var att = type.GetCustomAttributes(
                typeof(TAttribute), true
            ).FirstOrDefault() as TAttribute;
            if (att != null)
            {
                return valueSelector(att);
            }
            return default(TValue);
        }

        public static IEnumerable<Type> GetTypesWithHelpAttribute(Assembly assembly, Type typeOfAttribute)
        {
            foreach (Type type in assembly.GetTypes())
            {
                if (type.GetCustomAttributes(typeOfAttribute, true).Length > 0)
                {
                    yield return type;
                }
            }
        }

        //private Dictionary<string, string> GetDbColumns()
        //{
        //    Dictionary<string, string> _dict = new Dictionary<string, string>();

        //    PropertyInfo[] props = typeof(TEntity).GetProperties();
        //    foreach (PropertyInfo prop in props)
        //    {
        //        object[] attrs = prop.GetCustomAttributes(true);
        //        foreach (object attr in attrs)
        //        {
        //            DbColumnAttribute fieldName = attr as DbColumnAttribute;
        //            if (fieldName != null)
        //            {
        //                _dict.Add(prop.Name, fieldName.FieldName);
        //            }
        //        }
        //    }

        //    return _dict;
        //}
    }
}
