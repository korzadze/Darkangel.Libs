using System;

namespace Darkangel.Compare
{
    /// <summary>
    /// <para>Небезопасный (без проверки "пустых" значений) класс для сравнения значения с ключем</para>
    /// </summary>
    /// <typeparam name="T">Тип значения</typeparam>
    /// <typeparam name="TKey">Тип ключа</typeparam>
	/// <remarks>2021-04-18</remarks>
    public class UnsafeComparator<T, TKey> : IComparator<T, TKey>
        where T : IComparable<TKey>
    {
        /// <inheritdoc/>
        public int CompareValues(T val, TKey key) =>
            val.CompareTo(key);
    }
}
