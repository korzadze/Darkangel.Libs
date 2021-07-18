using Darkangel.IO;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Darkangel.IntegerX
{
    public static partial class IntegerXHelpers
    {
        private const int Int16_Size = 2;
        #region Получить размер значения
        /// <summary>
        /// <para>Получить размер переменной типа</para>
        /// </summary>
        /// <returns>Размер переменной типа</returns>
        public static int GetSize(this Int16 value) => Int16_Size;
        #endregion Получить размер значения
        #region Get buffer
        /// <summary>
        /// <para>Преобразовать значение <see cref="Int16"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение </param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        public static byte[] GetBytes(this Int16 value, bool isLittleEndian = true)
        {
            return GetBytes(unchecked((UInt16)value), isLittleEndian);
        }
        #endregion
        #region Swap
        /// <summary>
        /// <para>Изменить порядок байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <returns>Результируюущее значение</returns>
        public static Int16 Swap(this Int16 value)
        {
            return unchecked((Int16)Swap(unchecked((UInt16)value)));
        }
        #endregion Swap
        #region Buffered
        #region Load
        /// <summary>
        /// <para>Прочитать значение <see cref="Int16"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="value">Результирующее значение</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество считанных байт</returns>
        public static long Load(this byte[] data, out Int16 value, long offset = 0, bool isLittleEndian = true)
        {
            var len = Load(data, out UInt16 uval, offset, isLittleEndian);
            value = unchecked((Int16)uval);
            return len;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="Int16"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static Int16 LoadInt16(this byte[] data, long offset = 0, bool isLittleEndian = true)
        {
            Load(data, out UInt16 value, offset, isLittleEndian);
            return unchecked((Int16)value);
        }
        #endregion Read
        #region Write
        /// <summary>
        /// <para>Записать значение <see cref="Int16"/> в поток байт</para>
        /// </summary>
        /// <param name="data">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static long Store(this byte[] data, Int16 value, long offset = 0, bool isLittleEndian = true)
        {
            return Store(data, unchecked((UInt16)value), offset, isLittleEndian);
        }
        #endregion Write
        #endregion Buffered
        #region Streamble
        #region Read
        /// <summary>
        /// <para>Прочитать значение <see cref="Int16"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="value">Результирующее значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество считанных байт</returns>
        public static long Load(this Stream stream, out Int16 value, bool isLittleEndian = true)
        {
            value = LoadInt16(stream, isLittleEndian);
            return Int16_Size;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="Int16"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static Int16 LoadInt16(this Stream stream, bool isLittleEndian = true)
        {
            var t = Task.Run(() => LoadInt16Async(stream, isLittleEndian));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="Int16"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static async Task<Int16> LoadInt16Async(this Stream stream, bool isLittleEndian = true)
        {
            var buf = await stream.ReadBytesAsync(Int16_Size);
            Load(buf, out Int16 value, 0, isLittleEndian);
            return value;
        }
        #endregion Load
        #region Store
        /// <summary>
        /// <para>Записать значение <see cref="Int16"/> в поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static long Store(this Stream stream, Int16 value, bool isLittleEndian = true)
        {
            var t = Task.Run(() => StoreAsync(stream, value, isLittleEndian));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// <para>Записать значение <see cref="Int16"/> в поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static async Task<long> StoreAsync(this Stream stream, Int16 value, bool isLittleEndian = true)
        {
            var buf = GetBytes(value, isLittleEndian);
            await stream.WriteBytesAsync(buf);
            return buf.LongLength;
        }
        #endregion Store
        #endregion Streamble
    }
}
