using Kinta.Models.Entities;
using Kinta.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Application.DAL
{
    public class CategoryRepo : BaseRepository<CategoryModel>
    {
        public CategoryRepo(IUnitOfWork uow) : base(uow)
        {
        }
    }
}
