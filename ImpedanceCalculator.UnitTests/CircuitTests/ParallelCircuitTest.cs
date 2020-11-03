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
        //TODO: Все тесты правильнее оформить по методике три AAA https://habr.com/ru/post/169381/
		
		//TODO: Переделать в свойства
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

			var actualName = _circuit.Name;
			var actualSubSegments = _circuit.SubSegments;
			Assert.AreEqual(expextedName, actualName, "Контсруктор параллельной цепи " +
				"неправильно устанавливает значение Name");
			Assert.AreEqual(expextedSubSegments, actualSubSegments, "Контсруктор параллельной цепи " +
				"неправильно устанавливает значение SubSegments");
		}

		[Test(Description = "Тест метода CalculateZ последовательной цепи")]
		public void TestCalculateZ_CorrectValue()
		{
			//TODO:+RSDN
			var r = new Resistor("R", 10);
			var c = new Capacitor("C", 0.05);
			var frequency = 3;

			Complex expected = 1 / (1 / r.CalculateZ(frequency) + 1 / c.CalculateZ(frequency));

			InitParallelCircuit();
			Complex actual = _circuit.CalculateZ(frequency);

			Assert.AreEqual(expected, actual, 
				"Неправильное значение импеданса параллельной цепи");
		}
	}
}
