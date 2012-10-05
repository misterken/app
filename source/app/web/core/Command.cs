using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.web.core
{
	public class Command : ICommand
	{
		public OriginPoint Origin;

		public Command()
		{
			

		}

		public int GetX()
		{
			throw new NotImplementedException();
		}
	}

	public class OriginPoint
	{
		public OriginPoint()
		{

		}

		public int X { get; set; }
		public int Y { get; set; }
	}
}
