using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceCalculator
{
	/// <summary>
	/// Класс конденсатора 
	/// </summary>
	public class Capacitor : IElement
	{
		/// <summary>
		/// Название конденсатора
		/// </summary>
		private string _name;

		/// <summary>
		/// Емкость конденстатора
		/// </summary>
		private double _value;

		/// <inheritdoc/>
		public event EventHandler SegmentChanged;

		/// <inheritdoc/>
		public List<ISegment> SubSegments { get; } = null;

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
					throw new ArgumentException($"Resistor {nameof(Name)} " +
						$"must have positive value");
				}
				_value = value;

				SegmentChanged?.Invoke(this, EventArgs.Empty);
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

		/// <inheritdoc/>
		public override string ToString() 
			=> ($"Name: {nameof(Name)}. Value is {nameof(Value)}");

		/// <summary>
		/// Метод, расчитывающий емкость конденсатора в комплексной форме
		/// </summary>
		/// <param name="frequence"></param>
		/// <returns></returns>
		public Complex CalculateZ(double frequence)
		{ 
			double result = (1 / (2 * Math.PI * frequence * Value));
			Complex complexFormResult = new Complex(0, result);

			return complexFormResult;
		}
	}
}
