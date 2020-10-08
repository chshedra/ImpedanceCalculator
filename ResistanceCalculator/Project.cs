using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceCalculator
{
	/// <summary>
	/// Класс для хранения цепи
	/// </summary>
	public class Project
	{
		/// <summary>
		/// Устанавливает и возвращает список цепей
		/// </summary>
		public List<ISegment> Circuits { get; set; } = new List<ISegment>();

		/// <summary>
		/// Устанавливает и возвращает список частот
		/// </summary>
		public List<double> Frequencies { get; set; } = new List<double>();

		/// <summary>
		/// Устанавливает и возвращает список импедансов итоговых цепей
		/// </summary>
		public List<Complex> Impendances { get; set; } = new List<Complex>();

		/// <summary>
		/// Метод для создания цепей
		/// </summary>
		public List<ISegment> CreateCircuits()
		{
			List<ISegment> circuits = new List<ISegment>();

			circuits.Add(Circuit1());
			circuits.Add(Circuit2());
			circuits.Add(Circuit3());
			return circuits;
		}

		/// <summary>
		/// Метод создания первой цепи
		/// </summary>
		private ISegment Circuit1()
		{
			SerialCircuit circuit = new SerialCircuit(new List<ISegment>(), "Circuit 1");
			Resistor R1 = new Resistor("R1", 5);
			Capacitor C1 = new Capacitor("C1", 0.05);
			Inductor L1 = new Inductor("L1", 0.01);

			ParallelCircuit circuit2 = new ParallelCircuit();
			circuit2.Add(R1);
			circuit2.Add(L1);
			circuit.Add(circuit2);
			circuit.Add(C1);

			return circuit;
		}

		/// <summary>
		/// Метод создания второй цепи
		/// </summary>
		private ISegment Circuit2()
		{
			ParallelCircuit circuit = new ParallelCircuit(new List<ISegment>(), "Circuit2");
			Resistor R1 = new Resistor("R1", 0);
			Capacitor C1 = new Capacitor("C1", 1);
			Inductor L1 = new Inductor("L1", 1);
			Capacitor C2 = new Capacitor("C2", 0.05);

			ParallelCircuit circuit2 = new ParallelCircuit();
			circuit2.Name = "ParallelSegment";
			SerialCircuit circuit3 = new SerialCircuit();
			circuit3.Name = "SerialSegment";
			circuit3.Add(C2);
			circuit3.Add(R1);
			circuit2.Add(circuit3);
			circuit2.Add(L1);
			circuit.Add(circuit2);
			circuit.Add(C1);

			return circuit;
		}

		private ISegment Circuit3()
		{
			var circuit = new ParallelCircuit();

			var C1 = new Capacitor("C1", 2e-06);
			var C2 = new Capacitor("C2", 6e-06);

			circuit.Add(C1);
			circuit.Add(C2);

			return circuit;
		}
	}
}
