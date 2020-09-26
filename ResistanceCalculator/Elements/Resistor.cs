using System;
using System.Collections.Generic;
using System.Numerics;


namespace ImpedanceCalculator
{
	/// <summary>
	/// Класс резистора 
	/// </summary>
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

		/// <inheritdoc/>
		public event EventHandler SegmentChanged;

		/// <inheritdoc/>
		public List<ISegment> SubSegments { get; } = null;

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
					throw new ArgumentException($"The {nameof(Name)} must have a value");
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
					throw new ArgumentException($"Value of {nameof(Name)} must be positive");
				}
				_value = value;

				SegmentChanged?.Invoke(this, EventArgs.Empty);
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

		/// <inheritdoc/>
		public override string ToString() 
			=> ($"Name: {nameof(Name)}. Value is {nameof(Value)}");

		/// <summary>
		/// Метод, расчитывающий сопротивление в комплексной форме
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
	}
}
