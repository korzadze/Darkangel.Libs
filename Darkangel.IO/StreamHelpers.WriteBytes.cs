using System;
using System.IO;

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
            #region Check arguments
#if CHECK_ARGS
            _ = data ?? throw new ArgumentNullException(nameof(data));
#endif
            #endregion
            var dataSize = data.LongLength;
            if(dataSize < int.MaxValue)
            {
                stream.Write(data, 0, (int)dataSize);
                return dataSize;
            }
            else
            {
                var chunkBuf = new byte[CHUNK_SIZE];
                var chunkSize = (int)Math.Min(CHUNK_SIZE, dataSize);
                for (var off = 0L; off < dataSize; off += chunkSize)
                {
                    var cbWrite = Math.Min(dataSize - off, chunkSize);
                    Array.Copy(data, off, chunkBuf, 0, cbWrite);
                    stream.Write(chunkBuf, 0, (int)cbWrite);
                }
                return dataSize;
            }
        }
    }
}
