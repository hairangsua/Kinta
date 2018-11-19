using Kinta.Models.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Application.Command
{
    public class GetAllPostItemsQuery : IRequest<List<PostItemModel>>
    {
    }
}
