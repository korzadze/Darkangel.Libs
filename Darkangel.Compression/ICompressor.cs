using System.IO;

namespace Darkangel.Compression
{
    /// <summary>
    /// <para>Интерфейс объекта для сжатия данных</para>
    /// </summary>
    public interface ICompressor
    {
        /// <summary>
        /// <para>Упаковать поток байт</para>
        /// </summary>
        /// <param name="data">Данные для упаковки</param>
        /// <param name="start">Первый байт данных</param>
        /// <returns>Упакованные данные</returns>
        public byte[] Compress(byte[] data, long start);
        /// <summary>
        /// <para>Упаковать данные из входного потока, и записать в выходной поток</para>
        /// </summary>
        /// <param name="inStream">Входной поток</param>
        /// <param name="outStream">Выходной поток</param>
        /// <param name="count">Количество байт входного потока, которые необходимо упаковать</param>
        /// <returns>Количество байт, записанных в выходной поток</returns>
        public long Compress(Stream inStream, Stream outStream, long count);
    }
}
