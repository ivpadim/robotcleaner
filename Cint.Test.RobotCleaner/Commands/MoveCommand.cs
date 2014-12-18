using System;
using System.Collections.Generic;
using System.Linq;

namespace Cint.Test.RobotCleaner
{
	public class MoveCommand : ICommand
	{
		private readonly IEnumerable<char> cardinalDirections = new List<char> { 'N', 'E', 'S', 'W' };
		private char cardinalDirection;
		private int steps;

		public MoveCommand (string parameter)
		{
			var parameters = parameter.Split (' ');

			if (parameters.Length != 2)
				throw new ArgumentException ();

			cardinalDirection = char.Parse (parameters [0]);
			steps = int.Parse (parameters [1]);

			if (!cardinalDirections.Contains (cardinalDirection))
				throw new ArgumentOutOfRangeException ("direction");

			if (steps <= 0 || steps >= Position.MaxValue)
				throw new ArgumentOutOfRangeException ("steps");
		}


		public void Execute (Robot robot)
		{
			if (robot.Position == null)
				throw new InvalidOperationException ();

			switch (cardinalDirection) {
			case 'N':
				for (var i = 0; i < steps; i++)
					MoveNorth (robot);
				break;
			case 'E':
				for (var i = 0; i < steps; i++)
					MoveEast (robot);
				break;
			case 'S':
				for (var i = 0; i < steps; i++)
					MoveSouth (robot);
				break;
			case 'W':
				for (var i = 0; i < steps; i++)
					MoveWest (robot);
				break;
			}
		}

		private void MoveNorth (Robot robot)
		{
			robot.Position = new Position (robot.Position.X, robot.Position.Y + 1);
		}

		private void MoveSouth (Robot robot)
		{
			robot.Position = new Position (robot.Position.X, robot.Position.Y - 1);
		}

		private void MoveEast (Robot robot)
		{
			robot.Position = new Position (robot.Position.X + 1, robot.Position.Y);
		}

		private void MoveWest (Robot robot)
		{
			robot.Position = new Position (robot.Position.X - 1, robot.Position.Y);
		}
	}
}

