using System;
using NUnit.Framework;
using System.Numerics;
using ImpedanceCalculator.Elements;

namespace ImpedanceCalculator.UnitTests.ElementTests
{
	[TestFixture]
	public class CapacitorTest
	{
		private Capacitor TestCapacitor => new Capacitor("TestCapacitor", 0.05);
		

		[Test(Description = "Позитивный тест конструктора Capacitor ")]
		public void TestConstructor_PositiveTest()
		{
			//Arrange
			var expectedName = "C";
			double expectedValue = 0;

			//Act
			var actualCapacitor = new Capacitor();

			//Assert
			Assert.AreEqual(expectedName, actualCapacitor.Name,
				"Конструктор Capacitor неправильно устанавливает значение имени");
			Assert.AreEqual(expectedValue, actualCapacitor.Value,
				"Конструктор Capacitor неправильно устанавливает значение ");
		}

		[Test(Description = "Позитивный тест метода CalculateZ")]
		public void TestCalculateZ_CorrectValue()
		{
			double value = 0.05;
			double frequency = 1;
			var result = -(1 / (2 * Math.PI * frequency * value));

			//Assert
			var expected = new Complex(0, result);

			//Act
			Complex actual = TestCapacitor.CalculateZ(frequency);

			//Assert
			Assert.AreEqual(expected, actual,
				"Метод CalculateZ неправильно расчитывает значения");
		}

		[Test(Description = "Тест метода CalculateZ с отрицательной частотой")]
		public void TestCalculatez_NegativeFrequency()
		{
			//Arrange
			var wrongFrequency = -1;

			//Assert, Act
			Assert.Throws<ArgumentException>
			(
				() =>
				{
					var result = TestCapacitor.CalculateZ(wrongFrequency);
				},
				"Должно возникать исключение, если частота отрицательная"
			);
		}
	}
}
