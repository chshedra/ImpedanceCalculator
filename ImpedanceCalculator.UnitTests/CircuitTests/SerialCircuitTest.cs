using System.Collections.Generic;
using NUnit.Framework;
using System.Numerics;
using ImpedanceCalculator.Circuits;
using ImpedanceCalculator.Elements;

namespace ImpedanceCalculator.UnitTests.CircuitTests
{
	public class SerialCircuitTest
	{
        //TODO: +Все тесты правильнее оформить по методике три AAA https://habr.com/ru/post/169381/

        //TODO: +Переделать в приватное свойство

		private List<ISegment> Elements =>
			//TODO: +Можно инициализировать сразу
            new List<ISegment>
            {
	            new Resistor("R", 10),
	            new Capacitor("C", 0.05)
            };

		

		private SerialCircuit Circuit => new SerialCircuit(Elements, "TestCircuit");
		

		[Test(Description = "Тест конструктора последовательной цепи")]
		public void TestSerialCircuitConstructor_CorrectValue()
		{
			//Arrange
			var expextedName = "TestName";
			var expextedSubSegments = Elements;
			var circuit = new SerialCircuit(expextedSubSegments, expextedName);

			//Act
			var actualName = circuit.Name;
			var actualSubSegments = circuit.SubSegments;

            //TODO: +RSDN - длины строк
			//Assert
			Assert.AreEqual(expextedName, actualName, 
				"Контсруктор полседовательной цепи " +
				"неправильно устанавливает значение Name");
			Assert.AreEqual(expextedSubSegments, actualSubSegments, 
				"Контсруктор последовательной цепи " +
				"неправильно устанавливает значение SubSegments");
		}

		[Test(Description = "Тест метода CalculateZ последовательной цепи")]
		public void TestCalculateZ_CorrectValue()
		{
			//TODO: +RSDN
			var r = new Resistor("R", 10);
			var l = new Capacitor("C", 0.05);
			var frequency = 3;

			//Arrange
			Complex expected = r.CalculateZ(frequency) + l.CalculateZ(frequency);

			//Act
			Complex actual = Circuit.CalculateZ(frequency);

			//Assert
			Assert.AreEqual(expected, actual,
				"Неправильное значение импеданса последовательной цепи");
		}
	}
}
