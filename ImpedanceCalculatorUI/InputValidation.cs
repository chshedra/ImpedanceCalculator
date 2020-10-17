using System.Windows.Forms;
using System.Drawing;

namespace ImpedanceCalculatorUI
{
	//TODO: +Почему не статический?
	/// <summary>
	/// Содержит методы проверки входных значений
	/// </summary>
	public static class InputValidation
	{
		/// <summary>
		/// Проверяет корректность введенных значений
		/// </summary>
		/// <param name="textBox"></param>
		public static void CheckTextBoxValue(TextBox textBox)
		{
			//TODO: +Можно удалить объявление etalon и записать в параметрах парса "out _"
			textBox.BackColor = (double.TryParse(textBox.Text, out _))
				? Color.White
				: Color.IndianRed;
		}

		/// <summary>
		/// Вызывает предупреждающий MessageBox
		/// </summary>
		/// <param name="text"></param>
		/// <param name="caption"></param>
		public static void ShowWarningMessageBox(string text, string caption)
		{
			MessageBox.Show(text, caption,
				MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
	}
}
