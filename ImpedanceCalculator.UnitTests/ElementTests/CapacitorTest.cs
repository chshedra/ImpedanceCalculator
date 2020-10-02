using System;
using NUnit.Framework;
using System.Numerics;

namespace ImpedanceCalculator.UnitTests
{
	class CapacitorTest
	{
		private Capacitor _capacitor;

		private void CapacitorInit()
		{
			_capacitor = new Capacitor();
		}

		private Capacitor CreateTestCapacitor()
		{
			var C = new Capacitor("TestCapacitor", 0.05);
			return C;
		}

		[Test(Description = "Позитивный тест метода CalculateZ")]
		public void TestCalculateZ_CorrectValue()
		{
			double value = 0.05;
			double frequency = 1;
			var result = -(1 / (2 * Math.PI * frequency * value));
			var expected = new Complex(0, result);

			_capacitor = CreateTestCapacitor();

			Complex actual = _capacitor.CalculateZ(frequency);

			Assert.AreEqual(expected, actual,
				"Метод CalculateZ неправильно расчитывает значения");
		}

		[Test(Description = "Тест метода CalculateZ с отрицательной частотой")]
		public void TestCalculatez_NegativeFrequency()
		{
			_capacitor = CreateTestCapacitor();
			var wrongFrequency = -1;

			Assert.Throws<ArgumentException>(() =>
			{ var result = _capacitor.CalculateZ(wrongFrequency); },
			"Должно возникать исключение, если частота отрицательная");
		}
	}
}
