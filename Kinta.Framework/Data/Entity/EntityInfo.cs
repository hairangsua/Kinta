using Kinta.Framework.Data.MappingAttributes;
using Kinta.Framework.Helper;
using System.Collections.Generic;
using System.Reflection;

namespace Kinta.Framework.Data
{
    public class EntityInfo<TEntity>
    {
        public List<KintaPropertyInfo> PropertyInfos { get; set; }
        public string TableName { get; set; }

        public static EntityInfo<TEntity> Create()
        {
            var entityInfo = new EntityInfo<TEntity>();
            entityInfo.TableName = typeof(TEntity).GetAttributeValue((DbNameAttribute tbn) => tbn.Name);

            var propertyInfos = new List<KintaPropertyInfo>();
            PropertyInfo[] props = typeof(TEntity).GetProperties();
            foreach (PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                foreach (object attr in attrs)
                {
                    DbColumnAttribute attribute = attr as DbColumnAttribute;

                    propertyInfos.Add(new KintaPropertyInfo
                    {
                        Name = prop.Name,
                        ColumnName = attribute.Name,
                        DbType = attribute.DbType,
                        Length = attribute.Length,
                        IsKey = attribute.IsKey,
                        //Value = 
                    });
                }

            }

            entityInfo.PropertyInfos = propertyInfos;

            return entityInfo;
        }
    }
}
