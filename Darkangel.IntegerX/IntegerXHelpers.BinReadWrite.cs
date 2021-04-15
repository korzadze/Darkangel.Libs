using System;

namespace Darkangel.IntegerX
{
    /// <summary>
    /// <para>Утилиты для работы с целочисленными значениями</para>
    /// </summary>
    public static partial class IntegerXHelpers
    {
        #region Int8
        /// <summary>
        /// <para>Преобразовать значение <see cref="SByte"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
#pragma warning disable IDE0060 // Удалите неиспользуемый параметр
        public static byte[] GetBytes(this SByte value, bool isLittleEndian = true)
#pragma warning restore IDE0060 // Удалите неиспользуемый параметр
        {
            return new byte[] { (byte)value };
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="SByte"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Первый байт значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байтов значейния в потоке</param>
        /// <returns>Считанное значение</returns>
        public static SByte GetInt8(this byte[] data, long start = 0, bool isLittleEndian = true)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = data ?? throw new ArgumentNullException(nameof(data));
            if ((start < 0) || ((start + Int8_ByteSize) > data.LongLength))
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
#endif
            #endregion Check arguments

            return (SByte)data[start];
        }
        #endregion Int8
        #region UInt8
        /// <summary>
        /// <para>Преобразовать значение <see cref="Byte"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
#pragma warning disable IDE0060 // Удалите неиспользуемый параметр
        public static byte[] GetBytes(this Byte value, bool isLittleEndian = true)
#pragma warning restore IDE0060 // Удалите неиспользуемый параметр
        {
            return new byte[] { value };
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="Byte"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Первый байт значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байтов значейния в потоке</param>
        /// <returns>Считанное значение</returns>
        public static Byte GetUInt8(this byte[] data, long start = 0, bool isLittleEndian = true)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = data ?? throw new ArgumentNullException(nameof(data));
            if ((start < 0) || ((start + UInt8_ByteSize) > data.LongLength))
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
#endif
            #endregion Check arguments

            return (Byte)data[start];
        }
        #endregion UInt8
        #region Int16
        /// <summary>
        /// <para>Преобразовать значение <see cref="Int16"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        public static byte[] GetBytes(this Int16 value, bool isLittleEndian = true)
        {
            return GetBytes(unchecked((UInt16)value), isLittleEndian);
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="Int16"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Первый байт значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байтов значейния в потоке</param>
        /// <returns>Считанное значение</returns>
        public static Int16 GetInt16(this byte[] data, long start = 0, bool isLittleEndian = true)
        {
            return unchecked((Int16)GetUInt16(data, start, isLittleEndian));
        }
        #endregion Int16
        #region UInt16
        /// <summary>
        /// <para>Преобразовать значение <see cref="Int16"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        public static byte[] GetBytes(this UInt16 value, bool isLittleEndian = true)
        {
            var buf = new byte[UInt16_ByteSize];
            if (isLittleEndian)
            {
                buf[0]= (byte)((value >> 0) & 0xff);
                buf[1] =(byte)((value >> 8) & 0xff);
            }
            else
            {
                buf[1] = (byte)((value >> 0) & 0xff);
                buf[0] = (byte)((value >> 8) & 0xff);
            }
            return buf;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt16"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Первый байт значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байтов значейния в потоке</param>
        /// <returns>Считанное значение</returns>
        public static UInt16 GetUInt16(this byte[] data, long start = 0, bool isLittleEndian = true)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = data ?? throw new ArgumentNullException(nameof(data));
            if ((start < 0) || ((start + UInt16_ByteSize) > data.LongLength))
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
#endif
            #endregion Check arguments

            if (isLittleEndian)
            {
                return (UInt16)(
                    (data[start + 0] << 0) |
                    (data[start + 1] << 8)
                    );
            }
            else
            {
                return (UInt16)(
                    (data[start + 1] << 0) |
                    (data[start + 0] << 8)
                    );
            }
        }
        #endregion UInt16
        #region UInt24
        /// <summary>
        /// <para>Преобразовать значение <see cref="UInt24"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        public static byte[] GetBytes(this UInt24 value, bool isLittleEndian = true)
        {
            return value.GetBytes(isLittleEndian);
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt24"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Первый байт значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байтов значейния в потоке</param>
        /// <returns>Считанное значение</returns>
        public static UInt24 GetUInt24(this byte[] data, long start = 0, bool isLittleEndian = true)
        {
            return UInt24.FromBytes(data, start, isLittleEndian);
        }
        #endregion UInt24
        #region Int32
        /// <summary>
        /// <para>Преобразовать значение <see cref="Int32"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        public static byte[] GetBytes(this Int32 value, bool isLittleEndian = true)
        {
            return GetBytes(unchecked((UInt32)value), isLittleEndian);
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="Int32"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Первый байт значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байтов значейния в потоке</param>
        /// <returns>Считанное значение</returns>
        public static Int32 GetInt32(this byte[] data, long start = 0, bool isLittleEndian = true)
        {
            return unchecked((Int32)GetUInt32(data, start, isLittleEndian));
        }
        #endregion Int32
        #region UInt32
        /// <summary>
        /// <para>Преобразовать значение <see cref="UInt32"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        public static byte[] GetBytes(this UInt32 value, bool isLittleEndian = true)
        {
            var buf = new byte[UInt32_ByteSize];
            if (isLittleEndian)
            {
                buf[0] = (byte)((value >>  0) & 0xff);
                buf[1] = (byte)((value >>  8) & 0xff);
                buf[2] = (byte)((value >> 16) & 0xff);
                buf[3] = (byte)((value >> 24) & 0xff);
            }
            else
            {
                buf[3] = (byte)((value >>  0) & 0xff);
                buf[2] = (byte)((value >>  8) & 0xff);
                buf[1] = (byte)((value >> 16) & 0xff);
                buf[0] = (byte)((value >> 24) & 0xff);
            }
            return buf;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt32"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Первый байт значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байтов значейния в потоке</param>
        /// <returns>Считанное значение</returns>
        public static UInt32 GetUInt32(this byte[] data, long start = 0, bool isLittleEndian = true)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = data ?? throw new ArgumentNullException(nameof(data));
            if ((start < 0) || ((start + UInt32_ByteSize) > data.LongLength))
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
#endif
            #endregion Check arguments

            if (isLittleEndian)
            {
                return (UInt32)(
                    (data[start + 0] <<  0) |
                    (data[start + 1] <<  8) |
                    (data[start + 2] << 16) |
                    (data[start + 3] << 24)
                    );
            }
            else
            {
                return (UInt32)(
                    (data[start + 3] <<  0) |
                    (data[start + 2] <<  8) |
                    (data[start + 1] << 16) |
                    (data[start + 0] << 24)
                    );
            }
        }
        #endregion UInt32
        #region UInt48
        /// <summary>
        /// <para>Преобразовать значение <see cref="UInt48"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        public static byte[] GetBytes(this UInt48 value, bool isLittleEndian = true)
        {
            return value.GetBytes(isLittleEndian);
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt48"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Первый байт значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байтов значейния в потоке</param>
        /// <returns>Считанное значение</returns>
        public static UInt48 GetUInt48(this byte[] data, long start = 0, bool isLittleEndian = true)
        {
            return UInt48.FromBytes(data, start, isLittleEndian);
        }
        #endregion UInt48
        #region Int64
        /// <summary>
        /// <para>Преобразовать значение <see cref="Int64"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        public static byte[] GetBytes(this Int64 value, bool isLittleEndian = true)
        {
            return GetBytes(unchecked((UInt64)value), isLittleEndian);
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="Int64"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Первый байт значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байтов значейния в потоке</param>
        /// <returns>Считанное значение</returns>
        public static Int64 GetInt64(this byte[] data, long start = 0, bool isLittleEndian = true)
        {
            return unchecked((Int64)GetUInt64(data, start, isLittleEndian));
        }
        #endregion Int64
        #region UInt64
        /// <summary>
        /// <para>Преобразовать значение <see cref="UInt64"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        public static byte[] GetBytes(this UInt64 value, bool isLittleEndian = true)
        {
            var buf = new byte[UInt64_ByteSize];
            if (isLittleEndian)
            {
                buf[0] = (byte)((value >> 0) & 0xff);
                buf[1] = (byte)((value >> 8) & 0xff);
                buf[2] = (byte)((value >> 16) & 0xff);
                buf[3] = (byte)((value >> 24) & 0xff);
                buf[4] = (byte)((value >> 32) & 0xff);
                buf[5] = (byte)((value >> 40) & 0xff);
                buf[6] = (byte)((value >> 48) & 0xff);
                buf[7] = (byte)((value >> 56) & 0xff);
            }
            else
            {
                buf[7] = (byte)((value >> 0) & 0xff);
                buf[6] = (byte)((value >> 8) & 0xff);
                buf[5] = (byte)((value >> 16) & 0xff);
                buf[4] = (byte)((value >> 24) & 0xff);
                buf[3] = (byte)((value >> 32) & 0xff);
                buf[2] = (byte)((value >> 40) & 0xff);
                buf[1] = (byte)((value >> 48) & 0xff);
                buf[0] = (byte)((value >> 56) & 0xff);
            }
            return buf;
        }
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt64"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Первый байт значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байтов значейния в потоке</param>
        /// <returns>Считанное значение</returns>
        public static UInt64 GetUInt64(this byte[] data, long start = 0, bool isLittleEndian = true)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = data ?? throw new ArgumentNullException(nameof(data));
            if ((start < 0) || ((start + UInt64_ByteSize) > data.LongLength))
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
#endif
            #endregion Check arguments

            if (isLittleEndian)
            {
                return (UInt64)(
                    (data[start + 0] <<  0) |
                    (data[start + 1] <<  8) |
                    (data[start + 2] << 16) |
                    (data[start + 3] << 24) |
                    (data[start + 4] << 32) |
                    (data[start + 5] << 40) |
                    (data[start + 6] << 48) |
                    (data[start + 7] << 56)
                    );
            }
            else
            {
                return (UInt64)(
                    (data[start + 7] <<  0) |
                    (data[start + 6] <<  8) |
                    (data[start + 5] << 16) |
                    (data[start + 4] << 24) |
                    (data[start + 3] << 32) |
                    (data[start + 2] << 40) |
                    (data[start + 1] << 48) |
                    (data[start + 0] << 56)
                    );
            }
        }
        #endregion UInt64
    }
}
