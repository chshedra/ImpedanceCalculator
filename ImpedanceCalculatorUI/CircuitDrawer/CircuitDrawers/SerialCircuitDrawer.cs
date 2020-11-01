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
    //TODO: +RSDN
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

            //TODO: +RSDN - именование
			var graphics = Graphics.FromImage(bitmap);

			//TODO: +Скобочки
			foreach (SegmentDrawerBase node in Nodes)
			{
				var segmentImage = node.GetImage();
				//TODO: +RSDN
				//TODO: +Дубль ниже
				graphics.DrawImage(segmentImage, 
					new Point(x, y - segmentImage.Height / ImageDellimitterConst));
				x += node.GetSize().Width;
				//TODO: +switch-case
			}

			return bitmap;
		}

		/// <inheritdoc/>
		public override Size GetSize()
		{
			var size = Nodes.Count > 0 
				? new Size(0, 0) 
				: new Size(EmptyImageSize.Width, EmptyImageSize.Height);
			//TODO: +Скобочки
			foreach (SegmentDrawerBase node in Nodes)
			{
				//TODO:+switch-case
				switch (node.Segment)
				{
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
						var circuitSize = node.GetSize();
						//TODO: +RSDN
						size.Height = size.Height < circuitSize.Height 
							? circuitSize.Height 
							: size.Height;
						size.Width = size.Width + circuitSize.Width;

						break;
					}
				}
			}

			return size;
		}
    }
}
