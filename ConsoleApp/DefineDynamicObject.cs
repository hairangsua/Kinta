using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ConsoleApp
{
    public class DefineDynamicObject
    {
        public static void InitTest()
        {
            dynamic expando = new ExpandoObject();
            var p = expando as IDictionary<string, object>;
            p["code"] = "New val 1";
            p["name"] = "New val 2";
            p["age"] = 12;
            p["birthdate"] = DateTime.Now;
            var code = expando.code;
            var name = expando.name;
            var c = expando.age;
            var d = expando.birthdate;
        }
    }
}
