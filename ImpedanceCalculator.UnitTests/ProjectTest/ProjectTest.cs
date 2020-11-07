using System;
using System.Collections.Generic;
using NUnit.Framework;
using  System.Numerics;
using ImpedanceCalculator.Circuits;
using ImpedanceCalculator.Projects;

namespace ImpedanceCalculator.UnitTests.ProjectTest
{
	[TestFixture]
	public class ProjectTest
	{
        [Test(Description = "Позитивный тест cеттера свойства Circuits")]
		public void TestCircuitsSet_PositiveTest()
		{
			//Arrange
			var expected = new List<ISegment>()
			{
				new SerialCircuit(),
				new ParallelCircuit()
			};
			var project = new Project();
			project.Circuits = expected;

			//Assert, Act
			Assert.AreEqual(expected, project.Circuits,
				"Сеттер Circuit неправильно устанавливает значение");
		}

		[Test(Description = "Позитивный тест геттера свойства Circuits")]
		public void TestCircuitsGet_PositiveTest()
		{
			//Arrange
			var expected = new List<ISegment>()
			{
				new SerialCircuit(),
				new ParallelCircuit()
			};
			var project = new Project();
			project.Circuits = expected;

			//Act
			var actual = project.Circuits;
			
			//Assert
			Assert.AreEqual(expected, actual,
				"Геттер Circuit неправильно возвращает значение");
		}

		[Test(Description = "Позитивный тест сеттера свойства Frequencies")]
		public void TestFrequenciesSet_PositiveTest()
		{
			//Arrange
			var expected = new List<double>()
			{
				1.1,
				2.2
			};
			var project = new Project();
			project.Frequencies = expected;

			//Assert, Act
			Assert.AreEqual(expected, project.Frequencies,
				"Сеттер Frequencies неправильно устанавливает значение");
		}

		[Test(Description = "Позитивный тест геттера свойства Circuits")]
		public void TestFrequenciesGet_PositiveTest()
		{
			//Arrange
			var expected = new List<double>()
			{
				1.1,
				2.2
			};
			var project = new Project();
			project.Frequencies = expected;

			//Act
			var actual = project.Frequencies;

			//Assert
			Assert.AreEqual(expected, actual,
				"Геттер Frequencies неправильно возвращает значение");
		}

		[Test(Description = "Позитивный тест сеттера Impedancies")]
		public void TestImpedancesSet_PositiveTest()
		{
			//Arrange
			var expected = new List<Complex>()
			{
				new Complex(1, 1),
				new Complex(2, 2)
			};
			var project = new Project();
			project.Impendances = expected;

			//Act
			var actualImpedances = project.Impendances;

			//Assert
			Assert.AreEqual(expected, actualImpedances,
				"Сеттер Frequencies неправильно устанавливает значение");
		}

		[Test(Description = "Позитивный тест геттера Impedances")]
		public void TestImpedancesGet_PositiveTest()
		{
			//Arrange
			var expected = new List<Complex>()
			{
				new Complex(1, 1),
				new Complex(2, 2)
			};
			var project = new Project();
			project.Impendances = expected;

			//Act
			var actual = project.Impendances;

			//Assert
			Assert.AreEqual(expected, actual,
				"Геттер Frequencies неправильно устанавливает значение");
		}
	}
}
