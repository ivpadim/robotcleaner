using System;

namespace Cint.Test.RobotCleaner
{
	public class Position
	{
		public static int MinValue { get { return -100000;} }
		public static int MaxValue { get { return 100000; } }

		private int x;
		private int y;

		public Position (int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X 
		{ 
			get { return x; } 
			private set 
			{ 
				if (value < MinValue || value > MaxValue)
					throw new ArgumentOutOfRangeException ("X");
				x = value;
			}
		}
		public int Y 
		{ 
			get { return y; } 
			private set 
			{ 
				if (value < MinValue || value > MaxValue)
					throw new ArgumentOutOfRangeException ("Y");
				y = value;
			}
		}
	}
}

