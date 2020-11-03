using System.Drawing;
using ImpedanceCalculator;

namespace ImpedanceCalculatorUI.CircuitDrawer.ElementDrawers
{
	/// <summary>
	/// Содержит методы для отрисовки резистора
	/// </summary>
	public class ResistorDrawer : ElementDrawer
	{
		/// <summary>
		/// Создает объект ResistorDrawer и устанавливает значение Segment
		/// </summary>
		/// <param name="segment"></param>
		public ResistorDrawer(ISegment segment)
		{
			Segment = segment;
		}

		/// <summary>
		/// Рисует резистор
		/// </summary>
		/// <param name="graphics"></param>
		public override void Draw(Graphics graphics)
		{
			graphics.DrawRectangle(StandartPen, new Rectangle(20, 34, 60, 32));

			graphics.DrawLine(StandartPen, 0, 50, 20, 50);
			graphics.DrawLine(StandartPen, 80, 50, ElementSize.Width, 50);

			graphics.DrawString(Segment.Name, new Font(FontFamily.GenericSansSerif,
				10, FontStyle.Regular), new SolidBrush(Color.Black), 40, 10);
		}
	}
}
