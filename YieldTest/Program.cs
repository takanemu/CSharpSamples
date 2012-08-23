using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YieldTest
{
    class RangeString
    {
        private int from, to;

        public IEnumerator<string> GetEnumerator()
        {
            for (int i = from; i <= to; i++)
            {
                yield return "str(" + i + ")";
            }
        }

        public RangeString(int from, int to)
        {
            this.from = from;
            this.to = to;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string item in new RangeString(0, 9))
            {
                Console.Write("{0} ", item);
            }
        }
    }
}
