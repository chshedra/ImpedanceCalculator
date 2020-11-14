using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ImpedanceCalculator.Projects
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
		public static string DefaultPath { get; } =
			Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) +
			"\\ImpedanceCalculator\\ImpedanceCalculator.note";


		/// <summary>
		/// Сериализует данные в файл
		/// </summary>
		public static void SaveToFile(string fileName, object container)
		{
			string defaultDirectory = 
				Environment.GetFolderPath(Environment.
					SpecialFolder.ApplicationData) +
				"\\ImpedanceCalculator";

			if (!Directory.Exists(defaultDirectory))
			{
				Directory.CreateDirectory(defaultDirectory);
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
				try
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
							project = new Project();
						}
					}
				}
				catch (SerializationException)
				{
					project= new Project();
				}
			}

			return project;
		}
    }
}
