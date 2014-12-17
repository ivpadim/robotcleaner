using NUnit.Framework;
using System;

namespace Cint.Test.RobotCleaner.Tests
{
	[TestFixture]
	public class MoveCommandTest
	{
		Robot robot;

		[SetUp]
		public void SetUp ()
		{
			robot = new Robot (new Office (), null);
			robot.Position = new Position (1, 1);
		}

		[Test]
		public void CannotCreateWithInvalidValues ()
		{
			Assert.Throws<ArgumentException> (() => new MoveCommand (""));
			Assert.Throws<ArgumentException> (() => new MoveCommand ("N"));
			Assert.Throws<FormatException> (() => new MoveCommand ("N X"));
			Assert.Throws<ArgumentOutOfRangeException> (() => new MoveCommand ("X 1"));
			Assert.Throws<ArgumentOutOfRangeException> (() => new MoveCommand ("1 1"));
			Assert.Throws<ArgumentOutOfRangeException> (() => new MoveCommand ("N -100001"));
			Assert.Throws<ArgumentOutOfRangeException> (() => new MoveCommand ("N 100001"));
		}

		[Test]
		public void ShouldMoveToNorth ()
		{
			MoveNorth ();
			IsInThePosition (1, 2);
		}

		[Test]
		public void ShouldMoveToSouth ()
		{
			MoveSouth ();
			IsInThePosition (1, 0);
		}

		[Test]
		public void ShouldMoveToEast ()
		{
			MoveEast ();
			IsInThePosition (2, 1);
		}

		[Test]
		public void ShouldMoveToWest ()
		{
			MoveWest ();
			IsInThePosition (0, 1);
		}

		[Test]
		public void CannotMoveOutsideTheGrid ()
		{
			robot.Position = new Position (Position.MaxValue, Position.MaxValue);

			Assert.Throws<ArgumentOutOfRangeException> (() => new MoveCommand ("E 1").Execute (robot));
			Assert.Throws<ArgumentOutOfRangeException> (() => new MoveCommand ("N 1").Execute (robot));

			robot.Position = new Position (Position.MinValue, Position.MinValue);

			Assert.Throws<ArgumentOutOfRangeException> (() => new MoveCommand ("W 1").Execute (robot));
			Assert.Throws<ArgumentOutOfRangeException> (() => new MoveCommand ("S 1").Execute (robot));
		}

		[Test]
		[ExpectedException (typeof(InvalidOperationException))]
		public void CannotMoveIfPositionIsNotSet ()
		{
			robot = new Robot (new Office (), null);
			MoveNorth ();
		}

		private void IsInThePosition (int x, int y)
		{
			Assert.NotNull (robot.Position);
			Assert.That (robot.Position.X, Is.EqualTo (x));
			Assert.That (robot.Position.Y, Is.EqualTo (y));
		}

		private void MoveNorth ()
		{
			new MoveCommand ("N 1").Execute (robot);
		}

		private void MoveSouth ()
		{
			new MoveCommand ("S 1").Execute (robot);
		}

		private void MoveEast ()
		{
			new MoveCommand ("E 1").Execute (robot);
		}

		private void MoveWest ()
		{
			new MoveCommand ("W 1").Execute (robot);
		}


	}
}

