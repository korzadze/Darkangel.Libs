using System;
using System.Collections.Generic;

namespace Darkangel.CLib
{
    /// <summary>
    /// <para>Функции из стандартой библиотеки C/C++</para>
    /// </summary>
    public class StdLib
    {
        #region MemCpy
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
            if (mem1 is null)
            {
                throw new ArgumentNullException(nameof(mem1));
            }
            if (mem2 is null)
            {
                throw new ArgumentNullException(nameof(mem2));
            }
            if (length < 0 || length > mem1.Length || length > mem2.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
#endif
            #endregion Проверка аргументов
            Array.Copy(mem1._Data, mem1._Offset, mem2._Data, mem2._Offset, length);
        }
        #endregion MemCpy
        #region MemCmp
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

            IComparer<T> cmp = Comparer<T>.Default;

            for (var i = 0L; i < length; i++)
            {
                var rc = cmp.Compare(mem1[i], mem2[i]);
                if (rc != 0) return rc;
            }
            return 0;
        }
        /// <summary>
        /// <para>Сравнение векторов</para>
        /// </summary>
        /// <param name="mem1">Первый вектор</param>
        /// <param name="mem2">Второй вектор</param>
        /// <param name="length">Размер сравниваемой области</param>
        /// <returns>Результат сравения</returns>
        public static int MemCmp(PByte mem1, PByte mem2, long length)
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

            IComparer<byte> cmp = Comparer<byte>.Default;

            for (var i = 0L; i < length; i++)
            {
                var rc = cmp.Compare(mem1[i], mem2[i]);
                if (rc != 0) return rc;
            }
            return 0;
        }
        /// <summary>
        /// <para>Сравнение векторов</para>
        /// </summary>
        /// <typeparam name="T">Тип значения векторов</typeparam>
        /// <param name="mem1">Первый вектор</param>
        /// <param name="start1">Первый элемент вектора 1 для сравнения</param>
        /// <param name="mem2">Второй вектор</param>
        /// <param name="start2">Первый элемент вектора 2 для сравнения</param>
        /// <param name="length">Размер сравниваемой области</param>
        /// <returns>Результат сравения</returns>
        public static int MemCmp<T>(T[] mem1, long start1, T[] mem2, long start2, long length)
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
            if (start1 < 0 || start1 >= mem1.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(start1));
            }
            if (start2 < 0 || start2 >= mem1.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(start2));
            }
            if ((length < 0) ||
                ((length + start1) > mem1.LongLength) ||
                ((start2 + length) > mem2.LongLength))
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
#endif
            #endregion Проверка аргументов

            IComparer<T> cmp = Comparer<T>.Default;

            for (var i = 0L; i < length; i++)
            {
                var rc = cmp.Compare(mem1[i], mem2[i]);
                if (rc != 0) return rc;
            }
            return 0;
        }
        #endregion MemCmp
        #region MemRMem
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
        public static PByte MemRMem(PByte mem1, long len1, PByte mem2, long len2)
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
        /// <param name="start1">Начало бласти поиска</param>
        /// <param name="len1">Размер области поиска</param>
        /// <param name="mem2">Субвектор</param>
        /// <param name="start2">Начало субвектора</param>
        /// <param name="len2">Размер субвектора</param>
        /// <returns></returns>
        public static long MemRMem<T>(T[] mem1, long start1, long len1, T[] mem2, long start2, long len2)
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
            if (start1 < 0 || start1 >= mem1.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(start1));
            }
            if (start2 < 0 || start2 >= mem1.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(start2));
            }
            if (len1 < 0 || (start1 + len1) > mem1.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(len1));
            }
            if (len2 < 0 || (start2 + len2) > mem2.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(len2));
            }
#endif
            #endregion Проверка аргументов

            if (len1 == 0 || len2 == 0)
                return -1;

            if (len1 < len2)
                return -1;

            for (var i = len1 - len2; i >= start1; i--)
            {
                if (MemCmp(mem1, i, mem2, start2, len2) == 0)
                {
                    return i;
                }
            }

            return -1;
        }
        #endregion MemRMem
        #region MemChr
        /// <summary>
        /// <para>Поиск элемента в данных, адресуемых указателем</para>
        /// </summary>
        /// <typeparam name="T">Тип элемента данных</typeparam>
        /// <param name="ptr">Указатель на данные</param>
        /// <param name="elem">Искомый элемент</param>
        /// <param name="length">Размер области данных, в которой производится поиск</param>
        /// <returns>Указатель на позицию первого вхождения элемента в данных или null</returns>
        public static CPtr<T> MemChr<T>(CPtr<T> ptr, T elem, long length)
            where T : IComparable
        {
            #region Проверка аргументов
#if CHECK_ARGS
            if (ptr is null)
            {
                throw new ArgumentNullException(nameof(ptr));
            }
            if (length < 0 || length > ptr.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
#endif
            #endregion Проверка аргументов

            IComparer<T> cmp = Comparer<T>.Default;
            for (var i = 0L; i < length; i++)
            {
                if (cmp.Compare(ptr[i], elem) == 0)
                {
                    return new(ptr, i);
                }
            }
            return null;
        }
        /// <summary>
        /// <para>Поиск элемента в данных, адресуемых указателем</para>
        /// </summary>
        /// <param name="ptr">Указатель на данные</param>
        /// <param name="elem">Искомый элемент</param>
        /// <param name="length">Размер области данных, в которой производится поиск</param>
        /// <returns>Указатель на позицию первого вхождения элемента в данных или null</returns>
        public static PByte MemChr(PByte ptr, byte elem, long length)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            if (ptr is null)
            {
                throw new ArgumentNullException(nameof(ptr));
            }
            if (length < 0 || length > ptr.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
#endif
            #endregion Проверка аргументов

            IComparer<byte> cmp = Comparer<byte>.Default;
            for (var i = 0L; i < length; i++)
            {
                if (cmp.Compare(ptr[i], elem) == 0)
                {
                    return new(ptr, i);
                }
            }
            return null;
        }
        /// <summary>
        /// <para>Поиск элемента в данных, адресуемых указателем</para>
        /// </summary>
        /// <typeparam name="T">Тип элемента данных</typeparam>
        /// <param name="data">Вектор данных</param>
        /// <param name="start">Начало области поиска</param>
        /// <param name="elem">Искомый элемент</param>
        /// <param name="length">Размер области поиска</param>
        /// <returns>Номер позиции искомого элемента или -1</returns>
        public static long MemChr<T>(T[] data, long start, T elem, long length)
            where T : IComparable
        {
            #region Проверка аргументов
#if CHECK_ARGS
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (start < 0 || start >= data.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            if (length < 0 || (length + start) > data.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
#endif
            #endregion Проверка аргументов

            IComparer<T> cmp = Comparer<T>.Default;

            for (var i = 0L; i < length; i++)
            {
                if (cmp.Compare(data[i], elem) == 0)
                {
                    return i;
                }
            }
            return -1;
        }
        #endregion MemChr
    }
}
