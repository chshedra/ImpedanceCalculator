using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpedanceCalculator;

namespace ImpedanceCalculatorUI.CircuitDrawer
{
	interface ISegmentDrawer
	{
		ISegment Segment { get; set; }

		Bitmap GetImage();

		Size GetSize();
	}
}
