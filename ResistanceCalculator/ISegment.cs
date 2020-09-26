using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceCalculator
{
	public interface ISegment
	{
		/// <summary>
		/// Название элемента или участка цепи
		/// </summary>
		string Name { get; set; }

		/// <summary>
		/// Устанавливает и возвращает список переменных типа ISegment
		/// </summary>
		List<ISegment> SubSegments { get; }

		/// <summary>
		/// Метод, расчитывающий импеданс
		/// </summary>
		/// <param name="frequence"></param>
		Complex CalculateZ(double frequence);

		/// <summary>
		/// Событие изменения сегмента цепи
		/// </summary>
		event EventHandler SegmentChanged;

	}
}
