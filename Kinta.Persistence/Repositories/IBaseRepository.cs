using SqlKata;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kinta.Persistence.Repositories
{
    public interface IBaseRepository<TModel>
    {
        void BulkInsert(List<TModel> instances);
        bool Insert(TModel instance);
        bool Update(TModel instance);
        bool UpdateWhere(TModel instance, Query query);
        void BulkUpdate(List<TModel> instances);
        bool UpdateFields(TModel instance, string[] fields);
        bool Delete(TModel instance);
        List<TModel> Find(Expression<Func<TModel, bool>> expression);
        List<TModel> FindAll();
        TModel Single(Expression<Func<TModel, bool>> expression);
        TModel SingleOrDefault(Expression<Func<TModel, bool>> expression);
    }
}
