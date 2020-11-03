using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpedanceCalculator;
using ImpedanceCalculator.Circuits;
using ImpedanceCalculator.Elements;

namespace ImpedanceCalculatorUI.CircuitDrawer.CircuitDrawers
{
	/// <summary>
	/// Содержит методы для отрисовки последовательного участка цепи
	/// </summary>
	public class SerialCircuitDrawer : SegmentDrawerBase
	{
		/// <summary>
		/// Создает объект CerialCircuitDrawer и устанавливает значение Segment
		/// </summary>
		/// <param name="segment"></param>
		public SerialCircuitDrawer(ISegment segment)
		{
			Segment = segment;
		}

		/// <inheritdoc/>
		public override Bitmap GetImage()
		{
			var size = GetSize();

			var bitmap = new Bitmap(size.Width, size.Height);
			var x = 0;
			var y = size.Height / ImageDellimitterConst;

			var graphics = Graphics.FromImage(bitmap);

			foreach (SegmentDrawerBase node in Nodes)
			{
				var segmentImage = node.GetImage();
				graphics.DrawImage(segmentImage, 
					new Point(x, y - segmentImage.Height / ImageDellimitterConst));
				x += node.GetSize().Width;
			}

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
                //TODO: В глобальном смысле дублируется с ParallelCircuitDrawer
				switch (node.Segment)
				{
					//TODO: А в чём вообще смысл такого свича? В следующем свиче разве не дубль?
					case ElementBase element:
					{
						size.Height = size.Height < node.GetSize().Height
							? node.GetSize().Height
							: size.Height;
						size.Width = size.Width + node.GetSize().Width;

						break;
					}
					case CircuitBase circuit:
					{
						size.Height = size.Height < node.GetSize().Height 
							? node.GetSize().Height 
							: size.Height;
						size.Width = size.Width + node.GetSize().Width;

						break;
					}
				}
			}

			return size;
		}
    }
}
