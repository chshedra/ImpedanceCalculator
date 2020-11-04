using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ImpedanceCalculator.UnitTests.ElementTests
{
	[TestFixture]
	public class ElementTest
	{
        //TODO: +Все тесты правильнее оформить по методике три AAA https://habr.com/ru/post/169381/

        //TODO: +В чём смысл собирать в метод простой вызов конструктора?
		private ElementBaseInheritor Element => new ElementBaseInheritor();

		[Test(Description = "Позитивный тест геттера Name")]
		public void TestNameGet_CorrectValue()
		{
			var element = new ElementBaseInheritor();
			//Arrange
			var expected = "Name";

			//Act
			element.Name = expected;
			var actual = element.Name;

			//Assert
			Assert.AreEqual(expected, actual,
				"Геттер Name возвращает неправильное название");
		}

		[Test(Description = "Позитивный тест сеттера Name")]
		public void TestNameSet_CorrectValue()
		{
			var element = new ElementBaseInheritor(); ;
			var isCalled = false;
			element.SegmentChanged += (sender, e) => isCalled = true;

			//Arrange
			var expected = "Name";
			element.Name = expected;

			//Act
			var actual = element.Name;

			//Assert
			Assert.AreEqual(expected, actual,
				"Сеттер Name устанавливает неправильное название");
			Assert.IsTrue(isCalled, "Сеттер Name не вызывает событие SegmentChanged");
		}

		[Test(Description = "Негативный тест геттера Name")]
		public void TestNameSet_EmptyName()
		{
			//Arrange
			var emptyName = "";

            //TODO: +Если так пишите - выравнивайте хотябы аргументы,
            //а лучше переносите скобочки на отдельные строки, как в методе
			//Assert, Act
			Assert.Throws<ArgumentException>
			(
				() => { Element.Name = emptyName; },
				"Должно возникать исключение, если имя элемента пустое"
			);
		}

		[Test(Description = "Негативный тест геттера Name")]
		public void TestNameSet_NullName()
		{
			string nullName = null;

            //TODO: +Если так пишите - выравнивайте хотябы аргументы,
            //а лучше переносите скобочки на отдельные строки, как в методе
			Assert.Throws<ArgumentException>
			(
				() => { Element.Name = nullName; },
				"Должно возникать исключение, если имя элемента пустое"
			);
		}

		[Test(Description = "Позитивный тест геттера value")]
		public void TestValueGet_CorrectValue()
		{
			var element = new ElementBaseInheritor();

			//Arrange
			var expected = 12.99;
			element.Value = expected;

			//Act
			var actual = element.Value;

			//Assert
			Assert.AreEqual(expected, actual,
				"Геттер Value возвращает неправильное название");
		}

		[Test(Description = "Позитивный тест сеттера Value")]
		public void TestValueSet_CorrectValue()
		{
			var element = new ElementBaseInheritor();
			var isCalled = false;
			element.SegmentChanged += (sender, e) => isCalled = true;

			//Arrange
			var expected = 0.45;

			//Act
			element.Value = expected;
			var actual = element.Value;

			//Assert
			Assert.AreEqual(expected, actual,
				"Сеттер Value устанавливает неправильное название");
			Assert.IsTrue(isCalled, "Сеттер Value не вызывает событие SegmentChanged");
		}

		[Test(Description = "Негативный тест геттера Name")]
		public void TestValueSet_NegativeValue()
		{
			//Arrange
			double negativeValue = -1;
            //TODO: +Если так пишите - выравнивайте хотябы аргументы,
            //а лучше переносите скобочки на отдельные строки, как в методе
			//Assert
			Assert.Throws<ArgumentException>
			(
				() => { Element.Value = negativeValue; },
				"Должно возникать исключение, если значение отрицательное"
			);
		}

		[Test(Description = "Позитивный тест геттера SubSegments")]
		public void TestSubSegmentsGet_CorrectValue()
		{
			//Arrange
			List<ISegment> expected = null;

			//Act
			var actual = Element.SubSegments;

			//Assert
			Assert.AreEqual(expected, actual,
				"Геттер Name возвращает неправильное название");
		}

		[Test(Description = "Позитивный тест конструктора")]
		public void TestElementConstructor_CorrectValue()
		{
			//Arrange
			var expectedName = "Element";
			var expectedValue = 10;

			//Act
			var element = new ElementBaseInheritor(expectedName, expectedValue);

			//Assert
			Assert.AreEqual(expectedName, element.Name,
				"Конструктор устанавливает неправильное значение имени");
			Assert.AreEqual(expectedValue, element.Value,
				"Конструктор устанавливает неправильное значение");
		}

		[Test(Description = "Негативный тест конструктора Element с null именем")]
		public void TestElementConstructor_NullName()
		{
			//Arrange
			string nullName = null;

            //TODO: +Если так пишите - выравнивайте хотябы аргументы,
            //а лучше переносите скобочки на отдельные строки, как в методе
			//Assert
			Assert.Throws<ArgumentException>
			(
			   () => 
			   {
				   var actual = new ElementBaseInheritor(nullName, 0);
			   },
				"Должно возникать исключение, если имя null"
			);
		}

		[Test(Description = "Негативный тест конструктора Element с пустым именем")]
		public void TestElementConstructor_EmptyName()
		{
			//Arrange
			string emptyName = "";
            //TODO: +Если так пишите - выравнивайте хотябы аргументы,
            //а лучше переносите скобочки на отдельные строки, как в методе

			//Assert
			Assert.Throws<ArgumentException>
			(
			   () => 
			   {
				   var actual = new ElementBaseInheritor(emptyName, 0);
			   },
				"Должно возникать исключение, если имя пустое"
			   );
		}

		[Test(Description = "Негативный тест конструктора Element с пустым именем")]
		public void TestElementConstructor_negativeValue()
		{
			//Arrange
			var negativeValue = -3;
            //TODO: +Если так пишите - выравнивайте хотябы аргументы,
            //а лучше переносите скобочки на отдельные строки, как в методе
			//Assert
			Assert.Throws<ArgumentException>
			(
			   () => 
			   {
				   var actual = new ElementBaseInheritor("Name", negativeValue);
			   },
				"Должно возникать исключение, если значение отрицательное"
			);
		}
	}
}
