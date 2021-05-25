using System;

namespace Darkangel.Arrays
{
    /// <summary>
    /// <para>Утилиты для работы с массивами</para>
    /// </summary>
    public static partial class ArrayHelper
    {
        /// <summary>
        /// <para>Частичное сравнение двух одномерных массивов</para>
        /// </summary>
        /// <typeparam name="T">Тип элементов массивов</typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="length"></param>
        /// <returns>Результат сравнения</returns>
        /// <exception cref="ArgumentNullException">Один из массивов не определен</exception>
        /// <exception cref="ArgumentOutOfRangeException">length выходит за пределы одного из массивов</exception>
        /// <remarks>v.2021.04.18</remarks>
        public static int CompareWith<T>(this T[] left, T[] right, long length)
            where T : IComparable<T>
            =>
            CompareWith(left, 0, right, 0, length);
        /// <summary>
        /// <para>Частичное сравнение двух одномерных массивов</para>
        /// </summary>
        /// <typeparam name="T">Тип элементов массивов</typeparam>
        /// <param name="left">Первый сравниваемый массив</param>
        /// <param name="startLeft">Начало области сравнения в первом массиве</param>
        /// <param name="right">Второй сравниваемый массив</param>
        /// <param name="startRight">Начало области сравнения во втором массиве</param>
        /// <param name="length">Размер сравниваемой области</param>
        /// <returns>Результат сравнения</returns>
        /// <exception cref="ArgumentNullException">Один из массивов не определен</exception>
        /// <exception cref="ArgumentOutOfRangeException">Одно из значений start1, start2, (start1+length) или (start2+length) выходит за пределы массивов</exception>
        /// <remarks>v.2021.04.18</remarks>
        public static int CompareWith<T>(this T[] left, long startLeft, T[] right, long startRight, long length)
            where T : IComparable<T>
        {
            #region Check arguments
#if CHECK_ARGS
            _ = left ?? throw new ArgumentNullException(nameof(left));
            _ = right ?? throw new ArgumentNullException(nameof(right));

            if (startLeft < 0 || startLeft >= left.LongLength)
                throw new ArgumentOutOfRangeException(nameof(startLeft));

            if (startRight < 0 || startRight >= right.LongLength)
                throw new ArgumentOutOfRangeException(nameof(startRight));

            if ((length < 0) ||
                (length > (left.LongLength - startLeft)) ||
                (length > (right.LongLength - startRight)))
                throw new ArgumentOutOfRangeException(nameof(length));
#endif
            #endregion Check arguments

            for (var i = 0; i < length; i++)
            {
                var rc = left[startLeft + i].CompareTo(right[startRight + i]);
                if (rc != 0) return rc;
            }

            return 0;
        }
    }
}
