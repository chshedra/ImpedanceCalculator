using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImpedanceCalculator.Circuits;
using ImpedanceCalculator;

namespace ImpedanceCalculatorUI
{
	public partial class CircuitForm : Form
	{
		/// <summary>
		/// Хранит информацию о цепи
		/// </summary>
		private CircuitBase _circuit;

		/// <summary>
		/// Устанавливает и возвращает информацию о цепи 
		/// </summary>
		public CircuitBase CircuitBase
		{
			get => _circuit;
			set
			{
				_circuit = value;
				CircuitNameTextBox.Text = _circuit.Name;
			}
		}

		public CircuitForm()
		{
			InitializeComponent();
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
				
				var newCircuit = new SerialCircuit(new List<ISegment>(), CircuitNameTextBox.Text);
				
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
