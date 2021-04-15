using System;
using System.Text.RegularExpressions;

namespace Darkangel.Strings
{
    /// <summary>
    /// <para>Вспомогательный класс для определения системы счисления</para>
    /// </summary>
    internal class IntegerRadixDetector
    {
        public readonly int? Radix;
        public readonly Regex? Expression;
        public readonly string? Sign;
        public readonly string? Value;
        public readonly string? Format;
        internal IntegerRadixDetector(int radix, Regex expr)
        {
            Radix = radix;
            Expression = expr;
            Format = null;
            Sign = null;
            Value = null;
        }

        public IntegerRadixDetector(IntegerRadixDetector src, Match match)
        {
            Radix = src.Radix;
            Expression = null;
            Format = (match.Groups.ContainsKey(GroupNameFormat)) ? (match.Groups[GroupNameFormat].Value) : (null);
            Sign = (match.Groups.ContainsKey(GroupNameSign)) ? (match.Groups[GroupNameSign].Value) : (null);
            Value = (match.Groups.ContainsKey(GroupNameValue)) ? (match.Groups[GroupNameValue].Value) : (null);
        }

        public IntegerRadixDetector(int radix, string text)
        {
            Radix = radix;
            Expression = null;
            Format = null;
            Sign = null;
            Value = text;
        }

        public static IntegerRadixDetector? DetectRadixByFormat(string text)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = text ?? throw new ArgumentNullException(nameof(text));
#endif
            #endregion Проверка аргументов
            foreach (var md in _Detectors)
            {
                Match? m = md.Expression?.Match(text) ?? null;
                if (m?.Success ?? false)
                {
                    return new IntegerRadixDetector(md, m);
                }
            }
            return null;
        }

        public static IntegerRadixDetector? DetectRadixByContent(string text)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = text ?? throw new ArgumentNullException(nameof(text));
#endif
            #endregion Проверка аргументов
            var radix = -1;
            foreach (char ch in text)
            {
                var pos = StringHelpers.Digits.IndexOf(ch);
                if ((pos > 0) && (radix < pos))
                {
                    radix = pos;
                }
            }
            if (radix == 0) return new IntegerRadixDetector(10, text);

            radix++;
            if ((radix >= StringHelpers.MinRadix) &&
                (radix <= StringHelpers.MaxRadix))
            {
                return new IntegerRadixDetector(radix, text);
            }
            else
            {
                return null;
            }
        }

        private const string GroupNameSign = "sign";
        private const string GroupNameValue = "digits";
        private const string GroupNameFormat = "fmt";

        private const string sBinaryAsm = @"^(?<" + GroupNameValue + ">[01]+)(?<" + GroupNameFormat + ">b)$";
        private const string sBinaryCSharp = @"^(?<" + GroupNameFormat + ">b)(?<" + GroupNameValue + ">[01]+)$";
        private const string sHexadecimalC = @"^\(?<" + GroupNameFormat + ">$|0[Xx])(?<" + GroupNameValue + ">[0-9A-Fa-f]+)$";
        private const string sHexadecimalAsm = @"^(?<" + GroupNameValue + ">[0-9A-Fa-f]+)(?<" + GroupNameFormat + ">[Hh])$";
        private const string sOctal = @"^(?<" + GroupNameSign + ">[+-])?(?<" + GroupNameValue + ">0[1-7][0-7]*)$";
        private const string sDecimal = @"^(?<" + GroupNameSign + ">[+-])?(?<" + GroupNameValue + ">[1-9][0-9]*)$";

        private static readonly IntegerRadixDetector[] _Detectors = new[]
        {
            new IntegerRadixDetector( 2, new Regex(sBinaryAsm, RegexOptions.Compiled | RegexOptions.Singleline)),
            new IntegerRadixDetector( 2, new Regex(sBinaryCSharp, RegexOptions.Compiled | RegexOptions.Singleline)),
            new IntegerRadixDetector( 8, new Regex(sOctal, RegexOptions.Compiled | RegexOptions.Singleline)),
            new IntegerRadixDetector(16, new Regex(sHexadecimalC, RegexOptions.Compiled | RegexOptions.Singleline)),
            new IntegerRadixDetector(16, new Regex(sHexadecimalAsm, RegexOptions.Compiled | RegexOptions.Singleline)),
            new IntegerRadixDetector(10, new Regex(sDecimal, RegexOptions.Compiled | RegexOptions.Singleline)),
        };

        public static IntegerRadixDetector? DetectIntegerRadix(string text)
        {
            var m = DetectRadixByFormat(text);
            if (m != null)
            {
                return m;
            }
            m = DetectRadixByContent(text);
            if (m != null)
            {
                return m;
            }
            return null;
        }
    }
}
