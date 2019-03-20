using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp
{
    public class ValidConsoleInput
    {
        public static void Run()
        {
            bool isValid = false;
            int output = 0;

            while (!isValid)
            {
                Console.WriteLine("Nhap so:");

                string input = Console.ReadLine();

                isValid = int.TryParse(input, out output);
            }

            Console.WriteLine($"So vua nhap: {output}");

            Console.ReadKey();
        }
    }
}
