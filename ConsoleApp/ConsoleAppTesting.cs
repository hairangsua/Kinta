using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    public class ConsoleAppTesting
    {
        public static void Run()
        {
            Console.WriteLine("Ho: ");
            string ho = Console.ReadLine();
            Console.WriteLine("Dem: ");
            string dem = Console.ReadLine();
            Console.WriteLine("Ten: ");
            string ten = Console.ReadLine();

            Console.WriteLine("Tuoi:");
            string strTuoi = Console.ReadLine();

            int tuoi;
            bool isSuccess = int.TryParse(strTuoi, out tuoi);

            Console.WriteLine(ho + " " + dem + " " + ten + (isSuccess ? tuoi.ToString() : "lỗi"));

            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
