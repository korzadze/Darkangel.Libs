using System;

namespace Darkangel.CLib
{
    /// <summary>
    /// <para>Функции из стандартой библиотеки C/C++</para>
    /// </summary>
    public class StdLib
    {
        /// <summary>
        /// <para>Сравнение векторов</para>
        /// </summary>
        /// <typeparam name="T">Тип значения векторов</typeparam>
        /// <param name="mem1">Первый вектор</param>
        /// <param name="mem2">Второй вектор</param>
        /// <param name="length">Размер сравниваемой области</param>
        /// <returns>Результат сравения</returns>
        public static int MemCmp<T>(CPtr<T> mem1, CPtr<T> mem2, long length)
            where T : IComparable
        {
            #region Проверка аргументов
#if CHECK_ARGS
            if (mem1 is null)
            {
                throw new ArgumentNullException(nameof(mem1));
            }
            if (mem2 is null)
            {
                throw new ArgumentNullException(nameof(mem2));
            }
            if ((length < 0) || (length > mem1.Length) || (length > mem2.Length))
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
#endif
            #endregion Проверка аргументов

            for (var i = 0L; i < length; i++)
            {
                var rc = mem1[i].CompareTo(mem2[i]);
                if (rc != 0) return rc;
            }
            return 0;
        }
        /// <summary>
        /// <para>Копировать блок данных заданного размера</para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="mem1">Исходные вектор данных</param>
        /// <param name="mem2">Целевой вектор</param>
        /// <param name="length">Размер копируемого блока</param>
        public static void MemCpy<T>(CPtr<T> mem1, CPtr<T> mem2, long length)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = mem1 ?? throw new ArgumentNullException(nameof(mem1));
            _ = mem2 ?? throw new ArgumentNullException(nameof(mem2));
            if (length < 0 || length > mem1.Length || length > mem2.Length)
                throw new ArgumentOutOfRangeException(nameof(length));
#endif
            #endregion Проверка аргументов
            Array.Copy(mem1._Data, mem1._Offset, mem2._Data, mem2._Offset, length);
        }
        /// <summary>
        /// <para>Поиск последнего вхождения субвектора в вектор</para>
        /// </summary>
        /// <typeparam name="T">Тип элемента векторов</typeparam>
        /// <param name="mem1">Исходный вектор</param>
        /// <param name="len1">Размер области вектора для поиска</param>
        /// <param name="mem2">Субвектор</param>
        /// <param name="len2">Размер искомой области субвектора</param>
        /// <returns></returns>
        public static CPtr<T> MemRMem<T>(CPtr<T> mem1, long len1, CPtr<T> mem2, long len2)
            where T : IComparable
        {
            #region Проверка аргументов
#if CHECK_ARGS
            if (mem1 is null)
            {
                throw new ArgumentNullException(nameof(mem1));
            }
            if (mem2 is null)
            {
                throw new ArgumentNullException(nameof(mem2));
            }
            if (len1 < 0 || len1 > mem1.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(len1));
            }
            if (len2 < 0 || len2 > mem2.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(len2));
            }
#endif
            #endregion Проверка аргументов
            long i;

            if (len1 == 0 || len2 == 0)
                return null;

            if (len1 < len2)
                return null;

            i = len1 - len2;
            do
            {
                if (MemCmp(mem1 + i, mem2, len2) == 0)
                    return (mem1 + i);
            } while (i-- != 0);

            return null;
        }
        /// <summary>
        /// <para>Поиск последнего вхождения субвектора в вектор</para>
        /// </summary>
        /// <param name="mem1">Исходный вектор</param>
        /// <param name="len1">Размер области вектора для поиска</param>
        /// <param name="mem2">Субвектор</param>
        /// <param name="len2">Размер искомой области субвектора</param>
        /// <returns></returns>
        public static PByte MemRMem<T>(PByte mem1, long len1, PByte mem2, long len2)
            where T : IComparable
        {
            #region Проверка аргументов
#if CHECK_ARGS
            if (mem1 is null)
            {
                throw new ArgumentNullException(nameof(mem1));
            }
            if (mem2 is null)
            {
                throw new ArgumentNullException(nameof(mem2));
            }
            if (len1 < 0 || len1 > mem1.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(len1));
            }
            if (len2 < 0 || len2 > mem2.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(len2));
            }
#endif
            #endregion Проверка аргументов
            long i;

            if (len1 == 0 || len2 == 0)
                return null;

            if (len1 < len2)
                return null;

            i = len1 - len2;
            do
            {
                if (MemCmp(mem1 + i, mem2, len2) == 0)
                    return (mem1 + i);
            } while (i-- != 0);

            return null;
        }
    }
}
