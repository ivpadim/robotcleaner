using NUnit.Framework;
using System;

namespace Cint.Test.RobotCleaner.Tests
{
	[TestFixture]
	public class RobotFactoryTest
	{
		private TestWriter console;

		[SetUp]
		public void SetUp()
		{
			console = new TestWriter ();
		}


		[Test]
		public void CannotCreateWithInvalidValues()
		{
			console.WriteLine ("0");
			Assert.Throws<ArgumentOutOfRangeException> (() => RobotFactory.CreateRobot (console));
			console.WriteLine ("10001");
			Assert.Throws<ArgumentOutOfRangeException> (() => RobotFactory.CreateRobot (console));
		}

		[Test]
		public void ShouldCreateRobotSuccessfully()
		{
			console.WriteLine ("2");
			console.WriteLine ("10 22");
			console.WriteLine ("N 2");
			console.WriteLine ("E 1");

			var robot = RobotFactory.CreateRobot (console);

			Assert.That (robot, Is.Not.Null);
		}
	}
}

