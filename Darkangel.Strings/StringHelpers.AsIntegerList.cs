using System;
using System.Collections.Generic;

namespace Darkangel.Strings
{
    public static partial class StringHelpers
    {
        /// <summary>
        /// <para>Преобразовать в текст вектор значений</para>
        /// </summary>
        /// <param name="vector">Вектор значений</param>
        /// <param name="radix">Система счисления</param>
        /// <param name="delimiter">Разделитель значений</param>
        /// <returns>Список элементов вектора, в виде текста</returns>
        public static string AsString(this SByte[] vector, int radix, string delimiter = DefaultListDelimiter)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = vector ?? throw new ArgumentNullException(nameof(vector));
#endif
            #endregion Check arguments

            var list = new List<string>();
            foreach(var value in vector)
            {
                list.Add(value.IntToStr(radix));
            }
            return string.Join(delimiter ?? DefaultListDelimiter, list.ToArray());
        }
        /// <summary>
        /// <para>Преобразовать в текст вектор значений</para>
        /// </summary>
        /// <param name="vector">Вектор значений</param>
        /// <param name="radix">Система счисления</param>
        /// <param name="delimiter">Разделитель значений</param>
        /// <returns>Список элементов вектора, в виде текста</returns>
        public static string AsString(this Byte[] vector, int radix, string delimiter = DefaultListDelimiter)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = vector ?? throw new ArgumentNullException(nameof(vector));
#endif
            #endregion Check arguments
            var list = new List<string>();
            foreach (var value in vector)
            {
                list.Add(value.IntToStr(radix));
            }
            return string.Join(delimiter ?? DefaultListDelimiter, list.ToArray());
        }
        /// <summary>
        /// <para>Преобразовать в текст вектор значений</para>
        /// </summary>
        /// <param name="vector">Вектор значений</param>
        /// <param name="radix">Система счисления</param>
        /// <param name="delimiter">Разделитель значений</param>
        /// <returns>Список элементов вектора, в виде текста</returns>
        public static string AsString(this Int16[] vector, int radix, string delimiter = DefaultListDelimiter)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = vector ?? throw new ArgumentNullException(nameof(vector));
#endif
            #endregion Check arguments
            var list = new List<string>();
            foreach (var value in vector)
            {
                list.Add(value.IntToStr(radix));
            }
            return string.Join(delimiter ?? DefaultListDelimiter, list.ToArray());
        }
        /// <summary>
        /// <para>Преобразовать в текст вектор значений</para>
        /// </summary>
        /// <param name="vector">Вектор значений</param>
        /// <param name="radix">Система счисления</param>
        /// <param name="delimiter">Разделитель значений</param>
        /// <returns>Список элементов вектора, в виде текста</returns>
        public static string AsString(this UInt16[] vector, int radix, string delimiter = DefaultListDelimiter)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = vector ?? throw new ArgumentNullException(nameof(vector));
#endif
            #endregion Check arguments
            var list = new List<string>();
            foreach (var value in vector)
            {
                list.Add(value.IntToStr(radix));
            }
            return string.Join(delimiter ?? DefaultListDelimiter, list.ToArray());
        }
        /// <summary>
        /// <para>Преобразовать в текст вектор значений</para>
        /// </summary>
        /// <param name="vector">Вектор значений</param>
        /// <param name="radix">Система счисления</param>
        /// <param name="delimiter">Разделитель значений</param>
        /// <returns>Список элементов вектора, в виде текста</returns>
        public static string AsString(this Int32[] vector, int radix, string delimiter = DefaultListDelimiter)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = vector ?? throw new ArgumentNullException(nameof(vector));
#endif
            #endregion Check arguments
            var list = new List<string>();
            foreach (var value in vector)
            {
                list.Add(value.IntToStr(radix));
            }
            return string.Join(delimiter ?? DefaultListDelimiter, list.ToArray());
        }
        /// <summary>
        /// <para>Преобразовать в текст вектор значений</para>
        /// </summary>
        /// <param name="vector">Вектор значений</param>
        /// <param name="radix">Система счисления</param>
        /// <param name="delimiter">Разделитель значений</param>
        /// <returns>Список элементов вектора, в виде текста</returns>
        public static string AsString(this UInt32[] vector, int radix, string delimiter = DefaultListDelimiter)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = vector ?? throw new ArgumentNullException(nameof(vector));
#endif
            #endregion Check arguments
            var list = new List<string>();
            foreach (var value in vector)
            {
                list.Add(value.IntToStr(radix));
            }
            return string.Join(delimiter ?? DefaultListDelimiter, list.ToArray());
        }
        /// <summary>
        /// <para>Преобразовать в текст вектор значений</para>
        /// </summary>
        /// <param name="vector">Вектор значений</param>
        /// <param name="radix">Система счисления</param>
        /// <param name="delimiter">Разделитель значений</param>
        /// <returns>Список элементов вектора, в виде текста</returns>
        public static string AsString(this Int64[] vector, int radix, string delimiter = DefaultListDelimiter)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = vector ?? throw new ArgumentNullException(nameof(vector));
#endif
            #endregion Check arguments
            var list = new List<string>();
            foreach (var value in vector)
            {
                list.Add(value.IntToStr(radix));
            }
            return string.Join(delimiter ?? DefaultListDelimiter, list.ToArray());
        }
        /// <summary>
        /// <para>Преобразовать в текст вектор значений</para>
        /// </summary>
        /// <param name="vector">Вектор значений</param>
        /// <param name="radix">Система счисления</param>
        /// <param name="delimiter">Разделитель значений</param>
        /// <returns>Список элементов вектора, в виде текста</returns>
        public static string AsString(this UInt64[] vector, int radix, string delimiter = DefaultListDelimiter)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = vector ?? throw new ArgumentNullException(nameof(vector));
#endif
            #endregion Check arguments
            var list = new List<string>();
            foreach (var value in vector)
            {
                list.Add(value.IntToStr(radix));
            }
            return string.Join(delimiter ?? DefaultListDelimiter, list.ToArray());
        }
    }
}
