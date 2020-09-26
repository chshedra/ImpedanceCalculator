using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;


namespace ImpedanceCalculator
{
    /// <summary>
    /// Базовый абстрактный класс для реализации параллелльной и
    /// полседовательной цепей
    /// </summary>
    public abstract class Circuit : ISegment, IList<ISegment>
    {
        /// <inheritdoc/>
        public string Name { get; set; }

       /// <summary>
       /// Возвращает и устанавливает список элементов цепи
       /// </summary>
        public List<ISegment> SubSegments { get; private set; }

        /// <inheritdoc/>
        public event EventHandler CircuitChanged;

        /// <inheritdoc/>
        public event EventHandler SegmentChanged;

        /// <inheritdoc />
        public virtual Complex CalculateZ(double frequency) => new Complex(0, 0);

        /// <summary>
        /// Метод, вызывающий событие CircuitChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCircuitChange(object sender, EventArgs e)
        {
            CircuitChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Базовый конструктор цепи без параметров
        /// </summary>
        public Circuit() : this(new List<ISegment>(), "Circuit") { }

        /// <summary>
        /// Базовый конструктор цепи с параметрами
        /// </summary>
        /// <param name="subSegments"></param>
        /// <param name="name"></param>
        public Circuit(List<ISegment> subSegments, string name)
        {
            SubSegments = subSegments;
            Name = name;
        }

		#region IList members

		/// <inheritdoc/>
		public void Add(ISegment segment)
        {
            if (segment == null)
            {
                throw new ArgumentException(" ");
            }

            if (segment is IElement)
            {
                segment.SegmentChanged += OnCircuitChange;
            }
            else
            {
                foreach(var element in segment.SubSegments)
                {
                    element.SegmentChanged -= ((Circuit)segment).OnCircuitChange;
                    element.SegmentChanged += OnCircuitChange;
                }
                segment.SegmentChanged += OnCircuitChange;
            }
            
            SubSegments.Add(segment);

            
        }

        /// <inheritdoc/>
        public bool Remove(ISegment segment)
        {
            if (segment == null)
            {
                throw new ArgumentException(" ");
            }

            if (!SubSegments.Contains(segment))
            {
                throw new ArgumentException($"Circuit does not contain " +
                    $"segment with name {nameof(Name)}");
            }
            
            if (segment is IElement)
            {
                segment.SegmentChanged -= OnCircuitChange;
            }
            else
            {
                foreach(var removeSegment in segment.SubSegments)
                {
                    removeSegment.SegmentChanged -= OnCircuitChange;
                }
            }

            SegmentChanged?.Invoke(this, EventArgs.Empty);

            return SubSegments.Remove(segment);
        }

        /// <inheritdoc/>
        public void RemoveAt(int index)
        {
            SubSegments.RemoveAt(index);
        }

        /// <inheritdoc/>
        public ISegment this[int index]
        {
            get
            {
                return SubSegments[index];
            }
            set
            {
                SubSegments[index] = value;
            }
        }

        /// <inheritdoc/>
        public void Clear()
        {
            foreach(var segment in SubSegments)
            {
                this.Remove(segment);
            }
        }

        /// <inheritdoc/>
        public bool Contains(ISegment containSegment)
        {
            foreach(var segment in SubSegments)
            {
                if(containSegment == segment)
                {
                    return true;
                }
            }

            return false;
        }

        /// <inheritdoc/>
        public int IndexOf(ISegment segment) => SubSegments.IndexOf(segment);

        /// <inheritdoc/>
        public void Insert(int index, ISegment segment)
        {
            if (segment == null)
            {
                throw new ArgumentException(" ");
            }
            if (SubSegments.Contains(segment))
            {
                throw new ArgumentException($"Segment with name {nameof(Name)} already exists");
            }
            if (segment is IElement)
            {
                segment.SegmentChanged += OnCircuitChange;
            }

            SubSegments.Insert(index, segment);
        }

        /// <inheritdoc/>
        public bool IsFixedSize => false;

        /// <inheritdoc/>
        public bool IsReadOnly => false;

        /// <inheritdoc/>
        public int Count => SubSegments.Count();

        /// <inheritdoc />
        public IEnumerator<ISegment> GetEnumerator() => SubSegments.GetEnumerator();

        /// <inheritdoc />
        IEnumerator IEnumerable.GetEnumerator() => SubSegments.GetEnumerator();

        /// <inheritdoc />
        public void CopyTo(ISegment[] array, int index) => SubSegments.CopyTo(array, index);
		#endregion
	}
}
