using System;
using System.Drawing;
using System.Windows.Forms;
using ImpedanceCalculator.Elements;

namespace ImpedanceCalculatorUI
{
	public partial class ElementForm : Form
	{
		/// <summary>
		/// Объект класса Element для добавлеия или редактирования элемента цепи
		/// </summary>
		private ElementBase _element;

		 /// <summary>
		 /// Определяющая для чего была создана форма
		 /// </summary>
		private bool _isAdd;

		/// <summary>
		/// Возвращает и устанавливает значение _element
		/// </summary>
		public ElementBase Element
		{
			get => _element;

			set
			{
				_element = value;
				if (_element != null)
				{
					EditNameTextBox.Text = _element.Name;
					EditValueTextBox.Text = _element.Value.ToString();

					switch (_element)
					{
						case Resistor resistor:
						{
							ElementTypeComboBox.SelectedItem = "R";
							break;
						}
						case Capacitor capacitor:
						{
							ElementTypeComboBox.SelectedItem = "C";
								break;
						}
						case Inductor inductor:
						{
							ElementTypeComboBox.SelectedItem = "L";
							break;
						}
					}
				}
			}
		}

		/// <summary>
		/// Возвращает и устанавливает булеву переменную, проверяющую тип соединения
		/// </summary>
		public bool IsSerial { get; set; }

		/// <summary>
		/// Возвращает и устанавливает булеву переменную, проверяющую для какого действия вызвана форма
		/// </summary>
		public bool IsAdd
		{
			get
			{
				return _isAdd;
			}
			set
			{
				_isAdd = value;
				AddGroupBox.Visible = _isAdd;
			}
		}

		public ElementForm()
		{
			InitializeComponent();

			ElementTypeComboBox.Items.Add("R");
			ElementTypeComboBox.Items.Add("L");
			ElementTypeComboBox.Items.Add("C");

			ElementTypeComboBox.SelectedIndex = 0;

			ConnectionComboBox.Items.Add("Serial");
			ConnectionComboBox.Items.Add("Parallel");
			ConnectionComboBox.SelectedIndex = 0;
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			double etalon = 0.0;
			if (!double.TryParse(EditValueTextBox.Text, out etalon) ||
				String.IsNullOrWhiteSpace(EditValueTextBox.Text))
			{
				InputValidation.ShowWarningMessageBox("Value must have numerical format",
					"Incorrect format");
			}
			else if (double.Parse(EditValueTextBox.Text) < 0)
			{
				InputValidation.ShowWarningMessageBox("Value must have positive value",
					"Negative value");
			}
			else
			{
				if (ConnectionComboBox.SelectedItem == "Serial")
				{
					IsSerial = true;
				}
				else if (ConnectionComboBox.SelectedItem == "Parallel")
				{
					IsSerial = false;
				}

				switch (ElementTypeComboBox.SelectedItem.ToString())
				{
					case "R":
					{
						_element = new Resistor(EditNameTextBox.Text, 
							double.Parse(EditValueTextBox.Text));

						break;
					}
					case "L":
					{
						_element = new Inductor(EditNameTextBox.Text, 
							double.Parse(EditValueTextBox.Text) / 1000);

						break;
					}
					case "C":
					{
						_element = new Capacitor(EditNameTextBox.Text, 
							double.Parse(EditValueTextBox.Text) / 1000);

						break;
					}
				}

				DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void CancelEditButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void EditValueTextBox_TextChanged(object sender, EventArgs e)
		{
			InputValidation.CheckTextBoxValue(EditValueTextBox);
		}

		private void ElementTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			switch (ElementTypeComboBox.SelectedItem.ToString())
			{
				case "R":
				{
					SILabel.Text = "Ohm";
					break;
				}
				case "L":
				{
					SILabel.Text = "mH";
					break;
				}
				case "C":
				{
					SILabel.Text = "mF";
					break;
				}
			}
		}
	}
}
