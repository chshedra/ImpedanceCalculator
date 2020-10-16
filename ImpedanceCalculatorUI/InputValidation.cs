using System.Windows.Forms;
using System.Drawing;

namespace ImpedanceCalculatorUI
{
	//TODO: Почему не статический?
	public class InputValidation
	{
		/// <summary>
		/// Проверяет корректность введенных значений
		/// </summary>
		/// <param name="textBox"></param>
		public void CheckTextBoxValue(TextBox textBox)
		{
			//TODO: Можно удалить объявление etalon и записать в параметрах парса "out _"
			double etalon = 0.0;
			textBox.BackColor = (double.TryParse(textBox.Text, out etalon))
				? Color.White
				: Color.IndianRed;
		}

		/// <summary>
		/// Вызывает предупреждающий MessageBox
		/// </summary>
		/// <param name="text"></param>
		/// <param name="caption"></param>
		public void ShowWarningMessageBox(string text, string caption)
		{
			MessageBox.Show(text, caption,
				MessageBoxButtons.OK, MessageBoxIcon.Warning);
		}
	}
}
