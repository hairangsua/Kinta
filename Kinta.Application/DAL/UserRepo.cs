using Kinta.Models;
using Kinta.Models.Authentication;
using Kinta.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Application.DAL
{
    public class UserRepo : BaseRepository<User>
    {
        public UserRepo() : base(DbConstant.KINTA_DB)
        {

        }
    }

}
