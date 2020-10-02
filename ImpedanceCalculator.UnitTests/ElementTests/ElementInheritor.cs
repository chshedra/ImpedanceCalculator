using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
