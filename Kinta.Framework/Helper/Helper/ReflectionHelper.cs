using Kinta.Framework.Data;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Kinta.Framework.Helper
{
    public static partial class ReflectionHelper
    {
        public static bool HasProperty(this object src, string propName)
        {
            return HasProperty(src.GetType(), propName);
        }

        public static bool HasProperty(Type t, string propName)
        {
            var propInfo = t.GetProperty(propName);
            if (propInfo != null)
            {
                return true;
            }
            return false;
        }

        public static void SetPropValue(this object target, string propName, object value)
        {
            var propInfo = target.GetType().GetProperty(propName);
            if (propInfo == null)
            {
                throw new Exception("Property {0} not existed in target {1}".FormatStr(propName, target.GetType().ToString()));
            }

            propInfo.SetValue(target, value, null);
        }

        public static object GetPropValue(this object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

        public static dynamic DefineDynamicObject<TEntity>(TEntity entity, List<KintaPropertyInfo> propertyInfos)
        {
            if (propertyInfos.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(propertyInfos));
            }

            var expando = new ExpandoObject();
            var p = expando as IDictionary<string, object>;

            foreach (var item in propertyInfos)
            {
                //Type type = item.ObjectType;
                p[item.ColumnName] = entity.GetPropValue(item.Name);
            }

            return p;
        }
    }
}
