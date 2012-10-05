using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.web.core
{
	public interface IMicroMachine
	{
		OriginPoint PositionCar(int x, int y);
	}
}
