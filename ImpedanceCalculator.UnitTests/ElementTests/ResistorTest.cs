using System;
using System.Numerics;
using NUnit.Framework;
using ImpedanceCalculator;

namespace ImpedanceCalculator.UnitTests
{
	[TestFixture]
	class ResistorTest
	{
		private Resistor _resistor;

		private void ResistorInit()
		{
			_resistor = new Resistor();
		}

		private Resistor CreateTestResistor()
		{
			var R = new Resistor("TestResistor", 10);
			return R;
		}

		[Test(Description = "Позитивный тест vметода CalculateZ")]
		public void TestCalculateZ_CorrectValue()
		{
			string name = "Test";
			double value = 1;
			double frequency = 1;
			Complex expected = new Complex(value, 0);

			Resistor resistor = new Resistor(name, value);

			Complex actual = resistor.CalculateZ(frequency);

			Assert.AreEqual(expected, actual,
				"Метод CalculateZ неправильно расчитывает значения");
		}

		[Test(Description = "Тест метода CalculateZ с отрицательной частотой")]
		public void TestCalculatez_NegativeFrequency()
		{
			_resistor = CreateTestResistor();
			var wrongFrequency = -1;

			Assert.Throws<ArgumentException>(() =>
			{ var result = _resistor.CalculateZ(wrongFrequency); }, 
			"Должно возникать исключение, если частота отрицательная");
		}
	}
}
