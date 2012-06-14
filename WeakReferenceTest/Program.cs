using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeakReferenceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            WeakReferenceHost<SampleClass> sample = new WeakReferenceHost<SampleClass>();

            sample.Use((SampleClass ins) =>
            {
                Console.WriteLine(ins.Name);
            });

            Console.ReadKey();
        }
    }
}
