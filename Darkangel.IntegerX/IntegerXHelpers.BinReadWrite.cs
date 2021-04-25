using System;

namespace Darkangel.IntegerX
{
    public static partial class IntegerXHelpers
    {
        #region Int8
        /// <summary>
        /// <para>Преобразовать значение <see cref="SByte"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        /// <remarks>2021-04-18</remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Удалите неиспользуемый параметр", Justification = "<Ожидание>")]
        public static byte[] GetBytes(this SByte value, bool isLittleEndian = true) =>
            new byte[] { (byte)value };
        /// <summary>
        /// <para>Прочитать значение <see cref="SByte"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Первый байт значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байтов значейния в потоке</param>
        /// <returns>Считанное значение</returns>
        /// <remarks>2021-04-18</remarks>
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
        /// <summary>
        /// <para>Записать значение <see cref="SByte"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="stream"></param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        /// <remarks>2021-04-25</remarks>
        public static long WriteBuf(this SByte value, byte[] stream, long offset = 0, bool isLittleEndian = true)
        {
            const int ValueSize = Int8_ByteSize;
            #region Проверка аргументов
#if CHECK_ARGS
            _ = stream ?? throw new ArgumentNullException(nameof(stream));
            if (offset < 0 || (offset + ValueSize) > stream.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
#endif
            #endregion Проверка аргументов

#if USE_FULL
            var buf = value.GetBytes(isLittleEndian);
            Array.Copy(buf, 0, stream, offset, ValueSize);
#else
            stream[offset] = (byte)value;
#endif
            return ValueSize;
        }
        #endregion Int8
        #region UInt8
        /// <summary>
        /// <para>Преобразовать значение <see cref="Byte"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        /// <remarks>2021-04-18</remarks>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Удалите неиспользуемый параметр", Justification = "<Ожидание>")]
        public static byte[] GetBytes(this Byte value, bool isLittleEndian = true) =>
            new byte[] { value };
        /// <summary>
        /// <para>Прочитать значение <see cref="Byte"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Первый байт значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байтов значейния в потоке</param>
        /// <returns>Считанное значение</returns>
        /// <remarks>2021-04-18</remarks>
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
        /// <summary>
        /// <para>Записать значение <see cref="Byte"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="stream"></param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        /// <remarks>2021-04-25</remarks>
        public static long WriteBuf(this Byte value, byte[] stream, long offset = 0, bool isLittleEndian = true)
        {
            const int ValueSize = UInt8_ByteSize;
            #region Проверка аргументов
#if CHECK_ARGS
            _ = stream ?? throw new ArgumentNullException(nameof(stream));
            if (offset < 0 || (offset + ValueSize) > stream.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
#endif
            #endregion Проверка аргументов

#if USE_FULL
            var buf = value.GetBytes(isLittleEndian);
            Array.Copy(buf, 0, stream, offset, ValueSize);
#else
            stream[offset] = value;
#endif
            return ValueSize;
        }
        #endregion UInt8
        #region Int16
        /// <summary>
        /// <para>Преобразовать значение <see cref="Int16"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        /// <remarks>2021-04-18</remarks>
        public static byte[] GetBytes(this Int16 value, bool isLittleEndian = true) =>
            GetBytes(unchecked((UInt16)value), isLittleEndian);
        /// <summary>
        /// <para>Прочитать значение <see cref="Int16"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Первый байт значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байтов значейния в потоке</param>
        /// <returns>Считанное значение</returns>
        /// <remarks>2021-04-18</remarks>
        public static Int16 GetInt16(this byte[] data, long start = 0, bool isLittleEndian = true) =>
            unchecked((Int16)GetUInt16(data, start, isLittleEndian));
        /// <summary>
        /// <para>Записать значение <see cref="Int16"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="stream"></param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        /// <remarks>2021-04-25</remarks>
        public static long WriteBuf(this Int16 value, byte[] stream, long offset = 0, bool isLittleEndian = true)
        {
            const int ValueSize = Int16_ByteSize;
            #region Проверка аргументов
#if CHECK_ARGS
            _ = stream ?? throw new ArgumentNullException(nameof(stream));
            if (offset < 0 || (offset + ValueSize) > stream.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
#endif
            #endregion Проверка аргументов

            var buf = value.GetBytes(isLittleEndian);
            Array.Copy(buf, 0, stream, offset, ValueSize);
            return ValueSize;
        }
        #endregion Int16
        #region UInt16
        /// <summary>
        /// <para>Преобразовать значение <see cref="Int16"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        /// <remarks>2021-04-18</remarks>
        public static byte[] GetBytes(this UInt16 value, bool isLittleEndian = true)
        {
            var buf = new byte[UInt16_ByteSize];
            if (isLittleEndian)
            {
                buf[0] = (byte)((value >> 0) & 0xff);
                buf[1] = (byte)((value >> 8) & 0xff);
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
        /// <remarks>2021-04-18</remarks>
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
        /// <summary>
        /// <para>Записать значение <see cref="UInt16"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="stream"></param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        /// <remarks>2021-04-25</remarks>
        public static long WriteBuf(this UInt16 value, byte[] stream, long offset = 0, bool isLittleEndian = true)
        {
            const int ValueSize = UInt16_ByteSize;
            #region Проверка аргументов
#if CHECK_ARGS
            _ = stream ?? throw new ArgumentNullException(nameof(stream));
            if (offset < 0 || (offset + ValueSize) > stream.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
#endif
            #endregion Проверка аргументов

            var buf = value.GetBytes(isLittleEndian);
            Array.Copy(buf, 0, stream, offset, ValueSize);
            return ValueSize;
        }
        #endregion UInt16
        #region UInt24
        /// <summary>
        /// <para>Преобразовать значение <see cref="UInt24"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        /// <remarks>2021-04-18</remarks>
        public static byte[] GetBytes(this UInt24 value, bool isLittleEndian = true) =>
            value.GetBytes(isLittleEndian);
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt24"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Первый байт значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байтов значейния в потоке</param>
        /// <returns>Считанное значение</returns>
        /// <remarks>2021-04-18</remarks>
        public static UInt24 GetUInt24(this byte[] data, long start = 0, bool isLittleEndian = true) =>
            UInt24.FromBytes(data, start, isLittleEndian);
        /// <summary>
        /// <para>Записать значение <see cref="UInt24"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="stream"></param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        /// <remarks>2021-04-25</remarks>
        public static long WriteBuf(this UInt24 value, byte[] stream, long offset = 0, bool isLittleEndian = true)
        {
            const int ValueSize = UInt24_ByteSize;
            #region Проверка аргументов
#if CHECK_ARGS
            _ = stream ?? throw new ArgumentNullException(nameof(stream));
            if (offset < 0 || (offset + ValueSize) > stream.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
#endif
            #endregion Проверка аргументов

            var buf = value.GetBytes(isLittleEndian);
            Array.Copy(buf, 0, stream, offset, ValueSize);
            return ValueSize;
        }
        #endregion UInt24
        #region Int32
        /// <summary>
        /// <para>Преобразовать значение <see cref="Int32"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        /// <remarks>2021-04-18</remarks>
        public static byte[] GetBytes(this Int32 value, bool isLittleEndian = true) =>
            GetBytes(unchecked((UInt32)value), isLittleEndian);
        /// <summary>
        /// <para>Прочитать значение <see cref="Int32"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Первый байт значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байтов значейния в потоке</param>
        /// <returns>Считанное значение</returns>
        /// <remarks>2021-04-18</remarks>
        public static Int32 GetInt32(this byte[] data, long start = 0, bool isLittleEndian = true) =>
            unchecked((Int32)GetUInt32(data, start, isLittleEndian));
        /// <summary>
        /// <para>Записать значение <see cref="Int32"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="stream"></param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        /// <remarks>2021-04-25</remarks>
        public static long WriteBuf(this Int32 value, byte[] stream, long offset = 0, bool isLittleEndian = true)
        {
            const int ValueSize = Int32_ByteSize;
            #region Проверка аргументов
#if CHECK_ARGS
            _ = stream ?? throw new ArgumentNullException(nameof(stream));
            if (offset < 0 || (offset + ValueSize) > stream.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
#endif
            #endregion Проверка аргументов

            var buf = value.GetBytes(isLittleEndian);
            Array.Copy(buf, 0, stream, offset, ValueSize);
            return ValueSize;
        }
        #endregion Int32
        #region UInt32
        /// <summary>
        /// <para>Преобразовать значение <see cref="UInt32"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        /// <remarks>2021-04-18</remarks>
        public static byte[] GetBytes(this UInt32 value, bool isLittleEndian = true)
        {
            var buf = new byte[UInt32_ByteSize];
            if (isLittleEndian)
            {
                buf[0] = (byte)((value >> 0) & 0xff);
                buf[1] = (byte)((value >> 8) & 0xff);
                buf[2] = (byte)((value >> 16) & 0xff);
                buf[3] = (byte)((value >> 24) & 0xff);
            }
            else
            {
                buf[3] = (byte)((value >> 0) & 0xff);
                buf[2] = (byte)((value >> 8) & 0xff);
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
        /// <remarks>2021-04-18</remarks>
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
                    (data[start + 0] << 0) |
                    (data[start + 1] << 8) |
                    (data[start + 2] << 16) |
                    (data[start + 3] << 24)
                    );
            }
            else
            {
                return (UInt32)(
                    (data[start + 3] << 0) |
                    (data[start + 2] << 8) |
                    (data[start + 1] << 16) |
                    (data[start + 0] << 24)
                    );
            }
        }
        /// <summary>
        /// <para>Записать значение <see cref="UInt32"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="stream"></param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        /// <remarks>2021-04-25</remarks>
        public static long WriteBuf(this UInt32 value, byte[] stream, long offset = 0, bool isLittleEndian = true)
        {
            const int ValueSize = UInt32_ByteSize;
            #region Проверка аргументов
#if CHECK_ARGS
            _ = stream ?? throw new ArgumentNullException(nameof(stream));
            if (offset < 0 || (offset + ValueSize) > stream.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
#endif
            #endregion Проверка аргументов

            var buf = value.GetBytes(isLittleEndian);
            Array.Copy(buf, 0, stream, offset, ValueSize);
            return ValueSize;
        }
        #endregion UInt32
        #region UInt48
        /// <summary>
        /// <para>Преобразовать значение <see cref="UInt48"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        /// <remarks>2021-04-18</remarks>
        public static byte[] GetBytes(this UInt48 value, bool isLittleEndian = true) =>
            value.GetBytes(isLittleEndian);
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt48"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Первый байт значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байтов значейния в потоке</param>
        /// <returns>Считанное значение</returns>
        /// <remarks>2021-04-18</remarks>
        public static UInt48 GetUInt48(this byte[] data, long start = 0, bool isLittleEndian = true) =>
            UInt48.FromBytes(data, start, isLittleEndian);
        /// <summary>
        /// <para>Записать значение <see cref="UInt48"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="stream"></param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        /// <remarks>2021-04-25</remarks>
        public static long WriteBuf(this UInt48 value, byte[] stream, long offset = 0, bool isLittleEndian = true)
        {
            const int ValueSize = UInt48_ByteSize;
            #region Проверка аргументов
#if CHECK_ARGS
            _ = stream ?? throw new ArgumentNullException(nameof(stream));
            if (offset < 0 || (offset + ValueSize) > stream.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
#endif
            #endregion Проверка аргументов

            var buf = value.GetBytes(isLittleEndian);
            Array.Copy(buf, 0, stream, offset, ValueSize);
            return ValueSize;
        }
        #endregion UInt48
        #region Int64
        /// <summary>
        /// <para>Преобразовать значение <see cref="Int64"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        /// <remarks>2021-04-18</remarks>
        public static byte[] GetBytes(this Int64 value, bool isLittleEndian = true) =>
            GetBytes(unchecked((UInt64)value), isLittleEndian);
        /// <summary>
        /// <para>Прочитать значение <see cref="Int64"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Первый байт значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байтов значейния в потоке</param>
        /// <returns>Считанное значение</returns>
        /// <remarks>2021-04-18</remarks>
        public static Int64 GetInt64(this byte[] data, long start = 0, bool isLittleEndian = true) =>
            unchecked((Int64)GetUInt64(data, start, isLittleEndian));
        /// <summary>
        /// <para>Записать значение <see cref="Int64"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="stream"></param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        /// <remarks>2021-04-25</remarks>
        public static long WriteBuf(this Int64 value, byte[] stream, long offset = 0, bool isLittleEndian = true)
        {
            const int ValueSize = Int64_ByteSize;
            #region Проверка аргументов
#if CHECK_ARGS
            _ = stream ?? throw new ArgumentNullException(nameof(stream));
            if (offset < 0 || (offset + ValueSize) > stream.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
#endif
            #endregion Проверка аргументов

            var buf = value.GetBytes(isLittleEndian);
            Array.Copy(buf, 0, stream, offset, ValueSize);
            return ValueSize;
        }
        #endregion Int64
        #region UInt64
        /// <summary>
        /// <para>Преобразовать значение <see cref="UInt64"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Результирующий поток байт</returns>
        /// <remarks>2021-04-18</remarks>
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
        /// <remarks>2021-04-18</remarks>
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
                    (data[start + 0] << 0) |
                    (data[start + 1] << 8) |
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
                    (data[start + 7] << 0) |
                    (data[start + 6] << 8) |
                    (data[start + 5] << 16) |
                    (data[start + 4] << 24) |
                    (data[start + 3] << 32) |
                    (data[start + 2] << 40) |
                    (data[start + 1] << 48) |
                    (data[start + 0] << 56)
                    );
            }
        }
        /// <summary>
        /// <para>Записать значение <see cref="UInt64"/> в поток байт</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="stream"></param>
        /// <param name="offset">Смещение значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Количество записанных байт</returns>
        /// <remarks>2021-04-25</remarks>
        public static long WriteBuf(this UInt64 value, byte[] stream, long offset = 0, bool isLittleEndian = true)
        {
            const int ValueSize = UInt64_ByteSize;
            #region Проверка аргументов
#if CHECK_ARGS
            _ = stream ?? throw new ArgumentNullException(nameof(stream));
            if (offset < 0 || (offset + ValueSize) > stream.LongLength)
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
#endif
            #endregion Проверка аргументов

            var buf = value.GetBytes(isLittleEndian);
            Array.Copy(buf, 0, stream, offset, ValueSize);
            return ValueSize;
        }
        #endregion UInt64
    }
}
