﻿using System.Collections.Generic;
using System.Linq;
using LinqFasterer.Shared;
using Xunit;

namespace LinqFasterer.Tests
{
    public partial class Test
    {
        [Theory]
        [Trait(nameof(EnumerableF.TakeF), null)]
        [MemberData(nameof(Utilities.TestArray), typeof(int), 15, 0, 5, MemberType = typeof(Utilities))]
        [MemberData(nameof(Utilities.TestArray), typeof(int), 15, 0, 100, MemberType = typeof(Utilities))]
        [MemberData(nameof(Utilities.TestArray), typeof(int), 15, -5, -1, MemberType = typeof(Utilities))]
        [MemberData(nameof(Utilities.TestArray), typeof(int), 15, 50, 100, MemberType = typeof(Utilities))]
        public void TakeTest_Int(IList<int> source)
        {
            foreach (var i in source)
            {
                var expected = source.Take(i).ToArray();
                var actual = source.TakeF(i, true).ToArrayF();

                Assert.Equal(expected, actual);
            }
        }

        [Theory]
        [Trait(nameof(EnumerableF.TakeLastF), null)]
        [MemberData(nameof(Utilities.TestArray), typeof(int), 15, 0, 5, MemberType = typeof(Utilities))]
        [MemberData(nameof(Utilities.TestArray), typeof(int), 15, 0, 100, MemberType = typeof(Utilities))]
        [MemberData(nameof(Utilities.TestArray), typeof(int), 15, -5, -1, MemberType = typeof(Utilities))]
        [MemberData(nameof(Utilities.TestArray), typeof(int), 15, 50, 100, MemberType = typeof(Utilities))]
        public void TakeLastTest_Int(IList<int> source)
        {
            foreach (var i in source)
            {
                var expected = source.TakeLast(i).ToArray();
                var actual = source.TakeLastF(i, true).ToArrayF();

                Assert.Equal(expected, actual);
            }
        }

        [Theory]
        [Trait(nameof(EnumerableF.TakeWhileF), null)]
        [MemberData(nameof(Utilities.TestArray), typeof(int), 15, 0, 5, MemberType = typeof(Utilities))]
        [MemberData(nameof(Utilities.TestArray), typeof(int), 15, 0, 100, MemberType = typeof(Utilities))]
        [MemberData(nameof(Utilities.TestArray), typeof(int), 15, -5, -1, MemberType = typeof(Utilities))]
        [MemberData(nameof(Utilities.TestArray), typeof(int), 15, 50, 100, MemberType = typeof(Utilities))]
        public void TakeWhileTest_Int(IList<int> source)
        {
            var expected = source.TakeWhile(v => v > 2).ToArray();
            var actual = source.TakeWhileF(v => v > 2, true).ToArrayF();
            var actualIndexed = source.TakeWhileF((v, i) => v > 2, true).ToArrayF();

            Assert.Equal(expected, actual);
            Assert.Equal(expected, actualIndexed);
        }
    }
}