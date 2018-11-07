using Common.Attribute;
using Common.Helper;
using SqlKata;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Common.SQLKataExtension
{
    public static class SqlKataExtension
    {

    }

    //public class Query<TEntity, TComplier> : Query where TComplier : new()
    //{
    //    private TComplier Complier { get { return new TComplier(); } }

    //    public static Query Create()
    //    {
    //        var tableName = typeof(TEntity).GetAttributeValue((DbNameAttribute tbn) => tbn.Name);
    //        return new Query(tableName);
    //    }

    //    #region private methor

    //    private Dictionary<string, string> GetDbColumns()
    //    {
    //        Dictionary<string, string> _dict = new Dictionary<string, string>();

    //        PropertyInfo[] props = typeof(TEntity).GetProperties();
    //        foreach (PropertyInfo prop in props)
    //        {
    //            object[] attrs = prop.GetCustomAttributes(true);
    //            foreach (object attr in attrs)
    //            {
    //                DbColumnAttribute fieldName = attr as DbColumnAttribute;
    //                if (fieldName != null)
    //                {
    //                    _dict.Add(fieldName.FieldName, prop.Name);
    //                }
    //            }
    //        }

    //        return _dict;
    //    }
    //    #endregion

    //}
}
