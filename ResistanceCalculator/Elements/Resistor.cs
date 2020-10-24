using System;
using System.Numerics;

namespace ImpedanceCalculator.Elements
{
	/// <summary>
	/// Класс резистора 
	/// </summary>
	public class Resistor : ElementBase
	{
		#region Constructors

		/// <summary>
		/// Конструктор без параметров. Устанавливает значеия названия и сопротивления резистора
		/// </summary>
		public Resistor() : this("R", 0) { }

		/// <summary>
		/// Конструктор, устанавливающий значеия названия и сопротивления резистора
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public Resistor(string name, double value) : base(name, value) { }

		#endregion

		#region Methods

		/// <summary>
		/// Метод, расчитывающий сопротивление в комплексной форме
		/// </summary>
		/// <param name="frequency"></param>
		/// <returns></returns>
		public override Complex CalculateZ(double frequency)
		{
			if(frequency < 0)
			{
				throw new ArgumentException("The frequency must be positive");
			}
			var resistance = new Complex(Value, 0);
			return resistance;
		}

		#endregion

		#region Implementation of ICloneable

		/// <inheritdoc />
		public object Clone()
		{
			return new Resistor(Name, Value);
		}

		#endregion
	}
}
