using System.Collections.Generic;
using System.Linq;
using Kinta.Models;

namespace Kinta.Services
{
    public class CategoriesService : IService<CategoryModel>
    {
        public Dictionary<string, CategoryModel> categories;

        public CategoriesService()
        {
            categories = new Dictionary<string, CategoryModel>();
        }

        public int BulkInsert(List<CategoryModel> instances)
        {
            int count = 0;

            if (instances == null)
            {
                return count;
            }

            if (instances.Count == 0)
            {
                return count;
            }

            foreach (var item in instances)
            {
                categories.Add(item.Id, item);
            }

            return instances.Count;
        }

        public List<CategoryModel> GetAll()
        {
            return categories.Values.ToList();
        }

        public bool Insert(CategoryModel instance)
        {
            categories.Add(instance.Id, instance);

            return true;
        }
    }
}
