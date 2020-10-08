using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceCalculator.UnitTests.CircuitTests
{
	class CircuitInheritor : Circuit
	{
		public CircuitInheritor() : base() { }

		public CircuitInheritor(List<ISegment> subSegments, string name) :
			base(subSegments, name) { }

		public override Complex CalculateZ(double frequency)
		{
			throw new NotImplementedException();
		}
	}
}
