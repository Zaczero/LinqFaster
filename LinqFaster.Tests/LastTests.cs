﻿using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace LinqFasterer.Tests
{
	public partial class Test
	{
		[Theory]
		[Trait(nameof(LinqFasterer.LastF), null)]
		[MemberData(nameof(TestArray), typeof(int), 5, 0, 100)]
		public void LastTest_Int(IList<int> source)
		{
			var expected = source.Last();
			var actual = source.LastF();

			Assert.Equal(expected, actual);
		}
	}
}