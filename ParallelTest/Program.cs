using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Parallel.Invoke(
                () => Console.WriteLine("1st task!"),
                () => Console.WriteLine("2nd task!"));

            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            Parallel.ForEach(a, (n) => Console.Write("{0} ", n));
            Console.WriteLine("by parallel");

            Parallel.For(0, 10, (n) => Console.Write("{0} ", n));
            Console.WriteLine("by parallel");

            Console.ReadKey();
        }
    }
}
