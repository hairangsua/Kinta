using Kinta.Framework.Repository;
using Kinta.Models;
using Kinta.Models.Models;

namespace Kinta.Bussiness.DAL
{
    public class UserRepo : BaseRepository<User>
    {
        public UserRepo() : base(DbConstant.KINTA_DB)
        {

        }
    }

}
