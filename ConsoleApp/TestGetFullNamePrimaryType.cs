using System;
using System.Collections.Generic;
using System.Text;
using static ConsoleApp.TestFastMember;

namespace ConsoleApp
{
    class TestGetFullNamePrimaryType
    {
        public static void InitTest()
        {
            var a = typeof(List<string>).FullName;
            var b = typeof(int).FullName;
            var c = typeof(bool).FullName;
            var d = typeof(Dictionary<string, List<AModel>>).FullName;
        }
    }
}
