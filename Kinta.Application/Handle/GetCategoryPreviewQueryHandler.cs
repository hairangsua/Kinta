using Kinta.Application.Command;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kinta.Application.Handle
{
    public class GetAllTagOfCategoryQueryHandler : IRequestHandler<GetAllTagOfCategoryQuery, List<string>>
    {
        //private readonly NorthwindDbContext _context;

        //public GetAllTagOfCategoryQueryHandler(NorthwindDbContext context)
        //{
        //    _context = context;
        //}

        public Task<List<string>> Handle(GetAllTagOfCategoryQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}