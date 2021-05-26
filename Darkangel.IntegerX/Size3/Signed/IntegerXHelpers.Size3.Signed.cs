using Darkangel.IO;
using System;
using System.IO;

namespace Darkangel.IntegerX
{
    public static partial class IntegerXHelpers
    {
        private const long Int24_Size = 6;
        #region Get buffer
        /// <summary>
        /// <para>Преобразовать значение <see cref="Int24"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение </param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        public static byte[] GetBytes(this Int24 value, bool isLittleEndian = true)
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
        public static Int24 Swap(this Int24 value)
        {
            var buf = value.GetBytes_int(true);
            return Int24.FromBytes_int(buf, 0, false);
        }
        #endregion Swap
        #region Buffered
        #region Load
        /// <summary>
        /// <para>Прочитать значение <see cref="Int24"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="value">Результирующее значение</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество считанных байт</returns>
        public static long Load(this byte[] data, out Int24 value, long offset = 0, bool isLittleEndian = true)
        {
            value = Int24.FromBytes_int(data, offset, isLittleEndian);
            return Int24_Size;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="Int24"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static Int24 LoadInt24(this byte[] data, long offset = 0, bool isLittleEndian = true)
        {
            return Int24.FromBytes_int(data, offset, isLittleEndian);
        }
        #endregion Read
        #region Write
        /// <summary>
        /// <para>Записать значение <see cref="Int24"/> в поток байт</para>
        /// </summary>
        /// <param name="data">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static long Store(this byte[] data, Int24 value, long offset = 0, bool isLittleEndian = true)
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
        /// <para>Прочитать значение <see cref="Int24"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="value">Результирующее значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество считанных байт</returns>
        public static long Load(this Stream stream, out Int24 value, bool isLittleEndian = true)
        {
            var buf = stream.ReadBytes(Int24_Size);
            value = Int24.FromBytes_int(buf, 0, isLittleEndian);
            return buf.LongLength;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="Int24"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static Int24 LoadInt24(this Stream stream, bool isLittleEndian = true)
        {
            return Int24.FromBytes_int(stream.ReadBytes(Int24_Size), 0, isLittleEndian);
        }
        #endregion Load
        #region Store
        /// <summary>
        /// <para>Записать значение <see cref="Int24"/> в поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static long Store(this Stream stream, Int24 value, bool isLittleEndian = true)
        {
            var buf = value.GetBytes_int(isLittleEndian);
            stream.WriteBytes(buf);
            return buf.LongLength;
        }
        #endregion Store
        #endregion Streamble
    }
}
