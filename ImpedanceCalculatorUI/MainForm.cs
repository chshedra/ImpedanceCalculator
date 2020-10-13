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
		/// <summary>
		/// Хранит дерево цепей, список частот и список импедансов
		/// </summary>
		private readonly Project _project;

		/// <summary>
		/// Хранит значение перемещаемого узла дерева
		/// </summary>
		private SegmentTreeNode _replacingTreeNode;

		/// <summary>
		/// Хранит функции класса InputValidation
		/// </summary>
		private InputValidation _inputValidation = new InputValidation();

		public MainForm()
		{
			InitializeComponent();
			_project = new Project();

			CircuitsComboBox.DataSource = _project.Circuits;
			CircuitsComboBox.DisplayMember = "Name";

			FrequenciesListBox.DataSource = _project.Frequencies;
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

		private void CircuitTreeViewDataBind(SegmentTreeNode treeNode, List<ISegment> segments)
		{

			foreach (var segment in segments)
			{
				if (segment is Element)
				{
					SegmentTreeNode element = new SegmentTreeNode(segment);
					treeNode.Nodes.Add(element);
				}
				else if (segment is Circuit)
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

				var selectedNode = (SegmentTreeNode) CircuitTreeView.SelectedNode;
				var selectedNodeParent =
					(SegmentTreeNode) CircuitTreeView.SelectedNode.Parent;

				if (selectedNode.Segment is Circuit)
				{
					AddCircuitNode(addForm, selectedNode, node, selectedNodeParent);
				}
				else if (selectedNode.Segment is Element)
				{
					//TODO:+В switch c определением типов
					switch (selectedNodeParent.Segment)
					{
						case SerialCircuit serialCircuit:
						{
							if (addForm.IsSerial)
							{
								selectedNodeParent.Segment.SubSegments.Add(addForm.Element);
								selectedNodeParent.Nodes.Add(node);
							}
							else
							{
								var parallelSegment = new ParallelCircuit()
								{
									Name = "ParallelSegment"
								};
								CreateSegment(addForm.Element, selectedNode, selectedNodeParent, parallelSegment);
							}

							break;
						}
						case ParallelCircuit parallelCircuit:
						{
							if (addForm.IsSerial == false)
							{
								selectedNodeParent.Segment.SubSegments.Add(addForm.Element);
							}
							else
							{
								var serialSegment = new SerialCircuit()
								{
									Name = "Serial Segment"
								};
								CreateSegment(addForm.Element, selectedNode, selectedNodeParent, serialSegment);
							}

							break;
						}
					}
				}
			}
		}

		private void EditToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var selectedNode = (SegmentTreeNode) CircuitTreeView.SelectedNode;
			//TODO:+ В switch c определением типов

			switch (selectedNode.Segment)
			{
				case Element element:
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

					break;
				}
				case Circuit circuit:
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

					break;
				}
			}
		}

		private void CircuitTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			var selectedNode = (SegmentTreeNode) CircuitTreeView.SelectedNode;

			//TODO: +В switch c определением типов

			switch (selectedNode.Segment)
			{
				case Element element:
				{
					var selectedElement = (Element) selectedNode.Segment;
					ElementInfoTextbox.Text = "Name = " + selectedElement.Name + Environment.NewLine +
					                          "Value = " + selectedElement.Value;

					break;
				}
				case Circuit circuit:
				{
					string type = "";

					//TODO: +В switch c определением типов
					switch (selectedNode.Segment)
					{
						case SerialCircuit serialCircuit:
						{
							type = "Serial";
							break;
						}
						case ParallelCircuit parallelCircuit:
						{
							type = "Parallel";
							break;
						}
					}

					ElementInfoTextbox.Text = ($"Name: {selectedNode.Segment.Name}" + Environment.NewLine +
					                           $"Type: {type}");

					break;
				}
			}
		}

		private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RemoveNode((SegmentTreeNode) CircuitTreeView.SelectedNode);
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
				Circuit circuit = circuitForm.Circuit;
				_project.Circuits.Add(circuit);
				RefreshLists();
				CircuitsComboBox.SelectedIndex = _project.Circuits.IndexOf(circuit);
			}
		}

		private void CircuitTreeView_MouseDown(object sender, MouseEventArgs e)
		{
			//TODO: +В switch
			switch (e.Button)
			{
				case MouseButtons.Right:
				{
					var selectedNode = (SegmentTreeNode) CircuitTreeView.GetNodeAt(e.X, e.Y);
					CircuitTreeView.SelectedNode = selectedNode;

					if (selectedNode == null)
					{
						return;
					}

					NodeContextMenu.Show(PointToScreen(e.Location));
					break;
				}
				case MouseButtons.Left:
				{
					_replacingTreeNode = (SegmentTreeNode) CircuitTreeView.GetNodeAt(e.X, e.Y);
					break;
				}
			}
		}

		private void CircuitTreeView_MouseUp(object sender, MouseEventArgs e)
		{
			if (_replacingTreeNode != null)
			{
				var selectedNode = (SegmentTreeNode) CircuitTreeView.GetNodeAt(e.X, e.Y);
				var replacingNodeParent = (SegmentTreeNode) _replacingTreeNode.Parent;

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
			var selectedNode = (SegmentTreeNode) CircuitTreeView.SelectedNode;

			if (selectedNode.Segment == _project.Circuits[CircuitsComboBox.SelectedIndex])
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
					(SegmentTreeNode) CircuitTreeView.SelectedNode.Parent;

				selectedNodeParent.Segment.SubSegments.Remove(selectedNode.Segment);
				selectedNodeParent.Nodes.Remove(selectedNode);

				//TODO:+ Что за двойка? Почему двойка?
				if (selectedNodeParent.Nodes.Count <= 1)
				{
					var selectedNodeGrandParent =
						(SegmentTreeNode) selectedNodeParent.Parent;

					if (selectedNodeGrandParent != null)
					{
						//TODO:+ RSDN длины строк
						var lastElement =
							(SegmentTreeNode) selectedNodeParent.Nodes[0];

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
		/// Добавляет в дерево цепи сегмент Circuit
		/// </summary>
		/// <param name="addForm"></param>
		/// <param name="selectedNode"></param>
		/// <param name="node"></param>
		/// <param name="selectedNodeParent"></param>
		private void AddCircuitNode(ElementForm addForm, SegmentTreeNode selectedNode,
			SegmentTreeNode node, SegmentTreeNode selectedNodeParent)
		{

			if (addForm.IsSerial)
			{
				selectedNode.Segment.SubSegments.Add(addForm.Element);
				selectedNode.Nodes.Add(node);
			}
			else if (selectedNode.Segment == _project.Circuits[CircuitsComboBox.SelectedIndex])
			{
				Circuit newSegment;
				if (selectedNode.Segment is SerialCircuit)
				{
					newSegment = new ParallelCircuit()
					{
						Name = selectedNode.Segment.Name,
						SubSegments = selectedNode.Segment.SubSegments
					};
				}
				else
				{
					newSegment = new SerialCircuit()
					{
						Name = selectedNode.Segment.Name,
						SubSegments = selectedNode.Segment.SubSegments
					};
				}

				newSegment.Add(addForm.Element);
				var index = _project.Circuits.IndexOf(selectedNode.Segment);
				_project.Circuits.Remove(selectedNode.Segment);
				_project.Circuits.Insert(index, newSegment);

				RefreshCircuitTree();
			}
			else
			{
				if (selectedNode.Segment is SerialCircuit)
				{
					var parallelSegment = new ParallelCircuit()
					{
						Name = "Parallel Segment"
					};
					CreateSegment(addForm.Element, selectedNode, selectedNodeParent, parallelSegment);
				}
				else
				{
					selectedNodeParent.Segment.SubSegments.Add(addForm.Element);
					selectedNodeParent.Nodes.Add(node);
				}
			}
		}

		/// <summary>
		/// Создает новый сегмент для элемента
		/// </summary>
		/// <param name="element"></param>
		/// <param name="selectedSegment"></param>
		/// <param name="nodeParent"></param>
		/// <param name="segment"></param>
		private void CreateSegment(ISegment element, 
			SegmentTreeNode selectedSegment, SegmentTreeNode nodeParent, ISegment segment)
		{
			segment.SubSegments.Add(element);
			segment.SubSegments.Add(selectedSegment.Segment);
			var newNode = new SegmentTreeNode(segment);
			nodeParent.Segment.SubSegments.Remove(selectedSegment.Segment);
			nodeParent.Segment.SubSegments.Add(segment);
			CircuitTreeViewDataBind(newNode, segment.SubSegments);
			nodeParent.Nodes.Remove(selectedSegment);
			nodeParent.Nodes.Add(newNode);
		}
	}
}
