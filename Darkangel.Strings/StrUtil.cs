using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// <returns></returns>
        public static long StrLenA(byte[] data, long start = 0)
        {
            var res = 0L;
            for (var i = start; i < data.LongLength; i++)
            {
                if (data[i] == 0)
                {
                    return res;
                }
                else
                {
                    res++;
                }
            }
            return res;
        }
    }
}
