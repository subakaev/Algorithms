using System;
using System.Threading;
using Algorithms.Common;

namespace Algorithms.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", ArrayGenerator.Generate(10, false, 1, 11)));

            Console.WriteLine();

            var array = ArrayGenerator.Generate(10, true, 1, 11);

            Console.WriteLine(string.Join(" ", array));

            array.Shuffle();
            Console.WriteLine(string.Join(" ", array));

            array.Shuffle(1);
            Console.WriteLine(string.Join(" ", array));

            Console.ReadLine();
        }
    }
}
