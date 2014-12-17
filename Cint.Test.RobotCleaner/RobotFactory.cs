using System;
using System.Collections.Generic;

namespace Cint.Test.RobotCleaner
{
	public static class RobotFactory
	{
		public static Robot CreateRobot (IConsole console)
		{
			var number = int.Parse (console.ReadLine ());
			var commands = CreateCommands (console, number);
			var office = new Office ();
			var robot = new Robot (office, commands);
			return robot;
		}

		public static IEnumerable<ICommand> CreateCommands (IConsole console, int number)
		{
			var commands = new List<ICommand> ();

			var position = new PositionCommand (console.ReadLine ());
			commands.Add (position);

			for (var i = 0; i < number; i++) {
				var direction = new MoveCommand (console.ReadLine ());
				commands.Add (direction);
			}

			return commands;
		}
	}
}

