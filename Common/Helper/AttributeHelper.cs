using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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


        //private Dictionary<string, string> GetDbFieldNames()
        //{
        //    Dictionary<string, string> _dict = new Dictionary<string, string>();

        //    PropertyInfo[] props = typeof(TEntity).GetProperties();
        //    foreach (PropertyInfo prop in props)
        //    {
        //        object[] attrs = prop.GetCustomAttributes(true);
        //        foreach (object attr in attrs)
        //        {
        //            DbFieldNameAttribute fieldName = attr as DbFieldNameAttribute;
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
