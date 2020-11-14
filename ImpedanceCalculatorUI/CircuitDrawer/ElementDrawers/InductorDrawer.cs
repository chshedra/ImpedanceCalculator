using System.Drawing;
using ImpedanceCalculator;

namespace ImpedanceCalculatorUI.CircuitDrawer.ElementDrawers
{
	/// <summary>
	/// Содержит методы для отрисовки индуктора
	/// </summary>
	public class InductorDrawer : ElementDrawerBase
	{
		/// <summary>
		/// Создает объект InductorDrawer и устанавливает значение Segment
		/// </summary>
		/// <param name="segment"></param>
		public InductorDrawer(ISegment segment)
		{
			Segment = segment;
		}

		/// <summary>
		/// Рисует катушку индуктивности.
		/// </summary>
		/// <param name="graphics"></param>
		public override void Draw(Graphics graphics)
		{
            var firstBezierX = 45;
            var lastBezierX = 80;
            var bezierLength = 8;

			for (int i = firstBezierX; i < lastBezierX; i += 8)
            {
	            graphics.DrawBezier(StandartPen, i, 50, i, 40, 
		            i + bezierLength, 40, i + bezierLength, 50);
	          
            }

            graphics.DrawLine(StandartPen, 0, 50, 45, 50);
			graphics.DrawLine(StandartPen, 85, 50, ElementSize.Width, 50);

			var symbolSize = 7;
			var elementCenter = firstBezierX + 
			                    (lastBezierX - firstBezierX) / 2;
			var nameLocationX = elementCenter - 
			        (Segment.Name.Length * symbolSize) / 2;

			graphics.DrawString(Segment.Name, new Font(FontFamily.GenericSansSerif,
				10, FontStyle.Regular), new SolidBrush(Color.Black), nameLocationX, 20);


		}

	
	}
}
