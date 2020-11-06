using System;
using NUnit.Framework;
using System.Numerics;
using ImpedanceCalculator.Elements;

namespace ImpedanceCalculator.UnitTests.ElementTests
{
	//TODO: +RSDN
	[TestFixture]
	public class InductorTest
	{
		private Inductor TestInductor => new Inductor("TestResistor", 0.05);

		[Test(Description = "Позитивный тест конструктора Inductor ")]
		public void TestConstructor_PositiveTest()
		{
			//Arrange
			var expectedName = "L";
			double expectedValue = 0;

			//Act
			var actualCapacitor = new Inductor();

			//Assert
			Assert.AreEqual(expectedName, actualCapacitor.Name,
				"Конструктор Inductor неправильно устанавливает значение имени");
			Assert.AreEqual(expectedValue, actualCapacitor.Value,
				"Конструктор Inductor неправильно устанавливает значение ");
		}

		[Test(Description = "Позитивный тест vметода CalculateZ")]
		public void TestCalculateZ_CorrectValue()
		{
			double value = 0.05;
			double frequency = 1;
			var result = 2 * Math.PI * frequency * value;

			//Arrange
			var expected = new Complex(0, result);

			//Act
			Complex actual = TestInductor.CalculateZ(frequency);

			//Assert
			Assert.AreEqual(expected, actual,
				"Метод CalculateZ неправильно расчитывает значения");
		}

		[Test(Description = "Тест метода CalculateZ с отрицательной частотой")]
		public void TestCalculateZ_NegativeFrequency()
		{
			//Arrange
			var wrongFrequency = -1;

			//Assert
			Assert.Throws<ArgumentException>
			(
				() =>
				{
					var result = TestInductor.CalculateZ(wrongFrequency);
				},
			    "Должно возникать исключение, если частота отрицательная"
			);
		}
	}
}
