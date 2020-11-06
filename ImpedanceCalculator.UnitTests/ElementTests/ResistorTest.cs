using System;
using System.Numerics;
using NUnit.Framework;
using ImpedanceCalculator.Elements;

namespace ImpedanceCalculator.UnitTests.ElementTests
{
	//TODO: RSDN
	[TestFixture]
	class ResistorTest
	{
		private Resistor TestResistor => new Resistor("TestResistor", 10);

		[Test(Description = "Позитивный тест vметода CalculateZ")]
		public void TestCalculateZ_CorrectValue()
		{
			string name = "Test";
			double value = 1;
			double frequency = 1;

			//Arrange
			Complex expected = new Complex(value, 0);
			Resistor resistor = new Resistor(name, value);

			//Act
			Complex actual = resistor.CalculateZ(frequency);

			//Assert
			Assert.AreEqual(expected, actual,
				"Метод CalculateZ неправильно расчитывает значения");
		}

		[Test(Description = "Тест метода CalculateZ с отрицательной частотой")]
		public void TestCalculatez_NegativeFrequency()
		{
			//Arrange
			var wrongFrequency = -1;

			//Assert
			Assert.Throws<ArgumentException>
			(
				() =>
				{
					var result = TestResistor.CalculateZ(wrongFrequency);
				}, 
				"Должно возникать исключение, если частота отрицательная"
			);
		}
	}
}
