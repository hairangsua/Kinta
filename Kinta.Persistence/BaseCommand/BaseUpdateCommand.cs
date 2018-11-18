using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Persistence.BaseCommand
{
    public abstract class BaseUpdateCommand<TModel> : IRequest
    {
        public List<TModel> Instances { get; set; }
    }
}
