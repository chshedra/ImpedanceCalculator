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
            var (selectedNode, selectedSubSegments, treeNodes)
                = SelectedSubSegments((SegmentTreeNode)CircuitTreeView.SelectedNode);

			switch (selectedNode.Segment)
			{
				case ElementBase element:
				{
					var editForm = new ElementForm()
					{
						Element = element,
						IsAdd = false
					};

					editForm.ShowDialog();

					if (editForm.DialogResult == DialogResult.OK)
					{
						
						RemoveElements(selectedSubSegments, treeNodes, selectedNode);

                        var selectedSegment = selectedNode.Segment;
                        var editedElement = editForm.Element;
                        InsertElements(selectedSubSegments, treeNodes, 
                            selectedSegment, editedElement);
                        
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

        private static (SegmentTreeNode, List<ISegment>, TreeNodeCollection) 
            SelectedSubSegments(SegmentTreeNode selectedNode)
        {
            var selectedNodeParent = (SegmentTreeNode) selectedNode.Parent;
            var selectedSubSegments = selectedNodeParent.Segment.SubSegments;

            return (selectedNode, selectedSubSegments, selectedNodeParent.Nodes);
        }

        private void InsertElements(List<ISegment> selectedSubSegments, 
            TreeNodeCollection treeNodes, 
            ISegment selectedSegment, 
            ElementBase editedElement)
        {
			var elementIndex =
                selectedSubSegments.IndexOf(selectedSegment);
            selectedSubSegments.Insert(elementIndex, editedElement);
            treeNodes.Insert(elementIndex, new SegmentTreeNode(editedElement));
		}

        private static void RemoveElements(ICollection<ISegment> subSegments, 
            TreeNodeCollection treeNodeCollection,
            SegmentTreeNode treeNode)
        {
            subSegments.Remove(treeNode.Segment);
            treeNodeCollection.Remove(treeNode);
        }

        private static void AddElements(ICollection<ISegment> subSegments,
            TreeNodeCollection treeNodeCollection,
            SegmentTreeNode treeNode)
        {
            subSegments.Add(treeNode.Segment);
            treeNodeCollection.Add(treeNode);
        }

		private void RemoveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RemoveNode((SegmentTreeNode)CircuitTreeView.SelectedNode);
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
                        AddElements(targetNode.Segment.SubSegments, 
                            targetNode.Nodes, draggedNode);
                    }
				}

				targetNode.Expand();

				CircuitChanged?.Invoke(this, EventArgs.Empty);
			}
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
            var (removingNodeParent, removingSubSegments, treeNodes)
                = SelectedSubSegments((SegmentTreeNode)removingNode.Parent);

			RemoveElements(removingSubSegments, treeNodes, removingNodeParent);

			if (removingNodeParent.Segment.SubSegments.Count <= 1)
			{
				if ((removingNodeParent.Parent) != null)
				{
                    var (lastElement,lastSubSegments, lastTreeNodes)
                        = SelectedSubSegments((SegmentTreeNode)removingNodeParent.Nodes[0]);

					RemoveElements(lastSubSegments, lastTreeNodes, lastElement);

                    var (removingNodeGrandParent, 
                            removingNodeGrandSubSegments, 
                            removingNodeGrandTreeNodes)
                        = SelectedSubSegments((SegmentTreeNode)removingNodeParent.Parent);

                    RemoveElements(removingNodeGrandSubSegments, 
                        removingNodeGrandTreeNodes, removingNodeGrandParent);

					AddElements(removingNodeGrandSubSegments, 
                        removingNodeGrandTreeNodes, removingNodeGrandParent);
				}
			}

			CircuitChanged?.Invoke(this, EventArgs.Empty);
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
                var parentNode = (SegmentTreeNode) CircuitTreeView.SelectedNode.Parent;
				var selectedNode = (SegmentTreeNode)CircuitTreeView.SelectedNode;

				if (selectedNode.Segment is CircuitBase)
				{
					AddCircuitNode(addForm, selectedNode, node, parentNode);
				}
				else if (selectedNode.Segment is ElementBase)
				{
					switch (((SegmentTreeNode)CircuitTreeView.SelectedNode.Parent).Segment)
					{
						case SerialCircuit serialCircuit:
						{
							if (addForm.IsSerial)
							{
                                //TODO: Method ADD
									parentNode.Segment.SubSegments.Add(addForm.Element);
                                parentNode.Nodes.Add(node);
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
						//TODO: Method ADD
						serial.SubSegments.Add(addForm.Element);
						selectedNode.Nodes.Add(node);
						break;
					}
					case ParallelCircuit parallel:
					{
                        //TODO: Method ADD
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
                        //TODO: Method ADD
							selectedNode.Segment.SubSegments.Add(addForm.Element);
						selectedNode.Nodes.Add(node);
						break;
					}
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
            //TODO: Method ADD
			segment.SubSegments.Add(element);
			segment.SubSegments.Add(selectedSegment.Segment);
			//TODO: Method Remove/ADD?
			var newNode = new SegmentTreeNode(segment);
			nodeParent.Segment.SubSegments.Remove(selectedSegment.Segment);
			nodeParent.Segment.SubSegments.Add(segment);
			CircuitTreeViewDataBind(newNode, segment.SubSegments);
			nodeParent.Nodes.Remove(selectedSegment);
			nodeParent.Nodes.Add(newNode);
		}

		/// <summary>
		/// Вызывает форму для добавления первого элемента цепи
		/// </summary>
		public bool AddFirstElement()
		{
			var addForm = new ElementForm()
			{
				IsAdd = false
			};
			addForm.ShowDialog();
			if (addForm.DialogResult == DialogResult.OK)
			{
				var firstElement = new SegmentTreeNode(addForm.Element);
				//TODO: ADD Method
				CircuitTreeView.Nodes[0].Nodes.Add(firstElement);
				((SegmentTreeNode)CircuitTreeView.Nodes[0]).Segment.SubSegments.Add(addForm.Element);
				CircuitChanged?.Invoke(this, EventArgs.Empty);
				return true;
			}
			
			return false;
		}
	}
}


