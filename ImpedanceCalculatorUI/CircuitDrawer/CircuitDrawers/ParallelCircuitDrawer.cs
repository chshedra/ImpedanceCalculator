using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpedanceCalculator;
using ImpedanceCalculator.Circuits;
using ImpedanceCalculator.Elements;

namespace ImpedanceCalculatorUI.CircuitDrawer
{
	class ParallelCircuitDrawer : SegmentDrawer
	{
		public ParallelCircuitDrawer(ISegment segment) : base(segment) { }

		public override Bitmap GetImage()
		{

            var size = GetSize();
            var bitmap = new Bitmap(size.Width, size.Height);
            var x = InputLineLength;
            var y = 0;
            var firstSegment = new SegmentDrawer(((CircuitBase)Segment).FirstOrDefault());
            var lastElement = new SegmentDrawer(((CircuitBase)Segment).LastOrDefault());
            if (firstSegment == null || lastElement == null)
            {
                return bitmap;
            }
            var firstHeight = firstSegment.GetSize().Height;
            var lastHeight = lastElement.GetSize().Height;

            var g = Graphics.FromImage(bitmap);
            g.DrawLine(StandartPen, 0, size.Height / ImageDellimitterConst, InputLineLength,
                    size.Height / ImageDellimitterConst);

			g.DrawLine(StandartPen, x, y + firstHeight / ImageDellimitterConst, x,
				size.Height - lastHeight / ImageDellimitterConst);

            foreach (var segment in Segment.SubSegments)
            {
                var segmentDrawer = new SegmentDrawer(segment);
                    var elementImage = segmentDrawer.GetImage();
                    g.DrawImage(elementImage, new Point(x, y));

                    g.DrawLine(StandartPen, x + elementImage.Width,
                        y + elementImage.Height / ImageDellimitterConst, bitmap.Width - ParallelConnector,
                        y + elementImage.Height / ImageDellimitterConst);
                    y += elementImage.Height;
            }

            g.DrawLine(StandartPen, bitmap.Width - ParallelConnector, firstHeight / ImageDellimitterConst,
                bitmap.Width - ParallelConnector, size.Height - lastHeight / ImageDellimitterConst);


            g.DrawLine(StandartPen, bitmap.Width - ParallelConnector, bitmap.Height / ImageDellimitterConst,
                bitmap.Width, bitmap.Height / ImageDellimitterConst);
            return bitmap;
        }

		/// <summary>
		/// Вычисляет размер рисунка эл. цепи с параллельным соединением.
		/// </summary>
		/// <param name="circuit">Эл. цепь с параллельным соединением.</param>
		public override Size GetSize()
		{
			var size = Segment.SubSegments.Count > 0 ? new Size(0, 0) : new Size(EmptyImageSize.Width, EmptyImageSize.Height);
			foreach (var segment in Segment.SubSegments)
				if (segment is ElementBase)
				{
                    SegmentDrawer elementDrawer = new SegmentDrawer(segment);
					size.Height = size.Height + elementDrawer.GetSize().Height;
					size.Width = size.Width < elementDrawer.GetSize().Width
						? elementDrawer.GetSize().Width
						: size.Width;
				}
				else 
				{
                    SegmentDrawer circuitDrawer = new SegmentDrawer(segment);
					var scSize = circuitDrawer.GetSize();
					size.Width = size.Width < scSize.Width ? scSize.Width : size.Width;
					size.Height = size.Height + scSize.Height;
				}
			size.Width += InputLineLength + OutputLineLength;
			return size;
		}
    }
}
