using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ImpedanceCalculator;

namespace ImpedanceCalculatorUI
{
	public partial class MainForm : Form
	{
		CircuitFabric _circuitFabric;

		public MainForm()
		{
			InitializeComponent();
			_circuitFabric = new CircuitFabric();
			_circuitFabric.Circuits = _circuitFabric.CreateCircuits();
			CircuitsListBox.DataSource = _circuitFabric.Circuits;
			CircuitsListBox.DisplayMember = "Name";

			FrequenceListBox.DataSource = _circuitFabric.Frequencies;

			CircuitsListBox.SelectedIndex = 0;
		}

		private void CalculateButton_Click(object sender, EventArgs e)
		{
			MessageTextBox.Clear();

			CircuitTreeTraversal(_circuitFabric.Circuits);

			var impedance = _circuitFabric.Circuits[CircuitsListBox.SelectedIndex].CalculateZ
				(double.Parse(FrequencyTextBox.Text));

			_circuitFabric.Frequencies.Add(double.Parse(FrequencyTextBox.Text));

			_circuitFabric.Impendances.Add(impedance);
			ImpedanceListBox.Items.Add(impedance);

			FrequenceListBox.DataSource = null;
			FrequenceListBox.DataSource = _circuitFabric.Frequencies;
		}
		
		private void FrequenceListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ImpedanceListBox.SelectedIndex = FrequenceListBox.SelectedIndex;
		}

		private void ImpedanceListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			FrequenceListBox.SelectedIndex = ImpedanceListBox.SelectedIndex;
		}

		private void CircuitsListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			foreach (Circuit circuit in _circuitFabric.Circuits)
			{
				circuit.CircuitChanged -= ElementChangeMessage;
			}

			((Circuit)(_circuitFabric.Circuits[CircuitsListBox.SelectedIndex])).CircuitChanged +=
				ElementChangeMessage;
		}


		/// <summary>
		/// Метод обхода дерева цепей и установки значений
		/// </summary>
		/// <param name="segments"></param>
		private void CircuitTreeTraversal(List<ISegment> segments)
		{
			foreach (var segment in segments)
			{
				if (segment is IElement)
				{
					if (segment is Resistor)
					{
						((Resistor)segment).Value = double.Parse(R1TextBox.Text);
					}
					if (segment is Capacitor)
					{
						((Capacitor)segment).Value = double.Parse(C1TextBox.Text);
					}
					if (segment is Inductor)
					{
						((Inductor)segment).Value = double.Parse(L1TextBox.Text);
					}
				}
				else if (segment is Circuit)
				{
					CircuitTreeTraversal(segment.SubSegments);
				}
			}
		}

		/// <summary>
		/// Метод проверки ввода значений 
		/// </summary>
		/// <param name="textBox"></param>
		private void TextBoxCheck(TextBox textBox)
		{
			double num = 0.0;

			textBox.BackColor = (textBox.Text == null || !double.TryParse(textBox.Text, out num))
				? Color.IndianRed
				: Color.White;
		}

		/// <summary>
		/// Обработчик события измененения цепи
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ElementChangeMessage(object sender, EventArgs e)
		{
			if(sender is IElement)
			{
				MessageTextBox.Text += ((IElement)sender).Name + " new value is " + 
					((IElement)sender).Value + Environment.NewLine;
			}
			else if (sender is Circuit)
			{
				MessageTextBox.Text += ($"Segment {((Circuit)sender).Name} has been changed");
			}
		}
	}
}
