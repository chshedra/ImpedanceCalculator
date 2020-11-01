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
	//TODO: +В чём логика наследования от SegmentTreeNode?
	/// <summary>
	/// Содержит методы для отрисовки сегментов цепи
	/// </summary>
	public abstract class SegmentDrawerBase : TreeNode, ISegmentDrawer
	{
		/// <summary>
		/// Хранит значение сегмента данного узла
		/// </summary>
		protected ISegment _segment;

		/// <inheritdoc/>
		public ISegment Segment
		{
			get => _segment;

			set
			{
				_segment = value;
			}
		}

		//TODO: +Все константы ниже - почему public всё?
		/// <summary>
		/// Стандартная кисть для линий.
		/// </summary>
		protected static readonly Pen StandartPen = new Pen(Color.Black);

		/// <summary>
		/// Размер пустого битмапа.
		/// </summary>
		protected readonly Size EmptyImageSize = new Size(1, 1);

		/// <summary>
		/// Размер простейшего элемента эл.цепи
		/// </summary>
		protected readonly Size ElementSize = new Size(100, 100);

		/// <summary>
		/// Длина входной линии.
		/// </summary>
		protected const int InputLineLength = 20;

		/// <summary>
		/// Длина выходной линии.
		/// </summary>
		protected const int OutputLineLength = 40;

		/// <summary>
		///  Делитель изображения. Определяет в какой части будет находится входная и выходная линии.
		/// </summary>
		protected const int ImageDellimitterConst = 2;

		/// <summary>
		/// Определяет где будет находиться выходная вертикальная линий у параллельной цепи.
		/// </summary>
		protected const int ParallelConnector = 10;

		/// <inheritdoc/>
		public abstract Bitmap GetImage();

		/// <inheritdoc/>
		public abstract Size GetSize();
	}
}
