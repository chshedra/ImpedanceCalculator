using System;
using System.Drawing;
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

		 //TODO: RSDN
		private bool _isAdd;

		/// <summary>
		/// Возвращает и устанавливает значение _element
		/// </summary>
		public Element Element
		{
			get => _element;

			set
			{
				_element = value;
				if (_element != null)
				{
					EditNameTextBox.Text = _element.Name;
					EditValueTextBox.Text = _element.Value.ToString();

					//TODO: +В switch с определениями типов
					switch (_element)
					{
						case Resistor resistor:
						{
							RRadioButton.Checked = true;
							break;
						}
						case Capacitor capacitor:
						{
							CRadioButton.Checked = true;
							break;
						}
						case Inductor inductor:
						{
							LRadioButton.Checked = true;
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

			RRadioButton.Checked = true;
			AddSerialRadioButton.Checked = true;
		}

		private void OkButton_Click(object sender, EventArgs e)
		{
			double etalon = 0.0;
			//TODO: Duplication
			if (!double.TryParse(EditValueTextBox.Text, out etalon) ||
				String.IsNullOrWhiteSpace(EditValueTextBox.Text))
			{
				MessageBox.Show("Value must have numerical format", "Incorrect format",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else if (double.Parse(EditValueTextBox.Text) < 0)
			{
				MessageBox.Show("Value must have positive value", "Negative value",
				MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				//TODO: +Опустить true
				if (AddSerialRadioButton.Checked)
				{
					IsSerial = true;
				}
				else if (AddParallelRadioButton.Checked)
				{
					IsSerial = false;
				}

				if (RRadioButton.Checked)
				{
					_element = new Resistor(EditNameTextBox.Text, double.Parse(EditValueTextBox.Text));
				}
				else if (LRadioButton.Checked)
				{
					_element = new Inductor(EditNameTextBox.Text, double.Parse(EditValueTextBox.Text));
				}
				else if (CRadioButton.Checked)
				{
					_element = new Capacitor(EditNameTextBox.Text, double.Parse(EditValueTextBox.Text));
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
			//TODO: Дубль
			double etalon = 0.0;
			EditValueTextBox.BackColor = (double.TryParse(EditValueTextBox.Text, out etalon))
			 ? Color.White
			 : Color.IndianRed;
		}
	}
}
