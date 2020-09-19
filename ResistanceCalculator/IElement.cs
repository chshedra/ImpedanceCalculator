using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace ImpedanceCalculator
{
	public interface IElement
	{
		/// <summary>
		/// Устанавливает и возвращает название элемента
		/// </summary>
		string Name
		{
			get;
			set;
		}

		/// <summary>
		///  Устанавливает и возвращает значение элемента
		/// </summary>
		double Value
		{
			get;
			set;
		}

		/// <summary>
		/// событие изменения значения элемента цепи
		/// </summary>
		event EventHandler ValueChanged;

		/// <summary>
		/// Метод проверки наличия подписчиков у события ValueChanged
		/// </summary>
		bool HasSubscribers();


		/// <summary>
		/// Метод расчета сопротивления элемента
		/// </summary>
		/// <param name="frequence"></param>
		/// <returns></returns>
		Complex CalculateZ(double frequence);

	}
}
