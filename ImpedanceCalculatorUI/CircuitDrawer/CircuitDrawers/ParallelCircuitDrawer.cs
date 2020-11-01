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

//TODO: Несоответствие дефолтному namespace
namespace ImpedanceCalculatorUI.CircuitDrawer
{
	//TODO: RSDN
	/// <summary>
	/// Содержит методы для отрисовки параллельного участка цепи
	/// </summary>
	class ParallelCircuitDrawer : SegmentDrawerBase
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
			//TODO: RSDN
            var firstSegment = CircuitDrawManager.GetDrawSegment(((CircuitBase)Segment).FirstOrDefault());
            var lastElement = CircuitDrawManager.GetDrawSegment(((CircuitBase)Segment).LastOrDefault());
            
            var firstHeight = firstSegment.GetSize().Height;
            var lastHeight = lastElement.GetSize().Height;
			//TODO: RSDN
            var g = Graphics.FromImage(bitmap);
			//TODO: RSDN - именование
            g.DrawLine(StandartPen, 0, size.Height / ImageDellimitterConst, InputLineLength,
                    size.Height / ImageDellimitterConst);

			g.DrawLine(StandartPen, x, y + firstHeight / ImageDellimitterConst, x,
				size.Height - lastHeight / ImageDellimitterConst);

            foreach (SegmentDrawerBase node in Nodes)
            {
				//TODO: switch-case
	            if (node.Segment is ElementBase)
	            {
		            var elementImage = node.GetImage();
                    //TODO: Дубль ниже
					g.DrawImage(elementImage, new Point(x, y));
					//TODO: RSDN
		            g.DrawLine(StandartPen, x + elementImage.Width,
			            y + elementImage.Height / ImageDellimitterConst, bitmap.Width - ParallelConnector,
			            y + elementImage.Height / ImageDellimitterConst);
		            y += elementImage.Height;
	            }
	            else if (node.Segment is CircuitBase)
	            {
		            var circuitImage = new Bitmap(1, 1);
			            circuitImage = node.GetImage();
						//TODO: Дубль выше
		            g.DrawImage(circuitImage, new Point(x, y));

		            g.DrawLine(StandartPen, x + circuitImage.Width,
			            y + circuitImage.Height / ImageDellimitterConst, bitmap.Width - ParallelConnector,
			            y + circuitImage.Height / ImageDellimitterConst);
		            y += circuitImage.Height;
	            }
            }
			//TODO: RSDN
            g.DrawLine(StandartPen, bitmap.Width - ParallelConnector, firstHeight / ImageDellimitterConst,
                bitmap.Width - ParallelConnector, size.Height - lastHeight / ImageDellimitterConst);

			//TODO: RSDN
            g.DrawLine(StandartPen, bitmap.Width - ParallelConnector, bitmap.Height / ImageDellimitterConst,
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
                //TODO: switch-case
				if (node.Segment is ElementBase)
				{
					size.Height = size.Height + node.GetSize().Height;
					size.Width = size.Width < node.GetSize().Width
						? node.GetSize().Width
						: size.Width;
				}
				else if (node.Segment is CircuitBase)
				{
					var scSize = node.GetSize();
					//TODO: RSDN
					size.Width = size.Width < scSize.Width ? scSize.Width : size.Width;
					size.Height = size.Height + scSize.Height;
				}
			}

			size.Width += InputLineLength + OutputLineLength;
			return size;
		}
    }
}
