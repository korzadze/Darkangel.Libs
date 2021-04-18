using System;
using System.Collections;

namespace Darkangel.Compare
{
    /// <summary>
    /// <para>Небезопасный (без проверки "пустых" значений) класс для сравниения значения с ключем</para>
    /// </summary>
    /// <typeparam name="T">Тип значения</typeparam>
    /// <typeparam name="TKey">Тип ключа</typeparam>
    public class UnsafeComparator<T, TKey> : IComparator<T, TKey>
        where T : IComparable<TKey>
    {
        /// <inheritdoc/>
        public int CompareValues(T val, TKey key) =>
            val.CompareTo(key);
    }
}
