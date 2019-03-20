using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp
{
    public class DrawSquare
    {
        public static void Run()
        {
            int width = 5;
            int length = 3;

            for (int i = 0; i <= width; i++)
            {
                for (int j = 0; j <= length; j++)
                {
                    if (i % width == 0)
                    {
                        Console.Write("*");
                    }
                    else if (i % width != 0 && j % length == 0)
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("/");
                    }
                }
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
