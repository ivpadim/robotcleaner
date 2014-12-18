using System;
using System.Collections.Generic;

namespace Cint.Test.RobotCleaner.Tests
{
	public class TestWriter : IConsole
	{
		private Queue<string> lines = new Queue<string>();
		public void WriteLine(string line)
		{
			lines.Enqueue (line);
		}

		public string ReadLine()
		{
			return lines.Dequeue();
		}
	}
}

