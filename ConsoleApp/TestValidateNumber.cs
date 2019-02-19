using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    class TestValidateNumber
    {
        public static void Run()
        {
            string protype1 = "123123,-213 12";
            string protype2 = "123123,-213 12 / ? < + =";

            var arr1 = protype2.ToCharArray();
            bool hasLetter;
            foreach (var c in arr1)
            {
                hasLetter = char.IsLetter(c);
            }
        }
    }
}
