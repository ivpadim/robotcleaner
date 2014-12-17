using NUnit.Framework;
using System;

namespace Cint.Test.RobotCleaner.Tests
{
	[TestFixture]
	public class PositionTest
	{
		[Test]
		public void CannotCreateWithInvalidValues ()
		{
			Assert.Throws<ArgumentOutOfRangeException> (() => new Position (Position.MaxValue + 1, 1));
			Assert.Throws<ArgumentOutOfRangeException> (() => new Position (Position.MinValue - 1, 1));
			Assert.Throws<ArgumentOutOfRangeException> (() => new Position (1, Position.MaxValue + 1));
			Assert.Throws<ArgumentOutOfRangeException> (() => new Position (1, Position.MinValue - 1));
		}
	}
}

