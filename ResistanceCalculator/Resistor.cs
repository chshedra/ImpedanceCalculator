using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace ImpedanceCalculator
{

	public class Resistor : IElement
	{
		/// <summary>
		/// Название резистора
		/// </summary>
		private string _name;

		/// <summary>
		/// Сопротивление резистора
		/// </summary>
		private double _value;


		/// <summary>
		/// Устанавливает и возвращает название резистора
		/// </summary>
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if(value.Length == 0)
				{
					throw new ArgumentException("The name must have a value");
				}

				_name = value;
			}

		}

		/// <summary>
		/// Возвращает и устанавливает значение сопротивления резистора
		/// </summary>
		public double Value
		{
			get
			{
				return _value;
			}
			set
			{
				if(value < 0)
				{
					throw new ArgumentException("Resistance must be positive");
				}
				_value = value;

				ValueChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Конструктор без параметров. Устанавливает значеия названия и сопротивления резистора
		/// </summary>
		public Resistor() : this("R", 0) { }

		/// <summary>
		/// Конструктор, устанавливающий значеия названия и сопротивления резистора
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public Resistor(string name, double value)
		{
			Name = name;
			Value = value;
		}


		/// <summary>
		/// Метод, расчитывающий сопротивление сопротивление в комплексной форме
		/// </summary>
		/// <param name="frequence"></param>
		/// <returns></returns>
		public Complex CalculateZ(double frequence)
		{
			if(frequence < 0)
			{
				throw new ArgumentException("The frequence must be positive");
			}
			Complex resistance = new Complex(Value, 0);
			return resistance;
		}

		public event EventHandler ValueChanged;
	}
}
