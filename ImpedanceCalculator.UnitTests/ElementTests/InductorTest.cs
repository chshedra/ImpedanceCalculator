using System;
using NUnit.Framework;
using System.Numerics;
using ImpedanceCalculator.Elements;

namespace ImpedanceCalculator.UnitTests.ElementTests
{
	[TestFixture]
	class InductorTest
	{
        //TODO: Все тесты правильнее оформить по методике три AAA https://habr.com/ru/post/169381/
        //TODO: Зачем?
		private Inductor _inductor;

        //TODO: Не используется
		private void InductorInit()
		{
			_inductor = new Inductor();
		}

        //TODO: В свойство
		private Inductor CreateTestInductor()
		{
			//TODO: RSDN
			var L = new Inductor("TestResistor", 0.05);
			return L;
		}

		[Test(Description = "Позитивный тест конструктора Inductor ")]
		public void TestConstructor_PositiveTest()
		{
			var expectedName = "L";
			double expectedValue = 0;

			var actualCapacitor = new Inductor();

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

            //TODO: Если так пишите - выравнивайте хотябы аргументы,
            //а лучше переносите скобочки на отдельные строки, как в методе
			Assert.Throws<ArgumentException>(() =>
			{ var result = _inductor.CalculateZ(wrongFrequency); },
			"Должно возникать исключение, если частота отрицательная");
		}
	}
}
