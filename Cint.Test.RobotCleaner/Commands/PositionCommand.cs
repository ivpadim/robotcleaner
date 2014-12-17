using System;

namespace Cint.Test.RobotCleaner
{
	public class PositionCommand : ICommand
	{
		private Position position;

		public PositionCommand (string parameter)
		{
			var parameters = parameter.Split (' ');

			if (parameters.Length != 2)
				throw new ArgumentException ();

			var x = int.Parse (parameters [0]);
			var y = int.Parse (parameters [1]);

			position = new Position (x, y);

		}

		public void Execute(Robot robot)
		{
			robot.Position = position;
		}
	}
}

