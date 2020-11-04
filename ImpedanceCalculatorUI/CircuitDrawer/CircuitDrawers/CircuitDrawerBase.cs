using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpedanceCalculatorUI.CircuitDrawer.CircuitDrawers
{
	public abstract class CircuitDrawerBase : SegmentDrawerBase
	{
		/// <inheritdoc/>
		public override Size GetSize()
		{
			var size = Segment.SubSegments.Count > 0
				? new Size(0, 0)
				: new Size(EmptyImageSize.Width, EmptyImageSize.Height);

			foreach (SegmentDrawerBase node in Nodes)
			{
				//TODO: +В глобальном смысле дублируется с SerialCircuitDrawer
				//TODO: +А в чём вообще смысл такого свича? В следующем свиче разве не дубль?
				size.Height = size.Height + node.GetSize().Height;
				size.Width = size.Width < node.GetSize().Width
					? node.GetSize().Width
					: size.Width;
			}

			return size;
		}

		
	}
}
