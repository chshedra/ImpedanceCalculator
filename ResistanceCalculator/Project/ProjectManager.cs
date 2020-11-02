using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//TODO: Несоответствие дефолтному namespace
namespace ImpedanceCalculator
{
	/// <summary>
	/// Класс, содержащий метода для загрузки объекта Project из файла
	/// и созранения в файл
	/// </summary>
	public static class ProjectManager
	{
		/// <summary>
		/// Хранит путь к файлу для записи
		/// </summary>
		public static string DefaultPath { get; private set; } =
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
			"\\ImpedanceCalculator\\ImpedanceCalculator.note";


		/// <summary>
		/// Сериализует данные в файл
		/// </summary>
		public static void SaveToFile(string fileName, object container)
		{
			//TODO: RSDN
			string DefaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
			                          "\\ImpedanceCalculator";

			if (!Directory.Exists(DefaultDirectory))
			{
				Directory.CreateDirectory(DefaultDirectory);
			}

			var formatter = new BinaryFormatter();
			using (var serializeFileStream = new FileStream(fileName, FileMode.OpenOrCreate))
			{
				formatter.Serialize(serializeFileStream, container);
			}
		}

		/// <summary>
		/// Десериализует данные из файла
		/// </summary>
		public static Project LoadFromFile(string fileName)
		{
			Project project;
			if (!File.Exists(fileName))
			{
				project = new Project();
			}
			else
			{
				var formatter = new BinaryFormatter();
				using (var deserializeFile = new FileStream(fileName, FileMode.OpenOrCreate))
				{
					if (deserializeFile.Length > 0)
					{
						project = (Project) formatter.Deserialize(deserializeFile);  
						deserializeFile.Close();
					}
					else
					{
						throw new ArgumentException("Empty file");
					}
				}
			}

			return project;
		}
    }
}
