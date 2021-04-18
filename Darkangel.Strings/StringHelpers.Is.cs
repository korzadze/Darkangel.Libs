using Darkangel.Compare;

namespace Darkangel.Strings
{
    public static partial class StringHelpers
    {
        /// <summary>
        /// <para>Является ли символ двоичной цифрой?</para>
        /// </summary>
        /// <param name="ch">Исходный символ</param>
        /// <returns>Результат проверки</returns>
        /// <remarks>2021-04-18</remarks>
        public static bool IsBinaryDigit(this char ch) =>
            Digits.IndexOf(ch).Between(MinDigit, MaxBinaryDigit);
        /// <summary>
        /// <para>Является ли символ восьмеричной цифрой?</para>
        /// </summary>
        /// <param name="ch">Исходный символ</param>
        /// <returns>Результат проверки</returns>
        /// <remarks>2021-04-18</remarks>
        public static bool IsOctalDigit(this char ch) =>
            Digits.IndexOf(ch).Between(MinDigit, MaxOctalDigit);
        /// <summary>
        /// <para>Является ли символ десятичной цифрой?</para>
        /// </summary>
        /// <param name="ch">Исходный символ</param>
        /// <returns>Результат проверки</returns>
        /// <remarks>2021-04-18</remarks>
        public static bool IsDecimalDigit(this char ch) =>
            Digits.IndexOf(ch).Between(MinDigit, MaxDecimalDigit);
        /// <summary>
        /// <para>Является ли символ шестнадцатиричной цифрой?</para>
        /// </summary>
        /// <param name="ch">Исходный символ</param>
        /// <returns>Результат проверки</returns>
        /// <remarks>2021-04-18</remarks>
        public static bool IsHexadecimalDigit(this char ch)
        {
            var pos = Digits.IndexOf(ch);
            return
#if ONLY_HI_DIGITS
                pos.Between(MinDigit, MaxHexDigit);
#else
#if ONLY_LO_DIGITS
                pos.Between(MinHexDigitLo, MaxHexDigitLo);
#else
                pos.Between(MinDigit, MaxHexDigit) ||
                pos.Between(MinHexDigitLo, MaxHexDigitLo);
#endif
#endif
        }
    }
}
