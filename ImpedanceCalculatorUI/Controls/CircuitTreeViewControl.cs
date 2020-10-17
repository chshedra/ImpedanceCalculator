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
		/// Устанавливает и возвращает список узлов дерева
		/// </summary>
		public TreeNodeCollection Nodes
		{
			get => CircuitTreeView.Nodes;
			//TODO: ? Зачем? - потому что Nodes readonly и при попытке присвоить значение, должно вылетать исключение
			internal set
			{
				throw new NotImplementedException();
			}
		}

		/// <summary>
		/// Событие изменения выбранного сегмента
		/// </summary>
		public event EventHandler SegmentSelected;

		private void CircuitTreeView_MouseDown(object sender, MouseEventArgs e)
		{
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

				if (selectedNode.Segment is CircuitBase
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
				var node = new SegmentTreeNode(addForm.ElementBase);

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
										Segment.SubSegments.Add(addForm.ElementBase);
									((SegmentTreeNode)CircuitTreeView.SelectedNode.Parent).
										Nodes.Add(node);
								}
								else
								{
									var parallelSegment = new ParallelCircuit()
									{
										Name = "ParallelSegment"
									};
									CreateSegment(addForm.ElementBase, selectedNode, 
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
										Segment.SubSegments.Add(addForm.ElementBase);
								}
								else
								{
									var serialSegment = new SerialCircuit()
									{
										Name = "Serial Segment"
									};
									CreateSegment(addForm.ElementBase, selectedNode, 
										((SegmentTreeNode)CircuitTreeView.SelectedNode.Parent), 
										serialSegment);
								}

								break;
							}
					}
				}
			}
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
							ElementBase = element,
							IsAdd = false
						};
						editForm.ElementBase.Value *= 1000;
						editForm.ShowDialog();

						if (editForm.DialogResult == DialogResult.OK)
						{
							var editedElement = editForm.ElementBase;

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
						}

						break;
					}
				case CircuitBase circuit:
					{
						var circuitForm = new CircuitForm()
						{
							CircuitBase = circuit,
							IsAdd = false
						};
						circuitForm.ShowDialog();

						if (circuitForm.DialogResult == DialogResult.OK)
						{
							circuit.Name = circuitForm.CircuitBase.Name;
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
					if (segment is ElementBase)
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
				selectedNode.Segment.SubSegments.Add(addForm.ElementBase);
				selectedNode.Nodes.Add(node);
			}
			else if (selectedNode.Parent == null)
			{
				CircuitBase newSegment;
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

				newSegment.Add(addForm.ElementBase);
				var index = _project.Circuits.IndexOf(selectedNode.Segment);
				_project.Circuits.Remove(selectedNode.Segment);
				_project.Circuits.Insert(index, newSegment);
			}
			else
			{
				if (selectedNode.Segment is SerialCircuit)
				{
					var parallelSegment = new ParallelCircuit()
					{
						Name = "Parallel Segment"
					};
					CreateSegment(addForm.ElementBase, selectedNode, selectedNodeParent, parallelSegment);
				}
				else
				{
					selectedNodeParent.Segment.SubSegments.Add(addForm.ElementBase);
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

			//TODO: ?В куче мест эти сущности то создаются, то удаляются вместе. Может можно их как-то собрать для удобства (?)
			//TODO: ?и выполнить более корректную объектную декомпозицию, т.к. это много где дублируется
			((SegmentTreeNode)removingNode.Parent).
				Segment.SubSegments.Remove(removingNode.Segment);
			((SegmentTreeNode)removingNode.Parent).
				Nodes.Remove(removingNode);

				if (((SegmentTreeNode)removingNode.Parent).Nodes.Count <= 1)
				{

					if (((SegmentTreeNode)removingNode.Parent.Parent) != null)
					{
						var lastElement =
							(SegmentTreeNode)(removingNode.Parent).Nodes[0];

						((SegmentTreeNode)removingNode.Parent.Parent).Segment.SubSegments.
							Remove(((SegmentTreeNode)removingNode.Parent).Segment);
						((SegmentTreeNode)removingNode.Parent.Parent).Nodes.
							Remove(((SegmentTreeNode)removingNode.Parent));

						((SegmentTreeNode)removingNode.Parent.Parent).
							Segment.SubSegments.Add(lastElement.Segment);
						((SegmentTreeNode)removingNode.Parent.Parent).
							Nodes.Add(lastElement);
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

		private void CircuitTreeView_AfterSelect(object sender, TreeViewEventArgs e)
		{
			var selectedNode = (SegmentTreeNode) CircuitTreeView.SelectedNode;
			SegmentSelected?.Invoke(selectedNode.Segment, EventArgs.Empty);
		}
	}
}


