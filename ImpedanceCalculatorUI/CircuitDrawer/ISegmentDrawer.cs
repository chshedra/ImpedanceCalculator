using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpedanceCalculator;

namespace ImpedanceCalculatorUI.CircuitDrawer
{
	/// <summary>
	/// Содержит методы для отрисовки сегментов цепи
	/// </summary>
	interface ISegmentDrawer
	{
		/// <summary>
		/// Возвращает и устанавливает значение сегмента для отрисовки
		/// </summary>
		ISegment Segment { get; set; }

		/// <summary>
		/// Возвращает изображение сегмента
		/// </summary>
		Bitmap GetImage();

		/// <summary>
		/// Возвращает размер сегмента
		/// </summary>
		Size GetSize();
	}
}
