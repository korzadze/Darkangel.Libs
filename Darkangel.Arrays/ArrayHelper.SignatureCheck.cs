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
        /// <param name="signatureOffset">Первый байт сигнатуры в данных</param>
        /// <returns>Результат проверки подписи</returns>
        /// <remarks>v.2021.04.18</remarks>
        public static bool SignatureCheck(this byte[] data, byte[] signature, long signatureOffset = 0)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = signature ?? throw new ArgumentNullException(nameof(signature));
#endif
            #endregion Проверка аргументов

            return CompareWith(data, signatureOffset, signature, 0, signature.LongLength) == 0;
        }
    }
}
