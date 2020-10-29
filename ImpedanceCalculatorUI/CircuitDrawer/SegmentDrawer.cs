using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImpedanceCalculator;

namespace ImpedanceCalculatorUI.CircuitDrawer
{
	public class SegmentDrawer : TreeNode, ISegmentDrawer
	{
		public ISegment Segment { get; set; }

		/// <summary>
		/// Стандартная кисть для линий.
		/// </summary>
		public static readonly Pen StandartPen = new Pen(Color.Black);

		/// <summary>
		/// Размер пустого битмапа.
		/// </summary>
		public readonly Size EmptyImageSize = new Size(1, 1);

		/// <summary>
		/// Размер простейшего элемента эл.цепи
		/// </summary>
		public readonly Size ElementSize = new Size(100, 100);

		/// <summary>
		/// Длина входной линии.
		/// </summary>
		public const int InputLineLength = 20;

		/// <summary>
		/// Длина выходной линии.
		/// </summary>
		public const int OutputLineLength = 40;

		/// <summary>
		///  Делитель изображения. Определяет в какой части будет находится входная и выходная линии.
		/// </summary>
		public const int ImageDellimitterConst = 2;

		/// <summary>
		/// Определяет где будет находиться выходная вертикальная линий у параллельной цепи.
		/// </summary>
		public const int ParallelConnector = 10;

		public SegmentDrawer(ISegment segment)
		{
			Segment = segment;
		}

		public virtual Bitmap GetImage()
		{
			return new Bitmap(1, 1);
		}

		public virtual Size GetSize()
		{
			return new Size(0,0);
		}
	}
}
