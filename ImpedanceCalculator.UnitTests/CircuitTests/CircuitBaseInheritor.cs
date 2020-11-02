using System;
using System.Collections.Generic;
using System.Numerics;
using ImpedanceCalculator.Circuits;

namespace ImpedanceCalculator.UnitTests.CircuitTests
{
	//TODO: RSDN
	class CircuitBaseInheritor : CircuitBase
	{
		public CircuitBaseInheritor() : base() { }

		public CircuitBaseInheritor(List<ISegment> subSegments, string name) :
			base(subSegments, name) { }

		public override Complex CalculateZ(double frequency)
		{
			throw new NotImplementedException();
		}
	}
}
