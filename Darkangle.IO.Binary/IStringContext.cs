using System.Text;

namespace Darkangel.IO
{
    /// <summary>
    /// <para>Описание формата хранения строк в двоичном потоке</para>
    /// </summary>
    public interface IStringContext
    {
        /// <summary>
        /// <para>Если больше 0, то описывает размер префикса размера строки</para>
        /// </summary>
        long PreffixSize { get; }
        /// <summary>
        /// <para>Символ окончания строки в потоке</para>
        /// </summary>
        char Terminator { get; }
        /// <summary>
        /// <para>Символ дополнения строки до максимального размера</para>
        /// </summary>
        char PaddingChar { get; }
        /// <summary>
        /// <para>Кодировка текстовых данных</para>
        /// </summary>
        Encoding Encoding { get; }
    }
}
