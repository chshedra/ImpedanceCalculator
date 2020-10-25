using System.Collections.Generic;
using NUnit.Framework;
using System.IO;
using System.Numerics;
using System.Reflection;
using ImpedanceCalculator.Circuits;
using ImpedanceCalculator.Elements;

namespace ImpedanceCalculator.UnitTests.ProjectTest
{
	[TestFixture]
	public class ProjecrManagerTest
	{
		/// <summary>
		/// Путь до  эталонного файла
		/// </summary>
		private string _etalonFileLocation = Path.GetDirectoryName
			(Assembly.GetExecutingAssembly().Location) + "//TestData//TestData.txt";

		/// <summary>
		/// Путь до создаваемого файла для сохранения данных
		/// </summary>
		private string _savePath = Path.GetDirectoryName
			(Assembly.GetExecutingAssembly().Location) + "//TestData//SaveTestData.txt";

		/// <summary>
		/// Путь до эталонного поврежденного файла
		/// </summary>
		private string _etalonDamageFile = Path.GetDirectoryName
			(Assembly.GetExecutingAssembly().Location) + "//TestData//DamageFile.txt";

		private Project InitProject()
		{
			var r = new Resistor("R", 10);
			var circuit = new SerialCircuit(new List<ISegment>() { r }, "Circuit");
			var project = new Project()
			{
				Circuits = new List<ISegment>() {circuit},
				Frequencies = new List<double>() {1},
				Impendances = new List<Complex>() {new Complex(1, 0)}
			};

			return project;
		}

		[Test(Description = "Позитивный тест метод LoadFromFile с существующим путем." +
		                    "Должен вернуть проект со значениями")]
		public void TestLoadFromFile_ExistentPath()
		{
			var expected = InitProject();
			var actual = ProjectManager.LoadFromFile(_etalonFileLocation);

			

		}
	}
}
