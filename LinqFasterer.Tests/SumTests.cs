using System.Collections.Generic;
using System.Linq;
using LinqFasterer.Shared;
using Xunit;

namespace LinqFasterer.Tests
{
    public partial class Test
    {
        [Theory]
        [Trait(nameof(EnumerableF.SumF), null)]
        [MemberData(nameof(Utilities.TestArray), typeof(int), 5, 0, 100, MemberType = typeof(Utilities))]
        public void SumTest_Int(IList<int> source)
        {
            var expected = source.Sum();
            var actual = source.SumF();
            var actualSelector = source.SumF(v => v);

            Assert.InRange(expected - actual, -1e-3, 1e-3);
            Assert.InRange(expected - actualSelector, -1e-3, 1e-3);
        }

        [Theory]
        [Trait(nameof(EnumerableF.SumF), null)]
        [MemberData(nameof(Utilities.TestArray), typeof(long), 5, 0, 100, MemberType = typeof(Utilities))]
        public void SumTest_Long(IList<long> source)
        {
            var expected = source.Sum();
            var actual = source.SumF();
            var actualSelector = source.SumF(v => v);

            Assert.InRange(expected - actual, -1e-3, 1e-3);
            Assert.InRange(expected - actualSelector, -1e-3, 1e-3);
        }

        [Theory]
        [Trait(nameof(EnumerableF.SumF), null)]
        [MemberData(nameof(Utilities.TestArray), typeof(float), 5, 0, 100, MemberType = typeof(Utilities))]
        public void SumTest_Float(IList<float> source)
        {
            var expected = source.Sum();
            var actual = source.SumF();
            var actualSelector = source.SumF(v => v);

            Assert.InRange(expected - actual, -1e-3, 1e-3);
            Assert.InRange(expected - actualSelector, -1e-3, 1e-3);
        }

        [Theory]
        [Trait(nameof(EnumerableF.SumF), null)]
        [MemberData(nameof(Utilities.TestArray), typeof(double), 5, 0, 100, MemberType = typeof(Utilities))]
        public void SumTest_Double(IList<double> source)
        {
            var expected = source.Sum();
            var actual = source.SumF();
            var actualSelector = source.SumF(v => v);

            Assert.InRange(expected - actual, -1e-3, 1e-3);
            Assert.InRange(expected - actualSelector, -1e-3, 1e-3);
        }

        [Theory]
        [Trait(nameof(EnumerableF.SumF), null)]
        [MemberData(nameof(Utilities.TestArray), typeof(decimal), 5, 0, 100, MemberType = typeof(Utilities))]
        public void SumTest_Decimal(IList<decimal> source)
        {
            var expected = source.Sum();
            var actual = source.SumF();
            var actualSelector = source.SumF(v => v);

            Assert.InRange(expected - actual, -1e-3M, 1e-3M);
            Assert.InRange(expected - actualSelector, -1e-3M, 1e-3M);
        }
    }
}
