using System.Windows.Forms;
using System.Drawing;

namespace ImpedanceCalculatorUI
{
	public class InputValidation
	{
		/// <summary>
		/// Проверяет корректность введенных значений
		/// </summary>
		/// <param name="textBox"></param>
		public void CheckTextBoxValue(TextBox textBox)
		{
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
