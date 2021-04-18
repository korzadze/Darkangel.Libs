using System;
using System.Text;

namespace Darkangel.Strings
{
    public static partial class StringHelpers
    {
        /// <summary>
        /// <para>Прочитать из потока мультибайтную строку из потока байт</para>
        /// <para>NOTE: не стоит использовать <see cref="Encoding.Unicode"/> и аналогичные декодеры, т.к. в Unicode-строках, символ может начинаться с нулевого байта.</para>
        /// </summary>
        /// <param name="buf">Поток байт</param>
        /// <param name="start">Начало строки в потоке</param>
        /// <param name="encoding">Кодировка строки</param>
        /// <returns>Считанная строка</returns>
        /// <remarks>2021-04-18</remarks>
        public static string GetMBCSZ(this byte[] buf, long start, Encoding? encoding = null)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = buf ?? throw new ArgumentNullException(nameof(buf));
            if (start < 0 || start >= buf.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
#endif
            #endregion Check arguments

            encoding ??= Encoding.ASCII;
            var end = start;
            while ((buf[end] != 0) && (end < buf.LongLength)) end++;
            var len = (end > start) ? ((end - start)) : (0);
            var str = new byte[len];
            Array.Copy(buf, start, str, 0, len);
            return encoding.GetString(str);
        }
    }
}
