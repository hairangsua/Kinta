using Kinta.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Models.Command
{
    public class GetAllCategoryQuery : IRequest<List<CategoryModel>>
    {
    }
}
