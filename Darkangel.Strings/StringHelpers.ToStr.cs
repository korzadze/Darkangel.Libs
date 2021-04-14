using System;
using System.Text;

namespace Darkangel.Strings
{
    public static partial class StringHelpers
    {
        private static void CheckRadix(int radix)
        {
            if (radix < MinRadix || radix > MaxRadix)
            {
                throw new ArgumentOutOfRangeException(string.Format("radix: {0} (Must be between {1} and {2})", radix, MinRadix, MaxRadix));
            }
        }
        private static string Int2Str_Int(Int64 value, int radix)
        {
            #region Check arguments
#if CHECK_ARGS
            CheckRadix(radix);
#endif
            #endregion Check arguments
            if (value < 0)
            {
                return MinusSign + UInt2Str_Int((UInt64)(-value), radix);
            }
            else
            {
                return UInt2Str_Int((UInt64)value, radix);
            }
        }
        private static string UInt2Str_Int(UInt64 value, int radix)
        {
            if (value == 0) return Zero;

            #region Check arguments
#if CHECK_ARGS
            CheckRadix(radix);
#endif
            #endregion Check arguments

            var sb = new StringBuilder();
            var val = value;

            while (value > 0)
            {
                var part = value % (uint)radix;
                val /= (uint)radix;
                sb.Append(Digits[(int)part]);
            }

            char[] res = sb.ToString().ToCharArray();
            Array.Reverse(res);

            return new string(res);
        }
        /// <summary>
        /// <para>Преобразовать значение в строку, с учетом системы счисления</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="radix">Система счисления</param>
        /// <returns>Текстовое представление значения в указанной системе счисления</returns>
        public static string IntToStr(this Byte value, int radix) =>
            UInt2Str_Int(value, radix);
        /// <summary>
        /// <para>Преобразовать значение в строку, с учетом системы счисления</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="radix">Система счисления</param>
        /// <returns>Текстовое представление значения в указанной системе счисления</returns>
        public static string IntToStr(this SByte value, int radix) =>
            Int2Str_Int(value, radix);
        /// <summary>
        /// <para>Преобразовать значение в строку, с учетом системы счисления</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="radix">Система счисления</param>
        /// <returns>Текстовое представление значения в указанной системе счисления</returns>
        public static string IntToStr(this UInt16 value, int radix) =>
            UInt2Str_Int(value, radix);
        /// <summary>
        /// <para>Преобразовать значение в строку, с учетом системы счисления</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="radix">Система счисления</param>
        /// <returns>Текстовое представление значения в указанной системе счисления</returns>
        public static string IntToStr(this Int16 value, int radix) =>
            Int2Str_Int(value, radix);
        /// <summary>
        /// <para>Преобразовать значение в строку, с учетом системы счисления</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="radix">Система счисления</param>
        /// <returns>Текстовое представление значения в указанной системе счисления</returns>
        public static string IntToStr(this UInt32 value, int radix) =>
            UInt2Str_Int(value, radix);
        /// <summary>
        /// <para>Преобразовать значение в строку, с учетом системы счисления</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="radix">Система счисления</param>
        /// <returns>Текстовое представление значения в указанной системе счисления</returns>
        public static string IntToStr(this Int32 value, int radix) =>
            Int2Str_Int(value, radix);
        /// <summary>
        /// <para>Преобразовать значение в строку, с учетом системы счисления</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="radix">Система счисления</param>
        /// <returns>Текстовое представление значения в указанной системе счисления</returns>
        public static string IntToStr(this UInt64 value, int radix) =>
            UInt2Str_Int(value, radix);
        /// <summary>
        /// <para>Преобразовать значение в строку, с учетом системы счисления</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="radix">Система счисления</param>
        /// <returns>Текстовое представление значения в указанной системе счисления</returns>
        public static string IntToStr(this Int64 value, int radix) =>
            Int2Str_Int(value, radix);
    }
}
