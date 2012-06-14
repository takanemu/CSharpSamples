using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WeakReferenceTest
{
    public class SampleClass : IWeakReferenceGuest
    {
        public string Name { get; set; }

        /// <summary>
        /// 初期化処理
        /// </summary>
        /// <param name="first"></param>
        public void Initialize(bool first)
        {
            this.Name = "namae";
        }
    }
}
