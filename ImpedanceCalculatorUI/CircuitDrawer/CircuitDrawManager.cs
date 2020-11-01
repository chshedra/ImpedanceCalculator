using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImpedanceCalculator;
using ImpedanceCalculator.Circuits;
using ImpedanceCalculator.Elements;
using ImpedanceCalculatorUI.CircuitDrawer.CircuitDrawers;
using ImpedanceCalculatorUI.CircuitDrawer.ElementDrawers;

namespace ImpedanceCalculatorUI.CircuitDrawer
{
    //TODO: +RSDN
	/// <summary>
	/// Содержит методы для отрисовки основной цепи
	/// </summary>
	public class CircuitDrawManager
	{
		/// <summary>
		/// Определяет тип сегмента и создает соответствующий отрисовщик
		/// </summary>
		/// <param name="segment"></param>
		/// <returns></returns>
		public static SegmentDrawerBase GetDrawSegment(ISegment segment)
		{
			SegmentDrawerBase segmentDrawer;

			switch (segment)
			{
				case Resistor _:
				{
					segmentDrawer = new ResistorDrawer(segment);
					break;
				}

				case Inductor _:
				{
					segmentDrawer = new InductorDrawer(segment);
					break;
				}

				case Capacitor _:
				{
					segmentDrawer = new CapacitorDrawer(segment);
					break;
				}

				case ParallelCircuit _:
				{
					segmentDrawer = new ParallelCircuitDrawer(segment);
					break;
				}

				case SerialCircuit _:
				{
					segmentDrawer = new SerialCircuitDrawer(segment);
					break;
				}

				default:
				{
					throw new ArgumentException("Unknown Segment");
				}
			}

			return segmentDrawer;
		}

		/// <summary>
		/// Заполняет дерево
		/// </summary>
		/// <param name="drawerTreeNode"></param>
		/// <param name="segment"></param>
		private static void FillSegmentDrawerTreeNode(SegmentDrawerBase drawerTreeNode, ISegment segment)
		{
			foreach (var subSegment in segment.SubSegments)
			{
				var segmentTreeNode = GetDrawSegment(subSegment);

				drawerTreeNode.Nodes.Add(segmentTreeNode);
				if (!(subSegment is ElementBase element))
				{
					FillSegmentDrawerTreeNode(segmentTreeNode, subSegment);
				}
			}
		}
		
		/// <summary>
		/// Отрисовывает главную цепь
		/// </summary>
		/// <param name="circuit"></param>
		/// <returns></returns>
		public static Image GetMainCircuitImage(CircuitBase circuit)
		{
			SerialCircuitDrawer segmentDrawer = new SerialCircuitDrawer(circuit);
			FillSegmentDrawerTreeNode(segmentDrawer, circuit);

			return segmentDrawer.GetImage();
		}
	}
}
