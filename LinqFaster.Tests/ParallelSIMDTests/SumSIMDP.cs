﻿using System.Linq;
using JM.LinqFaster.SIMD.Parallel;
using NUnit.Framework;

namespace LinqFaster.Tests.ParallelSIMDTests
{
    [TestFixture]
    class SumSIMDP
    {
        [Test]
        public  void SumSIMDPArray()
        {
            var a = Test.intArray.SumSP();
            var b = Test.intArray.Sum();

            Assert.That(a, Is.EqualTo(b));

            var c = Test.floatArray.SumSP();
            var d = Test.floatArray.Sum();

//            Assert.That(c, Is.EqualTo(d));

         
  //          Assert.That(e, Is.EqualTo(f));
        }
      
    }
}
