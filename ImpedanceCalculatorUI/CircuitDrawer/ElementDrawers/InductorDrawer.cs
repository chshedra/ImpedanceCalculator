using System.Drawing;
using ImpedanceCalculator;
//TODO: +Несоответствие дефолтному namespace
namespace ImpedanceCalculatorUI.CircuitDrawer.ElementDrawers
{
	//TODO: +RSDN
	/// <summary>
	/// Содержит методы для отрисовки индуктора
	/// </summary>
	public class InductorDrawer : SegmentDrawerBase
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
			//TODO: +RSDN - именование
			var graphics = Graphics.FromImage(bitmap);

			Draw(graphics);

			return bitmap;
		}

		/// <summary>
		/// Рисует катушку индуктивности.
		/// </summary>
		/// <param name="graphics"></param>
		/// //TODO +Сигнатура XML комментария и метода различны
		public void Draw(Graphics graphics)
		{
            //TODO: +Можно собрать в for
            var firstBezierX = 40;
            var lastBezierX = 80;
            var bezierLength = 8;

			for (int i = firstBezierX; i < lastBezierX; i += 8)
            {
	            graphics.DrawBezier(StandartPen, i, 50, i, 40, 
		            i + bezierLength, 40, i + bezierLength, 50);
	          
            }

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
