using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Persistence.BaseCommand
{
    public abstract class BaseDeleteCommand<TModel> : IRequest
    {
        public List<TModel> Instances { get; set; }
    }
}
