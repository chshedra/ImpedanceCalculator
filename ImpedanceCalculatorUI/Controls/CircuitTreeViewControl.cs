using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImpedanceCalculator;

namespace ImpedanceCalculatorUI.Controls
{
	public partial class CircuitTreeViewControl : UserControl
	{
		/// <summary>
		/// Хранит список цепей
		/// </summary>
		private Project _project;

		/// <summary>
		/// Хранит значение перемещаемого узла дерева
		/// </summary>
		private SegmentTreeNode _replacingTreeNode;

		/// <summary>
		/// Конструктор CircuitTreeViewControl
		/// </summary>
		public CircuitTreeViewControl()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Устанавливает и возвращает выбранный узел дерева
		/// </summary>
		public SegmentTreeNode SelectedNode
		{
			get => (SegmentTreeNode)CircuitTreeView.SelectedNode;

			internal set
			{
				CircuitTreeView.SelectedNode = value;
			}
		}

		/// <summary>
		/// Устанавливает и возвращает список узлов дерева
		/// </summary>
		public TreeNodeCollection Nodes
		{
			get => CircuitTreeView.Nodes;
			
			internal set
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Событие удаления цепи
		/// </summary>
		public event EventHandler CircuitRemoved;

		private void CircuitTreeView_MouseDown(object sender, MouseEventArgs e)
		{
			//TODO: +В switch
			switch (e.Button)
			{
				case MouseButtons.Right:
				{
					removeToolStripMenuItem.Visible = true;
					var selectedNode = (SegmentTreeNode)CircuitTreeView.GetNodeAt(e.X, e.Y);
					CircuitTreeView.SelectedNode = selectedNode;
					if (selectedNode == null)
					{
						return;
					}

					if (selectedNode.Parent == null)
					{
						removeToolStripMenuItem.Visible = false;
					}

					NodeContextMenu.Show(PointToScreen(e.Location));
					break;
				}
				case MouseButtons.Left:
				{
					_replacingTreeNode = (SegmentTreeNode)CircuitTreeView.GetNodeAt(e.X, e.Y);
					break;
				}
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
					var replacingNode = _replacingTreeNode;
					CircuitTreeView.SelectedNode = selectedNode;

					RemoveNode(_replacingTreeNode);
					//replacingNodeParent.Segment.SubSegments.Remove(_replacingTreeNode.Segment);
					//replacingNodeParent.Nodes.Remove(_replacingTreeNode);

					selectedNode.Segment.SubSegments.Add(replacingNode.Segment);
					selectedNode.Nodes.Add(replacingNode);
				}
				else
				{
					_replacingTreeNode = null;
				}
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
			var selectedNode = (SegmentTreeNode)CircuitTreeView.SelectedNode;

			//TODO:+ В switch c определением типов
			switch (selectedNode.Segment)
			{
				case Element element:
					{
						var editForm = new ElementForm()
						{
							Element = (Element)selectedNode.Segment,
							IsAdd = false
						};
						editForm.ShowDialog();

						if (editForm.DialogResult == DialogResult.OK)
						{
							var editedElement = editForm.Element;
							var selectedNodeParent = (SegmentTreeNode)selectedNode.Parent;

							var elementIndex = 
								selectedNodeParent.Segment.SubSegments.IndexOf(selectedNode.Segment);

							selectedNodeParent.Segment.SubSegments.Remove(selectedNode.Segment);
							selectedNodeParent.Nodes.Remove(selectedNode);

							selectedNodeParent.Segment.SubSegments.Insert(elementIndex, editedElement);
							selectedNodeParent.Nodes.
								Insert(elementIndex, new SegmentTreeNode(editedElement));

							RefreshCircuitTree();
						}

						break;
					}
				case Circuit circuit:
					{
						var editCircuit = (Circuit)selectedNode.Segment;
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

		private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RemoveNode((SegmentTreeNode)CircuitTreeView.SelectedNode);
		}

		public SegmentTreeNode GetNodeAt(int x, int y)
		{
			return (SegmentTreeNode)CircuitTreeView.GetNodeAt(x, y);
		}

		/// <summary>
		/// Связывает узлы SubSegments с узлами SegmentTreeNode
		/// </summary>
		/// <param name="treeNode"></param>
		/// <param name="segments"></param>
		public void CircuitTreeViewDataBind(SegmentTreeNode treeNode, List<ISegment> segments)
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

		/// <summary>
		/// Определяет, содержится в узле другой узел
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
			else if (selectedNode.Parent == null)
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
		/// Удаляет узел дерева цепи
		/// </summary>
		/// <param name="removingNode"></param>
		private void RemoveNode(SegmentTreeNode removingNode)
		{
			if (removingNode.Parent == null)
			{
				CircuitRemoved?.Invoke(removingNode, EventArgs.Empty);
			}
			else
			{
				var removingNodeParent =
					(SegmentTreeNode)removingNode.Parent;

				removingNodeParent.Segment.SubSegments.Remove(removingNode.Segment);
				removingNodeParent.Nodes.Remove(removingNode);

				//TODO:+ Что за двойка? Почему двойка?
				if (removingNodeParent.Nodes.Count <= 1)
				{
					var selectedNodeGrandParent =
						(SegmentTreeNode)removingNodeParent.Parent;

					if (selectedNodeGrandParent != null)
					{
						//TODO:+ RSDN длины строк
						var lastElement =
							(SegmentTreeNode)removingNodeParent.Nodes[0];

						selectedNodeGrandParent.Segment.SubSegments.Remove(removingNodeParent.Segment);
						selectedNodeGrandParent.Nodes.Remove(removingNodeParent);

						selectedNodeGrandParent.Segment.SubSegments.Add(lastElement.Segment);
						selectedNodeGrandParent.Nodes.Add(lastElement);
					}
				}

				RefreshCircuitTree();
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

		/// <summary>
		/// Метод обновления дерева цепей
		/// </summary>
		internal void RefreshCircuitTree()
		{
			
		}
	}
}


