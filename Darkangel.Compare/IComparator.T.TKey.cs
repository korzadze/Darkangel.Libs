using System;

namespace Darkangel.Compare
{
    /// <summary>
    /// <para>Итерфейс сравнения значения с ключем</para>
    /// </summary>
    /// <typeparam name="T">Тип значения</typeparam>
    /// <typeparam name="TKey">Тип ключа</typeparam>
	/// <remarks>2021-04-18</remarks>
    public interface IComparator<T, TKey>
        where T : IComparable<TKey>
    {
        /// <summary>
        /// <para>Сравнить значение с ключем</para>
        /// </summary>
        /// <param name="val">Сравниваемое значение</param>
        /// <param name="key">Ключ для сравниения</param>
        /// <returns>Результат сравнения</returns>
        int CompareValues(T val, TKey key);
    }
}
