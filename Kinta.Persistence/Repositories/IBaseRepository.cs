using SqlKata;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kinta.Persistence.Repositories
{
    public interface IBaseRepository<TModel>
    {
        int BulkInsert(List<TModel> intances);
        bool Insert(TModel instance);
        bool Update(TModel instance);
        bool UpdateWhere(TModel instance, Query query);
        int BulkUpdate(List<TModel> instances);
        bool UpdateFields(TModel instance, string[] fields);
        bool Delete(TModel instance);
        List<TModel> Find(Query query);
        List<TModel> FindAll();
        TModel Single(Query query);
        TModel SingleOrDefault(Query query);
    }
}
