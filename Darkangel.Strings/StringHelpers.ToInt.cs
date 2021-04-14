using System;

namespace Darkangel.Strings
{
    public static partial class StringHelpers
    {
        private const char Minus = '-';
        private const char Plus = '+';

        /// <summary>
        /// <para>Преобразовать текст в число <see cref="Int64"/>, с учетом системы счисления</para>
        /// </summary>
        /// <param name="text">Исходный текст</param>
        /// <param name="radix">Система счисления</param>
        /// <returns>Результирующее число</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"/>
        public static Int64 StrToInt64(this string text, int radix)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(text));
            CheckRadix(radix);
#endif
            #endregion Проверка аргументов
            string str = text;
            bool negative = false;
            if (str.StartsWith(Minus))
            {
                negative = true;
                str = str[1..];
            }
            else if(str.StartsWith(Plus))
            {
                str = str[1..];
            }

            var res = StrToUInt64(str, radix);

            if(res > Int64.MaxValue)
            {
                throw new OverflowException();
            }
            return (negative) ? (-((Int64)res)) : ((Int64)res);
        }
        /// <summary>
        /// <para>Преобразовать текст в число <see cref="Int32"/>, с учетом системы счисления</para>
        /// </summary>
        /// <param name="text">Исходный текст</param>
        /// <param name="radix">Система счисления</param>
        /// <returns>Результирующее число</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"/>
        public static Int32 StrToInt32(this string text, int radix)
        {
            var res = StrToInt64(text, radix);
            if(res > Int32.MaxValue)
            {
                throw new OverflowException();
            }
            else
            {
                return (Int32)res;
            }
        }
        /// <summary>
        /// <para>Преобразовать текст в число <see cref="Int16"/>, с учетом системы счисления</para>
        /// </summary>
        /// <param name="text">Исходный текст</param>
        /// <param name="radix">Система счисления</param>
        /// <returns>Результирующее число</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"/>
        public static Int16 StrToInt16(this string text, int radix)
        {
            var res = StrToInt64(text, radix);
            if (res > Int16.MaxValue)
            {
                throw new OverflowException();
            }
            else
            {
                return (Int16)res;
            }
        }
        /// <summary>
        /// <para>Преобразовать текст в число <see cref="SByte"/>, с учетом системы счисления</para>
        /// </summary>
        /// <param name="text">Исходный текст</param>
        /// <param name="radix">Система счисления</param>
        /// <returns>Результирующее число</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"/>
        public static SByte StrToInt8(this string text, int radix)
        {
            var res = StrToInt64(text, radix);
            if (res > SByte.MaxValue)
            {
                throw new OverflowException();
            }
            else
            {
                return (SByte)res;
            }
        }

        /// <summary>
        /// <para>Преобразовать текст в число <see cref="Int64"/>, с учетом системы счисления</para>
        /// </summary>
        /// <param name="text">Исходный текст</param>
        /// <param name="radix">Система счисления</param>
        /// <returns>Результирующее число</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"/>
        public static UInt64 StrToUInt64(this string text, int radix)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException(nameof(text));
            CheckRadix(radix);
#endif
            #endregion Проверка аргументов
            string str = text;
            // Особый случай: шестнадцатиричные числа могут быть записаны
            // в "смешаном регистре". Остальные системы счисления идут, как есть.
            if (radix == 16)
            {
#if ONLY_LO_DIGITS
                str = str.ToLower();
#else
                str = str.ToUpper();
#endif
            }
            var res = 0UL;
            foreach (var ch in str.ToCharArray())
            {
                var pos = Digits.IndexOf(ch);
                if (pos < 0)
                {
                    throw new InvalidOperationException(
                        string.Format(StringResources.InvalidSymbolMessageFormat, ch, str, radix));
                }
                res *= (UInt64)radix;
                res += (UInt64)pos;
            }
            return res;
        }
        /// <summary>
        /// <para>Преобразовать текст в число <see cref="UInt32"/>, с учетом системы счисления</para>
        /// </summary>
        /// <param name="text">Исходный текст</param>
        /// <param name="radix">Система счисления</param>
        /// <returns>Результирующее число</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"/>
        public static UInt32 StrToUInt32(this string text, int radix)
        {
            var res = StrToUInt64(text, radix);
            if (res > UInt32.MaxValue)
            {
                throw new OverflowException();
            }
            else
            {
                return (UInt32)res;
            }
        }
        /// <summary>
        /// <para>Преобразовать текст в число <see cref="UInt16"/>, с учетом системы счисления</para>
        /// </summary>
        /// <param name="text">Исходный текст</param>
        /// <param name="radix">Система счисления</param>
        /// <returns>Результирующее число</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"/>
        public static UInt16 StrToUInt16(this string text, int radix)
        {
            var res = StrToUInt64(text, radix);
            if (res > UInt16.MaxValue)
            {
                throw new OverflowException();
            }
            else
            {
                return (UInt16)res;
            }
        }
        /// <summary>
        /// <para>Преобразовать текст в число <see cref="Byte"/>, с учетом системы счисления</para>
        /// </summary>
        /// <param name="text">Исходный текст</param>
        /// <param name="radix">Система счисления</param>
        /// <returns>Результирующее число</returns>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException"/>
        public static Byte StrToUInt8(this string text, int radix)
        {
            var res = StrToUInt64(text, radix);
            if (res > Byte.MaxValue)
            {
                throw new OverflowException();
            }
            else
            {
                return (Byte)res;
            }
        }
    }
}
