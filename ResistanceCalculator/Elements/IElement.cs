namespace ImpedanceCalculator
{
	/// <summary>
	/// Интерфейс элемента цепи
	/// </summary>
	public interface IElement : ISegment
	{
		/// <summary>
		///  Устанавливает и возвращает значение элемента
		/// </summary>
		double Value { get; set; }
	}
}
