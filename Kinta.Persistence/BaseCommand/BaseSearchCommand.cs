using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Persistence.BaseCommand
{
    public abstract class BaseSearchCommand<TEntity> : IRequest<List<TEntity>>
    {
        public string Id { get; set; }
    }
}
