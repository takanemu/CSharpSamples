
namespace WeakReferenceTest
{
    using System;
    using GordiasClassLibrary.Utility.WeakReference;

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
