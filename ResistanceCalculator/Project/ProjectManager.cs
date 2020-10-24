using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

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
		/// Сериализует данные в файл.
		/// </summary>
		/// <typeparam name="T">Тип сериализуемых данных.</typeparam>
		/// <param name="fileName">Имя файла.</param>
		/// <param name="container">Контейнер который требуется сериализовать.</param>
		public static void SerializeBinary<T>(string fileName, T container)
		{
			var formatter = new BinaryFormatter();
			using (var serializeFileStream = new FileStream(fileName, FileMode.OpenOrCreate))
			{
				formatter.Serialize(serializeFileStream, container);
			}
		}

		/// <summary>
		/// Десериализует данные из файла.
		/// </summary>
		/// <typeparam name="T">Тип десериализуемых данных.</typeparam>
		/// <param name="fileName">Имя файла.</param>
		/// <param name="container">Контейнер, куда будет записано содержимое.</param>
		public static void DeserializeBinary<T>(string fileName, ref T container)
		{
			var formatter = new BinaryFormatter();
			using (var deserializeFile = new FileStream(fileName, FileMode.OpenOrCreate))
			{
				if (deserializeFile.Length > 0)
				{
					container = (T)formatter.Deserialize(deserializeFile);
					deserializeFile.Close();
				}
				else
				{
					throw new ArgumentException("Empty file");
				}
			}
		}
    }
}
