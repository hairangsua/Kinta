using Kinta.Bussiness.DAL;
using Kinta.Framework.Bussiness;
using Kinta.Models.Entities;
using System.Collections.Generic;

namespace Kinta.Application.BL
{
    public class PostItemBL : BaseBL<PostItemModel, PostItemRepo>
    {
        public List<PostItemModel> GetAll()
        {
            return Repo.FindAll();
        }
    }
}
