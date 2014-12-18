using System;
using System.Collections.Generic;

namespace Cint.Test.RobotCleaner
{
	public class Robot
	{
		private readonly IEnumerable<ICommand> commands;
		private readonly Office office;
		private Position position;
		private int cleaned;
		private readonly IConsole console;

		public Robot (Office office, IEnumerable<ICommand> commands, IConsole console)
		{
			this.office = office;
			this.commands = commands;
			this.console = console;
		}

		public Position Position { 
			get { return position; } 
			set { 
				position = value;
				office.RecordCleaning (value);
			}
		}

		public void Clean ()
		{
			foreach (var command in commands)
				command.Execute (this);

			cleaned = office.TotalCleaned;
		}

		public void PrintReport ()
		{
			console.WriteLine (string.Format ("=> Cleaned: {0}", cleaned));
		}
	}
}

