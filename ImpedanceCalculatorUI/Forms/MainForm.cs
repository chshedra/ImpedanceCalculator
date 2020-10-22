using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ImpedanceCalculator.Circuits;
using ImpedanceCalculator.Elements;
using ImpedanceCalculator;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using ImpedanceCalculatorUI.CircuitDrawer;

namespace ImpedanceCalculatorUI
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// Хранит дерево цепей, список частот и список импедансов
		/// </summary>
		private readonly Project _project;

		public MainForm()
		{
			InitializeComponent();
			_project = new Project();


			FrequenciesListBox.DataSource = _project.Frequencies;

			CircuitTreeView.SegmentSelected += ChangeSegmentMessageTextBoxText;
			CircuitTreeView.CircuitChanged += DrawCircuit;

			_project.Circuits.Add(_project.CreateCircuit());

			CircuitsComboBox.DataSource = _project.Circuits;
			CircuitsComboBox.DisplayMember = "Name";

		}

		private void ListBoxes_SelectedIndexChanged(object sender, EventArgs e)
		{
			if ((ListBox) sender == ImpedanceListBox)
			{
				FrequenciesListBox.SelectedIndex = ImpedanceListBox.SelectedIndex;
			}
			else if ((ListBox) sender == FrequenciesListBox)
			{
				ImpedanceListBox.SelectedIndex = FrequenciesListBox.SelectedIndex;
			}
		}

		private void CalculateButton_Click(object sender, EventArgs e)
		{
            //TODO: +Можно удалить объявление etalon и записать в параметрах парса "out _"
            if (!double.TryParse(FrequencyTextBox.Text, out _))
			{
				InputValidation.ShowWarningMessageBox("Frequency must have numerical format",
					"Incorrect format");
			}
			else if (double.Parse(FrequencyTextBox.Text) < 0)
			{
				InputValidation.ShowWarningMessageBox("Frequency must have positive value",
					"Negative value");
			}
			else if (CircuitsComboBox.SelectedIndex < 0)
			{
				InputValidation.ShowWarningMessageBox("Select the circuit",
					"Any circuit selected");
			}
			else
			{
				if (!String.IsNullOrEmpty(FrequencyTextBox.Text))
				{
					_project.Frequencies.Add(double.Parse(FrequencyTextBox.Text));
				}

				if (_project.Frequencies.Count > 0)
				{
					_project.Impendances.Clear();
					foreach (var frequency in _project.Frequencies)
					{
						var result = _project.Circuits[CircuitsComboBox.SelectedIndex].CalculateZ(frequency);
						_project.Impendances.Add(result);
					}

					var index = CircuitsComboBox.SelectedIndex;
					RefreshLists();
					CircuitsComboBox.SelectedIndex = index;
				}
			}
		}

		private void FrequencyTextBox_TextChanged(object sender, EventArgs e)
		{
			InputValidation.CheckTextBoxValue(FrequencyTextBox);
		}

		private void CircuitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			CircuitTreeView.Nodes.Clear();

			if (CircuitsComboBox.SelectedIndex > -1)
			{
				var selectedCircuit = _project.Circuits[CircuitsComboBox.SelectedIndex];
				var selectedCircuitNode = new SegmentTreeNode(selectedCircuit);
				if (CircuitTreeView.Nodes.Count == 0)
				{
					CircuitTreeView.Nodes.Add(selectedCircuitNode);
				}

				CircuitTreeView.CircuitTreeViewDataBind(selectedCircuitNode,  selectedCircuit.SubSegments);
			}
		}

		private void AddCircuitButton_Click(object sender, EventArgs e)
		{
			var circuitForm = new CircuitForm();

			circuitForm.ShowDialog();
			if (circuitForm.DialogResult == DialogResult.OK)
			{
				var circuit = circuitForm.CircuitBase;
				_project.Circuits.Add(circuit);
				RefreshLists();
				SegmentTreeNode circuitNode = new SegmentTreeNode(circuit);
				CircuitTreeView.Nodes.Add(circuitNode);
				CircuitsComboBox.SelectedIndex = _project.Circuits.IndexOf(circuit);
				CircuitTreeView.AddFirstElement();
			}
		}

		private void RemoveCircuitButton_Click(object sender, EventArgs e)
		{
			var selectedCircuit = _project.Circuits[CircuitsComboBox.SelectedIndex];
			//TODO:+ Duplication
			if (MessageBox.Show($"Do you really want remove circuit {selectedCircuit.Name}?", 
				"Circuit removing", MessageBoxButtons.OKCancel, 
				MessageBoxIcon.Question) == DialogResult.OK)
			{
				_project.Circuits.RemoveAt(CircuitsComboBox.SelectedIndex);
				RefreshLists();
				if (_project.Circuits.Count > 0)
				{
					CircuitsComboBox.SelectedIndex = 0;
				}
			}
		}

		private void FrequenciesListBox_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button != MouseButtons.Right)
			{
				return;
			}

			var index = FrequenciesListBox.IndexFromPoint(e.Location);
			if (index != ListBox.NoMatches)
			{
				FrequenciesListBox.SelectedIndex = index;
				FrequencyContextMenuStrip.Show(Cursor.Position);
				FrequencyContextMenuStrip.Visible = true;
			}
			else
			{
				FrequencyContextMenuStrip.Visible = false;
			}
		}

		private void RemoveFrequencyToolStripMenuItem_Click(object sender, EventArgs e)
		{
			_project.Frequencies.RemoveAt(FrequenciesListBox.SelectedIndex);
			_project.Impendances.RemoveAt(FrequenciesListBox.SelectedIndex);
			RefreshLists();
		}

		/// <summary>
		///  Обновляет списки
		/// </summary>
		private void RefreshLists()
		{
			FrequenciesListBox.DataSource = null;
			FrequenciesListBox.DataSource = _project.Frequencies;

			CircuitsComboBox.DataSource = null;
			CircuitsComboBox.DataSource = _project.Circuits;
			CircuitsComboBox.DisplayMember = "Name";

			ImpedanceListBox.Items.Clear();
			foreach (var impedance in _project.Impendances)
			{
				ImpedanceListBox.Items.Add($"{impedance.Real} + {impedance.Imaginary} i");
			}
		}

		/// <summary>
		/// Изменяет текст в SegmentInfoTextBox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ChangeSegmentMessageTextBoxText(object sender, EventArgs e)
		{
			var selectedSegment = (ISegment) sender;
			string type = null;

			switch (selectedSegment)
			{
				case ElementBase element:
				{
					var selectedElement = (ElementBase) selectedSegment;
					string value = null;

					switch (selectedSegment)
					{
						case Resistor resistor:
						{
							type = "Resistor";
							value = selectedElement.Value + " Ohm";
							break;
						}
						case Inductor inductor:
						{
							type = "Inductor";
							value = selectedElement.Value + 1000 + " mH";
							break;
						}
						case Capacitor capacitor:
						{
							type = "Capacitor";
							value = selectedElement.Value * 1000 + " mF";
							break;
						}
					}

					SegmentInfoTextbox.Text = "Name: " + selectedSegment.Name + Environment.NewLine +
					                          "Value: " + value + Environment.NewLine +
					                          "Type: " + type;
					break;
				}
				case CircuitBase circuit:
				{
					selectedSegment = (CircuitBase) selectedSegment;

					switch (selectedSegment)
					{
						case SerialCircuit serial:
						{
							type = "Serial";
							break;
						}
						case ParallelCircuit parallel:
						{
							type = "Parallel";
							break;
						}
					}

					SegmentInfoTextbox.Text = "Name: " + selectedSegment.Name + Environment.NewLine +
					                          "Type: " + type;
					break;
				}
			}
		}

		/// <summary>
		/// Добавляет цепь на pictureBox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void DrawCircuit(object sender, EventArgs e)
		{
			Image circitImage = _project.Circuits[CircuitsComboBox.SelectedIndex].GetImage();
			CircuitPictureBox.Image = circitImage;
		}
	}

}
