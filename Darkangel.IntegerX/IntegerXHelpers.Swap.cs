using System;

namespace Darkangel.IntegerX
{
    public static partial class IntegerXHelpers
    {
        /// <summary>
        /// <para>Поменять порядок байт в значении</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <returns>Результат перестановки</returns>
        /// <remarks>2021-04-18</remarks>
        public static UInt16 Swap(this UInt16 value) =>
            (UInt16)
            (
            ((value & 0x00ff) << 8) |
            ((value & 0xff00) >> 8)
            );
        /// <summary>
        /// <para>Поменять порядок байт в значении</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <returns>Результат перестановки</returns>
        /// <remarks>2021-04-18</remarks>
        public static UInt24 Swap(this UInt24 value)
        {
            UInt32 res = value;
            return (UInt24)
            (
            ((res & 0x0000ff) << 16) |
            ((res & 0x00ff00) >>  0) |
            ((res & 0xff0000) >> 16)
            );
        }
        /// <summary>
        /// <para>Поменять порядок байт в значении</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <returns>Результат перестановки</returns>
        /// <remarks>2021-04-18</remarks>
        public static UInt32 Swap(this UInt32 value) =>
            (UInt32)
            (
            ((value & 0x000000ffU) << 24) |
            ((value & 0x0000ff00U) <<  8) |
            ((value & 0x00ff0000U) >>  8) |
            ((value & 0xff000000U) >> 24)
            );
        /// <summary>
        /// <para>Поменять порядок байт в значении</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <returns>Результат перестановки</returns>
        /// <remarks>2021-04-18</remarks>
        public static UInt48 Swap(this UInt48 value)
        {
            UInt64 res = value;
            return (UInt48)
            (
            ((res & 0x00000000000000ffUL) << 40) |
            ((res & 0x000000000000ff00UL) << 24) |
            ((res & 0x0000000000ff0000UL) <<  8) |
            ((res & 0x00000000ff000000UL) >>  8) |
            ((res & 0x000000ff00000000UL) >> 24) |
            ((res & 0x0000ff0000000000UL) >> 40)
            );
        }
        /// <summary>
        /// <para>Поменять порядок байт в значении</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <returns>Результат перестановки</returns>
        /// <remarks>2021-04-18</remarks>
        public static UInt64 Swap(this UInt64 value) =>
            (UInt64)
            (
            ((value & 0x00000000000000ffUL) << 56) |
            ((value & 0x000000000000ff00UL) << 40) |
            ((value & 0x0000000000ff0000UL) << 24) |
            ((value & 0x00000000ff000000UL) <<  8) |
            ((value & 0x000000ff00000000UL) >>  8) |
            ((value & 0x0000ff0000000000UL) >> 24) |
            ((value & 0x00ff000000000000UL) >> 40) |
            ((value & 0xff00000000000000UL) >> 56)
            );

        /// <summary>
        /// <para>Поменять порядок байт в значении</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <returns>Результат перестановки</returns>
        /// <remarks>2021-04-18</remarks>
        public static Int16 Swap(this Int16 value) =>
            unchecked((Int16)Swap(unchecked((UInt16)value)));
        /// <summary>
        /// <para>Поменять порядок байт в значении</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <returns>Результат перестановки</returns>
        /// <remarks>2021-04-18</remarks>
        public static Int32 Swap(this Int32 value) =>
            unchecked((Int32)Swap(unchecked((UInt32)value)));
        /// <summary>
        /// <para>Поменять порядок байт в значении</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <returns>Результат перестановки</returns>
        /// <remarks>2021-04-18</remarks>
        public static Int64 Swap(this Int64 value) =>
            unchecked((Int64)Swap(unchecked((UInt64)value)));
    }
}
