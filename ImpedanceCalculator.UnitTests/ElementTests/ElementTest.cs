using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace ImpedanceCalculator.UnitTests.ElementTests
{
	[TestFixture]
	class ElementTest
	{
		private ElementInheritor _element;

		private void InitElement()
		{
			_element = new ElementInheritor();
		}

		[Test(Description = "Позитивный тест геттера Name")]
		public void TestNameGet_CorrectValue()
		{
			InitElement();

			var expected = "Name";
			_element.Name = expected;
			var actual = _element.Name;
			Assert.AreEqual(expected, actual,
				"Геттер Name возвращает неправильное название");
		}

		[Test(Description = "Позитивный тест сеттера Name")]
		public void TestNameSet_CorrectValue()
		{
			InitElement();

			var isCalled = false;
			_element.SegmentChanged += (sender, e) => isCalled = true;

			var expected = "Name";
			_element.Name = expected;

			var actual = _element.Name;
			Assert.AreEqual(expected, actual,
				"Сеттер Name устанавливает неправильное название");
			Assert.IsTrue(isCalled, "Сеттер Name не вызывает событие SegmentChanged");
		}

		[Test(Description = "Негативный тест геттера Name")]
		public void TestNameSet_EmptyName()
		{
			InitElement();
			var emptyName = "";

			Assert.Throws<ArgumentException>(
				() => { _element.Name = emptyName; },
					"Должно возникать исключение, если имя элемента пустое");
		}

		[Test(Description = "Негативный тест геттера Name")]
		public void TestNameSet_NullName()
		{
			InitElement();
			string nullName = null;

			Assert.Throws<ArgumentException>(
				() => { _element.Name = nullName; },
					"Должно возникать исключение, если имя элемента пустое");
		}

		[Test(Description = "Позитивный тест геттера value")]
		public void TestValueGet_CorrectValue()
		{
			InitElement();

			var expected = 12.99;
			_element.Value = expected;
			var actual = _element.Value;
			Assert.AreEqual(expected, actual,
				"Геттер Value возвращает неправильное название");
		}

		[Test(Description = "Позитивный тест сеттера Value")]
		public void TestValueSet_CorrectValue()
		{
			InitElement();

			var isCalled = false;
			_element.SegmentChanged += (sender, e) => isCalled = true;

			var expected = 0.45;
			_element.Value = expected;
			var actual = _element.Value;

			Assert.AreEqual(expected, actual,
				"Сеттер Value устанавливает неправильное название");
			Assert.IsTrue(isCalled, "Сеттер Value не вызывает событие SegmentChanged");
		}

		[Test(Description = "Негативный тест геттера Name")]
		public void TestValueSet_NegativeValue()
		{
			InitElement();
			double negativeValue = -1;

			Assert.Throws<ArgumentException>(
				() => { _element.Value = negativeValue; },
					"Должно возникать исключение, если значение отрицательное");
		}

		[Test(Description = "Позитивный тест геттера SubSegments")]
		public void TestSubSegmentsGet_CorrectValue()
		{
			InitElement();

			List<ISegment> expected = null;
			var actual = _element.SubSegments;
			Assert.AreEqual(expected, actual,
				"Геттер Name возвращает неправильное название");
		}

		[Test(Description = "Позитивный тест конструктора")]
		public void TestElementConstructor_CorrectValue()
		{
			var expectedName = "Element";
			var expectedValue = 10;

			_element = new ElementInheritor(expectedName, expectedValue);

			Assert.AreEqual(expectedName, _element.Name,
				"Конструктор устанавливает неправильное значение имени");
			Assert.AreEqual(expectedValue, _element.Value,
				"Конструктор устанавливает неправильное значение");
		}

		[Test(Description = "Негативный тест конструктора Element с null именем")]
		public void TestElementConstructor_NullName()
		{
			string nullName = null;
			Assert.Throws<ArgumentException>(
			   () => {
				   var actual = new ElementInheritor(nullName, 0);
			   },
				   "Должно возникать исключение, если имя null");
		}

		[Test(Description = "Негативный тест конструктора Element с пустым именем")]
		public void TestElementConstructor_EmptyName()
		{
			string emptyName = "";

			Assert.Throws<ArgumentException>(
			   () => {
				   var actual = new ElementInheritor(emptyName, 0);
			   },
				   "Должно возникать исключение, если имя пустое");
		}

		[Test(Description = "Негативный тест конструктора Element с пустым именем")]
		public void TestElementConstructor_negativeValue()
		{
			var negativeValue = -3;
			Assert.Throws<ArgumentException>(
			   () => {
				   var actual = new ElementInheritor("Name", negativeValue);
			   },
				   "Должно возникать исключение, если значение отрицательное");
		}
	}
}
