using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Common;

namespace Algorithms.CommandLine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(" ", ArrayGenerator.Generate(10, false, 1, 11)));

            Console.WriteLine();

            Console.WriteLine(string.Join(" ", ArrayGenerator.Generate(10, true, 1, 11)));

            Console.ReadLine();
        }
    }
}
