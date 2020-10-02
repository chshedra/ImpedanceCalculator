using System;
using System.Numerics;

namespace ImpedanceCalculator
{
	/// <summary>
	/// Класс резистора 
	/// </summary>
	public class Resistor : Element
	{
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

		/// <summary>
		/// Метод, расчитывающий сопротивление в комплексной форме
		/// </summary>
		/// <param name="frequence"></param>
		/// <returns></returns>
		public override Complex CalculateZ(double frequence)
		{
			if(frequence < 0)
			{
				throw new ArgumentException("The frequence must be positive");
			}
			Complex resistance = new Complex(Value, 0);
			return resistance;
		}		
	}
}
