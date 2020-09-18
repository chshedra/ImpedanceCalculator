using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ImpedanceCalculator
{
	class Capacitor : IElement
	{
		/// <summary>
		/// Название конденсатора
		/// </summary>
		private string _name;

		/// <summary>
		/// Емкость конденстатора
		/// </summary>
		private double _value;


		/// <summary>
		/// Устанавливает и возвращает название конденсатора
		/// </summary>
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if (value.Length == 0)
				{
					throw new ArgumentException("The name must have a value");
				}

				_name = value;
			}

		}

		/// <summary>
		/// Возвращает и устанавливает значение емкости конденсатора
		/// </summary>
		public double Value
		{
			get
			{
				return _value;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("Resistance must be positive");
				}
				_value = value;

				ValueChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Конструктор без параметров. Устанавливает значеия названия и емкости конденсатора
		/// </summary>
		public Capacitor() : this("L", 0) { }

		/// <summary>
		/// Конструктор, устанавливающий значеия названия и емкости конденсатора
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public Capacitor(string name, double value)
		{
			Name = name;
			Value = value;
		}


		/// <summary>
		/// Метод, расчитывающий емкость конденсатора в комплексной форме
		/// </summary>
		/// <param name="frequence"></param>
		/// <returns></returns>
		public Complex CalculateZ(double frequence)
		{ 

			double resistance = -(1 / (2 * Math.PI * frequence * Value));
			Complex complexResistance = new Complex(0, resistance);

			return complexResistance;
		}

		public event EventHandler ValueChanged;
	}
}
