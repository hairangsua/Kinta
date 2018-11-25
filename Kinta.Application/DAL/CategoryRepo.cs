using Kinta.Framework.Repository;
using Kinta.Models;
using Kinta.Models.Entities;

namespace Kinta.Bussiness.DAL
{
    public class CategoryRepo : BaseRepository<CategoryModel>
    {
        public CategoryRepo() : base(DbConstant.KINTA_DB)
        {
        }
    }
}
