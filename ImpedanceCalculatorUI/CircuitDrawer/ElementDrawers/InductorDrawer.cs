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
	/// Содержит методы для отрисовки индуктора
	/// </summary>
	class InductorDrawer : SegmentDrawerBase
	{
		/// <summary>
		/// Создает объект InductorDrawer и устанавливает значение Segment
		/// </summary>
		/// <param name="segment"></param>
		public InductorDrawer(ISegment segment)
		{
			Segment = segment;
		}

		/// <inheritdoc/>
		public override Bitmap GetImage()
		{
			var bitmap = new Bitmap(GetSize().Height, GetSize().Width);
			var g = Graphics.FromImage(bitmap);

			Draw(g);

			return bitmap;
		}

		/// <summary>
		/// Рисует катушку индуктивности.
		/// </summary>
		/// <param name="graphics"></param>
		/// <param name="inductorName"></param>
		public void Draw(Graphics graphics)
		{
			graphics.DrawBezier(StandartPen, 40, 50, 40, 40, 48, 40, 48, 50);
			graphics.DrawBezier(StandartPen, 48, 50, 48, 40, 56, 40, 56, 50);
			graphics.DrawBezier(StandartPen, 56, 50, 56, 40, 64, 40, 64, 50);
			graphics.DrawBezier(StandartPen, 64, 50, 64, 40, 72, 40, 72, 50);
			graphics.DrawBezier(StandartPen, 72, 50, 72, 40, 80, 40, 80, 50);

			graphics.DrawLine(StandartPen, 0, 50, 40, 50);
			graphics.DrawLine(StandartPen, 80, 50, ElementSize.Width, 50);

			graphics.DrawString(Segment.Name, new Font(FontFamily.GenericSansSerif,
				10, FontStyle.Regular), new SolidBrush(Color.Black), 50, 20);
		}

		/// <inheritdoc/>
		public override Size GetSize()
		{
			return new Size(ElementSize.Width, ElementSize.Width);
		}
	}
}
