using Common.Constant;
using Kinta.Common.Helper;
using Kinta.Domain.Attributes;
using Kinta.Domain.Entities;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

namespace Kinta.Persistence.Repositories
{

    public class SQLServerReposiory<TEntity> : BaseRepository<TEntity, SqlServerCompiler> where TEntity : new()
    {



    }
}
