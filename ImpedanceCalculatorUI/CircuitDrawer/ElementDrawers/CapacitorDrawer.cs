using System.Drawing;
using ImpedanceCalculator;
//TODO: +Несоответствие дефолтному namespace
namespace ImpedanceCalculatorUI.CircuitDrawer.ElementDrawers
{
	//TODO: +RSDN
	/// <summary>
	/// Содержит методы для отрисовки конденсатора
	/// </summary>
	public class CapacitorDrawer : SegmentDrawerBase
	{
		/// <summary>
		/// Создает объект CaoacitorDrawer и устанавливает значение Segment
		/// </summary>
		/// <param name="segment"></param>
		public CapacitorDrawer(ISegment segment)
		{
			Segment = segment;
		}

		/// <inheritdoc/>
		public override Bitmap GetImage()
		{
			var bitmap = new Bitmap(GetSize().Height, GetSize().Width);
			//TODO: +RSDN - именование
			var graphics = Graphics.FromImage(bitmap);

			Draw(graphics);

			return bitmap;
		}

		/// <inheritdoc/>
		public override Size GetSize()
		{
			return new Size(ElementSize.Width, ElementSize.Width);
		}

		/// <summary>
		/// Рисует конденсатор.
		/// </summary>
		/// <param name="graphics"></param>
		/// //TODO +Сигнатура XML комментария и метода различны
		public void Draw(Graphics graphics)
		{
			graphics.DrawLine(StandartPen, 40, 35, 40, 65);
			graphics.DrawLine(StandartPen, 60, 35, 60, 65);

			graphics.DrawLine(StandartPen, 0, 50, 40, 50);
			graphics.DrawLine(StandartPen, 60, 50, ElementSize.Width, 50);

			graphics.DrawString(Segment.Name, new Font(FontFamily.GenericSansSerif,
				10, FontStyle.Regular), new SolidBrush(Color.Black), 40, 10);
		}
    }
}
