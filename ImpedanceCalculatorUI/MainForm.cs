using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ImpedanceCalculator;
using System.Numerics;

namespace ImpedanceCalculatorUI
{
	public partial class MainForm : Form
	{
		Project _project;

		public MainForm()
		{
			InitializeComponent();
			_project = new Project();
			_project.Circuits = _project.CreateCircuits();

			CircuitsListBox.DataSource = _project.Circuits;
			CircuitsListBox.DisplayMember = "Name";

			FrequenciesListBox.DataSource = _project.Frequencies;
		}
		
		private void FrequenceListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			ImpedanceListBox.SelectedIndex = FrequenciesListBox.SelectedIndex;
		}

		private void ImpedanceListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			FrequenciesListBox.SelectedIndex = ImpedanceListBox.SelectedIndex;
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

		private void CircuitTreeViewDataBind(TreeNode treeNode, List<ISegment> segments)
		{
			foreach (var segment in segments)
			{
				if (segment is Element)
				{
					treeNode.Nodes.Add(segment.Name);
				}
				else if(segment is Circuit)
				{
					var node = new TreeNode(segment.Name);
					treeNode.Nodes.Add(node);
					CircuitTreeViewDataBind(node, segment.SubSegments);
				}
			}
		}


		private void AddButton_Click(object sender, EventArgs e)
		{
			ElementForm addForm = new ElementForm();
			addForm.ShowDialog();
			
			if(addForm.DialogResult == DialogResult.OK)
			{
				var circuitIndex = CircuitsListBox.SelectedIndex;
				ISegment baseSegment;
				var segment = FindSegment(CircuitTreeView.SelectedNode.Text,
					_project.Circuits[circuitIndex], out baseSegment);

				if (addForm.IsSerial == true)
				{
					if (baseSegment is SerialCircuit)
					{
						baseSegment.SubSegments.Insert(baseSegment.SubSegments.IndexOf(segment) + 1,
							addForm.Element);
					}
					else if(baseSegment is ParallelCircuit)
					{
						
					}
				
				}
			
			}
		}

		private void MainFormSplitContainer_Panel2_Paint(object sender, PaintEventArgs e)
		{

		}

		private void CircuitTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{

		}

		private void CircuitsListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			CircuitTreeView.Nodes.Clear();
			var baseNode = new TreeNode(_project.Circuits[CircuitsListBox.SelectedIndex].Name);
			CircuitTreeViewDataBind(baseNode, _project.Circuits[CircuitsListBox.SelectedIndex].SubSegments);

			CircuitTreeView.Nodes.Add(baseNode);
		}

		private ISegment FindSegment(string name, ISegment segments, out ISegment baseSegment)
		{
			foreach(var segment in segments.SubSegments)
			{
				if(segment is Element)
				{
					if(segment.Name == name)
					{
						baseSegment = segments;
						return segment;
					}
				}
				else if(segment is Circuit)
				{
					if(segment.Name == name)
					{
						baseSegment = segments;
						return segment;
					}
					else
					{
						return FindSegment(name, segment, out baseSegment);
					}
				}
			}
			baseSegment = null;
			return null;
		}

		private void CalculateButton_Click(object sender, EventArgs e)
		{
			double etalon = 0.0;

			if (!double.TryParse(FrequencyTextBox.Text, out etalon))
			{
				MessageBox.Show("Frequency must have numerical format", "Incorrect format",
					MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else if (double.Parse(FrequencyTextBox.Text) < 0)
			{
				MessageBox.Show("Frequency must have positive value", "Negative value",
				MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
			else
			{
				if (!String.IsNullOrEmpty(FrequencyTextBox.Text))
				{
					_project.Frequencies.Add(double.Parse(FrequencyTextBox.Text));
				} 
				if(_project.Frequencies.Count > 0)
				{
					var result = new Complex();
					_project.Impendances.Clear();
					foreach(var frequency in _project.Frequencies)
					{
						result = _project.Circuits[CircuitsListBox.SelectedIndex].
							CalculateZ(frequency);
						_project.Impendances.Add(result);
					}
					RefreshLists();
				}
			}
		}

		private void FrequencyTextBox_TextChanged(object sender, EventArgs e)
		{
			double etalon = 0.0;
			FrequencyTextBox.BackColor = (double.TryParse(FrequencyTextBox.Text, out etalon))
			 ? Color.White
			 : Color.IndianRed;
		}

		/// <summary>
		/// Метод обновления списков
		/// </summary>
		private void RefreshLists()
		{
			FrequenciesListBox.DataSource = null;
			FrequenciesListBox.DataSource = _project.Frequencies;

			ImpedanceListBox.Items.Clear();
			foreach(var impedance in _project.Impendances)
			{
				ImpedanceListBox.Items.Add($"{impedance.Real} + {impedance.Imaginary} i");
			}
		}



	}
}
