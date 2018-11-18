using Kinta.Application.BL;
using Kinta.Application.Command;
using Kinta.Application.DAL;
using Kinta.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kinta.Application.Handle
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryModel>>
    {
        public Task<List<CategoryModel>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var bl = new CategoryBL();
                return Task.FromResult(bl.GetAll());
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
    }
}