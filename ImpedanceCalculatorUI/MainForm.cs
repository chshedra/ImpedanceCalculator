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
		 //TODO: RSDN
		private readonly Project _project;
		 //TODO: RSDN
		private SegmentTreeNode _replacingTreeNode;

		public MainForm()
		{
			InitializeComponent();
			_project = new Project();

			CircuitsComboBox.DataSource = _project.Circuits;
			CircuitsComboBox.DisplayMember = "Name";

			FrequenciesListBox.DataSource = _project.Frequencies;
		}

		//TODO: Можно привести к одному обработчику, выполнив типизацию sender-a
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
			//TODO: Duplication
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
			else if (CircuitsComboBox.SelectedIndex < 0)
			{
				MessageBox.Show("Select the circuit", "Any circuit selected",
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

					var index = CircuitsComboBox.SelectedIndex;
					RefreshLists();
					CircuitsComboBox.SelectedIndex = index;
				}
			}
		}

		private void FrequencyTextBox_TextChanged(object sender, EventArgs e)
		{
            //TODO: Дубль
			double etalon = 0.0;
			FrequencyTextBox.BackColor = (double.TryParse(FrequencyTextBox.Text, out etalon))
			 ? Color.White
			 : Color.IndianRed;
		}

		private void CircuitsComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			CircuitTreeView.Nodes.Clear();

			if (CircuitsComboBox.SelectedIndex > -1)
			{
				RefreshCircuitTree();
			}
		}

		private void AddToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var addForm = new ElementForm()
			{
				IsAdd = true
			};
			addForm.ShowDialog();

			if (addForm.DialogResult == DialogResult.OK)
			{
				var node = new SegmentTreeNode(addForm.Element);

				var selectedNode = (SegmentTreeNode)CircuitTreeView.SelectedNode;
				var selectedNodeParent =
					(SegmentTreeNode)CircuitTreeView.SelectedNode.Parent;

				if (selectedNode.Segment is Circuit)
				{
					if (selectedNode.Segment is SerialCircuit)
					{
						//TODO: Duplication
						//TODO: Опустить true
						if (addForm.IsSerial == true)
						{
							selectedNode.Segment.SubSegments.Add(addForm.Element);
							selectedNode.Nodes.Add(node);
						}
						else if (selectedNode.Segment == _project.Circuits[CircuitsComboBox.SelectedIndex])
						{
							var parallelCircuit = new ParallelCircuit()
							{
								Name = selectedNode.Segment.Name,
								SubSegments = selectedNode.Segment.SubSegments
							};
							parallelCircuit.Add(addForm.Element);

							var index = _project.Circuits.IndexOf(selectedNode.Segment);
							_project.Circuits.Remove(selectedNode.Segment);
							_project.Circuits.Insert(index, parallelCircuit);
							RefreshCircuitTree();
						}
						else
						{
							AddParallel(addForm.Element, selectedNode, selectedNodeParent);
						}
					}
					else if (selectedNode.Segment is ParallelCircuit)
					{
						//TODO: Duplication
						if (addForm.IsSerial == false)
						{
							selectedNode.Segment.SubSegments.Add(addForm.Element);
							selectedNode.Nodes.Add(node);
						}
						else if (selectedNode.Segment == _project.Circuits[CircuitsComboBox.SelectedIndex])
						{
							var serialCircuit = new SerialCircuit()
							{
								Name = selectedNode.Segment.Name,
								SubSegments = selectedNode.Segment.SubSegments
							};
							serialCircuit.Add(addForm.Element);

							var index = _project.Circuits.IndexOf(selectedNode.Segment);
							_project.Circuits.Remove(selectedNode.Segment);
							_project.Circuits.Insert(index, serialCircuit);
							RefreshCircuitTree();
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
					//TODO: В switch c определением типов
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
			var selectedNode = (SegmentTreeNode)CircuitTreeView.SelectedNode;
            //TODO: В switch c определением типов
			if (selectedNode.Segment is Element)
			{
				var editElement = (Element) selectedNode.Segment;
				var editForm = new ElementForm()
				{
					Element = editElement,
					IsAdd = false
				};
				editForm.ShowDialog();

				if (editForm.DialogResult == DialogResult.OK)
				{
					editElement.Name = editForm.Element.Name;
					editElement.Value = editForm.Element.Value;
					RefreshCircuitTree();
				}
			}
			else if (selectedNode.Segment is Circuit)
			{
				var editCircuit = (Circuit) selectedNode.Segment;
				var circuitForm = new CircuitForm()
				{
					Circuit = editCircuit,
					IsAdd = false
				};
				circuitForm.ShowDialog();

				if (circuitForm.DialogResult == DialogResult.OK)
				{
					editCircuit.Name = circuitForm.Circuit.Name;
					RefreshCircuitTree();
				}
			}

		}

		private void CircuitTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			var selectedNode = (SegmentTreeNode)CircuitTreeView.SelectedNode;

            //TODO: В switch c определением типов
			if (selectedNode.Segment is Element)
			{
				var selectedElement = (Element)selectedNode.Segment;
				ElementInfoTextbox.Text = "Name = " + selectedElement.Name + Environment.NewLine +
					"Value = " + selectedElement.Value;
			} else if (selectedNode.Segment is Circuit)
			{
				string type = "";
                //TODO: В switch c определением типов
				if (selectedNode.Segment is SerialCircuit)
				{
					type = "Serial";
				}
				else if(selectedNode.Segment is ParallelCircuit)
				{
					type = "Parallel";
				}

				ElementInfoTextbox.Text = ($"Name: {selectedNode.Segment.Name}" + Environment.NewLine +
				                           $"Type: {type}");
			}
		}

		private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RemoveNode((SegmentTreeNode)CircuitTreeView.SelectedNode);
		}

		private void AddCircuitButton_Click(object sender, EventArgs e)
		{
			var circuitForm = new CircuitForm();
			circuitForm.IsAdd = true;
			
			circuitForm.ShowDialog();
			if(circuitForm.DialogResult == DialogResult.OK)
			{
				Circuit circuit = circuitForm.Circuit;
				_project.Circuits.Add(circuit);
				RefreshLists();
				CircuitsComboBox.SelectedIndex = _project.Circuits.IndexOf(circuit);
			}
		}

		private void CircuitTreeView_MouseDown(object sender, MouseEventArgs e)
		{
            //TODO: В switch
			if (e.Button == MouseButtons.Right)
			{
				var selectedNode = (SegmentTreeNode)CircuitTreeView.GetNodeAt(e.X, e.Y);
				CircuitTreeView.SelectedNode = selectedNode;

				if (selectedNode == null)
				{
					return;
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
				var selectedNode = (SegmentTreeNode)CircuitTreeView.GetNodeAt(e.X, e.Y);
				var replacingNodeParent = (SegmentTreeNode)_replacingTreeNode.Parent;

				if (selectedNode.Segment is Circuit 
					&& selectedNode != _replacingTreeNode 
					&& selectedNode != replacingNodeParent 
					&& !IsNodeContains(_replacingTreeNode.Segment.SubSegments, selectedNode.Segment))
				{
					CircuitTreeView.SelectedNode = selectedNode;
					var replacingNode = _replacingTreeNode;

					replacingNodeParent.Segment.SubSegments.Remove(_replacingTreeNode.Segment);
					replacingNodeParent.Nodes.Remove(_replacingTreeNode);

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
			var selectedNode = (SegmentTreeNode)CircuitTreeView.SelectedNode;

			if(selectedNode.Segment == _project.Circuits[CircuitsComboBox.SelectedIndex])
			{
				if (MessageBox.Show($"Do you really want remove circuit{selectedNode.Text}?", "Circuit removing",
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
			else
			{
				var selectedNodeParent = 
					(SegmentTreeNode)CircuitTreeView.SelectedNode.Parent;

				selectedNodeParent.Segment.SubSegments.Remove(selectedNode.Segment);
				selectedNodeParent.Nodes.Remove(selectedNode);

				//TODO: Что за двойка? Почему двойка?
				if(selectedNodeParent.Nodes.Count < 2)
				{
					var selectedNodeGrandParent = (SegmentTreeNode)selectedNodeParent.Parent;

					if(selectedNodeGrandParent != null)
					{
						 //TODO: RSDN - длины строк
						var lastElement = (SegmentTreeNode)selectedNodeParent.Nodes[0];

						selectedNodeGrandParent.Segment.SubSegments.Remove(selectedNodeParent.Segment);
						selectedNodeGrandParent.Nodes.Remove(selectedNodeParent);

						selectedNodeGrandParent.Segment.SubSegments.Add(lastElement.Segment);
						selectedNodeGrandParent.Nodes.Add(lastElement);
					}
				}
			}			
		}

		/// <summary>
		/// Метод, определяющий содержится в узле другой узел
		/// </summary>
		/// <param name="parentSegment"></param>
		/// <param name="foundSegment"></param>
		/// <returns></returns>
		private bool IsNodeContains(List<ISegment> parentSegment, ISegment foundSegment)
		{
			if (parentSegment != null)
			{
				foreach (var segment in parentSegment)
				{
					if (segment is Element)
					{
						if (segment == foundSegment)
						{
							return true;
						}
					}
					else
					{
						IsNodeContains(segment.SubSegments, foundSegment);
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Метод обновления дерева цепей
		/// </summary>
		private void RefreshCircuitTree()
		{
			CircuitTreeView.Nodes.Clear();

			var baseNode = new SegmentTreeNode(_project.Circuits[CircuitsComboBox.SelectedIndex]);
			CircuitTreeViewDataBind(baseNode, _project.Circuits[CircuitsComboBox.SelectedIndex].SubSegments);
			CircuitTreeView.Nodes.Add(baseNode);
		}

		/// <summary>
		/// Метод добавления нового элемента к последовательной цепи параллельно
		/// </summary>
		/// <param name="element"></param>
		/// <param name="selectedSegment"></param>
		/// <param name="nodeParent"></param>
		private void AddParallel(Element element, SegmentTreeNode selectedSegment, SegmentTreeNode nodeParent)
		{
			//TODO: Duplication
            ParallelCircuit parallelSegment = new ParallelCircuit
            {
                Name = "ParallelSegment"
            };
            parallelSegment.SubSegments.Add(element);
			parallelSegment.SubSegments.Add(selectedSegment.Segment);
			nodeParent.Segment.SubSegments.Remove(selectedSegment.Segment);
			nodeParent.Segment.SubSegments.Add(parallelSegment);

            SegmentTreeNode newNode = new SegmentTreeNode(parallelSegment);
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
			//TODO: Duplication
			var serialSegment = new SerialCircuit();
			serialSegment.Name = "SerialSegment";
			serialSegment.SubSegments.Add(element);
			serialSegment.SubSegments.Add(selectedSegment.Segment);
			var newNode = new SegmentTreeNode(serialSegment);

			nodeParent.Segment.SubSegments.Remove(selectedSegment.Segment);
			nodeParent.Segment.SubSegments.Add(serialSegment);

			CircuitTreeViewDataBind(newNode, serialSegment.SubSegments);
			nodeParent.Nodes.Remove(selectedSegment);
			nodeParent.Nodes.Add(newNode);
		}

		/// <summary>
		/// Метод обновления списков
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
