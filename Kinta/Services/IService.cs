using SqlKata;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Kinta.Services
{
    public interface IService<TEntity>
    {
        bool Insert(TEntity instance);
        bool UpdateFields(TEntity entity, string[] propNames);
        bool UpdateFields(TEntity entity, params Expression<Func<TEntity, string>>[] expresstions);
        List<TEntity> FindAll();
        List<TEntity> FindAllWithSpecifyColumnByExps(params Expression<Func<TEntity, string>>[] expresstions);
        List<TEntity> Find(Query query);
    }

}
