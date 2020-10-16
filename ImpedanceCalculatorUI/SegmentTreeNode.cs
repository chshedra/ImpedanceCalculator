﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ImpedanceCalculator;

namespace ImpedanceCalculatorUI
{
	//TODO: Где XML комменты?
	public class SegmentTreeNode : TreeNode
	{
		public ISegment Segment { get; set; }

		public SegmentTreeNode()
		{
			Segment = null;
		}

		public SegmentTreeNode(ISegment segment)
		{
			Segment = segment;
			this.Text = segment.Name;
		}

		
	}
}
