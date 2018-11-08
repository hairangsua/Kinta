using System;
using System.Collections.Generic;
using System.Text;

namespace Kinta.Persistence.Repositories
{
    public class BaseBL<TEntity> where TEntity : new()
    {
        public SQLServerReposiory<TEntity> Repo { get { return new SQLServerReposiory<TEntity>(); } }
    }
}
