using System;
using System.Numerics;
using System.Collections.Generic;
using ImpedanceCalculator.Circuits;
using ImpedanceCalculator.Elements;
using NUnit.Framework;

namespace ImpedanceCalculator.UnitTests.CircuitTests
{
	public class ParallelCircuitTest
	{
		private ParallelCircuit _circuit;
		private List<ISegment> CreateElements()
		{
			List<ISegment> elements = new List<ISegment>();
			elements.Add(new Resistor("R", 10));
			elements.Add(new Capacitor("C", 0.05));
			return elements;
		}

		private void InitParallelCircuit()
		{
			_circuit = new ParallelCircuit(CreateElements(), "TestCircuit");
		}

		[Test(Description = "Тест конструктора последовательной цепи")]
		public void TestParallelCircuitConstructor_CorrectValue()
		{
			var expextedName = "TestName";
			var expextedSubSegments = CreateElements();

			_circuit = new ParallelCircuit(expextedSubSegments, expextedName);

			Assert.AreEqual(expextedName, _circuit.Name, "Контсруктор параллельной цепи " +
				"неправильно устанавливает значение Name");
			Assert.AreEqual(expextedSubSegments, _circuit.SubSegments, "Контсруктор параллельной цепи " +
				"неправильно устанавливает значение SubSegments");
		}

		[Test(Description = "Тест метода CalculateZ последовательной цепи")]
		public void TestCalculateZ_CorrectValue()
		{
			var R = new Resistor("R", 10);
			var C = new Capacitor("C", 0.05);
			var frequency = 3;

			Complex expected = 1 / (1 / R.CalculateZ(frequency) + 1 / C.CalculateZ(frequency));

			InitParallelCircuit();
			Complex actual = _circuit.CalculateZ(frequency);

			Assert.AreEqual(expected, actual, 
				"Неправильное значение импеданса параллельной цепи");
		}
	}
}
