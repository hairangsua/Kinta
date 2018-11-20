using Kinta.Models;
using Kinta.Models.Entities;
using Kinta.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Application.DAL
{
    public class PostItemRepo : BaseRepository<PostItemModel>
    {
        public PostItemRepo() : base(DbConstant.KINTA_DB)
        {
        }
    }
}
