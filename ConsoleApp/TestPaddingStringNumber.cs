using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class TestPaddingStringNumber
    {
        public static void Run()
        {
            var newString = "0".PadLeft(4, '0');
            var intPadd = 14.ToString("D3");
        }
    }
}
