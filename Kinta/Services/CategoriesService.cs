using Kinta.Application.Models;
using Kinta.Persistence.Repositories;
using SqlKata;
using SqlKata.Compilers;

namespace Kinta.Services
{
    public class CategoriesService : BaseRepository<CategoryModel, SqlServerCompiler>, IService<CategoryModel>
    {
        Query IService<CategoryModel>.QueryInstance => QueryInstance;
    }
}
