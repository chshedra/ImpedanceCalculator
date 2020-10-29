using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpedanceCalculator;

namespace ImpedanceCalculatorUI.CircuitDrawer
{
	class ResistorDrawer : SegmentDrawer
	{
		public ResistorDrawer(ISegment segment) : base(segment){ }

		public override Bitmap GetImage()
		{
			var bitmap = new Bitmap(GetSize().Height, GetSize().Width);
			var g = Graphics.FromImage(bitmap);

			Draw(g);

			return bitmap;
		}

		public void Draw(Graphics graphics)
		{
			graphics.DrawRectangle(StandartPen, new Rectangle(20, 34, 60, 32));

			graphics.DrawLine(StandartPen, 0, 50, 20, 50);
			graphics.DrawLine(StandartPen, 80, 50, ElementSize.Width, 50);

			graphics.DrawString(Segment.Name, new Font(FontFamily.GenericSansSerif,
				10, FontStyle.Regular), new SolidBrush(Color.Black), 40, 10);
		}

		public override Size GetSize()
		{
			return new Size(ElementSize.Width, ElementSize.Width);
		}
    }
}
