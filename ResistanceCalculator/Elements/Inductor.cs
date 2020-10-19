using System;
using System.Numerics;

namespace ImpedanceCalculator.Elements
{
	/// <summary>
	/// Класс катушки индуктивности
	/// </summary>
	public class Inductor : ElementBase
	{
		#region Constructor

		/// <summary>
		/// Конструктор без параметров. Устанавливает значеия названия и индуктивности катушки
		/// </summary>
		public Inductor() : this("L", 0) { }

		/// <summary>
		/// Конструктор, устанавливающий значеия названия и  индуктивности катушки
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public Inductor(string name, double value) : base(name, value) { }

		#endregion

		#region Methods

		/// <summary>
		/// Метод, вычисляющий индуктивность катушки в комплексной форме
		/// </summary>
		/// <param name="frequence"></param>
		/// <returns></returns>
		public override Complex CalculateZ(double frequency)
		{
			if (frequency < 0)
			{
				throw new ArgumentException("The frequence must be positive");
			}
			double result = 2 * Math.PI * frequency * Value;
			Complex complexFormResult = new Complex(0, result);

			return complexFormResult;
		}

		#endregion
	}
}
