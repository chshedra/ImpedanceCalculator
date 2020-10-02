namespace ImpedanceCalculator
{
	/// <summary>
	/// Интерфейс д
	/// </summary>
	public interface IElement : ISegment
	{
		/// <summary>
		///  Устанавливает и возвращает значение элемента
		/// </summary>
		double Value { get; set; }
	}
}
