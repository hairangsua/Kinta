using Kinta.Common.Helper;
using Kinta.Persistence.Repositories;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Kinta.Persistence.BaseBL
{
    public abstract class BaseBL<TEntity, TRepo> where TEntity : new() where TRepo : BaseRepository<TEntity>
    {
        protected TRepo Repo
        {
            get
            {
                var connectionInfo = "";
                var connection = new MySqlConnection("");
                var uow = new UnitOfWork(connection);
                return (TRepo)Activator.CreateInstance(typeof(TRepo), uow);
            }
        }
    }
}
