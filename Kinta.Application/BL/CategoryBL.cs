using Kinta.Application.DAL;
using Kinta.Models;
using Kinta.Models.Entities;
using Kinta.Persistence.BaseBL;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Application.BL
{
    public class CategoryBL : BaseBL<CategoryModel, CategoryRepo>
    {
        protected override string DbName { get { return DbConstant.KINTA_DB; } }

        public List<CategoryModel> GetAll()
        {
            return Repo.Find(x => x.Id == "23213213");
        }

        //public CategoryModel GetSomething()
        //{
        //    using ()
        //    {

        //    }
        //}
    }
}
