using System;
using System.Collections.Generic;

namespace Darkangel.Collections
{
    public static partial class CollectionHelper
    {
        /// <summary>
        /// <para>Проверка на наличие значения в списке</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Список значений</param>
        /// <param name="value">Искомое значение</param>
        /// <returns>Результат проверки</returns>
        /// <remarks>2021-04-18</remarks>
        public static bool Contains<T>(this IEnumerable<T> list, T value)
            where T : IEquatable<T>
        {
            if (list != null)
            {
                foreach (var item in list)
                {
                    if (item.Equals(value)) return true;
                }
            }
            return false;
        }
    }
}
