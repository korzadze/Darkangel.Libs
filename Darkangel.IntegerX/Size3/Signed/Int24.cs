using System;
using System.Runtime.InteropServices;

namespace Darkangel.IntegerX
{
    /// <summary>
    /// <para>3-байтное целое со знаком</para>
    /// </summary>
    /// <remarks>2021-04-18</remarks>
    [Serializable]
    [ComVisible(false)]
    public struct Int24 : IComparable, IComparable<Int24>, IEquatable<Int24>, IFormattable, IConvertible
    {
        #region Внутренние значения
        private const UInt32 ValueMask = 0x00ffffff;
        private const UInt32 SignMask  = 0x00800000;
        private const UInt32 SignBytes = 0xff000000;

        internal readonly Int32 _Value;
        #endregion Внутренние значения
        #region Статические поля
        /// <summary>
        /// <para>Размер значения <see cref="Int24"/> в байтах</para>
        /// </summary>
        public const int Size = 3;
        /// <summary>
        /// <para>Минимальное значение типа <see cref="Int24"/></para>
        /// </summary>
        public static Int24 MinValue => new(-8388608);
        /// <summary>
        /// <para>Максимальное значение типа <see cref="Int24"/></para>
        /// </summary>
        public static Int24 MaxValue => new(8388607);
        #endregion Статические поля
        #region Получить размер значения
        /// <summary>
        /// <para>Получить размер переменной типа</para>
        /// </summary>
        /// <returns>Размер переменной типа</returns>
        public int GetSize() => Size;
        #endregion Получить размер значения
        #region Конструкторы
        private Int24(Int64 val)
        {
            _Value = unchecked((Int32)(val & ValueMask));
            if ((unchecked((UInt32)_Value) & SignMask) != 0)
            {
                _Value = (Int32)(unchecked((UInt32)_Value) | SignBytes);
            }
        }
        private Int24(Int32 val)
            : this((Int64)val)
        {
        }
        private Int24(Int16 val)
            => _Value = val;
        #endregion Конструкторы
        #region Потоковые преобразования
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt24"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Начало значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Считанное значение</returns>
        internal static Int24 FromBytes_int(byte[] data, long start = 0, bool isLittleEndian = true)
        {
            #region Check arguments
#if CHECK_ARGS
            _ = data ?? throw new ArgumentNullException(nameof(data));
            if ((start < 0) || ((start + Size) > data.LongLength))
            {
                throw new ArgumentOutOfRangeException(nameof(start));
            }
#endif
            #endregion Check arguments

            return (isLittleEndian) ?
                new Int24(unchecked((Int32)
                    (
                    (data[start + 0] << 0) |
                    (data[start + 1] << 8) |
                    (data[start + 2] << 16)
                    ))) :
                new Int24(unchecked((Int32)
                    (
                    (data[start + 2] << 0) |
                    (data[start + 1] << 8) |
                    (data[start + 0] << 16)
                    )));
        }
        /// <summary>
        /// <para>Преобразовать значение <see cref="UInt24"/> в поток байт</para>
        /// </summary>
        /// <param name="isLittleEndian">Порядок байтов значения в потоке</param>
        /// <returns>Результирующий поток</returns>
        internal byte[] GetBytes_int(bool isLittleEndian = true)
        {
            var res = new byte[Size];

            if (isLittleEndian)
            {
                res[0] = unchecked((byte)((_Value >> 0) & 0xff));
                res[1] = unchecked((byte)((_Value >> 8) & 0xff));
                res[2] = unchecked((byte)((_Value >> 16) & 0xff));
            }
            else
            {
                res[2] = unchecked((byte)((_Value >> 0) & 0xff));
                res[1] = unchecked((byte)((_Value >> 8) & 0xff));
                res[0] = unchecked((byte)((_Value >> 16) & 0xff));
            }
            return res;
        }
        #endregion Потоковые преобразования
        #region Преобразования значений
        #region To UInt24
        #region 1 byte
        /// <summary>
        /// Преобразовать <see cref="Byte"/> в <see cref="Int24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator Int24(Byte value)
            => new(value);
        /// <summary>
        /// Преобразовать <see cref="SByte"/> в <see cref="Int24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator Int24(SByte value)
            => new(value);
        #endregion 1 byte
        #region 2 byte
        /// <summary>
        /// Преобразовать <see cref="UInt16"/> в <see cref="Int24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator Int24(UInt16 value)
            => new(value);
        /// <summary>
        /// Преобразовать <see cref="Int16"/> в <see cref="Int24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator Int24(Int16 value)
            => new(unchecked((UInt16)value));
        #endregion 2 byte
        #region 3 byte
        /// <summary>
        /// Преобразовать <see cref="UInt24"/> в <see cref="Int24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator Int24(UInt24 value)
            => new(value._Value);
        #endregion 3 byte
        #region 4 byte
        /// <summary>
        /// Преобразовать <see cref="UInt32"/> в <see cref="Int24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator Int24(UInt32 value)
            => new(unchecked((Int32)value));
        /// <summary>
        /// Преобразовать <see cref="Int32"/> в <see cref="Int24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator Int24(Int32 value)
            => new(unchecked((UInt32)value));
        #endregion 4 byte
        #region 6 byte
        /// <summary>
        /// Преобразовать <see cref="UInt48"/> в <see cref="Int24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator Int24(UInt48 value)
            => new(unchecked((Int64)value._Value));
        /// <summary>
        /// Преобразовать <see cref="Int48"/> в <see cref="Int24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator Int24(Int48 value)
            => new(value._Value);
        #endregion 6 byte
        #region 8 byte
        /// <summary>
        /// Преобразовать <see cref="UInt64"/> в <see cref="Int24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator Int24(UInt64 value)
            => new(unchecked((Int64)value));
        /// <summary>
        /// Преобразовать <see cref="Int64"/> в <see cref="Int24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator Int24(Int64 value)
            => new(value);
        #endregion 8 byte
        #endregion To UInt24
        #region From UInt24
        #region 1 byte
        /// <summary>
        /// Преобразовать <see cref="Int24"/> в <see cref="Byte"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator Byte(Int24 value)
            => unchecked((Byte)value._Value);
        /// <summary>
        /// Преобразовать <see cref="Int24"/> в <see cref="SByte"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator SByte(Int24 value)
            => unchecked((SByte)value._Value);
        #endregion 1 byte
        #region 2 byte
        /// <summary>
        /// Преобразовать <see cref="Int24"/> в <see cref="UInt16"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator UInt16(Int24 value)
            => unchecked((UInt16)value._Value);
        /// <summary>
        /// Преобразовать <see cref="Int24"/> в <see cref="Int16"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator Int16(Int24 value)
            => unchecked((Int16)value._Value);
        #endregion 2 byte
        #region 3 byte
        // Int24
        #endregion 3 byte
        #region 4 byte
        /// <summary>
        /// Преобразовать <see cref="Int24"/> в <see cref="UInt32"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator UInt32(Int24 value)
            => unchecked((UInt32)value._Value);
        /// <summary>
        /// Преобразовать <see cref="Int24"/> в <see cref="Int32"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator Int32(Int24 value)
            => value._Value;
        #endregion 4 byte
        #region 6 byte
        // UInt48
        // Int48
        #endregion 6 byte
        #region 8 byte
        /// <summary>
        /// Преобразовать <see cref="Int24"/> в <see cref="UInt64"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator UInt64(Int24 value)
            => unchecked((UInt64)value._Value);
        /// <summary>
        /// Преобразовать <see cref="Int24"/> в <see cref="Int64"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator Int64(Int24 value)
            => unchecked((Int64)value._Value);
        #endregion 8 byte
        #endregion From UInt24
        #endregion Преобразования значений
        #region IComparable
        /// <inheritdoc/>
        public int CompareTo(object obj) =>
            _Value.CompareTo(obj);
        #endregion IComparable
        #region IComparable<Int24>
        /// <inheritdoc/>
        public int CompareTo(Int24 other) =>
            _Value.CompareTo(other._Value);
        #endregion IComparable<Int24>
        #region IEquatable<Int24>
        /// <inheritdoc/>
        public bool Equals(Int24 other) =>
            _Value.Equals(other._Value);
        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Int24 v)
            {
                return _Value.Equals(v._Value);
            }
            else
            {
                return _Value.Equals(obj);
            }
        }
        /// <inheritdoc/>
        public override int GetHashCode() =>
            _Value.GetHashCode();
        #endregion IEquatable<Int24>
        #region IFormattable
        /// <inheritdoc/>
        public string ToString(string format, IFormatProvider formatProvider) =>
            _Value.ToString(format, formatProvider);
        #endregion IFormattable
        #region IConvertible
        /// <inheritdoc/>
        public TypeCode GetTypeCode() =>
            Type.GetTypeCode(GetType());
        /// <inheritdoc/>
        public bool ToBoolean(IFormatProvider provider = null) =>
            ((IConvertible)_Value).ToBoolean(provider);
        /// <inheritdoc/>
        public byte ToByte(IFormatProvider provider = null) =>
            ((IConvertible)_Value).ToByte(provider);
        /// <inheritdoc/>
        public char ToChar(IFormatProvider provider = null) =>
            ((IConvertible)_Value).ToChar(provider);
        /// <inheritdoc/>
        public DateTime ToDateTime(IFormatProvider provider = null) =>
            ((IConvertible)_Value).ToDateTime(provider);
        /// <inheritdoc/>
        public decimal ToDecimal(IFormatProvider provider = null) =>
            ((IConvertible)_Value).ToDecimal(provider);
        /// <inheritdoc/>
        public double ToDouble(IFormatProvider provider = null) =>
            ((IConvertible)_Value).ToDouble(provider);
        /// <inheritdoc/>
        public short ToInt16(IFormatProvider provider = null) =>
            ((IConvertible)_Value).ToInt16(provider);
        /// <inheritdoc/>
        public int ToInt32(IFormatProvider provider = null) =>
            ((IConvertible)_Value).ToInt32(provider);
        /// <inheritdoc/>
        public long ToInt64(IFormatProvider provider = null) =>
            ((IConvertible)_Value).ToInt64(provider);
        /// <inheritdoc/>
        public sbyte ToSByte(IFormatProvider provider = null) =>
            ((IConvertible)_Value).ToSByte(provider);
        /// <inheritdoc/>
        public float ToSingle(IFormatProvider provider = null) =>
            ((IConvertible)_Value).ToSingle(provider);
        /// <inheritdoc/>
        public string ToString(IFormatProvider provider = null) =>
            ((IConvertible)_Value).ToString(provider);
        /// <inheritdoc/>
        public object ToType(Type conversionType, IFormatProvider provider = null) =>
            ((IConvertible)_Value).ToType(conversionType, provider);
        /// <inheritdoc/>
        public ushort ToUInt16(IFormatProvider provider = null) =>
            ((IConvertible)_Value).ToUInt16(provider);
        /// <inheritdoc/>
        public uint ToUInt32(IFormatProvider provider = null) =>
            ((IConvertible)_Value).ToUInt32(provider);
        /// <inheritdoc/>
        public ulong ToUInt64(IFormatProvider provider = null) =>
            ((IConvertible)_Value).ToUInt64(provider);
        #endregion IConvertible
        #region Equals operators
        /// <inheritdoc/>
        public static bool operator ==(Int24 left, Int24 right) =>
            left._Value == right._Value;
        /// <inheritdoc/>
        public static bool operator !=(Int24 left, Int24 right) =>
            left._Value != right._Value;
        #endregion Equals operators
        #region Compare operators
        /// <inheritdoc/>
        public static bool operator >(Int24 left, Int24 right) =>
            left._Value > right._Value;
        /// <inheritdoc/>
        public static bool operator >=(Int24 left, Int24 right) =>
            left._Value >= right._Value;
        /// <inheritdoc/>
        public static bool operator <(Int24 left, Int24 right) =>
            left._Value < right._Value;
        /// <inheritdoc/>
        public static bool operator <=(Int24 left, Int24 right) =>
            left._Value <= right._Value;
        #endregion Compare operators
    }
}
