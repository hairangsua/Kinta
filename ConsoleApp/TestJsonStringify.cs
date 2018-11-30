using Kinta.Framework.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using static ConsoleApp.TestFastMember;

namespace ConsoleApp
{
    public class TestJsonStringify
    {
        public static void InitTest()
        {
            var aObj = new AModel
            {
                Age = 11,
                BirthDate = DateTime.Now,
                Code = "123129873",
                Objectives = new string[2] { "1232", "123123" }
            };

            var obj = new AModel();
            var json1 = JSONHelper.Stringify(obj);

            var json = JSONHelper.Stringify(aObj);
        }
    }
}
