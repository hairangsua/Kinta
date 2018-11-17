using Kinta.Common.Helper;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Kinta.Persistence.Repositories
{
    public class RepositoryHelper
    {
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
