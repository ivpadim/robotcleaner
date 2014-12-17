using System;

namespace Cint.Test.RobotCleaner
{
	public interface ICommand
	{
		void Execute (Robot robot);
	}
}

