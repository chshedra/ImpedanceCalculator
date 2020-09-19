using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;


namespace ImpedanceCalculator
{
	class Inductor : IElement
	{
		/// <summary>
		/// Название катушки индуктивности
		/// </summary>
		private string _name;

		/// <summary>
		/// Индуктивность катушки 
		/// </summary>
		private double _value;
		

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
					throw new ArgumentException("The name must have a value");
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
					throw new ArgumentException("Industance must be positive");
				}

				_value = value;

				ValueChanged?.Invoke(this, EventArgs.Empty);
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


		/// <summary>
		/// Метод, вычисляющий индуктивность катушки в комплексной форме
		/// </summary>
		/// <param name="frequence"></param>
		/// <returns></returns>
		public Complex CalculateZ(double frequence)
		{
			double resistance = 2 * Math.PI * frequence * Value;
			Complex complexResistance = new Complex(0, resistance);

			return complexResistance;
		}

		/// <summary>
		/// Метод проверки наличия подписчиков у события ValueChanged
		/// </summary>
		public bool HasSubscribers()
		{
			return ValueChanged == null;
		}

		/// <summary>
		/// событие изменения значения элемента цепи
		/// </summary>
		public event EventHandler ValueChanged;
	}
}
