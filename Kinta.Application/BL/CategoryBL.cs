﻿using Kinta.Application.DAL;
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
        public List<CategoryModel> GetAll()
        {
            return Repo.FindAll();
        }
    }
}
