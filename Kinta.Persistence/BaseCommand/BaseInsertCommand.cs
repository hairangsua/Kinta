using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Persistence.BaseCommand
{
    public abstract class BaseInsertCommand<TModel> : IRequest
    {
        public List<TModel> Instances { get; set; }
    }
}
