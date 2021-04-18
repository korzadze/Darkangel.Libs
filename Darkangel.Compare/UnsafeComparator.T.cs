using System;
using System.Collections;

namespace Darkangel.Compare
{
    /// <summary>
    /// <para>Небезопасный (без проверки "пустых" значений) класс для сравниения двух значений</para>
    /// </summary>
    /// <typeparam name="T">Тип значений</typeparam>
    public class UnsafeComparator<T>: IComparator<T>
        where T : IComparable
    {
        /// <inheritdoc/>
        public int CompareValues(T val1, T val2) =>
            val1.CompareTo(val2);
    }
}
