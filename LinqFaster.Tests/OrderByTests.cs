﻿using System;
using JM.LinqFaster;
using NUnit.Framework;
using static LinqFaster.Tests.Test;

namespace LinqFaster.Tests
{
    [TestFixture]
    class OrderByTests
    {
        [Test]
        public void OrderByArray()
        {
            Func<int,int> lambda1 = (x => x*x);
            var a = intArray.OrderByF(lambda1);
            for (var i = 0; i < a.Length-1;i++)
            {
                Assert.That(lambda1(a[i]), Is.LessThanOrEqualTo(lambda1(a[i+1])));
            }
            
        }

        [Test]
        public void OrderByDescendingArray() {
            Func<int, int> lambda1 = (x => x * x);
            var a = intArray.OrderByDescendingF(lambda1);
          
            for (var i = 0; i < a.Length - 1; i++) {                
                Assert.That(lambda1(a[i]), Is.GreaterThanOrEqualTo(lambda1(a[i + 1])));
            }
            

        }

        [Test]
        public void OrderByList() {
            Func<int, int> lambda1 = (x => x * x);
            var a = intList.OrderByF(lambda1);
            for (var i = 0; i < a.Count - 1; i++) {
                Assert.That(lambda1(a[i]), Is.LessThanOrEqualTo(lambda1(a[i + 1])));
            }

        }

        [Test]
        public void OrderByDescendingList() {
            Func<int, int> lambda1 = (x => x * x);
            var a = intList.OrderByDescendingF(lambda1);
            for (var i = 0; i < a.Count - 1; i++) {
                Assert.That(lambda1(a[i]), Is.GreaterThanOrEqualTo(lambda1(a[i + 1])));
            }

        }




    }
}
