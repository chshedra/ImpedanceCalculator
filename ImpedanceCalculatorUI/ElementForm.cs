using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImpedanceCalculator;

namespace ImpedanceCalculatorUI
{
	public partial class ElementForm : Form
	{
		/// <summary>
		/// Объект класса Element для добавлеия или редактирования элемента цепи
		/// </summary>
		private Element _element;

		/// <summary>
		/// Возвращает и устанавливает значение _element
		/// </summary>
		public Element Element
		{
			get
			{
				return _element;
			}
			set
			{
				_element = value;
				if (_element != null)
				{
					_element.Name = EditNameTextBox.Text;
					_element.Value = double.Parse(EditValueTextBox.Text);
				}
			}
		}

		/// <summary>
		/// Возвращает и устанавливает булеву переменную, проверяющую тип соединения
		/// </summary>
		public bool IsSerial { get; set; }

		public ElementForm()
		{
			InitializeComponent();

			RRadioButton.Checked = true;
			AddSerialRadioButton.Checked = true;
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			if(String.IsNullOrWhiteSpace(EditNameTextBox.Text) ||
				String.IsNullOrWhiteSpace(EditValueTextBox.Text))
			{
				MessageBox.Show("Enter the name and value of element", "Warning",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);	
			}

			if(AddSerialRadioButton.Checked == true)
			{
				IsSerial = true;
			}
			else if (AddParallelRadioButton.Checked == true)
			{
				IsSerial = false;
			}

			if (RRadioButton.Checked == true)
			{
				_element = new Resistor(EditNameTextBox.Text, double.Parse(EditValueTextBox.Text));
			}
			else if (LRadioButton.Checked == true)
			{
				_element = new Inductor(EditNameTextBox.Text, double.Parse(EditValueTextBox.Text));
			}
			else if (CRadioButton.Checked == true)
			{
				_element = new Capacitor(EditNameTextBox.Text, double.Parse(EditValueTextBox.Text));
			}

			DialogResult = DialogResult.OK;
			this.Close();
		}

		private void CancelEditButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
