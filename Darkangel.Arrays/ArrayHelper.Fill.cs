using System;

namespace Darkangel.Arrays
{
    /// <summary>
    /// <para>Функция-делегат, генерирующая значения</para>
    /// </summary>
    /// <typeparam name="T">Тип значения</typeparam>
    /// <param name="index">Порядковый номер значения</param>
    /// <returns>Сгенерированное значение</returns>
    public delegate T ValueGenerator<T>(long index);

    /// <summary>
    /// <para>Интерфейс генератора значений</para>
    /// </summary>
    /// <typeparam name="T">Тип значения</typeparam>
    public interface IValueGenerator<T>
    {
        /// <summary>
        /// <para>Генератор значений</para>
        /// </summary>
        /// <param name="index">Порядковый номер значения</param>
        /// <returns>Сгенерированное значение</returns>
        T Generate(long index);
    }

    public static partial class ArrayHelper
    {
        /// <summary>
        /// <para>Заполнить массив значением</para>
        /// </summary>
        /// <typeparam name="T">Тип элементов массива</typeparam>
        /// <param name="array">Заполняемый массив</param>
        /// <param name="value">Значение для заполнения</param>
        /// <param name="start">Первый элемент массива, с которого начинается заполнение</param>
        /// <param name="count">Количество элементов массива, заменяемых новым значением</param>
        public static void Fill<T>(this T[] array, T value, long start = 0, long count = 0)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = array ?? throw new ArgumentNullException(nameof(array));

            if (count < 0 || count > array.Length)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (start < 0 || (start + count) > array.Length)
                throw new ArgumentOutOfRangeException(nameof(start));
#endif
            #endregion Check arguments

            var end = (count == 0) ? (array.Length) : (start + count);

            for (var i = start; i < end; i++)
            {
                array[i] = value;
            }
        }
        /// <summary>
        /// <para>Заполнить массив значениями</para>
        /// </summary>
        /// <typeparam name="T">Тип элементов массива</typeparam>
        /// <param name="array">Заполняемый массив</param>
        /// <param name="generator">Функция-генератор значений</param>
        /// <param name="start">Первый элемент массива, с которого начинается заполнение</param>
        /// <param name="count">Количество элементов массива, заменяемых новым значением</param>
        public static void Fill<T>(this T[] array, ValueGenerator<T> generator, long start = 0, long count = 0)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = array ?? throw new ArgumentNullException(nameof(array));
            _ = generator ?? throw new ArgumentNullException(nameof(generator));

            if (count < 0 || count > array.Length)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (start < 0 || (start + count) > array.Length)
                throw new ArgumentOutOfRangeException(nameof(start));
#endif
            #endregion Check arguments

            var end = (count == 0) ? (array.Length) : (start + count);

            for (var i = start; i < end; i++)
            {
                array[i] = generator(i);
            }
        }
        /// <summary>
        /// <para>Заполнить массив значениями</para>
        /// </summary>
        /// <typeparam name="T">Тип элементов массива</typeparam>
        /// <param name="array">Заполняемый массив</param>
        /// <param name="generator">Генератор значений</param>
        /// <param name="start">Первый элемент массива, с которого начинается заполнение</param>
        /// <param name="count">Количество элементов массива, заменяемых новым значением</param>
        public static void Fill<T>(this T[] array, IValueGenerator<T> generator, long start = 0, long count = 0)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = array ?? throw new ArgumentNullException(nameof(array));
            _ = generator ?? throw new ArgumentNullException(nameof(generator));

            if (count < 0 || count > array.Length)
                throw new ArgumentOutOfRangeException(nameof(count));

            if (start < 0 || (start + count) > array.Length)
                throw new ArgumentOutOfRangeException(nameof(start));
#endif
            #endregion Check arguments

            var end = (count == 0) ? (array.Length) : (start + count);

            for (var i = start; i < end; i++)
            {
                array[i] = generator.Generate(i);
            }
        }
    }
}
