using System;
using NUnit.Framework;
using System.Numerics;

namespace ImpedanceCalculator.UnitTests.ElementTests
{
	[TestFixture]
	class InductorTest
	{
		private Inductor _inductor;

		private void InductorInit()
		{
			_inductor = new Inductor();
		}

		private Inductor CreateTestInductor()
		{
			var L = new Inductor("TestResistor", 0.05);
			return L;
		}

		[Test(Description = "Позитивный тест vметода CalculateZ")]
		public void TestCalculateZ_CorrectValue()
		{
			double value = 0.05;
			double frequency = 1;
			var result = 2 * Math.PI * frequency * value;
			var expected = new Complex(0, result);

			_inductor = CreateTestInductor();

			Complex actual = _inductor.CalculateZ(frequency);

			Assert.AreEqual(expected, actual,
				"Метод CalculateZ неправильно расчитывает значения");
		}

		[Test(Description = "Тест метода CalculateZ с отрицательной частотой")]
		public void TestCalculateZ_NegativeFrequency()
		{
			_inductor = CreateTestInductor();
			var wrongFrequency = -1;

			Assert.Throws<ArgumentException>(() =>
			{ var result = _inductor.CalculateZ(wrongFrequency); },
			"Должно возникать исключение, если частота отрицательная");
		}
	}
}
