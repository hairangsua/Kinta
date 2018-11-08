using Common.Helper;
using Kinta.Models;
using Kinta.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kinta.ServiceConfiguration
{
    public class ServiceHelper
    {
        public static List<string> GetAllEntities()
        {
            var type = typeof(IService<CategoryModel>);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                 .Where(x => typeof(IService<CategoryModel>).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                 .Select(x => x.Name).ToList();
        }
    }
}
