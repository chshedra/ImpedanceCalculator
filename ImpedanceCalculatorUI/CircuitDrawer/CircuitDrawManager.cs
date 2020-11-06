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
            //TODO: +Рука-лицо о_О   
            switch (segment)
			{
				case Resistor resistor:
				{
					return new ResistorDrawer(resistor);
				}

				case Inductor inductor:
				{
					return new InductorDrawer(inductor);
				}

				case Capacitor capacitor:
				{
					return new CapacitorDrawer(capacitor);
				}

				case ParallelCircuit parallelCircuit:
				{
					return new ParallelCircuitDrawer(parallelCircuit);
				}

				case SerialCircuit serialCircuit:
				{
					return new SerialCircuitDrawer(serialCircuit);
				}

				default:
				{
					throw new ArgumentException("Unknown Segment");
				}
			}
		}

		/// <summary>
		/// Заполняет дерево
		/// </summary>
		/// <param name="drawerTreeNode"></param>
		/// <param name="segment"></param>
		public static void FillSegmentDrawerTreeNode(SegmentDrawerBase drawerTreeNode, ISegment segment)
		{
			if (drawerTreeNode.Segment.SubSegments != null)
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
