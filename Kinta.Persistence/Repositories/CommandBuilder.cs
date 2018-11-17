using Kinta.Common.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using SqlKata;
using SqlKata.Compilers;
using System.Linq;

namespace Kinta.Persistence.Repositories
{
    public class CommandBuilder
    {
        public static string CreateInsertCommand<TEntity>(EntityInfo<TEntity> entityInfo)
        {
            if (entityInfo == null)
            {
                entityInfo = EntityInfo<TEntity>.Create();
            }

            if (entityInfo.TableName.IsEmpty())
            {
                throw new ArgumentNullException(nameof(entityInfo.TableName));
            }

            if (entityInfo.PropertyInfos.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(entityInfo.PropertyInfos));
            }

            //INSERT INTO tbl_name VALUES(expr, expr)
            string insertCmd = $"INSERT INTO {entityInfo.TableName} VALUES ({string.Join(",", entityInfo.PropertyInfos.Select(x => $"@{x.ColumnName}").ToList())});";

            return insertCmd;
        }

        public static string CreateUpdateCommand<TEntity>(EntityInfo<TEntity> entityInfo, string[] updateFields)
        {

            if (entityInfo == null)
            {
                entityInfo = EntityInfo<TEntity>.Create();
            }

            if (entityInfo.TableName.IsEmpty())
            {
                throw new ArgumentNullException(nameof(entityInfo.TableName));
            }

            if (entityInfo.PropertyInfos.IsNullOrEmpty())
            {
                throw new ArgumentNullException(nameof(entityInfo.PropertyInfos));
            }

            var keyProp = entityInfo.PropertyInfos.FindAll(x => x.IsKey);
            if (keyProp.IsNullOrEmpty())
            {
                throw new ArgumentException($"Can not find property key in model {nameof(TEntity)}");
            }

            if (keyProp.Count > 1)
            {
                throw new ArgumentException($"Have more than 1 key in model {nameof(TEntity)}");
            }

            var key = keyProp.FirstOrDefault();
            var updateProp = updateFields.HasItem() ? entityInfo.PropertyInfos.FindAll(x => updateFields.Contains(x.Name)) : entityInfo.PropertyInfos;

            string updateCmd = $"UPDATE {entityInfo.TableName} SET ({string.Join(",", updateProp.Where(x => !x.IsKey).Select(x => $"{x.ColumnName} = @{x.ColumnName}").ToList())} WHERE {key} = @{key} );";

            return updateCmd;
        }
    }
}
