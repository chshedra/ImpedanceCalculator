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
    //TODO: RSDN
	/// <summary>
	/// Содержит методы для отрисовки последовательного участка цепи
	/// </summary>
	class SerialCircuitDrawer : SegmentDrawerBase
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

            //TODO: RSDN - именование
			var g = Graphics.FromImage(bitmap);

			//TODO: Скобочки
			foreach (SegmentDrawerBase node in Nodes)
                //TODO: switch-case
				if (node.Segment is IElement)
				{
					var elementImage = node.GetImage();
					//TODO: RSDN
					//TODO: Дубль ниже
					g.DrawImage(elementImage, new Point(x, y - elementImage.Height / ImageDellimitterConst));
					x += node.GetSize().Width;
				}
				else if (node.Segment is CircuitBase)
				{
                    //TODO: RSDN
					var circuitImage = new Bitmap(EmptyImageSize.Width, EmptyImageSize.Height);
					circuitImage = node.GetImage();
					//TODO: Дубль выше
					g.DrawImage(circuitImage, new Point(x, y - circuitImage.Height / ImageDellimitterConst));
					x += node.GetSize().Width;
				}
			return bitmap;
		}

		/// <inheritdoc/>
		public override Size GetSize()
		{
			var size = Nodes.Count > 0 
				? new Size(0, 0) 
				: new Size(EmptyImageSize.Width, EmptyImageSize.Height);
			//TODO: Скобочки
			foreach (SegmentDrawerBase node in Nodes)
                //TODO: switch-case
				if (node.Segment is ElementBase)
				{
					size.Height = size.Height < node.GetSize().Height
						? node.GetSize().Height
						: size.Height;
					size.Width = size.Width + node.GetSize().Width;
				}
				else if (node.Segment is CircuitBase)
				{
					var scSize = node.GetSize();
					//TODO: RSDN
					size.Height = size.Height < scSize.Height ? scSize.Height : size.Height;
					size.Width = size.Width + scSize.Width;
				}
			return size;
		}
    }
}
