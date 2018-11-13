using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Application.Categories.Queries
{
    public class GetAllTagOfCategoryQuery : IRequest<List<string>>
    {

    }
}
