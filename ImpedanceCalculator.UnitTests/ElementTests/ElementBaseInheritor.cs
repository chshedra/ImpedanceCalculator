using System;
using System.Numerics;
using ImpedanceCalculator.Elements;

namespace ImpedanceCalculator.UnitTests.ElementTests
{
	public class ElementBaseInheritor : ElementBase
	{
		public override Complex CalculateZ(double frequency)
		{
			throw new NotImplementedException();
		}

		internal ElementBaseInheritor() : this(" ", 0) { }

		internal ElementBaseInheritor(string name, double value) : base(name, value) { }
	}
}
