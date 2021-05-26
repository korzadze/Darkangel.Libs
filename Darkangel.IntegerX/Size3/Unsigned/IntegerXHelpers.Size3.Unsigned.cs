using Darkangel.IO;
using System;
using System.IO;

namespace Darkangel.IntegerX
{
    public static partial class IntegerXHelpers
    {
        private const long UInt24_Size = 6;
        #region Get buffer
        /// <summary>
        /// <para>Преобразовать значение <see cref="UInt24"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение </param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        public static byte[] GetBytes(this UInt24 value, bool isLittleEndian = true)
        {
            return value.GetBytes_int(isLittleEndian);
        }
        #endregion
        #region Swap
        /// <summary>
        /// <para>Изменить порядок байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <returns>Результируюущее значение</returns>
        public static UInt24 Swap(this UInt24 value)
        {
            var buf = value.GetBytes_int(true);
            return UInt24.FromBytes_int(buf, 0, false);
        }
        #endregion Swap
        #region Buffered
        #region Load
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt24"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="value">Результирующее значение</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество считанных байт</returns>
        public static long Load(this byte[] data, out UInt24 value, long offset = 0, bool isLittleEndian = true)
        {
            value = UInt24.FromBytes_int(data, offset, isLittleEndian);
            return UInt24_Size;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt24"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static UInt24 LoadUInt24(this byte[] data, long offset = 0, bool isLittleEndian = true)
        {
            return UInt24.FromBytes_int(data, offset, isLittleEndian);
        }
        #endregion Read
        #region Write
        /// <summary>
        /// <para>Записать значение <see cref="UInt24"/> в поток байт</para>
        /// </summary>
        /// <param name="data">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static long Store(this byte[] data, UInt24 value, long offset = 0, bool isLittleEndian = true)
        {
            var buf = value.GetBytes_int(isLittleEndian);
            Array.Copy(data, offset, buf, 0, buf.LongLength);
            return buf.LongLength;
        }
        #endregion Write
        #endregion Buffered
        #region Streamble
        #region Read
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt24"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="value">Результирующее значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество считанных байт</returns>
        public static long Load(this Stream stream, out UInt24 value, bool isLittleEndian = true)
        {
            var buf = stream.ReadBytes(UInt24_Size);
            value = UInt24.FromBytes_int(buf, 0, isLittleEndian);
            return buf.LongLength;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt24"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static UInt24 LoadUInt24(this Stream stream, bool isLittleEndian = true)
        {
            return UInt24.FromBytes_int(stream.ReadBytes(UInt24_Size), 0, isLittleEndian);
        }
        #endregion Load
        #region Store
        /// <summary>
        /// <para>Записать значение <see cref="UInt24"/> в поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static long Store(this Stream stream, UInt24 value, bool isLittleEndian = true)
        {
            var buf = value.GetBytes_int(isLittleEndian);
            stream.Write(buf, 0, buf.Length);
            return buf.Length;
        }
        #endregion Store
        #endregion Streamble
    }
}
