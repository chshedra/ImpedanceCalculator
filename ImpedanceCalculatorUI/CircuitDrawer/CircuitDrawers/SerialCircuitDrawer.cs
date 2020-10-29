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
	class SerialCircuitDrawer : SegmentDrawer
	{
		public SerialCircuitDrawer(ISegment segment) : base(segment) { }

		/// <summary>
		///     Вычисляет размер рисунка эл. цепи с последовательным соединением.
		/// </summary>
		/// <param name="circuit">Эл. цепь с последовательным соединением.</param>
		public override Size GetSize()
		{
			var size = Nodes.Count > 0 
				? new Size(0, 0) 
				: new Size(EmptyImageSize.Width, EmptyImageSize.Height);

			foreach (var segment in Segment.SubSegments)
				if (segment is ElementBase)
				{
					var elementDrawer = new SegmentDrawer(segment);
					size.Height = size.Height < elementDrawer.GetSize().Height
						? elementDrawer.GetSize().Height
						: size.Height;
					size.Width = size.Width + elementDrawer.GetSize().Width;

					size.Height = size.Height + elementDrawer.GetSize().Height;
					size.Width = size.Width < elementDrawer.GetSize().Width
						? elementDrawer.GetSize().Width
						: size.Width;
				}
				else if (segment is CircuitBase)
				{
					var circuitDrawer = new SegmentDrawer(segment);
					var scSize = circuitDrawer.GetSize();
					size.Height = size.Height < scSize.Height ? scSize.Height : size.Height;
					size.Width = size.Width + scSize.Width;
				}
			return size;
		}
    }
}
