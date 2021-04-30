using System.IO;

namespace Darkangel.Compression
{
    /// <summary>
    /// <para>Интерфейс объекта для сжатия данных</para>
    /// </summary>
    public interface ICompressor
    {
        /// <summary>
        /// <para>Инициализировать настройки сжатия по-умолчанию</para>
        /// </summary>
        /// <returns>Настройки по-умолчанию</returns>
        object InitDefaultCompressSettings();
        /// <summary>
        /// <para>Упаковать поток байт</para>
        /// </summary>
        /// <param name="data">Данные для упаковки</param>
        /// <param name="start">Первый байт данных</param>
        /// <param name="count">Размер упаковываемого блока данных</param>
        /// <param name="compressorSettings">Дополнительные настройки для сжатия данных</param>
        /// <returns>Упакованные данные</returns>
        byte[] Compress(byte[] data, long start = 0, long count = -1, object compressorSettings = null);
        /// <summary>
        /// <para>Упаковать данные из входного потока, и записать в выходной поток</para>
        /// </summary>
        /// <param name="inStream">Входной поток</param>
        /// <param name="outStream">Выходной поток</param>
        /// <param name="count">Размер упаковываемого блока данных</param>
        /// <param name="compressorSettings">Дополнительные настройки для сжатия данных</param>
        /// <returns>Количество байт, записанных в выходной поток</returns>
        long Compress(Stream inStream, Stream outStream, long count = -1, object compressorSettings = null);
    }
}
