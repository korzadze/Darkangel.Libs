namespace Darkangel.Strings
{
    /// <summary>
    /// <para>Утилиты для работы со строками</para>
    /// </summary>
    public static partial class StringHelpers
    {
        /// <summary>
        /// <para>Разделитель значений списка по-умолчанию</para>
        /// </summary>
        public const string DefaultListDelimiter = ", ";

        private const string Zero = "0";
        private const string MinusSign = "-";
        /// <summary>
        /// <para>Строка 'чисел', используемиых в преобразованиях</para>
        /// </summary>
#if ONLY_HI_DIGITS
        public static string Digits => "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
#else
#if ONLY_LO_DIGITS
        public static string Digits => "0123456789abcdefghijklmnopqrstuvwxyz";
#else
        public static string Digits => "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
#endif
#endif
        private const int MinDigit = 0;
        private const int MaxBinaryDigit = 1;
        private const int MaxOctalDigit = 7;
        private const int MaxDecimalDigit = 9;
        private const int MaxHexDigit = 15;

#if ONLY_HI_DIGITS
#else
#if ONLY_LO_DIGITS
#else
        private const int MinHexDigitLo = 36;
        private const int MaxHexDigitLo = 41;
#endif
#endif

        /// <summary>
        /// <para>Минимальная система счисления, поддерживаемая библиотекой</para>
        /// </summary>
        public static int MinRadix => 2;
        /// <summary>
        /// <para>Максимальная система счисления, поддерживаемая библиотекой</para>
        /// </summary>
        public static int MaxRadix => Digits.Length - 1;
    }
}
