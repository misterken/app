using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGame
{
	public class Frame
	{
		public int? Roll1 { get; set; }
		public int? Roll2 { get; set; }
		public int? Roll3 { get; set; }
		public int? Score { get; set; }

		public bool IsFrameComplete(int frameNumber)
		{
			if (frameNumber < 10)
			{
				if (Roll1 == 10)
					return true;
				else if (Roll1 != null && Roll2 != null)
					return true;
				else
					return false;
			}
			else if (frameNumber == 10)
			{
				if (Roll1 < 10 && Roll2 < 10 && Roll1 + Roll2 < 10)
					return true;
				else if (Roll1 == 10 && Roll2 < 10 & Roll3 < 10)
					return true;
				else if (Roll1 == 10 && Roll2 == 10 && Roll3 == 10)
					return true;
				else
					return false;		
			}
			else
				return false;
		}
	}
}
