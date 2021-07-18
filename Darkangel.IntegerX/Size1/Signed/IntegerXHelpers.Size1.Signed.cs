using System;
using System.IO;
using System.Threading.Tasks;

namespace Darkangel.IntegerX
{
    public static partial class IntegerXHelpers
    {
        private const int SByte_Size = 1;
        #region Получить размер значения
        /// <summary>
        /// <para>Получить размер переменной типа</para>
        /// </summary>
        /// <returns>Размер переменной типа</returns>
        public static int GetSize(this SByte value) => SByte_Size;
        #endregion Получить размер значения
        #region Get buffer
        /// <summary>
        /// <para>Преобразовать значение <see cref="SByte"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение </param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        public static byte[] GetBytes(this SByte value, bool isLittleEndian = true)
        {
            return new byte[] { unchecked((Byte)value) };
        }
        #endregion
        #region Swap
        /// <summary>
        /// <para>Изменить порядок байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <returns>Результируюущее значение</returns>
        public static SByte Swap(this SByte value)
        {
            return value;
        }
        #endregion Swap
        #region Buffered
        #region Load
        /// <summary>
        /// <para>Прочитать значение <see cref="SByte"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="value">Результирующее значение</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество считанных байт</returns>
        public static long Load(this byte[] data, out SByte value, long offset = 0, bool isLittleEndian = true)
        {
            value = unchecked((SByte)data[offset]);
            return SByte_Size;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="SByte"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static SByte LoadSByte(this byte[] data, long offset = 0, bool isLittleEndian = true)
        {
            return unchecked((SByte)data[offset]);
        }
        #endregion Load
        #region Store
        /// <summary>
        /// <para>Записать значение <see cref="SByte"/> в поток байт</para>
        /// </summary>
        /// <param name="data">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static long Store(this byte[] data, SByte value, long offset = 0, bool isLittleEndian = true)
        {
            data[offset] = unchecked((byte)value);
            return SByte_Size;
        }
        #endregion Store
        #endregion Buffered
        #region Streamble
        #region Load
        /// <summary>
        /// <para>Прочитать значение <see cref="SByte"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="value">Результирующее значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество считанных байт</returns>
        public static long Load(this Stream stream, out SByte value, bool isLittleEndian = true)
        {
            value = unchecked((SByte)stream.ReadByte());
            return SByte_Size;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="SByte"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static SByte LoadSByte(this Stream stream, bool isLittleEndian = true)
        {
            return unchecked((SByte)stream.ReadByte());
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="SByte"/> из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующее значение</returns>
        public static async Task<SByte> LoadSByteAsync(this Stream stream, bool isLittleEndian = true)
        {
            return unchecked((SByte)await Task.Run(() => stream.ReadByte()));
        }
        #endregion Load
        #region Store
        /// <summary>
        /// <para>Записать значение <see cref="SByte"/> в поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static long Store(this Stream stream, SByte value, bool isLittleEndian = true)
        {
            var t = Task.Run(() => StoreAsync(stream, value, isLittleEndian));
            t.Wait();
            return t.Result;
        }
        /// <summary>
        /// <para>Записать значение <see cref="SByte"/> в поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        public static async Task<long> StoreAsync(this Stream stream, SByte value, bool isLittleEndian = true)
        {
            await Task.Run(() => stream.WriteByte(unchecked((byte)value)));
            return SByte_Size;
        }
        #endregion Store
        #endregion Streamble
    }
}

