using System;

namespace Darkangel.Compare
{
    /// <summary>
    /// <para>Итерфейс сравнения значений</para>
    /// </summary>
    /// <typeparam name="T">Тип значения</typeparam>
	/// <remarks>2021-04-18</remarks>
    public interface IComparatorOf<T>
        where T : IComparable<T>
    {
        /// <summary>
        /// <para>Сравнить два значения</para>
        /// </summary>
        /// <param name="val1">Первое значение</param>
        /// <param name="val2">Второе значение</param>
        /// <returns>Результат сравнения</returns>
        int CompareValues(T val1, T val2);
    }
}
