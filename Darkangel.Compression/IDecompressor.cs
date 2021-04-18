using System.IO;

namespace Darkangel.Compression
{
    /// <summary>
    /// <para>Интерфейс объекта для распаковки данных</para>
    /// </summary>
    public interface IDecompressor
    {
        /// <summary>
        /// <para>Распаковать поток байт</para>
        /// </summary>
        /// <param name="data">Данные для распаковки</param>
        /// <param name="start">Первый байт упакованных данных</param>
        /// <returns>Распакованные данные</returns>
        public byte[] Decompress(byte[] data, long start);
        /// <summary>
        /// <para>Распаковать данные из входного потока, и записать в выходной поток</para>
        /// </summary>
        /// <param name="inStream">Входной поток</param>
        /// <param name="outStream">Выходной поток</param>
        /// <param name="count">Количество байт входного потока, которые необходимо распаковать</param>
        /// <returns>Количество байт, записанных в выходной поток</returns>
        public long Decompress(Stream inStream, Stream outStream, long count);
    }
}
