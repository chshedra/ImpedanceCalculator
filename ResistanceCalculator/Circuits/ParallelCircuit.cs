using System;
using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceCalculator.Circuits
{
    /// <summary>
	/// Класс параллельной цепи
	/// </summary>
    [Serializable]
    public class ParallelCircuit : CircuitBase
    {
	    #region Constructors

	    /// <inheritdoc/>
        public ParallelCircuit() : base() { }

        /// <inheritdoc/>
        public ParallelCircuit(List<ISegment> subSegments, string name)
            : base(subSegments, name) { }

        #endregion

        #region Methods

        /// <inheritdoc />
        public override Complex CalculateZ(double frequency)
        {
            Complex result = new Complex();
            foreach (ISegment segment in SubSegments)
            {
                result += 1 / segment.CalculateZ(frequency);
            }

            return 1 / result;
        }

		#endregion
    }
}
