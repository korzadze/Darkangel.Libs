using Darkangel.IO;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Darkangel.IntegerX
{
    public static partial class IntegerXHelpers
    {
        private const int UInt64_Size = 8;
        #region Получить размер значения
        /// <summary>
        /// <para>Получить размер переменной типа</para>
        /// </summary>
        /// <returns>Размер переменной типа</returns>
        public static int GetSize(this UInt64 value) => UInt64_Size;
        #endregion Получить размер значения
        #region Get buffer
        /// <summary>
        /// <para>Преобразовать значение <see cref="UInt64"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение </param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        public static byte[] GetBytes(this UInt64 value, bool isLittleEndian = true)
        {
            const long DataSize = UInt64_Size;

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
        public static UInt64 Swap(this UInt64 value)
        {
            return LoadUInt64(value.GetBytes(true), 0, false);
        }
        #endregion Swap
        #region Buffered
        #region Load
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt64"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="value">Результирующее значение</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество считанных байт</returns>
        public static long Load(this byte[] data, out UInt64 value, long offset = 0, bool isLittleEndian = true)
        {
            const long DataSize = UInt64_Size;

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
        /// <para>Прочитать значение <see cref="UInt64"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static UInt64 LoadUInt64(this byte[] data, long offset = 0, bool isLittleEndian = true)
        {
            Load(data, out UInt64 value, offset, isLittleEndian);
            return value;
        }
        #endregion Read
        #region Write
        /// <summary>
        /// <para>Записать значение <see cref="UInt64"/> в поток байт</para>
        /// </summary>
        /// <param name="data">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static long Store(this byte[] data, UInt64 value, long offset = 0, bool isLittleEndian = true)
        {
            var buf = GetBytes(value, isLittleEndian);
            Array.Copy(data, offset, buf, 0, buf.LongLength);
            return buf.LongLength;
        }
        #endregion Write
        #endregion Buffered
        #region Streamble
        #region Load
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt64"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="value">Результирующее значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество считанных байт</returns>
        public static long Load(this Stream stream, out UInt64 value, bool isLittleEndian = true)
        {
            value = LoadUInt64(stream, isLittleEndian);
            return UInt64_Size;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt64"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static UInt64 LoadUInt64(this Stream stream, bool isLittleEndian = true)
        {
            var t = Task.Run(() => LoadUInt64Async(stream, isLittleEndian));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt64"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static async Task<UInt64> LoadUInt64Async(this Stream stream, bool isLittleEndian = true)
        {
            var buf = await stream.ReadBytesAsync(UInt64_Size);
            Load(buf, out UInt16 value, 0, isLittleEndian);
            return value;
        }
        #endregion Load
        #region Store
        /// <summary>
        /// <para>Записать значение <see cref="UInt64"/> в поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static long Store(this Stream stream, UInt64 value, bool isLittleEndian = true)
        {
            var t = Task.Run(() => StoreAsync(stream, value, isLittleEndian));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// <para>Записать значение <see cref="UInt64"/> в поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static async Task<long> StoreAsync(this Stream stream, UInt64 value, bool isLittleEndian = true)
        {
            var buf = GetBytes(value, isLittleEndian);
            await stream.WriteBytesAsync(buf);
            return buf.LongLength;
        }
        #endregion Store
        #endregion Streamble
    }
}
