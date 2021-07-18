using Darkangel.IO;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Darkangel.IntegerX
{
    public static partial class IntegerXHelpers
    {
        private const int UInt16_Size = 2;
        #region Получить размер значения
        /// <summary>
        /// <para>Получить размер переменной типа</para>
        /// </summary>
        /// <returns>Размер переменной типа</returns>
        public static int GetSize(this UInt16 value) => UInt16_Size;
        #endregion Получить размер значения
        #region Get buffer
        /// <summary>
        /// <para>Преобразовать значение <see cref="UInt16"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение </param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        public static byte[] GetBytes(this UInt16 value, bool isLittleEndian = true)
        {
            const long DataSize = UInt16_Size;

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
        public static UInt16 Swap(this UInt16 value)
        {
            return LoadUInt16(value.GetBytes(true), 0, false);
        }
        #endregion Swap
        #region Buffered
        #region Load
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt16"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="value">Результирующее значение</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество считанных байт</returns>
        public static long Load(this byte[] data, out UInt16 value, long offset = 0, bool isLittleEndian = true)
        {
            const long DataSize = UInt16_Size;

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
        /// <para>Прочитать значение <see cref="UInt16"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static UInt16 LoadUInt16(this byte[] data, long offset = 0, bool isLittleEndian = true)
        {
            Load(data, out UInt16 value, offset, isLittleEndian);
            return value;
        }
        #endregion Read
        #region Write
        /// <summary>
        /// <para>Записать значение <see cref="UInt16"/> в поток байт</para>
        /// </summary>
        /// <param name="data">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static long Store(this byte[] data, UInt16 value, long offset = 0, bool isLittleEndian = true)
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
        /// <para>Прочитать значение <see cref="UInt16"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="value">Результирующее значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество считанных байт</returns>
        public static long Load(this Stream stream, out UInt16 value, bool isLittleEndian = true)
        {
            value = LoadUInt16(stream, isLittleEndian);
            return UInt16_Size;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt16"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static UInt16 LoadUInt16(this Stream stream, bool isLittleEndian = true)
        {
            var t = Task.Run(() => LoadUInt16Async(stream, isLittleEndian));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt16"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static async Task<UInt16> LoadUInt16Async(this Stream stream, bool isLittleEndian = true)
        {
            var buf = await stream.ReadBytesAsync(UInt16_Size);
            Load(buf, out UInt16 value, 0, isLittleEndian);
            return value;
        }
        #endregion Load
        #region Store
        /// <summary>
        /// <para>Записать значение <see cref="UInt16"/> в поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static long Store(this Stream stream, UInt16 value, bool isLittleEndian = true)
        {
            var t = Task.Run(() => StoreAsync(stream, value, isLittleEndian));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// <para>Записать значение <see cref="UInt16"/> в поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static async Task<long> StoreAsync(this Stream stream, UInt16 value, bool isLittleEndian = true)
        {
            var buf = GetBytes(value, isLittleEndian);
            await stream.WriteBytesAsync(buf);
            return buf.LongLength;
        }
        #endregion Store
        #endregion Streamble
    }
}
