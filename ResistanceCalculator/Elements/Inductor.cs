using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceCalculator
{
	/// <summary>
	/// Класс катушки индуктивности
	/// </summary>
	public class Inductor : IElement
	{
		/// <summary>
		/// Название катушки индуктивности
		/// </summary>
		private string _name;

		/// <summary>
		/// Индуктивность катушки 
		/// </summary>
		private double _value;

		/// <inheritdoc/>
		public event EventHandler SegmentChanged;

		/// <inheritdoc/>
		public List<ISegment> SubSegments { get; } = null;

		/// <summary>
		/// Возвращает и устанавливает название катушки индуктивности 
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
					throw new ArgumentException("Inductor name must have a value");
				}
				_name = value;
			}
		}

		/// <summary>
		/// Возвращает и устанавливает индуктивность катушки 
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
					throw new ArgumentException($"Inductor {nameof(Name)} " +
						$"must have positive value");
				}

				_value = value;

				SegmentChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Конструктор без параметров. Устанавливает значеия названия и индуктивности катушки
		/// </summary>
		public Inductor() : this("L", 0) { }

		/// <summary>
		/// Конструктор, устанавливающий значеия названия и  индуктивности катушки
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public Inductor(string name, double value)
		{
			Name = name;
			Value = value;
		}

		/// <inheritdoc/>
		public override string ToString() 
			=> ($"Name: {nameof(Name)}. Value is {nameof(Value)}");

		/// <summary>
		/// Метод, вычисляющий индуктивность катушки в комплексной форме
		/// </summary>
		/// <param name="frequence"></param>
		/// <returns></returns>
		public Complex CalculateZ(double frequence)
		{
			double result = 2 * Math.PI * frequence * Value;
			Complex complexFormResult = new Complex(0, result);

			return complexFormResult;
		}
	}
}
