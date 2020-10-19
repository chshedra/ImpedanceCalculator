using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceCalculator
{
	/// <summary>
	/// Класс для хранения цепи
	/// </summary>
	public class Project
	{
		#region Public Properties

		/// <summary>
		/// Устанавливает и возвращает список цепей
		/// </summary>
		public List<ISegment> Circuits { get; set; }

		/// <summary>
		/// Устанавливает и возвращает список частот
		/// </summary>
		public List<double> Frequencies { get; set; }

		/// <summary>
		/// Устанавливает и возвращает список импедансов итоговых цепей
		/// </summary>
		public List<Complex> Impendances { get; set; }

		#endregion

		#region Constructors

		public Project()
		{
			Circuits = new List<ISegment>();
			Frequencies = new List<double>();
			Impendances = new List<Complex>();
		}

		#endregion
	}
}
