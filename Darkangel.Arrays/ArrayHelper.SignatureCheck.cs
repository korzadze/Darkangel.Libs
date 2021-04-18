using System;

namespace Darkangel.Arrays
{
    public static partial class ArrayHelper
    {
        /// <summary>
        /// <para>Проверить правильность сигнатуры</para>
        /// </summary>
        /// <param name="data">Исходные данные</param>
        /// <param name="signature">Сигнатура данных</param>
        /// <param name="start">Первый байт сигнатуры в данных</param>
        /// <returns>Результат проверки подписи</returns>
        /// <remarks>v.2021.04.18</remarks>
        public static bool SignatureCheck(this byte[] data, byte[] signature, long start = 0)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = data ?? throw new ArgumentNullException(nameof(data));
            _ = signature ?? throw new ArgumentNullException(nameof(signature));
            if (start < 0 || (start + signature.LongLength) >= data.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
#endif
            #endregion Check arguments
            return data.CompareWith(start, signature, 0, signature.LongLength, false) == 0;
        }
    }
}
