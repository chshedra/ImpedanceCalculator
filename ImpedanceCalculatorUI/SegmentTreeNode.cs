using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ImpedanceCalculator;

namespace ImpedanceCalculatorUI
{
	/// <summary>
	/// Дочерний класс TreeNode, который позволяет хранить значения ISegment в узлах TreeView
	/// </summary>
	public class SegmentTreeNode : TreeNode
	{
		/// <summary>
		/// Устанавливает и возвращает значение ISegment узла
		/// </summary>
		public ISegment Segment { get; set; }

		/// <summary>
		/// Конструктор узла без параметров
		/// </summary>
		public SegmentTreeNode()
		{
			Segment = null;
		}

		/// <summary>
		/// Конструктор, устанавливающий значение ISegment в узел
		/// </summary>
		/// <param name="segment"></param>
		public SegmentTreeNode(ISegment segment)
		{
			Segment = segment;
			Text = segment.Name;
		}

		
		
	}
}
