using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpedanceCalculator;
using ImpedanceCalculator.Circuits;
using ImpedanceCalculator.Elements;
using ImpedanceCalculatorUI.CircuitDrawer.CircuitDrawers;


namespace ImpedanceCalculatorUI.CircuitDrawer.CircuitDrawers
{
	/// <summary>
	/// Содержит методы для отрисовки параллельного участка цепи
	/// </summary>
	public class ParallelCircuitDrawer : SegmentDrawerBase
	{
		/// <summary>
		/// Создает объект ParallelCircuitDrawer и устанавливает значение Segment
		/// </summary>
		/// <param name="segment"></param>
		public ParallelCircuitDrawer(ISegment segment)
		{
			Segment = segment;
		}

		/// <inheritdoc/>
		public override Bitmap GetImage()
		{
			var size = GetSize();
            var bitmap = new Bitmap(size.Width, size.Height);
            var x = InputLineLength;
            var y = 0;

            var firstSegment = 
	            CircuitDrawManager.
		        GetDrawSegment(((CircuitBase)Segment).FirstOrDefault());
			CircuitDrawManager.FillSegmentDrawerTreeNode(firstSegment, 
				((CircuitBase)Segment).FirstOrDefault());

            var lastElement = 
	            CircuitDrawManager.
		        GetDrawSegment(((CircuitBase)Segment).LastOrDefault());
            CircuitDrawManager.FillSegmentDrawerTreeNode(lastElement, 
	            ((CircuitBase)Segment).LastOrDefault());

			var firstHeight = firstSegment.GetSize().Height;
            var lastHeight = lastElement.GetSize().Height;

            var graphics = Graphics.FromImage(bitmap);

            graphics.DrawLine(StandartPen, 0, 
	            size.Height / ImageDellimitterConst, 
	            InputLineLength,
	            size.Height / ImageDellimitterConst);

			graphics.DrawLine(StandartPen, x, 
				y + firstHeight / ImageDellimitterConst, x,
				size.Height - lastHeight / ImageDellimitterConst);

            foreach (SegmentDrawerBase node in Nodes)
            {
	            var segmentImage = node.GetImage();

	            graphics.DrawImage(segmentImage, new Point(x, y));

	            graphics.DrawLine(StandartPen, x + segmentImage.Width,
		            y + segmentImage.Height / ImageDellimitterConst,
		            bitmap.Width - ParallelConnector,
		            y + segmentImage.Height / ImageDellimitterConst);

	            y += segmentImage.Height;
            }

            graphics.DrawLine(StandartPen, bitmap.Width - ParallelConnector, 
	            firstHeight / ImageDellimitterConst,
                bitmap.Width - ParallelConnector, 
	            size.Height - lastHeight / ImageDellimitterConst);

            graphics.DrawLine(StandartPen, bitmap.Width - ParallelConnector, 
	            bitmap.Height / ImageDellimitterConst,
                bitmap.Width, bitmap.Height / ImageDellimitterConst);

            return bitmap;
        }

		/// <inheritdoc/>
		public override Size GetSize()
		{
			var size = Segment.SubSegments.Count > 0 
				? new Size(0, 0) 
				: new Size(EmptyImageSize.Width, EmptyImageSize.Height);

			foreach (SegmentDrawerBase node in Nodes)
			{
                size.Height = size.Height + node.GetSize().Height;
						size.Width = size.Width < node.GetSize().Width
							? node.GetSize().Width
							: size.Width;

			}

			size.Width += InputLineLength + OutputLineLength;
			return size;
		}
    }
}
