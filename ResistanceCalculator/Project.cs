using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.Remoting.Messaging;

namespace ImpedanceCalculator
{
	/// <summary>
	/// Класс для хранения цепи
	/// </summary>
	public class Project
	{
		/// <summary>
		/// Список, хранящий цепи
		/// </summary>
		private List<ISegment> _circuits;

		/// <summary>
		/// Список, хранящий значения частот
		/// </summary>
		private List<double> _frequencies;

		/// <summary>
		/// Список, хранящий значения импедансов
		/// </summary>
		private List<Complex> _impedances;


		/// <summary>
		/// Устанавливает и возвращает список цепей
		/// </summary>
		public List<ISegment> Circuits
		{
			get =>  _circuits;
			//TODO: Непонятно, зачем нужен set
			set
			{
				if (value == null)
				{
					throw new ArgumentException($" {nameof(_frequencies)} can not be null");
				}
				
				_circuits = value;
			}
		}

		/// <summary>
		/// Устанавливает и возвращает список частот
		/// </summary>
		public List<double> Frequencies
		{
			get => _frequencies;
            //TODO: Непонятно, зачем нужен set
			set
			{
				if (value == null)
				{
					throw new ArgumentException($" {nameof(_frequencies)} can not be null");
				}
				
				_frequencies = value;
				
			}
		}


		/// <summary>
		/// Устанавливает и возвращает список импедансов итоговых цепей
		/// </summary>
		public List<Complex> Impendances
		{
			get => _impedances;
            //TODO: Непонятно, зачем нужен set
			set
			{
				if (value == null)
				{
					throw new ArgumentException($" {nameof(_impedances)} can not be null");
				}

				_impedances = value;
			}
		}

		public Project()
		{
			Circuits = new List<ISegment>();
			Frequencies = new List<double>();
			Impendances = new List<Complex>();
		}

	}
}
