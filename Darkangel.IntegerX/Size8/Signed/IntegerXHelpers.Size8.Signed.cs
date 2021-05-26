using System;
using System.IO;

namespace Darkangel.IntegerX
{
    public static partial class IntegerXHelpers
    {
        #region Получить размер значения
        /// <summary>
        /// <para>Получить размер переменной типа</para>
        /// </summary>
        /// <returns>Размер переменной типа</returns>
        public static int GetSize(this Int64 value) => UInt64_Size;
        #endregion Получить размер значения
        #region Get buffer
        /// <summary>
        /// <para>Преобразовать значение <see cref="Int64"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение </param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        public static byte[] GetBytes(this Int64 value, bool isLittleEndian = true)
        {
            return GetBytes(unchecked((UInt64)value), isLittleEndian);
        }
        #endregion
        #region Swap
        /// <summary>
        /// <para>Изменить порядок байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <returns>Результируюущее значение</returns>
        public static Int64 Swap(this Int64 value)
        {
            return unchecked((Int64)Swap(unchecked((UInt64)value)));
        }
        #endregion Swap
        #region Buffered
        #region Load
        /// <summary>
        /// <para>Прочитать значение <see cref="Int64"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="value">Результирующее значение</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество считанных байт</returns>
        public static long Load(this byte[] data, out Int64 value, long offset = 0, bool isLittleEndian = true)
        {
            var len = Load(data, out UInt64 uval, offset, isLittleEndian);
            value = unchecked((Int64)uval);
            return len;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="Int64"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static Int64 LoadInt64(this byte[] data, long offset = 0, bool isLittleEndian = true)
        {
            Load(data, out UInt64 value, offset, isLittleEndian);
            return unchecked((Int64)value);
        }
        #endregion Read
        #region Write
        /// <summary>
        /// <para>Записать значение <see cref="Int64"/> в поток байт</para>
        /// </summary>
        /// <param name="data">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static long Store(this byte[] data, Int64 value, long offset = 0, bool isLittleEndian = true)
        {
            return Store(data, unchecked((UInt64)value), offset, isLittleEndian);
        }
        #endregion Write
        #endregion Buffered
        #region Streamble
        #region Read
        /// <summary>
        /// <para>Прочитать значение <see cref="Int64"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="value">Результирующее значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество считанных байт</returns>
        public static long Load(this Stream stream, out Int64 value, bool isLittleEndian = true)
        {
            var res = Load(stream, out UInt64 uval, isLittleEndian);
            value = unchecked((Int64)uval);
            return res;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="Int64"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static Int64 LoadInt64(this Stream stream, bool isLittleEndian = true)
        {
            return unchecked((Int64)LoadUInt64(stream, isLittleEndian));
        }
        #endregion Load
        #region Store
        /// <summary>
        /// <para>Записать значение <see cref="Int64"/> в поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static long Store(this Stream stream, Int64 value, bool isLittleEndian = true)
        {
            return Store(stream, unchecked((UInt64)value), isLittleEndian);
        }
        #endregion Store
        #endregion Streamble
    }
}
