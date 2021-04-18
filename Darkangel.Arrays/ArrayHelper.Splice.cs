using System;

namespace Darkangel.Arrays
{
    public static partial class ArrayHelper
    {
        /// <summary>
        /// <para>Создать копию части одномерного массива</para>
        /// </summary>
        /// <typeparam name="T">Тип элементов массива</typeparam>
        /// <param name="array">Исходный массив</param>
        /// <param name="start">Первый копируемый элемент массива</param>
        /// <param name="length">Количество копируемых элементов массива</param>
        /// <returns>Вырезанный субвектор</returns>
        /// <remarks>v.2021.04.18</remarks>
        public static T[] Splice<T>(this T[] array, long start, long length)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = array ?? throw new ArgumentNullException(nameof(array));
            if ((start < 0) || (start >= array.LongLength))
                throw new ArgumentOutOfRangeException(nameof(start));
            if (length < 0)
                throw new ArgumentOutOfRangeException(nameof(length));
            if ((start + length) > array.LongLength)
                throw new IndexOutOfRangeException(nameof(length));
#endif
            #endregion Check arguments
            var res = new T[length];
            Array.Copy(array, start, res, 0, length);

            return res;
        }
        /// <summary>
        /// <para>Создать копию части одномерного массива</para>
        /// </summary>
        /// <typeparam name="T">Тип элементов массива</typeparam>
        /// <param name="array">Исходный массив</param>
        /// <param name="start">Первый копируемый элемент массива</param>
        /// <returns>Вырезанный субвектор</returns>
        /// <remarks>v.2021.04.18</remarks>
        public static T[] Splice<T>(this T[] array, long start)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = array ?? throw new ArgumentNullException(nameof(array));
#endif
            #endregion

            return Splice(array, start, array.LongLength - start);
        }
    }
}
