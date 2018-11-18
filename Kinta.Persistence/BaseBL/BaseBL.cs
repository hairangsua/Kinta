using Kinta.Models;
using Kinta.Persistence.Repositories;
using MySql.Data.MySqlClient;
using System;

namespace Kinta.Persistence.BaseBL
{
    public abstract class BaseBL<TEntity, TRepo> where TEntity : new() where TRepo : BaseRepository<TEntity>
    {
        public TRepo Repo
        {
            get
            {
                var connectionInfo = ConnectionStringInfo.GetConnectionByName(DbConstant.KINTA_DB);
                if (connectionInfo == null)
                {
                    throw new Exception("Can not get connection info");
                }
                var connection = new MySqlConnection(connectionInfo.Value);
                var uow = new UnitOfWork(connection);
                return (TRepo)Activator.CreateInstance(typeof(TRepo), uow);
            }
        }
    }
}
