using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using ImpedanceCalculator.Circuits;

namespace ImpedanceCalculator 
{
	/// <summary>
	/// Класс для хранения цепи
	/// </summary>
	[Serializable]
	public class Project : ICloneable
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

		#region Methods

		/// <inheritdoc />
		public object Clone()
		{
			var proj = new Project
			{
				Circuits = new List<ISegment>(),
				Frequencies = new List<double>(),
				Impendances = new List<Complex>()
			};
			foreach (double f in Frequencies)
			{
				proj.Frequencies.Add(f);
			}
			foreach (Complex impedance in Impendances)
			{
				proj.Impendances.Add(impedance);
			}

			foreach (ISegment segment in Circuits)
			{
				if (segment is CircuitBase circuit)
				{
					proj.Circuits.Add((CircuitBase)circuit.Clone());
				}
			}
			return proj;
		}

		#endregion
	}
}
