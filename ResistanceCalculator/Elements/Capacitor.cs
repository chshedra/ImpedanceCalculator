using System;
using System.Numerics;

namespace ImpedanceCalculator.Elements
{
	/// <summary>
	/// Класс конденсатора 
	/// </summary>
	[Serializable()]
	public class Capacitor : ElementBase
	{
		#region Constructors

		/// <summary>
		/// Конструктор без параметров. Устанавливает значеия названия и емкости конденсатора
		/// </summary>
		public Capacitor() : this("C", 0) { }

		/// <summary>
		/// Конструктор, устанавливающий значеия названия и емкости конденсатора
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public Capacitor(string name, double value) : base(name, value) { }
		#endregion

		#region Methods

		///<inheritdoc/>
		public override Complex CalculateZ(double frequence)
		{
			if (frequence < 0)
			{
				throw new ArgumentException("The frequence must be positive");
			}
			double result = -(1 / (2 * Math.PI * frequence * Value));
			Complex complexFormResult = new Complex(0, result);

			return complexFormResult;
		}

		#endregion
	}
}
