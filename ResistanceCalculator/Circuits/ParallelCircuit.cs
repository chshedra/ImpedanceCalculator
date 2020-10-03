using System.Collections.Generic;
using System.Numerics;

namespace ImpedanceCalculator
{
    /// <summary>
	/// Класс параллельной цепи
	/// </summary>
    public class ParallelCircuit : Circuit
    {
        /// <inheritdoc/>
        public ParallelCircuit() : base() { }

        /// <inheritdoc/>
        public ParallelCircuit(List<ISegment> subSegments, string name)
            : base(subSegments, name) { }

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
    }
}
