using NUnit.Framework;
using System;

namespace Cint.Test.RobotCleaner.Tests
{
	[TestFixture]
	public class PositionCommandTest
	{
		[Test]
		public void CannotCreateWithInvalidValues ()
		{
			Assert.Throws<ArgumentException> (() => new PositionCommand (""));
			Assert.Throws<ArgumentException> (() => new PositionCommand ("x"));
			Assert.Throws<FormatException> (() => new PositionCommand ("x x"));
			Assert.Throws<ArgumentOutOfRangeException> (() => new PositionCommand ("1 100001"));
		}

		[Test]
		public void ShouldMoveToInitialPosition()
		{
			var robot = new Robot (new Office (), null);
			var command = new PositionCommand ("1 1");
			command.Execute (robot);

			Assert.That (robot.Position.X, Is.EqualTo (1));
			Assert.That (robot.Position.Y, Is.EqualTo (1));
		}
	}
}

