using System;

namespace Darkangel.IO
{
    /// <summary>
    /// <para>Утилиты для чтения/записи двоичных данных из потока</para>
    /// </summary>
    public static partial class StreamHelpers
    {
        /// <summary>
        /// <para>К сожалению, базовая библиотека не умеет читать кусками больше, чем <see cref="Int32.MaxValue"/></para>
        /// </summary>
        private const int CHUNK_SIZE = 0x10000;
    }
}
