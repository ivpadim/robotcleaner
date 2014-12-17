using System;

namespace Cint.Test.RobotCleaner
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			var console = new ConsoleWriter ();

			var robot = RobotFactory.CreateRobot (console);
			robot.Clean ();
			robot.PrintOutput(console);
			Console.ReadLine ();
		}
	}
}
