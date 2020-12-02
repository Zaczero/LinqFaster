﻿using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LinqFasterer.Tests
{
	public partial class Test
	{
		[Theory]
		[Trait(nameof(LinqFasterer.AggregateF), null)]
		[MemberData(nameof(TestArray), typeof(int), 5, 0, 100)]
		public void AggregateTest_Int(IList<int> source)
		{
			var expected = source.Aggregate((l, r) => l + r);
			var actual = source.AggregateF((l, r) => l + r);

			Assert.Equal(expected, actual);
		}

		[Theory]
		[Trait(nameof(LinqFasterer.AggregateF), null)]
		[MemberData(nameof(TestArray), typeof(int), 5, 0, 100)]
		public void AggregateTest_IntSeed(IList<int> source)
		{
			var expected = source.Aggregate("S33D", (l, r) => string.Concat(l, r));
			var actual = source.AggregateF("S33D", (l, r) => string.Concat(l, r));

			Assert.Equal(expected, actual);
		}

		[Theory]
		[Trait(nameof(LinqFasterer.AggregateF), null)]
		[MemberData(nameof(TestArray), typeof(int), 5, 0, 100)]
		public void AggregateTest_IntSeedSelector(IList<int> source)
		{
			var expected = source.Aggregate("S33D", (l, r) => string.Concat(l, r), result => result + result);
			var actual = source.AggregateF("S33D", (l, r) => string.Concat(l, r), result => result + result);

			Assert.Equal(expected, actual);
		}
	}
}