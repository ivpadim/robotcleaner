using System;
using System.Collections.Generic;
using System.Linq;

namespace Cint.Test.RobotCleaner
{
	public class Office
	{
		private List<CleanCell> cells = new List<CleanCell>();

		public void RecordCleaning(Position position)
		{
			var cell = cells.FirstOrDefault(c => c.Position.Y == position.Y &&
				c.Position.X == position.X);
			if (cell == null)
				cells.Add (new CleanCell (position));
		}

		public int TotalCleaned 
		{
			get { return cells.Count (); }
		}

	}

	public class CleanCell
	{
		public CleanCell(Position position){
			this.Position = position;
		}

		public Position Position {get;set;}
	}
}

