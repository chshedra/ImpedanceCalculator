using System.Drawing;
using ImpedanceCalculator;

namespace ImpedanceCalculatorUI.CircuitDrawer.ElementDrawers
{
	/// <summary>
	/// Содержит методы для отрисовки конденсатора
	/// </summary>
	public class CapacitorDrawer : ElementDrawerBase
	{
		/// <summary>
		/// Создает объект CaoacitorDrawer и устанавливает значение Segment
		/// </summary>
		/// <param name="segment"></param>
		public CapacitorDrawer(ISegment segment)
		{
			Segment = segment;
		}

		/// <summary>
		/// Рисует конденсатор.
		/// </summary>
		/// <param name="graphics"></param>
		public override void Draw(Graphics graphics)
		{
			graphics.DrawLine(StandartPen, 55, 35, 55, 65);
			graphics.DrawLine(StandartPen, 75, 35, 75, 65);

			graphics.DrawLine(StandartPen, 0, 50, 55, 50);
			graphics.DrawLine(StandartPen, 75, 50, ElementSize.Width, 50);

			graphics.DrawString(Segment.Name, new Font(FontFamily.GenericSansSerif,
				10, FontStyle.Regular), new SolidBrush(Color.Black), 60, 10);
		}
    }
}
