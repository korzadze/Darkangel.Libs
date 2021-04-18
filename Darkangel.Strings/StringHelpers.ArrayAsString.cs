using System;
using System.Collections.Generic;

namespace Darkangel.Strings
{
    public static partial class StringHelpers
    {
        /// <summary>
        /// <para>Преобразовать вектор в строку списка значений</para>
        /// </summary>
        /// <typeparam name="T">Тип элементов вектора</typeparam>
        /// <param name="arr">Вектор значений</param>
        /// <param name="delimiter">Разделитель элементов в списке</param>
        /// <returns>Список значений ввиде строки</returns>
        /// <remarks>2021-04-18</remarks>
        public static string AsString<T>(this T[] arr, string delimiter = DefaultListDelimiter)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = arr ?? throw new ArgumentNullException(nameof(arr));
#endif
            #endregion Check arguments

            return string.Join(delimiter ?? DefaultListDelimiter, arr);
        }
        /// <summary>
        /// <para>Представить вектор значений, как список шестнадцатиричных значений в исходном коде C#</para>
        /// </summary>
        /// <param name="arr">Вектор значений</param>
        /// <param name="delimiter">Разделитель значений в списке</param>
        /// <returns>Список значений вектора</returns>
        /// <remarks>2021-04-18</remarks>
        public static string AsHexString(this Byte[] arr, string delimiter = DefaultListDelimiter)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = arr ?? throw new ArgumentNullException(nameof(arr));
#endif
            #endregion Check arguments

            var vals = new List<string>();
            foreach (var v in arr)
            {
                vals.Add(string.Format("0x{0:x02}", v));
            }
            return string.Join(delimiter ?? DefaultListDelimiter, vals);
        }
        /// <summary>
        /// <para>Представить вектор значений, как список шестнадцатиричных значений в исходном коде C#</para>
        /// </summary>
        /// <param name="arr">Вектор значений</param>
        /// <param name="delimiter">Разделитель значений в списке</param>
        /// <returns>Список значений вектора</returns>
        /// <remarks>2021-04-18</remarks>
        public static string AsHexString(this UInt16[] arr, string delimiter = DefaultListDelimiter)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = arr ?? throw new ArgumentNullException(nameof(arr));
#endif
            #endregion Check arguments

            var vals = new List<string>();
            foreach (var v in arr)
            {
                vals.Add(string.Format("0x{0:x04}", v));
            }
            return string.Join(delimiter ?? DefaultListDelimiter, vals);
        }
        /// <summary>
        /// <para>Представить вектор значений, как список шестнадцатиричных значений в исходном коде C#</para>
        /// </summary>
        /// <param name="arr">Вектор значений</param>
        /// <param name="delimiter">Разделитель значений в списке</param>
        /// <returns>Список значений вектора</returns>
        /// <remarks>2021-04-18</remarks>
        public static string AsHexString(this UInt32[] arr, string delimiter = DefaultListDelimiter)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = arr ?? throw new ArgumentNullException(nameof(arr));
#endif
            #endregion Check arguments

            var vals = new List<string>();
            foreach (var v in arr)
            {
                vals.Add(string.Format("0x{0:x08}U", v));
            }
            return string.Join(delimiter ?? DefaultListDelimiter, vals);
        }
        /// <summary>
        /// <para>Представить вектор значений, как список шестнадцатиричных значений в исходном коде C#</para>
        /// </summary>
        /// <param name="arr">Вектор значений</param>
        /// <param name="delimiter">Разделитель значений в списке</param>
        /// <returns>Список значений вектора</returns>
        /// <remarks>2021-04-18</remarks>
        public static string AsHexString(this UInt64[] arr, string delimiter = DefaultListDelimiter)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = arr ?? throw new ArgumentNullException(nameof(arr));
#endif
            #endregion Check arguments

            var vals = new List<string>();
            foreach (var v in arr)
            {
                vals.Add(string.Format("0x{0:x016}UL", v));
            }
            return string.Join(delimiter ?? DefaultListDelimiter, vals);
        }
    }
}
