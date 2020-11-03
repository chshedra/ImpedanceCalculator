using System.Drawing;


namespace ImpedanceCalculatorUI.CircuitDrawer.ElementDrawers
{
	/// <summary>
	/// Содержит методы для получения изображения элемента
	/// </summary>
	public abstract class ElementDrawer : SegmentDrawerBase
	{
		/// <summary>
		/// Отрисовывает элемент
		/// </summary>
		/// <param name="graphics"></param>
		public abstract void Draw(Graphics graphics);

		/// <inheritdoc/>
		public override Size GetSize()
		{
			//TODO: +Дубль в наследниках
			return new Size(ElementSize.Width, ElementSize.Width);
		}

		/// <inheritdoc/>
		public override Bitmap GetImage()
		{
			//TODO: +Дубль в наследниках
			var bitmap = new Bitmap(GetSize().Height, GetSize().Width);
			var graphics = Graphics.FromImage(bitmap);

			Draw(graphics);

			return bitmap;
		}
	}
}
