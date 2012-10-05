using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.web.core
{
	public class MicroMachine
	{
		public MicroMachine()
		{}

		private OriginPoint originPoint = new OriginPoint();

		OriginPoint PositionCar(int x, int y)
		{
			originPoint.X = x;
			originPoint.Y = y;

			return originPoint;
		}
	}
}
