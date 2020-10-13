﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ImpedanceCalculator
{
	/// <summary>
	/// Абстрактный класс элемента цепи
	/// </summary>
	public abstract class Element : IElement
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
		public List<ISegment> SubSegments { get; } = null;

		/// <inheritdoc/>
		public event EventHandler SegmentChanged;

		/// <summary>
		/// Устанавливает и возвращает название элемента
		/// </summary>
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if (String.IsNullOrEmpty(value))
				{
					throw new ArgumentException($"The {nameof(Name)} must have a value");
				}

				_name = value;
				SegmentChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Возвращает и устанавливает значение элемента
		/// </summary>
		public double Value
		{
			get => _value;
			set
			{
				if (value < 0)
				{
					throw new ArgumentException($"Resistor {Name} " +
						$"must have positive value");
				}
				_value = value;

				SegmentChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		/// <summary>
		/// Устанавливает и возвращает имя и значение элемента
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		public Element(string name, double value)
		{
			Name = name;
			Value = value;
		}

		/// <inheritdoc/>
		public override string ToString()
			=> ($"Name: {Name}. Value: {Value}");

		/// <summary>
		/// Метод расчета импеданса элемента
		/// </summary>
		/// <param name="frequence"></param>
		/// <returns></returns>
		public abstract Complex CalculateZ(double frequence);
	}
}
