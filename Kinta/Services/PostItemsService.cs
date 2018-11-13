using Kinta.Application.Models;
using Kinta.Persistence.Repositories;
using SqlKata;
using SqlKata.Compilers;

namespace Kinta.Services
{
    public class PostItemsService : BaseRepository<PostItemModel, SqlServerCompiler>, IService<PostItemModel>
    {
        Query IService<PostItemModel>.QueryInstance => QueryInstance;
    }
}
