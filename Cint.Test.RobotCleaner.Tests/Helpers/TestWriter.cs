using System;

namespace Cint.Test.RobotCleaner.Tests
{
	public class TestWriter : IConsole
	{
		private string line;
		public void WriteLine(string line)
		{
			this.line = line;
		}

		public string ReadLine()
		{
			return line;
		}
	}
}

