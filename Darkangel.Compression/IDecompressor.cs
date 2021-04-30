using System.IO;

namespace Darkangel.Compression
{
    /// <summary>
    /// <para>Интерфейс объекта для распаковки данных</para>
    /// </summary>
    public interface IDecompressor
    {
        /// <summary>
        /// <para>Инициализировать настройки распаковки по-умолчанию</para>
        /// </summary>
        /// <returns>Настройки по-умолчанию</returns>
        object InitDefaultDecompressSettings();
        /// <summary>
        /// <para>Распаковать поток байт</para>
        /// </summary>
        /// <param name="data">Данные для распаковки</param>
        /// <param name="start">Первый байт упакованных данных</param>
        /// <param name="count">Размер распаковываемого блока данных</param>
        /// <param name="compressorSettings">Дополнительные настройки для распаковки данных</param>
        /// <returns>Распакованные данные</returns>
        byte[] Decompress(byte[] data, long start = 0, long count = -1, object compressorSettings = null);
        /// <summary>
        /// <para>Распаковать данные из входного потока, и записать в выходной поток</para>
        /// </summary>
        /// <param name="inStream">Входной поток</param>
        /// <param name="outStream">Выходной поток</param>
        /// <param name="count">Размер распаковываемого блока данных</param>
        /// <param name="compressorSettings">Дополнительные настройки для распаковки данных</param>
        /// <returns>Количество байт, записанных в выходной поток</returns>
        long Decompress(Stream inStream, Stream outStream, long count = -1, object compressorSettings = null);
    }
}
