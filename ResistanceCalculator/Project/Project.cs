using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using ImpedanceCalculator.Circuits;

//TODO: Несоответствие дефолтному namespace
namespace ImpedanceCalculator 
{
	/// <summary>
	/// Класс для хранения цепи
	/// </summary>
	[Serializable]
	public class Project : ICloneable
	{
		#region Private Fields

		/// <summary>
		/// Хранит список цепей
		/// </summary>
		private List<ISegment> _circuits;

		/// <summary>
		/// Хранит список импедансов
		/// </summary>
		private List<Complex> _impedances;

		/// <summary>
		/// Хранит список частот
		/// </summary>
		private List<double> _frequencies;

		#endregion


		#region Public Properties

		/// <summary>
		/// Устанавливает и возвращает список цепей
		/// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public List<ISegment> Circuits
		{
			get;
			set;
		}

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

		#region Methods

		/// <inheritdoc />
		public object Clone()
		{
			var project = new Project
			{
				Circuits = new List<ISegment>(),
				Frequencies = new List<double>(),
				Impendances = new List<Complex>()
			};
			foreach (double f in Frequencies)
			{
				project.Frequencies.Add(f);
			}
			foreach (Complex impedance in Impendances)
			{
				project.Impendances.Add(impedance);
			}

			foreach (ISegment segment in Circuits)
			{
				if (segment is CircuitBase circuit)
				{
					project.Circuits.Add((CircuitBase)circuit.Clone());
				}
			}
			return project;
		}

		#endregion
	}
}
