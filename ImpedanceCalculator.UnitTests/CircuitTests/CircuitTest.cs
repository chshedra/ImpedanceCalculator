using System;
using System.Collections.Generic;
using NUnit.Framework;
using System.Numerics;
using ImpedanceCalculator.Circuits;
using ImpedanceCalculator.Elements;

namespace ImpedanceCalculator.UnitTests.CircuitTests
{
	[TestFixture]
	public class CircuitTest
	{
		private CircuitBase EmptyCircuit => 
			new CircuitBaseInheritor(new List<ISegment>(), "Circuit");
		
		private CircuitBase TestCircuit =>
		    new SerialCircuit
			{
				new ParallelCircuit
				{
					new Resistor("R", 10.0),
					new Inductor("L1", 0.05)
				},
				new Capacitor("C1", 0.01)
			};
		

		[Test(Description = "Позитивный тест геттера Name")]
		public void TestNameGet_CorrectValue()
		{
			// Arrange 
			var expected = "Circuit";

			//Act
			var actual = EmptyCircuit.Name;

			// Assert
			Assert.AreEqual(expected, actual,
				"Геттер Name возвращает неправильное название");
		}

		[Test(Description = "Позитивный тест сеттера Name")]
		public void TestNameSet_CorrectValue()
		{
			//Arrange
			var circuit = new CircuitBaseInheritor();

			//Act
			var isCalled = false;
			circuit.SegmentChanged += (o, e) => isCalled = true;

			//Arrange
			var expected = "Name";
			circuit.Name = expected;

			//Act
			var actual = circuit.Name;

			//Assert
			Assert.AreEqual(expected, actual,
				"Сеттер Name устанавливает неправильное название");
			Assert.IsTrue(isCalled, "Сеттер Name не вызывает событие SegmenChanged");
		}

		[Test(Description = "Негативный тест геттера Name")]
		public void TestNameSet_EmptyName()
		{
			//Arrange 
			var emptyName = "";

			//Act, Assert
			Assert.Throws<ArgumentException>
			(
                () => { EmptyCircuit.Name = emptyName; },
				"Должно возникать исключение, если имя элемента пустое"
            );
		}

		[Test(Description = "Негативный тест геттера Name")]
		public void TestNameSet_NullName()
		{
			//Arrange
			string nullName = null;

			//Act, Assert
			Assert.Throws<ArgumentException>
			(
				() => { EmptyCircuit.Name = nullName; },
				"Должно возникать исключение, если имя элемента пустое"
            );
		}

		[Test(Description = "Позитивный тест сеттера Name")]
		public void TestCircuitDefaultConstructor_PositiveTest()
		{
			//Arrange
			var expectedName = "Circuit";
			var expectedSubSegments = new List<ISegment>();
			var circuit = new CircuitBaseInheritor();

			//Act
			var actualName = circuit.Name;
			var actualSubSegments = circuit.SubSegments;

			//Assert
			Assert.AreEqual(expectedName, actualName,
			"Конструктор без прарметров Circuit устанавливает неправильное название");
			Assert.AreEqual(expectedSubSegments, actualSubSegments,
				"Конструктор без прарметров Circuit устанавливает неправильное название");
		}

		[Test(Description = "Позитивный тест сеттера Name")]
		public void TestCircuitConstructor_PositiveTest()
		{
			//Arrange
			var expectedName = "NewCircuit";
			List<ISegment> segments = new List<ISegment>()
			{
				new Resistor()
			};

			var expectedSubSegments = segments;
			var circuit = new CircuitBaseInheritor(segments, expectedName);

			//Act
			var actualName = circuit.Name;
			var actualSubSegments = circuit.SubSegments;

			//Assert
			Assert.AreEqual(expectedName, actualName,
				"Конструктор без прарметров Circuit устанавливает неправильное название");
			Assert.AreEqual(expectedSubSegments, actualSubSegments,
				"Конструктор без прарметров Circuit устанавливает неправильное название");
		}

		[Test(Description = "Positive test of the Circuit CalculateZ")]
		public void TestCalculateZ()
		{
			//Arrange
			double frequency = 10;
			var r = new Resistor("R", 10.0);
			var l = new Inductor("L1", 0.05);
			var c = new Capacitor("C1", 0.01);

			Complex result1 = 1.0 / r.CalculateZ(frequency) + 1.0 / l.CalculateZ(frequency);
			result1 = 1 / result1;
			Complex result = result1 + c.CalculateZ(frequency);
			var expected = result;

			//Act
			var actual = TestCircuit.CalculateZ(frequency);

			//Assert
			Assert.AreEqual(expected, actual,
				"Incorrect calculations for the CalculateZ method");
		}


		[Test(Description = "Позитивный тест метода Add")]
		public void TestAdd_PositiveTest()
		{
			//Arrange
			var expected = new Resistor();
			var circuit = new CircuitBaseInheritor();
			circuit.Add(expected);

			//Act
			var actual = circuit[0];

			//Assert
			Assert.AreEqual(expected, actual, "Метод Add некорректно добавляет элементы");
		}

		[Test(Description = "Тест метода Add с null объектом")]
		public void TestAdd_NullObject()
		{
            //Assert
			Assert.Throws<ArgumentException>
			(
				//Act
				() => { EmptyCircuit.Add(null); },
				"Должно возникать исключение, если элемент равен null"
			);
		}

		[Test(Description = "Позитивный тест метода Add")]
		public void TestRemove_PositiveTest()
		{
			//Arrange
			var element = new Resistor();
			var circuit = new CircuitBaseInheritor();
			circuit.Add(element);
			circuit.Remove(element);
			var expected = 0;

			//Act
			var actual = circuit.Count;

			//Assert
			Assert.AreEqual(expected, actual, "Метод Remove некорректно удаляет элементы");
		}

		[Test(Description = "Тест метода Add с null объектом")]
		public void TestRemove_NotContainedElement()
		{
			//Arrange
			var element = new Resistor();

			//Assert
			Assert.Throws<ArgumentException>
			(
				//Act
				() => { EmptyCircuit.Remove(element); },
				"Должно возникать исключение, если элемента нет в списке"
			);
		}

		[Test(Description = "Тест переопределенного метода Contains")]
		public void TestContains_PositiveTest()
		{
			//Arrange
			var element = new Resistor();
			var circuit = new CircuitBaseInheritor();
			circuit.Add(element);

			//Assert
			Assert.IsTrue
			(
				//Act
				circuit.Contains(element), 
				"Метод некорректно определяет наличие элемента в списке"
			);
		}

		[Test(Description = "Тест переопределенного метода Clear")]
		public void TestClear_PositiveTest()
		{
			//Arrange
			var element = new Resistor();
			EmptyCircuit.Add(element);
			EmptyCircuit.Add(element);
			EmptyCircuit.Clear();

			//Assert
			Assert.IsTrue
			(
				//Act
				EmptyCircuit.Count == 0,
				"Метод некорректно определяет наличие элемента в списке"
			);
		}

		[Test(Description = "Тест переопределенного метода IndexOf")]
		public void TestIndexOf_PositiveTest()
		{
			//Arrange
			var element = new Resistor();
			EmptyCircuit.Add(element);
			var expected = EmptyCircuit.SubSegments.IndexOf(element);

			//Act
			var actual = EmptyCircuit.IndexOf(element);

			//Assert
			Assert.AreEqual(expected, actual,
				"Метод IndexOf возвращает непрвильное значение");
		}

		[Test(Description = "Позитивный тест метода Insert")]
		public void TestInsert_PositiveTest()
		{
			//Arrange
			var expected = new Resistor();
			var circuit = new CircuitBaseInheritor();
			circuit.Insert(0,expected);

			//Act
			var actual = circuit[0];

			//Assert
			Assert.AreEqual(expected, actual, "Метод Insert некорректно вставляет элементы");
		}

		[Test(Description = "Тест метода Inert с null объектом")]
		public void TestInsert_NullObject()
		{
			//Assert
			Assert.Throws<ArgumentException>
			(
				//Act
				() => { EmptyCircuit.Insert(0,null); }, 
				"Должно возникать исключение, если элемент равен null"
			);
		}

		[Test(Description = "Позитивный тест метода ISReadOnly")]
		public void TestIsReadOnly_PositiveTest()
		{
			//Arrange
			var expected = false;

			//Assert, Act
			Assert.AreEqual(expected, EmptyCircuit.IsReadOnly, "Метод Insert некорректно вставляет элементы");
		}
	}
}
