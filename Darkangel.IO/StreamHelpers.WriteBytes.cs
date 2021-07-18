using System;
using System.IO;
using System.Threading.Tasks;

namespace Darkangel.IO
{
    public static partial class StreamHelpers
    {
        /// <summary>
        /// <para>Записать вектор байт в поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="data">Исходный вектор</param>
        /// <returns>Количество записанных байт</returns>
        /// <remarks>2021-04-18</remarks>
        public static long WriteBytes(this Stream stream, byte[] data)
        {
            return stream.Write(data, 0, data.LongLength);
        }
        /// <summary>
        /// <para>Записать вектор байт в поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="data">Исходный вектор</param>
        /// <returns>Количество записанных байт</returns>
        /// <remarks>2021-04-18</remarks>
        public static async Task<long> WriteBytesAsync(this Stream stream, byte[] data)
        {
            return await stream.WriteAsync(data, 0, data.LongLength);
        }
        /// <summary>
        /// <para>Записать вектор байт в поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="data">Исходные данные</param>
        /// <param name="start">Начало записываемового блока в векторе</param>
        /// <param name="length">Размер записываемого блока</param>
        /// <returns>Количество записанных в поток байт</returns>
        public static long Write(this Stream stream, byte[] data, long start, long length)
        {
            #region Check arguments
#if CHECK_ARGS
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (start < 0 || start >= data.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
            if (length < 0 || (length + start) > data.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
#endif
            #endregion

            var chunkBuf = new byte[CHUNK_SIZE];
            for (var off = 0L; off < length; off += CHUNK_SIZE)
            {
                var chunkSize = Math.Min(length - off, CHUNK_SIZE);
                Array.Copy(data, off, chunkBuf, 0, chunkSize);
                stream.Write(chunkBuf, 0, (int)chunkSize);
            }
            return length;
        }
        /// <summary>
        /// <para>Записать вектор байт в поток</para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="data">Исходные данные</param>
        /// <param name="start">Начало записываемового блока в векторе</param>
        /// <param name="length">Размер записываемого блока</param>
        /// <returns>Количество записанных в поток байт</returns>
        public static async Task<long> WriteAsync(this Stream stream, byte[] data, long start, long length)
        {
            #region Check arguments
#if CHECK_ARGS
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (start < 0 || start >= data.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
            if (length < 0 || (length + start) > data.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
#endif
            #endregion

            var chunkBuf = new byte[CHUNK_SIZE];
            for (var off = 0L; off < length; off += CHUNK_SIZE)
            {
                var chunkSize = Math.Min(length - off, CHUNK_SIZE);
                Array.Copy(data, off, chunkBuf, 0, chunkSize);
                await stream.WriteAsync(chunkBuf, 0, (int)chunkSize);
            }
            return length;
        }
    }
}
