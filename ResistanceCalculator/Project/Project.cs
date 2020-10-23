using System.Collections.Generic;
using System.Numerics;
using ImpedanceCalculator.Circuits;
using ImpedanceCalculator.Elements;

namespace ImpedanceCalculator
{
	/// <summary>
	/// Класс для хранения цепи
	/// </summary>
	public class Project
	{
		#region Public Properties

		/// <summary>
		/// Устанавливает и возвращает список цепей
		/// </summary>
		public List<ISegment> Circuits { get; set; }

		/// <summary>
		/// Устанавливает и возвращает список частот
		/// </summary>
		public List<double> Frequencies { get; set; }

		/// <summary>
		/// Устанавливает и возвращает список импедансов итоговых цепей
		/// </summary>
		public List<Complex> Impendances { get; set; }

		#endregion

		#region Constructors

		public Project()
		{
			Circuits = new List<ISegment>();
			Frequencies = new List<double>();
			Impendances = new List<Complex>();
		}

		#endregion

		#region Methods

		public CircuitBase CreateCircuit()
		{
			var r1 = new Resistor("R1", 1);
			var c1 = new Capacitor("C1", 0.01);
			var l1 = new Inductor("L1", 0.02);
			var r2 = new Resistor("R2", 10);
			var l2 = new Capacitor("C2", 0.003);
			var r3 = new Resistor("R3", 1);
			var r4 = new Resistor("R4", 1);

			var serialSegment = new SerialCircuit(new List<ISegment>(), "SerialSegment");
			serialSegment.Add(r2);
			serialSegment.Add(l2);

			var parallelSegment = new ParallelCircuit(new List<ISegment>(), "ParallelSegment");
			parallelSegment.Add(l1);
			parallelSegment.Add(serialSegment);

			var mainCircuit = new SerialCircuit(new List<ISegment>(), "Circuit");
			mainCircuit.Add(r1);
			mainCircuit.Add(c1);
			mainCircuit.Add(parallelSegment);
			mainCircuit.Add(r3);
			mainCircuit.Add(r4);

			return mainCircuit;
		}

		#endregion
	}
}
