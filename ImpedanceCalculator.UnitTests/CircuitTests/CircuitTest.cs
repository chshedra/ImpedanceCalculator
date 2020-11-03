using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Numerics;
using ImpedanceCalculator.Circuits;
using ImpedanceCalculator.Elements;

namespace ImpedanceCalculator.UnitTests.CircuitTests
{
	//TODO: +RSDN
	[TestFixture]
	public class CircuitTest
	{
		//TODO: Все тесты правильнее оформить по методике три AAA https://habr.com/ru/post/169381/
		private CircuitBaseInheritor _circuit;

        //TODO: Переделать в свойство
		private void InitCircuit ()
		{
			_circuit = new CircuitBaseInheritor(new List<ISegment>(), "Circuit");
		}

        //TODO: Переделать в свойство
		private CircuitBase CreateTestCircuit()
		{

			var R = new Resistor("R", 10.0);
			var L = new Inductor("L1", 0.05);
			var C = new Capacitor("C1", 0.01);
			var circuit = new SerialCircuit();
			var subCircuit = new ParallelCircuit();
			subCircuit.Add(R);
			subCircuit.Add(L);
			circuit.Add(subCircuit);
			circuit.Add(C);
			return circuit;
		}

		[Test(Description = "Позитивный тест геттера Name")]
		public void TestNameGet_CorrectValue()
		{
			InitCircuit();

			var expected = "Name";
			_circuit.Name = expected;
			var actual = _circuit.Name;

			Assert.AreEqual(expected, actual,
				"Геттер Name возвращает неправильное название");
		}

		[Test(Description = "Позитивный тест сеттера Name")]
		public void TestNameSet_CorrectValue()
		{
			InitCircuit();

			var isCalled = false;
			_circuit.SegmentChanged += (o, e) => isCalled = true;

			var expected = "Name";
			_circuit.Name = expected;
			var actual = _circuit.Name;

			Assert.AreEqual(expected, actual,
				"Сеттер Name устанавливает неправильное название");
			Assert.IsTrue(isCalled, "Сеттер Name не вызывает событие SegmenChanged");
		}

		[Test(Description = "Негативный тест геттера Name")]
		public void TestNameSet_EmptyName()
		{
			InitCircuit();
			var emptyName = "";

			Assert.Throws<ArgumentException>
			(
                //TODO: +Если так пишите - выравнивайте хотябы аргументы,
                //а лучше переносите скобочки на отдельные строки, как в методе
                () => { _circuit.Name = emptyName; },
					"Должно возникать исключение, если имя элемента пустое"
            );
		}

		[Test(Description = "Негативный тест геттера Name")]
		public void TestNameSet_NullName()
		{
			InitCircuit();
			string nullName = null;

			Assert.Throws<ArgumentException>(
                //TODO: +Если так пишите - выравнивайте хотябы аргументы,
                //а лучше переносите скобочки на отдельные строки, как в методе
				() => { _circuit.Name = nullName; },
				"Должно возникать исключение, если имя элемента пустое");
		}

		[Test(Description = "Позитивный тест сеттера Name")]
		public void TestCircuitDefaultConstructor_PositiveTest()
		{
			var expectedName = "Circuit";
			var expectedSubSegments = new List<ISegment>();
			_circuit = new CircuitBaseInheritor();
			
			Assert.AreEqual(expectedName, _circuit.Name,
				"Конструктор без прарметров Circuit устанавливает неправильное название");
			Assert.AreEqual(expectedSubSegments, _circuit.SubSegments,
				"Конструктор без прарметров Circuit устанавливает неправильное название");
		}

		[Test(Description = "Позитивный тест сеттера Name")]
		public void TestCircuitConstructor_PositiveTest()
		{
			var expectedName = "NewCircuit";
			List<ISegment> segments = new List<ISegment>();
			segments.Add(new Resistor());

			var expectedSubSegments = segments;
			_circuit = new CircuitBaseInheritor(segments, expectedName);

			Assert.AreEqual(expectedName, _circuit.Name,
				"Конструктор без прарметров Circuit устанавливает неправильное название");
			Assert.AreEqual(expectedSubSegments, _circuit.SubSegments,
				"Конструктор без прарметров Circuit устанавливает неправильное название");
		}

		[Test(Description = "Positive test of the Circuit CalculateZ")]
		public void TestCalculateZ()
		{
			InitCircuit();
			double frequency = 10;
			var r = new Resistor("R", 10.0);
			var l = new Inductor("L1", 0.05);
			var c = new Capacitor("C1", 0.01);

			Complex result1 = 1.0 / r.CalculateZ(frequency) + 1.0 / l.CalculateZ(frequency);
			result1 = 1 / result1;
			Complex result = result1 + c.CalculateZ(frequency);
			var expected = result;

			var actual = CreateTestCircuit().CalculateZ(frequency);

			Assert.AreEqual(expected, actual,
				"Incorrect calculations for the CalculateZ method");
		}


		[Test(Description = "Позитивный тест метода Add")]
		public void TestAdd_PositiveTest()
		{
			InitCircuit();
			var expected = new Resistor();

			_circuit.Add(expected);
			var actual = _circuit[0];

			Assert.AreEqual(expected, actual, "Метод Add некорректно добавляет элементы");
		}

		[Test(Description = "Тест метода Add с null объектом")]
		public void TestAdd_NullObject()
		{
			InitCircuit();

            //TODO: +Если так пишите - выравнивайте хотябы аргументы,
            //а лучше переносите скобочки на отдельные строки, как в методе
			Assert.Throws<ArgumentException>
			(
				() => { _circuit.Add(null); },
				"Должно возникать исключение, если элемент равен null"
			);
		}

		[Test(Description = "Позитивный тест метода Add")]
		public void TestRemove_PositiveTest()
		{
			InitCircuit();

			var element = new Resistor();
			_circuit.Add(element);
			var expected = 0;

			_circuit.Remove(element);
			var actual = _circuit.Count;

			Assert.AreEqual(expected, actual, "Метод Remove некорректно удаляет элементы");
		}

		[Test(Description = "Тест метода Add с null объектом")]
		public void TestRemove_NotContainedElement()
		{
			InitCircuit();
			var element = new Resistor();

            //TODO: +Если так пишите - выравнивайте хотябы аргументы,
            //а лучше переносите скобочки на отдельные строки, как в методе
			Assert.Throws<ArgumentException>
			(
				() => { _circuit.Remove(element); }, 
				"Должно возникать исключение, если элемента нет в списке"
			);
		}

		[Test(Description = "Тест переопределенного метода Contains")]
		public void TestContains_PositiveTest()
		{
			InitCircuit();
			var element = new Resistor();
			_circuit.Add(element);

			Assert.IsTrue(_circuit.Contains(element), 
				"Метод некорректно определяет наличие элемента в списке");
		}

		[Test(Description = "Тест переопределенного метода Clear")]
		public void TestClear_PositiveTest()
		{
			InitCircuit();
			var element = new Resistor();
			_circuit.Add(element);
			_circuit.Add(element);
			_circuit.Clear();

			Assert.IsTrue(_circuit.Count == 0,
				"Метод некорректно определяет наличие элемента в списке");
		}

		[Test(Description = "Тест переопределенного метода IndexOf")]
		public void TestIndexOf_PositiveTest()
		{
			InitCircuit();
			var element = new Resistor();
			_circuit.Add(element);

			var expected = _circuit.SubSegments.IndexOf(element);
			var actual = _circuit.IndexOf(element);

			Assert.AreEqual(expected, actual,
				"Метод IndexOf возвращает непрвильное значение");
		}

		[Test(Description = "Позитивный тест метода Insert")]
		public void TestInsert_PositiveTest()
		{
			InitCircuit();
			var expected = new Resistor();

			_circuit.Insert(0,expected);
			var actual = _circuit[0];

			Assert.AreEqual(expected, actual, "Метод Insert некорректно вставляет элементы");
		}

		[Test(Description = "Тест метода Inert с null объектом")]
		public void TestInsert_NullObject()
		{
			InitCircuit();

            //TODO:+ Если так пишите - выравнивайте хотябы аргументы,
            //а лучше переносите скобочки на отдельные строки, как в методе
			Assert.Throws<ArgumentException>
			(
				() => { _circuit.Insert(0,null); }, 
				"Должно возникать исключение, если элемент равен null"
			);
		}

		[Test(Description = "Позитивный тест метода ISReadOnly")]
		public void TestIsReadOnly_PositiveTest()
		{
			InitCircuit();
			var expected = false;
			Assert.AreEqual(expected, _circuit.IsReadOnly, "Метод Insert некорректно вставляет элементы");
		}
	}
}
