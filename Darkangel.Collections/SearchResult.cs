namespace Darkangel.Collections
{
    /// <summary>
    /// <para>Результат поиска в сортированном списке</para>
    /// </summary>
    public class SearchResult
	{
		/// <summary>
		/// <para>Поиск прошел удачно.</para>
		/// </summary>
		public bool IsFound { get; internal set; }
		/// <summary>
		/// <para>Поиск прошел неудачно.</para>
		/// </summary>
		public bool IsNotFound => !IsFound;
		/// <summary>
		/// <para>Индекс искомого элемента, если поиск удачен. SearchResult.IsFound</para>
		/// <para>Предполагаемый индекс элемента, если поиск неудачен. !SearchResult.IsFound</para>
		/// </summary>
		public int Index { get; internal set; }
		/// <summary>
		/// <para>Преобразовать значение в bool.</para>
		/// </summary>
		/// <param name="sr">Исходный результат поиска</param>
		public static implicit operator bool(SearchResult sr) => sr.IsFound;
	}
}
