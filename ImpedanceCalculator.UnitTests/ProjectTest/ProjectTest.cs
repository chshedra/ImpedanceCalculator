using System;
using System.Collections.Generic;
using NUnit.Framework;
using  System.Numerics;
using ImpedanceCalculator.Circuits;

namespace ImpedanceCalculator.UnitTests.ProjectTest
{
	[TestFixture]
	public class ProjectTest
	{
		private Project _project;

		//TODO: В свойство
		private void InitProject()
		{
			_project = new Project();
		}

		[Test(Description = "Позитивный тест cеттера свойства Circuits")]
		public void TestCircuitsSet_PositiveTest()
		{
			var expected = new List<ISegment>()
			{
				new SerialCircuit(),
				new ParallelCircuit()
			};

			InitProject();
			_project.Circuits = expected;

			Assert.AreEqual(expected, _project.Circuits,
				"Сеттер Circuit неправильно устанавливает значение");
		}

		[Test(Description = "Позитивный тест cеттера свойства Circuits")]
		public void TestCircuitsSet_NullList()
		{
			List<ISegment> nullList = null;
			InitProject();
            //TODO: Если так пишите - выравнивайте хотябы аргументы,
            //а лучше переносите скобочки на отдельные строки, как в методе
			Assert.Throws<ArgumentException>(
				() => { _project.Circuits = nullList; },
				"Должно возникать исключение, если список цепей пустой");
		}

		[Test(Description = "Позитивный тест геттера свойства Circuits")]
		public void TestCircuitsGet_PositiveTest()
		{
			var expected = new List<ISegment>()
			{
				new SerialCircuit(),
				new ParallelCircuit()
			};
			InitProject();
			_project.Circuits = expected;
			var actual = _project.Circuits;
			

			Assert.AreEqual(expected, actual,
				"Геттер Circuit неправильно возвращает значение");
		}

		[Test(Description = "Позитивный тест сеттера свойства Frequencies")]
		public void TestFrequenciesSet_PositiveTest()
		{
			var expected = new List<double>()
			{
				1.1,
				2.2
			};

			InitProject();
			_project.Frequencies = expected;

			Assert.AreEqual(expected, _project.Frequencies,
				"Сеттер Frequencies неправильно устанавливает значение");
		}

		[Test(Description = "Позитивный тест cеттера свойства Circuits")]
		public void TestFrequenciesSet_NullList()
		{
			List<double> nullList = null;
			InitProject();
            //TODO: Если так пишите - выравнивайте хотябы аргументы,
            //а лучше переносите скобочки на отдельные строки, как в методе
			Assert.Throws<ArgumentException>(
				() => { _project.Frequencies = nullList; },
				"Должно возникать исключение, если список частот пустой");
		}

		[Test(Description = "Позитивный тест геттера свойства Circuits")]
		public void TestFrequenciesGet_PositiveTest()
		{
			var expected = new List<double>()
			{
				1.1,
				2.2
			};
			InitProject();
			_project.Frequencies = expected;
			var actual = _project.Frequencies;


			Assert.AreEqual(expected, actual,
				"Геттер Frequencies неправильно возвращает значение");
		}

		[Test(Description = "Позитивный тест сеттера Impedancies")]
		public void TestImpedancesSet_PositiveTest()
		{
			var expected = new List<Complex>()
			{
				new Complex(1, 1),
				new Complex(2, 2)
			};

			InitProject();
			_project.Impendances = expected;

			Assert.AreEqual(expected, _project.Impendances,
				"Сеттер Frequencies неправильно устанавливает значение");
		}

		[Test(Description = "Позитивный тест cеттера свойства Circuits")]
		public void TestImpedancesSet_NullList()
		{
			List<Complex> nullList = null;
			InitProject();

            //TODO: Если так пишите - выравнивайте хотябы аргументы,
            //а лучше переносите скобочки на отдельные строки, как в методе
			Assert.Throws<ArgumentException>(
				() => { _project.Impendances = nullList; },
				"Должно возникать исключение, если список импедансов пустой");
		}

		[Test(Description = "Позитивный тест геттера Impedances")]
		public void TestImpedancesGet_PositiveTest()
		{
			var expected = new List<Complex>()
			{
				new Complex(1, 1),
				new Complex(2, 2)
			};

			InitProject();
			_project.Impendances = expected;
			var actual = _project.Impendances;

			Assert.AreEqual(expected, actual,
				"Геттер Frequencies неправильно устанавливает значение");
		}
	}
}
