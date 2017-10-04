using System;
using System.ComponentModel;
using Algorithms.Common;
using Algorithms.Common.PerformanceAnalyzer;
using Algorithms.Sort;

namespace Algorithms.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", ArrayGenerator.Generate(10, false, 1, 11)));

            Console.WriteLine();

            var array = ArrayGenerator.Generate(10, true, 1, 151);

          Console.WriteLine(string.Join(" ", array));

            var result = new int[0];
            var ticks = 0L;

//            var time = PerformanceAnalyzer.GetExecutionTime(() => result = new Bogosort<int>().SortDebug(array, ListSortDirection.Ascending, out ticks));

//            Console.WriteLine($"Random sort:\n{string.Join(" ", result)} for {time.Milliseconds} ms; {ticks} iterations");

            var time = PerformanceAnalyzer.GetExecutionTime(() => result = new BruteForceSort<int>().SortDebug(array, ListSortDirection.Ascending, out ticks));

            Console.WriteLine($"Brute force sort:\n{string.Join(" ", result)} for {time.Milliseconds} ms; {ticks} iterations");

            time = PerformanceAnalyzer.GetExecutionTime(() => result = new StoogeSort<int>().Sort(array, ListSortDirection.Ascending));

            Console.WriteLine($"Brute force sort:\n{string.Join(" ", result)} for {time.Milliseconds} ms; {ticks} iterations");

            /*var busted = new int[array.Length];

            var count = 0;

            Bust(busted, array, 0, ref count);*/

//            Console.WriteLine($"Total combinations: {count}");

/*              array.Shuffle();
            Console.WriteLine(string.Join(" ", array));

            array.Shuffle(1);
            Console.WriteLine(string.Join(" ", array));*/

            Console.ReadLine();
        }
    }
}
