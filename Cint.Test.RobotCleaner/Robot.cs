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

		public Robot (Office office, IEnumerable<ICommand> commands)
		{
			this.office = office;
			this.commands = commands;
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

		public void PrintOutput (IConsole console)
		{
			console.WriteLine (string.Format ("=> Cleaned: {0}", cleaned));
		}
	}
}

