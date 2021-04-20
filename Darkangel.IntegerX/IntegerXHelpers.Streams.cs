using System;
using System.IO;

namespace Darkangel.IntegerX
{
    public static partial class IntegerXHelpers
    {
        /// <summary>
        /// <para>Прочитать из потока значение <see cref="SByte"/></para>
        /// </summary>
        /// <param name="stream">Входной поток</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <returns>Считанное значение</returns>
        /// <remarks>2021-04-18</remarks>
        public static SByte ReadInt8(this Stream stream, bool isLittleEndian = true) =>
            (SByte)stream.ReadByte();
        /// <summary>
        /// <para>Записать в поток значение <see cref="SByte"/></para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Записываемое значение</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <remarks>2021-04-18</remarks>
        public static void Write(this Stream stream, SByte value, bool isLittleEndian = true) =>
            stream.WriteByte((byte)value);
        /// <summary>
        /// <para>Прочитать из потока значение <see cref="Byte"/></para>
        /// </summary>
        /// <param name="stream">Входной поток</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <returns>Считанное значение</returns>
        /// <remarks>2021-04-18</remarks>
        public static Byte ReadUInt8(this Stream stream, bool isLittleEndian = true) =>
            (Byte)stream.ReadByte();
        /// <summary>
        /// <para>Записать в поток значение <see cref="Byte"/></para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Записываемое значение</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <remarks>2021-04-18</remarks>
        public static void Write(this Stream stream, Byte value, bool isLittleEndian = true) =>
            stream.WriteByte(value);
        /// <summary>
        /// <para>Прочитать из потока значение <see cref="Int16"/></para>
        /// </summary>
        /// <param name="stream">Входной поток</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <returns>Считанное значение</returns>
        /// <remarks>2021-04-18</remarks>
        public static Int16 ReadInt16(this Stream stream, bool isLittleEndian = true)
        {
            var buf = new byte[Int16_ByteSize];
            if (stream.Read(buf, 0, buf.Length) != buf.Length)
            {
                throw new EndOfStreamException();
            }
            return GetInt16(buf, isLittleEndian: isLittleEndian);
        }
        /// <summary>
        /// <para>Записать в поток значение <see cref="Int16"/></para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Записываемое значение</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <remarks>2021-04-18</remarks>
        public static void Write(this Stream stream, Int16 value, bool isLittleEndian = true)
        {
            var buf = value.GetBytes(isLittleEndian: isLittleEndian);
            stream.Write(buf, 0, buf.Length);
        }
        /// <summary>
        /// <para>Прочитать из потока значение <see cref="UInt16"/></para>
        /// </summary>
        /// <param name="stream">Входной поток</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <returns>Считанное значение</returns>
        /// <remarks>2021-04-18</remarks>
        public static UInt16 ReadUInt16(this Stream stream, bool isLittleEndian = true)
        {
            var buf = new byte[UInt16_ByteSize];
            if (stream.Read(buf, 0, buf.Length) != buf.Length)
            {
                throw new EndOfStreamException();
            }
            return GetUInt16(buf, isLittleEndian: isLittleEndian);
        }
        /// <summary>
        /// <para>Записать в поток значение <see cref="UInt16"/></para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Записываемое значение</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <remarks>2021-04-18</remarks>
        public static void Write(this Stream stream, UInt16 value, bool isLittleEndian = true)
        {
            var buf = value.GetBytes(isLittleEndian: isLittleEndian);
            stream.Write(buf, 0, buf.Length);
        }
        /// <summary>
        /// <para>Прочитать из потока значение <see cref="UInt24"/></para>
        /// </summary>
        /// <param name="stream">Входной поток</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <returns>Считанное значение</returns>
        /// <remarks>2021-04-18</remarks>
        public static UInt24 ReadUInt24(this Stream stream, bool isLittleEndian = true)
        {
            var buf = new byte[UInt24_ByteSize];
            if (stream.Read(buf, 0, buf.Length) != buf.Length)
            {
                throw new EndOfStreamException();
            }
            return GetUInt24(buf, isLittleEndian: isLittleEndian);
        }
        /// <summary>
        /// <para>Записать в поток значение <see cref="UInt24"/></para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Записываемое значение</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <remarks>2021-04-18</remarks>
        public static void Write(this Stream stream, UInt24 value, bool isLittleEndian = true)
        {
            var buf = value.GetBytes(isLittleEndian: isLittleEndian);
            stream.Write(buf, 0, buf.Length);
        }
        /// <summary>
        /// <para>Прочитать из потока значение <see cref="Int32"/></para>
        /// </summary>
        /// <param name="stream">Входной поток</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <returns>Считанное значение</returns>
        /// <remarks>2021-04-18</remarks>
        public static Int32 ReadInt32(this Stream stream, bool isLittleEndian = true)
        {
            var buf = new byte[Int32_ByteSize];
            if (stream.Read(buf, 0, buf.Length) != buf.Length)
            {
                throw new EndOfStreamException();
            }
            return GetInt32(buf, isLittleEndian: isLittleEndian);
        }
        /// <summary>
        /// <para>Записать в поток значение <see cref="Int32"/></para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Записываемое значение</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <remarks>2021-04-18</remarks>
        public static void WriteInt32(this Stream stream, Int32 value, bool isLittleEndian = true)
        {
            var buf = value.GetBytes(isLittleEndian: isLittleEndian);
            stream.Write(buf, 0, buf.Length);
        }
        /// <summary>
        /// <para>Прочитать из потока значение <see cref="UInt32"/></para>
        /// </summary>
        /// <param name="stream">Входной поток</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <returns>Считанное значение</returns>
        /// <remarks>2021-04-18</remarks>
        public static UInt32 ReadUInt32(this Stream stream, bool isLittleEndian = true)
        {
            var buf = new byte[UInt32_ByteSize];
            if (stream.Read(buf, 0, buf.Length) != buf.Length)
            {
                throw new EndOfStreamException();
            }
            return GetUInt32(buf, isLittleEndian: isLittleEndian);
        }
        /// <summary>
        /// <para>Записать в поток значение <see cref="UInt32"/></para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Записываемое значение</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <remarks>2021-04-18</remarks>
        public static void WriteUInt32(this Stream stream, UInt32 value, bool isLittleEndian = true)
        {
            var buf = value.GetBytes(isLittleEndian: isLittleEndian);
            stream.Write(buf, 0, buf.Length);
        }
        /// <summary>
        /// <para>Прочитать из потока значение <see cref="UInt48"/></para>
        /// </summary>
        /// <param name="stream">Входной поток</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <returns>Считанное значение</returns>
        /// <remarks>2021-04-18</remarks>
        public static UInt48 ReadUInt48(this Stream stream, bool isLittleEndian = true)
        {
            var buf = new byte[UInt48_ByteSize];
            if (stream.Read(buf, 0, buf.Length) != buf.Length)
            {
                throw new EndOfStreamException();
            }
            return GetUInt48(buf, isLittleEndian: isLittleEndian);
        }
        /// <summary>
        /// <para>Записать в поток значение <see cref="UInt48"/></para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Записываемое значение</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <remarks>2021-04-18</remarks>
        public static void WriteUInt48(this Stream stream, UInt48 value, bool isLittleEndian = true)
        {
            var buf = value.GetBytes(isLittleEndian: isLittleEndian);
            stream.Write(buf, 0, buf.Length);
        }
        /// <summary>
        /// <para>Прочитать из потока значение <see cref="Int64"/></para>
        /// </summary>
        /// <param name="stream">Входной поток</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <returns>Считанное значение</returns>
        /// <remarks>2021-04-18</remarks>
        public static Int64 ReadInt64(this Stream stream, bool isLittleEndian = true)
        {
            var buf = new byte[Int64_ByteSize];
            if (stream.Read(buf, 0, buf.Length) != buf.Length)
            {
                throw new EndOfStreamException();
            }
            return GetInt64(buf, isLittleEndian: isLittleEndian);
        }
        /// <summary>
        /// <para>Записать в поток значение <see cref="Int64"/></para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Записываемое значение</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <remarks>2021-04-18</remarks>
        public static void WriteInt64(this Stream stream, Int64 value, bool isLittleEndian = true)
        {
            var buf = value.GetBytes(isLittleEndian: isLittleEndian);
            stream.Write(buf, 0, buf.Length);
        }
        /// <summary>
        /// <para>Прочитать из потока значение <see cref="UInt64"/></para>
        /// </summary>
        /// <param name="stream">Входной поток</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <returns>Считанное значение</returns>
        /// <remarks>2021-04-18</remarks>
        public static UInt64 ReadUInt64(this Stream stream, bool isLittleEndian = true)
        {
            var buf = new byte[UInt64_ByteSize];
            if (stream.Read(buf, 0, buf.Length) != buf.Length)
            {
                throw new EndOfStreamException();
            }
            return GetUInt64(buf, isLittleEndian: isLittleEndian);
        }
        /// <summary>
        /// <para>Записать в поток значение <see cref="UInt64"/></para>
        /// </summary>
        /// <param name="stream">Целевой поток</param>
        /// <param name="value">Записываемое значение</param>
        /// <param name="isLittleEndian">Порядок следования байт значения в потоке</param>
        /// <remarks>2021-04-18</remarks>
        public static void WriteUInt64(this Stream stream, UInt64 value, bool isLittleEndian = true)
        {
            var buf = value.GetBytes(isLittleEndian: isLittleEndian);
            stream.Write(buf, 0, buf.Length);
        }
    }
}
