using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImpedanceCalculatorUI.CircuitDrawer.ElementDrawers
{
	public abstract class ElementDrawerBase : SegmentDrawerBase
	{
		public abstract void Draw(Graphics graphics);

		/// <summary>
		/// Возвращает битмап с изображением элемента
		/// </summary>
		public override Bitmap GetImage()
		{
			var bitmap = new Bitmap(GetSize().Height, GetSize().Width);
			var graphics = Graphics.FromImage(bitmap);

			Draw(graphics);

			return bitmap;
		}

		/// <inheritdoc/>
		public override Size GetSize()
		{
			return new Size(ElementSize.Width, ElementSize.Width);
		}
	}
}
