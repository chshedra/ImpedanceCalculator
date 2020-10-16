using System;
using System.Numerics;
//TODO: Дефолтный namespace не совпадает с текущим
namespace ImpedanceCalculator
{
	/// <summary>
	/// Класс конденсатора 
	/// </summary>
	public class Capacitor : Element, IElement
	{
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

		/// <summary>
		/// Метод, расчитывающий емкость конденсатора в комплексной форме
		/// </summary>
		/// <param name="frequence"></param>
		/// <returns></returns>
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
	}
}
