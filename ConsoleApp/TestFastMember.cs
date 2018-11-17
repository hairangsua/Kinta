using FastMember;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class TestFastMember
    {
        public class AModel
        {
            public string Code { get; set; }

            public int Age { get; set; }

            public DateTime BirthDate { get; set; }
        }

        public static void InitTest()
        {
            var a = new { code = "21", age = 12, birth_date = DateTime.Now };

            var accessor = TypeAccessor.Create(typeof(AModel));
            //accessor[""];
            object baseObj = new { };
            var reader = ObjectReader.Create(new List<object> { baseObj }, "code", "age", "birth_date");


            var b = reader["code"];
        }
    }


}
