using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Cint.Test.RobotCleaner.Tests
{
	[TestFixture]
	public class RobotTest
	{
		private Robot robot;
		private Office office;
		private TestWriter output;

		private void Clean()
		{
			output = new TestWriter ();
			office = new Office ();
			robot = new Robot (office, new List<ICommand> () {
				new PositionCommand ("10 22"),
				new MoveCommand ("N 2"),
				new MoveCommand ("E 1")
			},
			output);

			robot.Clean ();
			robot.PrintReport ();
		}

		[SetUp]
		public void SetUp()
		{
			Clean ();
		}

		[Test]
		public void ShouldCleanSuccessfully()
		{
			Assert.That (robot.Position.X, Is.EqualTo (11));
			Assert.That (robot.Position.Y, Is.EqualTo (24));
			Assert.That (office.TotalCleaned, Is.EqualTo (4));
		}


		[Test]
		public void ShouldPrintOutputCorrectly()
		{
			Assert.That (output.ReadLine(), Is.EqualTo ("=> Cleaned: 4"));
		}

	}
}

