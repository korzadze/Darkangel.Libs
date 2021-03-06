using System;

namespace Darkangel.Compare
{
    /// <summary>
    /// <para>Небезопасный (без проверки "пустых" значений) класс для сравнения двух значений</para>
    /// </summary>
    /// <typeparam name="T">Тип значений</typeparam>
	/// <remarks>2021-04-18</remarks>
    public class UnsafeComparatorOf<T> : IComparatorOf<T>
        where T : IComparable<T>
    {
        /// <inheritdoc/>
        public int CompareValues(T val1, T val2) =>
            val1.CompareTo(val2);
    }
}
