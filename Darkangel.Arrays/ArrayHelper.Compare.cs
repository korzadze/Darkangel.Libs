using System;

namespace Darkangel.Arrays
{
    /// <summary>
    /// <para>Утилиты для работы с массивами</para>
    /// </summary>
    public static partial class ArrayHelper
    {
        /// <summary>
        /// <para>Сравнение двух одномерных массивов</para>
        /// </summary>
        /// <typeparam name="T">Тип элементов массивов</typeparam>
        /// <param name="left">Первый сравниваемый массив</param>
        /// <param name="right">Второй сравниваемый массив</param>
        /// <param name="fullCompare">Сравнивать массивы полностью или только минимальную область [0..Min(left.Length, right.Length)].
        /// При совпадении минимальной области и полном сравнении, больше тот массив, который имет больший размер.</param>
        /// <returns>Результат сравнения</returns>
        /// <exception cref="ArgumentNullException">Один из массивов не определен</exception>
        public static int CompareWith<T>(this T[] left, T[] right, bool fullCompare = true)
            where T : IComparable<T>
            =>
            CompareWith(left, 0, right, 0, -1, fullCompare);
        /// <summary>
        /// <para>Частичное сравнение двух одномерных массивов</para>
        /// </summary>
        /// <typeparam name="T">Тип элементов массивов</typeparam>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">Один из массивов не определен</exception>
        /// <exception cref="ArgumentOutOfRangeException">length выходит за пределы одного из массивов</exception>
        public static int CompareWith<T>(this T[] left, T[] right, long length)
            where T : IComparable<T>
            =>
            CompareWith(left, 0, right, 0, length);
        /// <summary>
        /// <para>Частичное сравнение двух одномерных массивов</para>
        /// </summary>
        /// <typeparam name="T">Тип элементов массивов</typeparam>
        /// <param name="left">Первый сравниваемый массив</param>
        /// <param name="start1">Начало области сравнения в первом массиве</param>
        /// <param name="right">Второй сравниваемый массив</param>
        /// <param name="start2">Начало области сравнения во втором массиве</param>
        /// <param name="length">Размер сравниваемой области</param>
        /// <param name="fullCompare">Сравнивать области массивов полностью или только минимальную область [0..Min(length, left.Length - start1, right.Length - start2)]. При совпадении минимальной части и полном сравнении, большим считается тот массив, размер части которого больше.</param>
        /// <returns>Результат сравнения</returns>
        /// <exception cref="ArgumentNullException">Один из массивов не определен</exception>
        /// <exception cref="ArgumentOutOfRangeException">Одно из значений start1, start2, (start1+length) или (start2+length) выходит за пределы массивов</exception>
        public static int CompareWith<T>(this T[] left, long start1, T[] right, long start2 = 0, long length = -1, bool fullCompare = true)
            where T : IComparable<T>
        {
            #region Check arguments
#if CHECK_ARGS
            _ = left ?? throw new ArgumentNullException(nameof(left));
            _ = right ?? throw new ArgumentNullException(nameof(right));

            if (start1 < 0 || start1 >= left.LongLength)
                throw new ArgumentOutOfRangeException(nameof(start1));

            if (start2 < 0 || start2 >= right.LongLength)
                throw new ArgumentOutOfRangeException(nameof(start2));
#endif
            #endregion Check arguments

            var len1 = left.LongLength - start1;
            var len2 = right.LongLength - start2;
            var minLen = length;

            if (length == 0) // Нет смысла сравнивать: пустые массивы равны
            {
                return 0;
            }
            if (length > 0) // Размер области сравнения задан
            {
                if (length > len1) // Выход за пределы первого массива
                {
                    throw new ArgumentOutOfRangeException("start1 + length", start1 + length, " > left.Length");
                }
                else if (length > len2) // Выход за пределы второго массива
                {
                    throw new ArgumentOutOfRangeException("start2 + length", start2 + length, " > right.Length");
                }
                else // Область вписывается в оба массива
                {
                    len1 = len2 = length;
                }
            }
            else //Автоопределение
            {
                minLen = Math.Min(len1, len2);
            }

            for (var i = 0; i < minLen; i++)
            {
                var rc = left[i].CompareTo(right[i]);
                if (rc != 0) return rc;
            }

            return (fullCompare) ? (len1.CompareTo(len2)) : (0);
        }
    }
}
