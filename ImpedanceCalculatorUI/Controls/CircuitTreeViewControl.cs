using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ImpedanceCalculator;
using ImpedanceCalculator.Elements;
using ImpedanceCalculator.Circuits;

namespace ImpedanceCalculatorUI.Controls
{
	public partial class CircuitTreeViewControl : UserControl
	{
		/// <summary>
		/// Хранит список цепей
		/// </summary>
		private Project _project;

		/// <summary>
		/// Конструктор CircuitTreeViewControl
		/// </summary>
		public CircuitTreeViewControl()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Устанавливает и возвращает список узлов дерева
		/// </summary>
		public TreeNodeCollection Nodes
		{
			get => CircuitTreeView.Nodes;
		}

		/// <summary>
		/// Событие изменения выбранного сегмента
		/// </summary>
		public event EventHandler SegmentSelected;

		/// <summary>
		/// Событие изменения дерева 
		/// </summary>
		public event EventHandler CircuitChanged;


		private void AddToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AddElement();
		}

		private void EditToolStripMenuItem_Click(object sender, EventArgs e)
		{
			SegmentTreeNode selectedNode = (SegmentTreeNode)CircuitTreeView.SelectedNode;
			
			
			switch (selectedNode.Segment)
			{
				case ElementBase element:
					{
						var editForm = new ElementForm()
						{
							//TODO: +Можно сразу использовать element
							Element = element,
							IsAdd = false
						};
						editForm.Element.Value *= 1000;
						editForm.ShowDialog();

						if (editForm.DialogResult == DialogResult.OK)
						{
							var editedElement = editForm.Element;

							//TODO: +Можно сразу создать нужные переменные типа
							//TODO: +selectedNode.Parent.Segment.SubSegments и selectedNodeParent.Nodes. и работать с ними
							var elementIndex =
								//TODO: ?Можно сразу использовать element - element типа ISegment, нельзя получить доступ к родителю
								((SegmentTreeNode)selectedNode.Parent).Segment.
								SubSegments.IndexOf(selectedNode.Segment);
							//TODO: ?Можно сразу использовать element - element типа ISegment, нельзя получить доступ к родителю
							((SegmentTreeNode)selectedNode.Parent).
								Segment.SubSegments.Remove(selectedNode.Segment);
							((SegmentTreeNode)selectedNode.Parent).Nodes.Remove(selectedNode);

							((SegmentTreeNode)selectedNode.Parent).
								Segment.SubSegments.Insert(elementIndex, editedElement);
							((SegmentTreeNode)selectedNode.Parent).Nodes.
								Insert(elementIndex, new SegmentTreeNode(editedElement));

							CircuitChanged?.Invoke(this, EventArgs.Empty);
						}

						break;
					}
				case CircuitBase circuit:
					{
						var circuitForm = new CircuitForm()
						{
							CircuitBase = circuit
						};
						circuitForm.ShowDialog();

						if (circuitForm.DialogResult == DialogResult.OK)
						{
							circuit.Name = circuitForm.CircuitBase.Name;

							CircuitChanged?.Invoke(this, EventArgs.Empty);
						}

						break;
					}
			}
		}

		private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RemoveNode((SegmentTreeNode)CircuitTreeView.SelectedNode);
		}

		/// <summary>
		/// Связывает узлы SubSegments с узлами SegmentTreeNode
		/// </summary>
		/// <param name="treeNode"></param>
		/// <param name="segments"></param>
		public void CircuitTreeViewDataBind(SegmentTreeNode treeNode, List<ISegment> segments)
		{
			CircuitChanged?.Invoke(this, EventArgs.Empty);
			foreach (var segment in segments)
			{
				if (segment is ElementBase)
				{
					SegmentTreeNode element = new SegmentTreeNode(segment);
					treeNode.Nodes.Add(element);
				}
				else if (segment is CircuitBase)
				{
					var node = new SegmentTreeNode(segment);
					treeNode.Nodes.Add(node);
					CircuitTreeViewDataBind(node, segment.SubSegments);
				}
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
			if (selectedNode == null || selectedNodeParent == null)
			{
				throw new ArgumentException("Selected node or selected node parent is null");
			}

			if (addForm.IsSerial)
			{
				switch (selectedNode.Segment)
				{
					case SerialCircuit serial:
					{
						serial.SubSegments.Add(addForm.Element);
						selectedNode.Nodes.Add(node);
						break;
					}
					case ParallelCircuit parallel:
					{
						((SegmentTreeNode)selectedNode.Parent).Segment.SubSegments.Add(addForm.Element);
						selectedNode.Parent.Nodes.Add(node);
						break;
					}
				}
			}
			else
			{
				switch (selectedNode.Segment)
				{
					case SerialCircuit serial:
					{
						var parallelSegment = new ParallelCircuit()
						{
							Name = "Parallel Segment"
						};
						CreateSegment(addForm.Element, selectedNode, selectedNodeParent, parallelSegment);
							break;
					}
					case ParallelCircuit parallel:
					{
						selectedNode.Segment.SubSegments.Add(addForm.Element);
						selectedNode.Nodes.Add(node);
						break;
					}
				}
			}
		}

		private void CircuitsTreeView_ItemDrag(object sender, ItemDragEventArgs e)
		{
			DoDragDrop(e.Item, DragDropEffects.Move);
		}

		private void CircuitsTreeView_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = e.AllowedEffect;
		}

		private void CircuitTreeView_DragOver(object sender, DragEventArgs e)
		{
			Point targetPoint = CircuitTreeView.PointToClient(new Point(e.X, e.Y));

			CircuitTreeView.SelectedNode = CircuitTreeView.GetNodeAt(targetPoint);
		}

		private void CircuitsTreeView_DragDrop(object sender, DragEventArgs e)
		{ 
			var targetPoint = CircuitTreeView.PointToClient(new Point(e.X, e.Y));

			var targetNode = CircuitTreeView.GetNodeAt(targetPoint) as SegmentTreeNode;

			var draggedNode = e.Data.GetData(typeof(SegmentTreeNode)) as SegmentTreeNode;

			if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode) &&
			    e.Effect == DragDropEffects.Move)
			{
				if (e.Effect == DragDropEffects.Move)
				{
					if (targetNode.Segment is CircuitBase)
					{
						RemoveNode(draggedNode);
						targetNode.Nodes.Add(draggedNode);
						targetNode.Segment.SubSegments.Add(draggedNode.Segment);
					}
				}

				targetNode.Expand();

				CircuitChanged?.Invoke(this, EventArgs.Empty);
			}
		}

		private bool ContainsNode(SegmentTreeNode node1, SegmentTreeNode node2)
		{
			if (node2.Parent == null) return false;
			if (node2.Parent.Equals(node1)) return true;

			return ContainsNode(node1, (SegmentTreeNode)node2.Parent);
		}

		/// <summary>
		/// Удаляет узел дерева цепи
		/// </summary>
		/// <param name="removingNode"></param>
		private void RemoveNode(SegmentTreeNode removingNode)
		{
			var removingNodeParent = (SegmentTreeNode) removingNode.Parent;
			//TODO: ?В куче мест эти сущности то создаются, то удаляются вместе. Может можно их как-то собрать для удобства (?)
			//TODO: ?и выполнить более корректную объектную декомпозицию, т.к. это много где дублируется
			removingNodeParent.
				Segment.SubSegments.Remove(removingNode.Segment);
			removingNodeParent.
				Nodes.Remove(removingNode);

			if (removingNodeParent.Nodes.Count <= 1)
			{
				if ((removingNodeParent.Parent) != null)
				{
					var removingNodeGrandParent =
						(SegmentTreeNode)removingNodeParent.Parent;
					var lastElement =
						(SegmentTreeNode)removingNodeParent.Nodes[0];

					removingNodeParent.Segment.SubSegments.
						Remove(lastElement.Segment);
					removingNodeParent.Nodes.
						Remove(lastElement);

					removingNodeGrandParent.Segment.SubSegments.
						Remove(removingNodeParent.Segment);
					removingNodeGrandParent.Nodes.
						Remove(removingNodeParent);

					removingNodeGrandParent.
						Segment.SubSegments.Add(lastElement.Segment);
					removingNodeGrandParent.
						Nodes.Add(lastElement);
				}
			}

			CircuitChanged?.Invoke(this, EventArgs.Empty);
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

		private void CircuitTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			var selectedNode = (SegmentTreeNode) CircuitTreeView.SelectedNode;
			SegmentSelected?.Invoke(selectedNode.Segment, EventArgs.Empty);
		}

		private void CircuitTreeView_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				removeToolStripMenuItem.Visible = true;
				addToolStripMenuItem.Visible = true;

				var selectedNode = (SegmentTreeNode) CircuitTreeView.GetNodeAt(e.X, e.Y);
				CircuitTreeView.SelectedNode = selectedNode;
				if (selectedNode == null)
				{
					return;
				}

				if (selectedNode.Parent == null)
				{
					removeToolStripMenuItem.Visible = false;
					addToolStripMenuItem.Visible = false;
				}

				NodeContextMenu.Show(PointToScreen(e.Location));
			}
		}

		/// <summary>
		/// Вызывает форму для добавления нового элемента
		/// </summary>
		public void AddElement()
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

				if (selectedNode.Segment is CircuitBase)
				{
					AddCircuitNode(addForm, selectedNode, node,
						(SegmentTreeNode)CircuitTreeView.SelectedNode.Parent);
				}
				else if (selectedNode.Segment is ElementBase)
				{
					switch (((SegmentTreeNode)CircuitTreeView.SelectedNode.Parent).Segment)
					{
						case SerialCircuit serialCircuit:
						{
							if (addForm.IsSerial)
							{
								((SegmentTreeNode)CircuitTreeView.SelectedNode.Parent).
									Segment.SubSegments.Add(addForm.Element);
								((SegmentTreeNode)CircuitTreeView.SelectedNode.Parent).
									Nodes.Add(node);
							}
							else
							{
								var parallelSegment = new ParallelCircuit()
								{
									Name = "ParallelSegment"
								};
								CreateSegment(addForm.Element, selectedNode,
									((SegmentTreeNode)CircuitTreeView.SelectedNode.Parent),
									parallelSegment);
							}

							break;
						}
						case ParallelCircuit parallelCircuit:
						{
							if (addForm.IsSerial == false)
							{
								((SegmentTreeNode)CircuitTreeView.SelectedNode.Parent).
									Segment.SubSegments.Add(addForm.Element);
							}
							else
							{
								var serialSegment = new SerialCircuit()
								{
									Name = "Serial Segment"
								};
								CreateSegment(addForm.Element, selectedNode,
									((SegmentTreeNode)CircuitTreeView.SelectedNode.Parent),
									serialSegment);
							}

							break;
						}
					}

					CircuitChanged?.Invoke(this, EventArgs.Empty);
				}
			}
		}

		/// <summary>
		/// Вызывает форму для добавления первого элемента цепи
		/// </summary>
		public void AddFirstElement()
		{
			var addForm = new ElementForm()
			{
				IsAdd = false
			};
			addForm.ShowDialog();
			if (addForm.DialogResult == DialogResult.OK)
			{
				var firstElement = new SegmentTreeNode(addForm.Element);
				CircuitTreeView.Nodes[0].Nodes.Add(firstElement);
				((SegmentTreeNode)CircuitTreeView.Nodes[0]).Segment.SubSegments.Add(addForm.Element);
			}
		}
	}
}


