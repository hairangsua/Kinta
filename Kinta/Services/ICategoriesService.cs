using Kinta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kinta.Services
{
    public interface IService<TModel>
    {
        bool Insert(TModel instance);
        int BulkInsert(List<TModel> instances);
        List<TModel> GetAll();
    }
}
