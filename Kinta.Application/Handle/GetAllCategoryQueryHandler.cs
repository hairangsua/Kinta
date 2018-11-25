using Kinta.Application.BL;
using Kinta.Models.Command;
using Kinta.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Kinta.Bussiness.Handler
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