using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darkangel.Compare
{
    /// <summary>
    /// <para>Итерфейс сравнения значений</para>
    /// </summary>
    /// <typeparam name="T">Тип значения</typeparam>
    public interface IComparator<T>
        where T : IComparable
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
