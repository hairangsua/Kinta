using System.Collections.Generic;
using System.Linq;
using Common.Base;
using Kinta.Models;
using SqlKata;
using SqlKata.Compilers;

namespace Kinta.Services
{
    public class CategoriesService : DataRepository<CategoryModel, SqlServerCompiler>, IService<CategoryModel>
    {
        Query IService<CategoryModel>.QueryInstance => QueryInstance;
    }
}
