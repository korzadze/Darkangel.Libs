using System.Linq;

namespace Darkangel.Arrays
{
    public static partial class ArrayHelper
    {
        /// <summary>
        /// <para>Объединить два массива</para>
        /// </summary>
        /// <typeparam name="T">Тип элементов массивов</typeparam>
        /// <param name="array">Исходный массив</param>
        /// <param name="newElements">Добавляемый массив</param>
        /// <returns>Результируюший массив</returns>
        /// <remarks>v.2021.04.18</remarks>
        public static T[] JoinWith<T>(this T[] array, T[] newElements)
        {
            return array.Union(newElements).ToArray();
        }
    }
}
