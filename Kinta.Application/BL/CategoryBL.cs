using Kinta.Bussiness.DAL;
using Kinta.Framework.Bussiness;
using Kinta.Models.Entities;
using System.Collections.Generic;

namespace Kinta.Application.BL
{
    public class CategoryBL : BaseBL<CategoryModel, CategoryRepo>
    {
        public List<CategoryModel> GetAll()
        {
            return Repo.FindAll();
        }
    }
}
