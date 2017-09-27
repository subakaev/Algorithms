using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithms.Common;

namespace Algorithms.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine(string.Join(" ", ArrayGenerator.Generate(10)));

            System.Console.WriteLine();

            System.Console.WriteLine(string.Join(" ", ArrayGenerator.Generate(10, true)));

            System.Console.ReadLine();
        }
    }
}
