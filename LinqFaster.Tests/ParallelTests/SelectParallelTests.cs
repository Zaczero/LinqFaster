﻿using System.Linq;
using JM.LinqFaster.Parallel;
using NUnit.Framework;
using static LinqFaster.Tests.Test;

namespace LinqFaster.Tests.ParallelTests
{
    [TestFixture]
    class SelectParallel
    {

        [Test]
        public void ParallelSelectArray()
        {
            var a = intArray.SelectP(x => x * x);
            var b = intArray.Select(x => x * x);

            Assert.That(a, Is.EqualTo(b));

            a = intArray.SelectP((x, i) => x + i);
            b = intArray.Select((x, i) => x + i);

            Assert.That(a, Is.EqualTo(b));
        }

        [Test]
        public void ParallelSelectList()
        {
            var a = intList.SelectP(x => x * x);
            var b = intList.Select(x => x * x).ToList();
            Assert.That(a.Count, Is.Not.EqualTo(0));
            Assert.That(a, Is.EqualTo(b));

            a = intList.SelectP((x, i) => x + i);
            b = intList.Select((x, i) => x + i).ToList();

            Assert.That(a, Is.EqualTo(b));
        }
    }
}

