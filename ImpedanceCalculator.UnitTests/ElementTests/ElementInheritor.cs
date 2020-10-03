using System;
using System.Numerics;

namespace ImpedanceCalculator.UnitTests
{
	class ElementInheritor : Element
	{
		public override Complex CalculateZ(double frequence)
		{
			throw new NotImplementedException();
		}

		internal ElementInheritor() : this(" ", 0) { }

		internal ElementInheritor(string name, double value) : base(name, value) { }
	}
}
