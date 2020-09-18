using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ImpedanceCalculator
{
	public interface IElement
	{
		string Name
		{
			get;
			set;
		}

		double Value
		{
			get;
			set;
		}

		event EventHandler ValueChanged;

		Complex CalculateZ(double frequence);

	}
}
