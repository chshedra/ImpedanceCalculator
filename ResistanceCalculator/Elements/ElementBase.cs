using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace ImpedanceCalculator.Elements
{
    //TODO: Зачем тут ICloneable? У ISegment-a уже есть.
	/// <summary>
	/// Абстрактный класс элемента цепи
	/// </summary>
	[Serializable]
	public abstract class ElementBase : IElement
	{
		#region Private Fields

		/// <summary>
		/// Название конденсатора
		/// </summary>
		private string _name;

		/// <summary>
		/// Емкость конденстатора
		/// </summary>
		private double _value;

		#endregion

		#region Public Properties

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
					//TODO: При чём здесь резистор?
					throw new ArgumentException($"Resistor {Name} " +
						$"must have positive value");
				}
				_value = value;

				SegmentChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Устанавливает и возвращает имя и значение элемента
		/// </summary>
		/// <param name="name"></param>
		/// <param name="value"></param>
		protected ElementBase(string name, double value)
		{
			Name = name;
			Value = value;
		}

		#endregion

		#region Methods

		/// <inheritdoc/>
		public override string ToString()
			=> ($"Name: {Name}. Value: {Value}");

		/// <summary>
		/// Метод расчета импеданса элемента
		/// </summary>
		/// <param name="frequence"></param>
		/// <returns></returns>
		public abstract Complex CalculateZ(double frequency);

		#endregion

		#region Implementation of ICloneable

		/// <inheritdoc />
		public object Clone()
		{
			//TODO: В корне не верно!
			switch (this)
			{
				case Resistor resistor:
				{
					return resistor.Clone(); 
				}
				case Inductor inductor:
				{
					return inductor.Clone();
				}
				case Capacitor capacitor:
				{
					return capacitor.Clone();
				}
				default:
				{
					return null;
				}
			}
		}

		#endregion
	}
}
