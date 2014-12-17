using System;

namespace Cint.Test.RobotCleaner
{
	public class ConsoleWriter : IConsole
	{
		public void WriteLine(string line)
		{
			Console.WriteLine (line);
		}

		public string ReadLine()
		{
			return Console.ReadLine ();
		}
	}
}

