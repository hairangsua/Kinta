using Common.Helper;
using Kinta.Models;
using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConvertToNewDynamicObject<CategoryModel>.ConvertToDbNameObject(new CategoryModel
            {
                Id = IdHelper.NewGuid(),
                Code = "Code",
                Name = "Name",
                ParentCode = "",
                Description = "sadaskjd",
                ChildCode = "s",
                Path = "sdasd",
                Tag = "tag",
                CreatedTime = DateTime.Now,
                UpdatedTime = DateTime.Now
            });
        }
    }
}
