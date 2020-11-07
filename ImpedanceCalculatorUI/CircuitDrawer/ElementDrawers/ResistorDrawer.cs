using System.Drawing;
using ImpedanceCalculator;

namespace ImpedanceCalculatorUI.CircuitDrawer.ElementDrawers
{
	/// <summary>
	/// Содержит методы для отрисовки резистора
	/// </summary>
	public class ResistorDrawer : ElementDrawerBase
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
			graphics.DrawRectangle(StandartPen, new Rectangle(32, 34, 60, 32));

			graphics.DrawLine(StandartPen, 0, 50, 30, 50);
			graphics.DrawLine(StandartPen, 92, 50, ElementSize.Width, 50);

			var emSize = 3;
			var nameLocationX = ElementSize.Width / 2 - 
									(Segment.Name.Length * emSize) / 2;

			graphics.DrawString(Segment.Name, new Font(FontFamily.GenericSansSerif,
				10, FontStyle.Regular), new SolidBrush(Color.Black), nameLocationX, 10);
		}
	}
}
