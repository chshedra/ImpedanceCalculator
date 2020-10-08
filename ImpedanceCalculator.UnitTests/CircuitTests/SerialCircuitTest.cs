using System.Collections.Generic;
using NUnit.Framework;
using System.Numerics;

namespace ImpedanceCalculator.UnitTests.CircuitTests
{
	class SerialCircuitTest
	{
		private SerialCircuit _circuit;
		private List<ISegment> CreateElements()
		{
			List<ISegment> elements = new List<ISegment>();
			elements.Add(new Resistor("R", 10));
			elements.Add(new Capacitor("C", 0.05));
			return elements;

		}

		private void InitParallelCircuit()
		{
			_circuit = new SerialCircuit(CreateElements(), "TestCircuit");
		}

		[Test(Description = "Тест конструктора последовательной цепи")]
		public void TestSerialCircuitConstructor_CorrectValue()
		{
			var expextedName = "TestName";
			var expextedSubSegments = CreateElements();

			_circuit = new SerialCircuit(expextedSubSegments, expextedName);

			Assert.AreEqual(expextedName, _circuit.Name, "Контсруктор полседовательной цепи " +
				"неправильно устанавливает значение Name");
			Assert.AreEqual(expextedSubSegments, _circuit.SubSegments, "Контсруктор последовательной цепи " +
				"неправильно устанавливает значение SubSegments");
		}

		[Test(Description = "Тест метода CalculateZ последовательной цепи")]
		public void TestCalculateZ_CorrectValue()
		{
			var R = new Resistor("R", 10);
			var C = new Capacitor("C", 0.05);
			var frequency = 3;

			Complex expected = R.CalculateZ(frequency) + C.CalculateZ(frequency);

			InitParallelCircuit();
			Complex actual = _circuit.CalculateZ(frequency);

			Assert.AreEqual(expected, actual,
				"Неправильное значение импеданса последовательной цепи");
		}
	}
}
