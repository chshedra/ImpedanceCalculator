using System;
using System.Numerics;
using NUnit.Framework;
using ImpedanceCalculator.Elements;

namespace ImpedanceCalculator.UnitTests.ElementTests
{
	[TestFixture]
	class ResistorTest
	{
        //TODO: Все тесты правильнее оформить по методике три AAA https://habr.com/ru/post/169381/

		//TODO: Зачем?
		private Resistor _resistor;

		//TODO: Не используется
		private void ResistorInit()
		{
			_resistor = new Resistor();
		}

		//TODO: В свойство
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

            //TODO: Если так пишите - выравнивайте хотябы аргументы,
            //а лучше переносите скобочки на отдельные строки, как в методе
			Assert.Throws<ArgumentException>(() =>
			{ var result = _resistor.CalculateZ(wrongFrequency); }, 
			"Должно возникать исключение, если частота отрицательная");
		}
	}
}
