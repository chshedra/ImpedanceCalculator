using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ImpedanceCalculator;
using System.Numerics;

namespace ImpedanceCalculatorUI
{
	public partial class MainForm : Form
	{
		/// <summary>
		/// Хранит дерево цепей, список частот и список импедансов
		/// </summary>
		private readonly Project _project;

		/// <summary>
		/// Хранит функции класса InputValidation
		/// </summary>
		private readonly InputValidation _inputValidation = new InputValidation();

		public MainForm()
		{
			InitializeComponent();
			_project = new Project();

			CircuitsComboBox.DataSource = _project.Circuits;
			CircuitsComboBox.DisplayMember = "Name";

			FrequenciesListBox.DataSource = _project.Frequencies;

			CircuitTreeView.CircuitRemoved += RemoveCircuit;
		}

		//TODO: +Можно привести к одному обработчику, выполнив типизацию sender-a


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
			double etalon = 0.0;
			//TODO:+ Duplication
			if (!double.TryParse(FrequencyTextBox.Text, out etalon))
			{
				_inputValidation.ShowWarningMessageBox("Frequency must have numerical format",
					"Incorrect format");
			}
			else if (double.Parse(FrequencyTextBox.Text) < 0)
			{
				_inputValidation.ShowWarningMessageBox("Frequency must have positive value",
					"Negative value");
			}
			else if (CircuitsComboBox.SelectedIndex < 0)
			{
				_inputValidation.ShowWarningMessageBox("Select the circuit",
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
					var result = new Complex();
					_project.Impendances.Clear();
					foreach (var frequency in _project.Frequencies)
					{
						result = _project.Circuits[CircuitsComboBox.SelectedIndex].CalculateZ(frequency);
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
			//TODO: +Дубль
			_inputValidation.CheckTextBoxValue(FrequencyTextBox);
		}

		private void CircuitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			CircuitTreeView.Nodes.Clear();

			if (CircuitsComboBox.SelectedIndex > -1)
			{
				var selectedCircuit = (Circuit) CircuitsComboBox.SelectedItem;
				CircuitTreeView.CircuitTreeViewDataBind(new SegmentTreeNode(),  selectedCircuit.SubSegments);
			}
		}

		private void AddCircuitButton_Click(object sender, EventArgs e)
		{
			var circuitForm = new CircuitForm()
			{
				IsAdd = true
			};

			circuitForm.ShowDialog();
			if (circuitForm.DialogResult == DialogResult.OK)
			{
				var circuit = circuitForm.Circuit;
				_project.Circuits.Add(circuit);
				RefreshLists();
				CircuitsComboBox.SelectedIndex = _project.Circuits.IndexOf(circuit);
				SegmentTreeNode circuitNode = new SegmentTreeNode(circuit);
				CircuitTreeView.Nodes.Add(circuitNode);
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

		private void RemoveCircuit(object sender, EventArgs e)
		{
			var selectedCircuit = (SegmentTreeNode) sender;
			if (MessageBox.Show($"Do you really want remove circuit{selectedCircuit.Name}?", "Circuit removing",
				MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				_project.Circuits.RemoveAt(CircuitsComboBox.SelectedIndex);
				RefreshLists();
				if (_project.Circuits.Count > 0)
				{
					CircuitsComboBox.SelectedIndex = 0;
				}
			}
			else
			{
				return;
			}
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

	}

}
