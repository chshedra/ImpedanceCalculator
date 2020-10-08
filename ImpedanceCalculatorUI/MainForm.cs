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
		SegmentTreeNode _replacingTreeNode = new SegmentTreeNode();

		public MainForm()
		{
			InitializeComponent();
			_project = new Project();
			_project.Circuits = _project.CreateCircuits();

			CircuitsComboBox.DataSource = _project.Circuits;
			CircuitsComboBox.DisplayMember = "Name";

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

		private void CircuitTreeViewDataBind(SegmentTreeNode treeNode, List<ISegment> segments)
		{
			foreach (var segment in segments)
			{
				if (segment is Element)
				{
					SegmentTreeNode element = new SegmentTreeNode(segment);
					treeNode.Nodes.Add(element);
				}
				else if(segment is Circuit)
				{
					var node = new SegmentTreeNode(segment);
					treeNode.Nodes.Add(node);
					CircuitTreeViewDataBind(node, segment.SubSegments);
				}
			}
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
						result = _project.Circuits[CircuitsComboBox.SelectedIndex].
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

		private void CircuitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			CircuitTreeView.Nodes.Clear();
			var baseNode = new SegmentTreeNode(_project.Circuits[CircuitsComboBox.SelectedIndex]);
			CircuitTreeViewDataBind(baseNode, _project.Circuits[CircuitsComboBox.SelectedIndex].SubSegments);

			CircuitTreeView.Nodes.Add(baseNode);
		}


		private void AddToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ElementForm addForm = new ElementForm();
			addForm.ShowDialog();

			if (addForm.DialogResult == DialogResult.OK)
			{
				SegmentTreeNode node = new SegmentTreeNode(addForm.Element);

				SegmentTreeNode selectedNode = (SegmentTreeNode)CircuitTreeView.SelectedNode;
				SegmentTreeNode selectedNodeParent =
					(SegmentTreeNode)CircuitTreeView.SelectedNode.Parent;

				if (selectedNode.Segment is Circuit)
				{
					if (selectedNode.Segment is SerialCircuit)
					{
						if (addForm.IsSerial == true)
						{
							selectedNode.Segment.SubSegments.Add(addForm.Element);
							selectedNode.Nodes.Add(node);
						}
						else
						{
							AddParallel(addForm.Element, selectedNode, selectedNodeParent);
						}
					}
					else if (selectedNode.Segment is ParallelCircuit)
					{
						if (addForm.IsSerial == false)
						{
							selectedNode.Segment.SubSegments.Add(addForm.Element);
							selectedNode.Nodes.Add(node);
						}
						else
						{
							selectedNodeParent.Segment.SubSegments.Add(addForm.Element);
							selectedNodeParent.Nodes.Add(node);
						}
					}
				}
				else if (selectedNode.Segment is Element)
				{
					if (selectedNodeParent.Segment is SerialCircuit)
					{
						if (addForm.IsSerial == true)
						{
							selectedNodeParent.Segment.SubSegments.Add(addForm.Element);
							selectedNodeParent.Nodes.Add(node);
						}
						else
						{
							AddParallel(addForm.Element, selectedNode, selectedNodeParent);
						}
					}
					else if (selectedNodeParent.Segment is ParallelCircuit)
					{
						if (addForm.IsSerial == false)
						{
							selectedNodeParent.Segment.SubSegments.Add(addForm.Element);
						}
						else
						{
							AddSerial(addForm.Element, selectedNode, selectedNodeParent);
						}
					}
				}
			}
		}

		private void EditToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SegmentTreeNode selectedNode = (SegmentTreeNode)CircuitTreeView.SelectedNode;
			Element editElement = (Element)selectedNode.Segment;

			ElementForm editForm = new ElementForm();
			editForm.Element = editElement;
			editForm.ShowDialog();

			if (editForm.DialogResult == DialogResult.OK)
			{
				editElement.Name = editForm.Element.Name;
				editElement.Value = editForm.Element.Value;

			}
		}

		/// <summary>
		/// Метод добавления нового элемента к последовательной цепи параллельно
		/// </summary>
		/// <param name="element"></param>
		/// <param name="selectedSegment"></param>
		/// <param name="nodeParent"></param>
		private void AddParallel(Element element, SegmentTreeNode selectedSegment, SegmentTreeNode nodeParent)
		{
			ParallelCircuit parallelSegment = new ParallelCircuit();
			parallelSegment.Name = "ParallelSegment";
			parallelSegment.SubSegments.Add(element);
			parallelSegment.SubSegments.Add(selectedSegment.Segment);
			SegmentTreeNode newNode = new SegmentTreeNode(parallelSegment);

			nodeParent.Segment.SubSegments.Remove(selectedSegment.Segment);
			nodeParent.Segment.SubSegments.Add(parallelSegment);

			CircuitTreeViewDataBind(newNode, parallelSegment.SubSegments);
			nodeParent.Nodes.Remove(selectedSegment);
			nodeParent.Nodes.Add(newNode);
		}

		/// <summary>
		/// Метод добавления нового элемента в параллельную цеь последовательно
		/// </summary>
		/// <param name="element"></param>
		/// <param name="selectedSegment"></param>
		/// <param name="nodeParent"></param>
		private void AddSerial(Element element, SegmentTreeNode selectedSegment, SegmentTreeNode nodeParent)
		{
			SerialCircuit serialSegment = new SerialCircuit();
			serialSegment.Name = "SerialSegment";
			serialSegment.SubSegments.Add(element);
			serialSegment.SubSegments.Add(selectedSegment.Segment);
			SegmentTreeNode newNode = new SegmentTreeNode(serialSegment);

			nodeParent.Segment.SubSegments.Remove(selectedSegment.Segment);
			nodeParent.Segment.SubSegments.Add(serialSegment);

			CircuitTreeViewDataBind(newNode, serialSegment.SubSegments);
			nodeParent.Nodes.Remove(selectedSegment);
			nodeParent.Nodes.Add(newNode);
		}

		private void CircuitTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			SegmentTreeNode selectedNode = (SegmentTreeNode)CircuitTreeView.SelectedNode;



			if (selectedNode.Segment is Element)
			{
				Element selectedElement = (Element)selectedNode.Segment;
				ElementInfoTextbox.Text = "Name = " + selectedElement.Name + Environment.NewLine +
					"Value = " + selectedElement.Value;
			}

		}

		private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			
		}

		private void AddCircuitButton_Click(object sender, EventArgs e)
		{
			
		}

		private void CircuitTreeView_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				SegmentTreeNode selectedNode = (SegmentTreeNode)CircuitTreeView.GetNodeAt(e.X, e.Y);
				CircuitTreeView.SelectedNode = selectedNode;

				if (selectedNode == null)
				{
					return;
				}

				if (selectedNode.Segment is Circuit)
				{
					EditToolStripMenuItem.Visible = false;
				}
				else if (selectedNode.Segment is Element)
				{
					EditToolStripMenuItem.Visible = true;
				}
				NodeContextMenu.Show(PointToScreen(e.Location));
			}
			else if(e.Button == MouseButtons.Left)
			{
				_replacingTreeNode  = (SegmentTreeNode)CircuitTreeView.GetNodeAt(e.X, e.Y);
				
			}
		}

		private void CircuitTreeView_MouseUp(object sender, MouseEventArgs e)
		{
			if (_replacingTreeNode != null)
			{
				SegmentTreeNode selectedNode = (SegmentTreeNode)CircuitTreeView.GetNodeAt(e.X, e.Y);

				if (selectedNode.Segment is Circuit && selectedNode != _replacingTreeNode)
				{
					SegmentTreeNode replacingNodeParent = (SegmentTreeNode)_replacingTreeNode.Parent;
					var replacingNode = _replacingTreeNode;

					replacingNodeParent.Nodes.Remove(_replacingTreeNode);
					replacingNodeParent.Segment.SubSegments.Remove(_replacingTreeNode.Segment);

					selectedNode.Segment.SubSegments.Add(replacingNode.Segment);
					selectedNode.Nodes.Add(replacingNode);
				}
				else
				{
					_replacingTreeNode = null;
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

		private void RemoveNode(SegmentTreeNode removingNode)
		{
			SegmentTreeNode selectedNode = (SegmentTreeNode)CircuitTreeView.SelectedNode;
			SegmentTreeNode selectedNodeParent =
				(SegmentTreeNode)CircuitTreeView.SelectedNode.Parent;

			selectedNodeParent.Segment.SubSegments.Remove(selectedNode.Segment);
			CircuitTreeView.Nodes.Remove(selectedNode);

			SegmentTreeNode selectedNodeGrandParent =
				(SegmentTreeNode)selectedNodeParent.Parent;

			if (selectedNodeParent.Segment.SubSegments.Count < 2)
			{
				var lastElement = selectedNodeParent.Segment.SubSegments[0];
				var lastNode = selectedNodeParent.Nodes[0];

				selectedNodeGrandParent.Segment.SubSegments.Remove(lastElement);
				selectedNodeGrandParent.Nodes.Remove(lastNode);

				selectedNodeGrandParent.Segment.SubSegments.Add(lastElement);
				selectedNodeGrandParent.Nodes.Add(lastNode);

				_project.Circuits[CircuitsComboBox.SelectedIndex].SubSegments.Remove(selectedNodeParent.Segment);
				CircuitTreeView.Nodes.Remove(selectedNodeParent);
			}
		}

	}
}
