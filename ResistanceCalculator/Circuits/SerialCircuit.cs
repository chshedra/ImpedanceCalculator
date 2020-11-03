using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceCalculator.Circuits
{
	/// <summary>
	/// Класс последовательной цепи
	/// </summary>
	[Serializable]
	public class SerialCircuit : CircuitBase
	{
		#region Constructors

		/// <inheritdoc/>
		public SerialCircuit() : base() { }

		/// <inheritdoc/>
		public SerialCircuit(List<ISegment> subSegments, string name)
			: base(subSegments, name) { }

		#endregion

		#region Methods

		/// <inheritdoc />
		public override Complex CalculateZ(double frequency)
		{
			var result = new Complex();
			foreach (ISegment element in SubSegments)
			{
				result += element.CalculateZ(frequency);
			}

			return result;
		}

		#endregion
	}
}
