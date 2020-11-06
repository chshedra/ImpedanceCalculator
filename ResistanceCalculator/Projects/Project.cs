using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using ImpedanceCalculator.Circuits;

namespace ImpedanceCalculator.Projects 
{
	/// <summary>
	/// Класс для хранения цепи
	/// </summary>
	[Serializable]
	public class Project 
	{
		#region Public Properties

		/// <summary>
		/// Устанавливает и возвращает список цепей
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public List<ISegment> Circuits { get; set; }

		/// <summary>
		/// Устанавливает и возвращает список частот
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public List<double> Frequencies { get; set; }

		/// <summary>
		/// Устанавливает и возвращает список импедансов итоговых цепей
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
