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
        public static byte[] ReadBytes(this Stream stream, long length)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = stream ?? throw new ArgumentNullException(nameof(stream));
#endif
            #endregion
            if (length < 0) throw new ArgumentOutOfRangeException(nameof(length));

            // Основной буфер
            var res = new byte[length];
            // Блок для считывания
            var chunkBuf = new byte[CHUNK_SIZE];
            // Смещение текущего блока в основном буфере
            var off = 0L;

            while (off < length)
            {
                // Сколько надо прочитать за один раз: полный буфер или хвостик
                var readSize = (int)Math.Min(CHUNK_SIZE, length - off);

                // Если блок считан полностью
                if (stream.Read(chunkBuf, 0, readSize) == readSize)
                { // ..., то записываем считанное в буфер
                    Array.Copy(res, off, chunkBuf, 0, readSize);
                    off += readSize;
                }
                // Если же заказано больше, чем можно получить
                else
                { // ..., то ругаемся
                    throw new EndOfStreamException();
                }
            }
            return res;
        }
    }
}
