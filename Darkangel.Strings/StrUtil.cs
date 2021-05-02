namespace Darkangel.Strings
{
    /// <summary>
    /// <para>Утилиты для работы со строками стандартной библиотеки C/C++</para>
    /// </summary>
    public static class StrUtil
    {
        /// <summary>
        /// <para>Определить длину строки по символу завершения ('\0')</para>
        /// </summary>
        /// <remarks>Аналог функции strlen библиотеки C/C++</remarks>
        /// <param name="data"></param>
        /// <param name="start"></param>
        /// <returns>Длина строки</returns>
        public static long StrLenA(byte[] data, long start = 0)
        {
            var pos = start;
            while ((pos < data.LongLength) && (data[pos] != 0)) pos++;
            return pos - start;
        }
    }
}
