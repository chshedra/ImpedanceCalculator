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
        private List<ISegment> CreateElements =>
            new List<ISegment>
            {
                new Resistor("R", 10),
                new Capacitor("C", 0.05)
            };
		
        private CircuitBase Circuit => 
	        new ParallelCircuit(CreateElements, "TestCircuit");

		[Test(Description = "Тест конструктора последовательной цепи")]
		public void TestParallelCircuitConstructor_CorrectValue()
		{
			//Arrange
			var expextedName = "TestName";
			var expextedSubSegments = CreateElements;
			var circuit = new ParallelCircuit(expextedSubSegments, expextedName);

			//Act
			var actualName = circuit.Name;
			var actualSubSegments = circuit.SubSegments;

			//Assert
			Assert.AreEqual(expextedName, circuit.Name, "Контсруктор параллельной цепи " +
				"неправильно устанавливает значение Name");
			Assert.AreEqual(expextedSubSegments, circuit.SubSegments, "Контсруктор параллельной цепи " +
				"неправильно устанавливает значение SubSegments");
		}

		[Test(Description = "Тест метода CalculateZ последовательной цепи")]
		public void TestCalculateZ_CorrectValue()
		{
			var r = new Resistor("R", 10);
			var c = new Capacitor("C", 0.05);
			var frequency = 3;
			
			//Arrange
			Complex expected = 1 / (1 / c.CalculateZ(frequency) + 1 / r.CalculateZ(frequency));

			//Act
			Complex actual = Circuit.CalculateZ(frequency);

			//Assert
			Assert.AreEqual(expected, actual, 
				"Неправильное значение импеданса параллельной цепи");
		}
	}
}
