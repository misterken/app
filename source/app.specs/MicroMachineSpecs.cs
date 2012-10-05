using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using app.web.core;

namespace app.specs
{
	[Subject(typeof (MicroMachine))]
	public class MicroMachineSpecs_KToy
	{
		public abstract class concern : Observes<IMicroMachine,
			                                MicroMachine>
		{

		}

		public class when_fetching_a_command : concern
		{
			private Establish e = () =>
				                      {
					                      cmd = fake.an<ICommand>();

					                      #region FalseStart

					                      //cmd.setup(x => x.RawCommand)
					                      //              .Return("0,0|R2R3L1");
					                      //cmd.setup(x => x.Origin.X).Return(0);
					                      //cmd.setup(x => x.Origin.Y).Return(0); 

					                      #endregion

					                      OriginPoint originPoint = new OriginPoint();
					                      originPoint.X = 0;
					                      originPoint.Y = 0;
					                      cmd.setup(x => x.Origin).Return(originPoint);
				                      };

			private Because b = () =>
				                    {
					                    OriginPoint result = sut.PositionCar(cmd.Origin.X, cmd.Origin.Y);
				                    };

			private It should_expect_be_positioned_at_the_origin = () =>
				                                                       {
					                                                       result.X.ShouldEqual(0);
					                                                       result.Y.ShouldEqual(0);
				                                                       };

			private static ICommand cmd;
			private static OriginPoint originPoint;
			private static OriginPoint result;
		}
	}
}
