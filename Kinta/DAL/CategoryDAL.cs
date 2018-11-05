using Common.Base;
using Common.Constant;
using Kinta.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SqlKata.Compilers;

namespace Kinta.DAL
{
    public class CategoryDAL : DataRepository<CategoryModel, SqlServerCompiler>
    {
    }
}
