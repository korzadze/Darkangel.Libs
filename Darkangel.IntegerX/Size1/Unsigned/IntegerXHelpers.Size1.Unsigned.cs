using System;
using System.IO;
using System.Threading.Tasks;

namespace Darkangel.IntegerX
{
    public static partial class IntegerXHelpers
    {
        private const int Byte_Size = 1;
        #region Получить размер значения
        /// <summary>
        /// <para>Получить размер переменной типа</para>
        /// </summary>
        /// <returns>Размер переменной типа</returns>
        public static int GetSize(this Byte value) => Byte_Size;
        #endregion Получить размер значения
        #region Get buffer
        /// <summary>
        /// <para>Преобразовать значение <see cref="Byte"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение </param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        public static byte[] GetBytes(this Byte value, bool isLittleEndian = true)
        {
            return new byte[] { value };
        }
        #endregion
        #region Swap
        /// <summary>
        /// <para>Изменить порядок байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <returns>Результируюущее значение</returns>
        public static Byte Swap(this Byte value)
        {
            return value;
        }
        #endregion Swap
        #region Buffered
        #region Load
        /// <summary>
        /// <para>Прочитать значение <see cref="Byte"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="value">Результирующее значение</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество считанных байт</returns>
        public static long Load(this byte[] data, out Byte value, long offset = 0, bool isLittleEndian = true)
        {
            value = data[offset];
            return Byte_Size;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="Byte"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static Byte LoadByte(this byte[] data, long offset = 0, bool isLittleEndian = true)
        {
            return data[offset];
        }
        #endregion Load
        #region Store
        /// <summary>
        /// <para>Записать значение <see cref="Byte"/> в поток байт</para>
        /// </summary>
        /// <param name="data">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static long Store(this byte[] data, Byte value, long offset = 0, bool isLittleEndian = true)
        {
            var buf = GetBytes(value, isLittleEndian);
            Array.Copy(data, offset, buf, 0, buf.LongLength);
            return buf.LongLength;
        }
        #endregion Store
        #endregion Buffered
        #region Streamble
        #region Load
        /// <summary>
        /// <para>Прочитать значение <see cref="Byte"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="value">Результирующее значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество считанных байт</returns>
        public static long Load(this Stream stream, out Byte value, bool isLittleEndian = true)
        {
            value = unchecked((Byte)stream.ReadByte());
            return Byte_Size;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="Byte"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static Byte LoadByte(this Stream stream, bool isLittleEndian = true)
        {
            return unchecked((Byte)stream.ReadByte());
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="Byte"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static async Task<Byte> LoadByteAsync(this Stream stream, bool isLittleEndian = true)
        {
            return unchecked((Byte)await Task.Run(() => stream.ReadByte()));
        }
        #endregion Load
        #region Store
        /// <summary>
        /// <para>Записать значение <see cref="Byte"/> в поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static long Store(this Stream stream, Byte value, bool isLittleEndian = true)
        {
            stream.WriteByte(value);
            return Byte_Size;
        }
        /// <summary>
        /// <para>Записать значение <see cref="Byte"/> в поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static async Task<long> StoreAsync(this Stream stream, Byte value, bool isLittleEndian = true)
        {
            await Task.Run(() => stream.WriteByte(value));
            return Byte_Size;
        }
        #endregion Store
        #endregion Streamble
    }
}
