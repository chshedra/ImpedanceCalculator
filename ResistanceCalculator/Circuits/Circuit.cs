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
        /// <summary>
        /// Хранит значение имени цепи
        /// </summary>
        private string _name;

        /// <summary>
        /// Хранит список сегментов цепи
        /// </summary>
        private List<ISegment> _segments;

        /// <inheritdoc/>
        public string Name 
        { 
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException($"The {nameof(Name)} must have a value");
                }

                _name = value;
                SegmentChanged?.Invoke(this, EventArgs.Empty);
            }
        }

       /// <summary>
       /// Возвращает и устанавливает список элементов цепи
       /// </summary>
        public List<ISegment> SubSegments 
        { 
            get
            {
                return _segments;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException($"The {nameof(Name)} must have a value");
                }

                _segments = value;
                SegmentChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <inheritdoc/>
        public event EventHandler CircuitChanged;

        /// <inheritdoc/>
        public event EventHandler SegmentChanged;

        /// <summary>
        /// Метод, вызывающий событие CircuitChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCircuitChanged(object sender, EventArgs e)
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

        /// <inheritdoc />
        public abstract Complex CalculateZ(double frequency) ;

        #region IList members

        /// <inheritdoc/>
        public void Add(ISegment segment)
        {
            if (segment == null)
            {
                throw new ArgumentException($"{nameof(Name)} must not be null");
            }

            if (segment is IElement)
            {
                segment.SegmentChanged += OnCircuitChanged;
            }
            else
            {
                foreach(var element in segment.SubSegments)
                {
                    element.SegmentChanged -= ((Circuit)segment).OnCircuitChanged;
                    element.SegmentChanged += OnCircuitChanged;
                }
                segment.SegmentChanged += OnCircuitChanged;
            }
            
            SubSegments.Add(segment);            
        }

        /// <inheritdoc/>
        public bool Remove(ISegment segment)
        {
            if (segment == null)
            {
                throw new ArgumentException($"{nameof(Name)} must not be null");
            }

            if (!SubSegments.Contains(segment))
            {
                throw new ArgumentException($"Circuit does not contain " +
                    $"segment with name {nameof(Name)}");
            }
            
            if (segment is IElement)
            {
                segment.SegmentChanged -= OnCircuitChanged;
            }
            else
            {
                foreach(var removeSegment in segment.SubSegments)
                {
                    removeSegment.SegmentChanged -= OnCircuitChanged;
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
            SubSegments.Clear();    
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
                throw new ArgumentException($"{ nameof(Name) } must not be null");
            }
            if (SubSegments.Contains(segment))
            {
                throw new ArgumentException($"Segment with name {nameof(Name)} already exists");
            }
            if (segment is IElement)
            {
                segment.SegmentChanged += OnCircuitChanged;
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
