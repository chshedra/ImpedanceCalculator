using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceCalculator
{
	/// <summary>
	/// Интерфейс сегмента цепи
	/// </summary>
	public interface ISegment : ICloneable
	{
		#region Properties

		/// <summary>
		/// Название элемента или участка цепи
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Устанавливает и возвращает список переменных типа ISegment
		/// </summary>
		List<ISegment> SubSegments { get; }

		#endregion

		#region Events

		/// <summary>
		/// Событие изменения сегмента цепи
		/// </summary>
		event EventHandler SegmentChanged;

		#endregion

		#region Methods

		/// <summary>
		/// Метод, расчитывающий импеданс
		/// </summary>
		/// <param name="frequency"></param>
		Complex CalculateZ(double frequency);
		#endregion
	}
}
