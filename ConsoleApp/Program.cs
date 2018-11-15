using FastMember;
using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new { code = "21", age = 12, birth_date = DateTime.Now };

            var accessor = TypeAccessor.Create(typeof(AModel));
            //accessor[""];
            object baseObj = new { };
            var reader = ObjectReader.Create(new List<object> { baseObj }, "code", "age", "birth_date");

            var b = reader["code"];

            TestHashSet.ListHashSetPerformanceBenchmark();
        }

        public class AModel
        {
            public string Code { get; set; }

            public int Age { get; set; }

            public DateTime BirthDate { get; set; }
        }
    }
}
