using System;
using System.IO;

namespace Darkangel.IO
{
    public static partial class StreamHelpers
    {
        /// <summary>
        /// <para>Считать цепочку байт из потока</para>
        /// <para>К сожалению, базовая библиотека не умеет читать кусками больше, чем <see cref="Int32.MaxValue"/></para>
        /// </summary>
        /// <param name="stream">Входной поток</param>
        /// <param name="length">Количество байт, считываемых из потока</param>
        /// <returns>Цепочка байт, считанных из потока</returns>
        /// <remarks>2021-04-18</remarks>
        /// <exception cref="EndOfStreamException"/>
        public static byte[] ReadBytes(this Stream stream, long length)
        {
            var buf = new byte[length];
            var cbRead = stream.Read(buf, 0, length);
            if (cbRead != length) throw new EndOfStreamException();
            return buf;
        }
        /// <summary>
        /// <para>Прочитать из потока вектор байт</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="data">Буфер для считываемых данных</param>
        /// <param name="start">Начало считываемых данных в буфере</param>
        /// <param name="length">Размер считываемых данных</param>
        /// <returns>Размер считанных данных</returns>
        public static long Read(this Stream stream, byte[] data, long start, long length)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = stream ?? throw new ArgumentNullException(nameof(stream));
            _ = data ?? throw new ArgumentNullException(nameof(data));

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

            // Буффер для считывания
            var chunkBuf = new byte[CHUNK_SIZE];
            // Смещение текущего блока в основном буфере
            var off = 0L;

            while (off < length)
            {
                // Сколько надо прочитать за один раз: полный буфер или хвостик
                var chunkSize = (int)Math.Min(CHUNK_SIZE, length - off);

                var cbRead = stream.Read(chunkBuf, 0, chunkSize);
                Array.Copy(chunkBuf, 0, data, start + off, cbRead);
                off += cbRead;

                if (cbRead < chunkSize)
                {
                    break;
                }
            }
            return off;
        }
    }
}
