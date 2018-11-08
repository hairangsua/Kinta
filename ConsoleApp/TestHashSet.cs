using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace ConsoleApp
{
    public class TestHashSet
    {
        public static void ListHashSetPerformanceBenchmark()
        {
            //const int COUNT = 50; 
            const int COUNT = 50000;

            HashSet<int> intHashSet = new HashSet<int>();
            Stopwatch stopWatch = new Stopwatch();
            for (int i = 0; i < COUNT; i++)
            {
                intHashSet.Add(i);
            }

            stopWatch.Start();
            for (int i = 0; i < COUNT; i++)
            {
                intHashSet.Contains(i);
            }
            stopWatch.Stop();

            Console.WriteLine("HashSet " + stopWatch.Elapsed);

            stopWatch.Reset();
            List<int> intList = new List<int>();
            for (int i = 0; i < COUNT; i++)
            {
                intList.Add(i);
            }

            stopWatch.Start();
            for (int i = 0; i < COUNT; i++)
            {
                intList.Contains(i);
            }
            stopWatch.Stop();

            Console.WriteLine("List " + stopWatch.Elapsed);
        }
    }
}
