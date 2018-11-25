using Kinta.Framework.Repository;
using Kinta.Models;
using Kinta.Models.Entities;

namespace Kinta.Bussiness.DAL
{
    public class PostItemRepo : BaseRepository<PostItemModel>
    {
        public PostItemRepo() : base(DbConstant.KINTA_DB)
        {
        }
    }
}
