﻿using System.Collections.Generic;
using System.Linq;
using Common.Base;
using Kinta.Models;
using SqlKata.Compilers;

namespace Kinta.Services
{
    public class PostItemsService : DataRepository<PostItemModel, SqlServerCompiler>, IService<PostItemModel>
    {

    }
}
