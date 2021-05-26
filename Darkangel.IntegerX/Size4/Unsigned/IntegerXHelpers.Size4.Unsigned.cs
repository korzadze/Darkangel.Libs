using Darkangel.IO;
using System;
using System.IO;

namespace Darkangel.IntegerX
{
    public static partial class IntegerXHelpers
    {
        private const int UInt32_Size = 4;
        #region Получить размер значения
        /// <summary>
        /// <para>Получить размер переменной типа</para>
        /// </summary>
        /// <returns>Размер переменной типа</returns>
        public static int GetSize(this UInt32 value) => UInt32_Size;
        #endregion Получить размер значения
        #region Get buffer
        /// <summary>
        /// <para>Преобразовать значение <see cref="UInt32"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение </param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        public static byte[] GetBytes(this UInt32 value, bool isLittleEndian = true)
        {
            const long DataSize = UInt32_Size;

            var buf = new byte[DataSize];
            if (isLittleEndian)
            {
                for (var i = 0L; i < DataSize; i++)
                {
                    buf[i] = (byte)(value & 0xff);
                    value >>= 8;
                }
            }
            else
            {
                for (var i = DataSize - 1; i >= 0; i--)
                {
                    buf[i] = (byte)(value & 0xff);
                    value >>= 8;
                }
            }
            return buf;
        }
        #endregion
        #region Swap
        /// <summary>
        /// <para>Изменить порядок байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <returns>Результируюущее значение</returns>
        public static UInt32 Swap(this UInt32 value)
        {
            return LoadUInt32(value.GetBytes(true), 0, false);
        }
        #endregion Swap
        #region Buffered
        #region Load
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt32"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="value">Результирующее значение</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество считанных байт</returns>
        public static long Load(this byte[] data, out UInt32 value, long offset = 0, bool isLittleEndian = true)
        {
            const long DataSize = UInt32_Size;

            value = 0;
            if (!isLittleEndian)
            {
                for (var i = 0L; i < DataSize; i++)
                {
                    value <<= 8;
                    value |= data[i + offset];
                }
            }
            else
            {
                for (var i = DataSize - 1; i >= 0; i--)
                {
                    value <<= 8;
                    value |= data[i + offset];
                }
            }
            return DataSize;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt32"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static UInt32 LoadUInt32(this byte[] data, long offset = 0, bool isLittleEndian = true)
        {
            Load(data, out UInt32 value, offset, isLittleEndian);
            return value;
        }
        #endregion Read
        #region Write
        /// <summary>
        /// <para>Записать значение <see cref="UInt32"/> в поток байт</para>
        /// </summary>
        /// <param name="data">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static long Store(this byte[] data, UInt32 value, long offset = 0, bool isLittleEndian = true)
        {
            var buf = GetBytes(value, isLittleEndian);
            Array.Copy(data, offset, buf, 0, buf.LongLength);
            return buf.LongLength;
        }
        #endregion Write
        #endregion Buffered
        #region Streamble
        #region Read
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt32"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="value">Результирующее значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество считанных байт</returns>
        public static long Load(this Stream stream, out UInt32 value, bool isLittleEndian = true)
        {
            var buf = stream.ReadBytes(UInt16_Size);
            Load(buf, out value, 0, isLittleEndian);
            return buf.LongLength;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt32"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static UInt32 LoadUInt32(this Stream stream, bool isLittleEndian = true)
        {
            Load(stream, out UInt32 value, isLittleEndian);
            return value;
        }
        #endregion Load
        #region Store
        /// <summary>
        /// <para>Записать значение <see cref="UInt32"/> в поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static long Store(this Stream stream, UInt32 value, bool isLittleEndian = true)
        {
            var buf = GetBytes(value, isLittleEndian);
            stream.WriteBytes(buf);
            return buf.LongLength;
        }
        #endregion Store
        #endregion Streamble
    }
}
