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
	public partial class CircuitForm : Form
	{
		/// <summary>
		/// Хранит информацию о цепи
		/// </summary>
		private Circuit _circuit;

		/// <summary>
		/// Определяет, для чего была создана форма
		/// </summary>
		private bool _isAdd;

		/// <summary>
		/// Устанавливает и возвращает информацию о цепи 
		/// </summary>
		public Circuit Circuit
		{
			get
			{
				return _circuit;
			}
			set
			{
				_circuit = value;
				CircuitNameTextBox.Text = _circuit.Name;
			}
		}

		/// <summary>
		/// Устанавливает и возвращает переменную, проверяющую для чего вызвана форма
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
				ConnectionTupeGroupBox.Visible = _isAdd;
			}
		}

		public CircuitForm()
		{
			InitializeComponent();

			SerialConnectionRadioButton.Checked = true;
		}


		private void OkButton_Click(object sender, EventArgs e)
		{
			if(String.IsNullOrWhiteSpace(CircuitNameTextBox.Text))
			{
				MessageBox.Show("Enter the name", "Empty name", 
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				Circuit newCircuit = null;
				if(SerialConnectionRadioButton.Checked)
				{
					 newCircuit = new SerialCircuit(new List<ISegment>(), CircuitNameTextBox.Text);
				}
				//TODO: А тут уже не надо?
				else if(ParallelConnectionRadioButton.Checked == true)
				{
					newCircuit = new ParallelCircuit(new List<ISegment>(), CircuitNameTextBox.Text);
				}

				_circuit = newCircuit;
				DialogResult = DialogResult.OK;
			}

			this.Close();
		}

		private void CancelButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
