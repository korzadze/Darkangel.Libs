using System;
using System.Runtime.InteropServices;

namespace Darkangel.IntegerX
{
    /// <summary>
    /// 6-байтное беззнаковое целое
    /// </summary>
    /// <remarks>2021-04-18</remarks>
    [Serializable]
    [ComVisible(false)]
    public struct UInt48 : IComparable, IComparable<UInt48>, IEquatable<UInt48>, IFormattable, IConvertible
    {
        private const UInt64 ValueMask = 0xffffffffffffUL;
        private readonly UInt64 _Value;
        /// <summary>
        /// <para>Размер значения <see cref="UInt48"/> в байтах</para>
        /// </summary>
        public const int Size = 6;

        #region Конструкторы
        private UInt48(UInt64 val)
            => _Value = (UInt64)val & ValueMask;
        private UInt48(UInt32 val)
            => _Value = val;
        private UInt48(UInt16 val)
            => _Value = val;
        private UInt48(Byte val)
            => _Value = val;
        #endregion Конструкторы
        #region Потоковые преобразования
        /// <summary>
        /// <para>Прочитать значение <see cref="UInt48"/> из потока байт</para>
        /// </summary>
        /// <param name="data">Исходный поток байт</param>
        /// <param name="start">Начало значения в потоке</param>
        /// <param name="isLittleEndian">Порядок байт значения в потоке</param>
        /// <returns>Считанное значение</returns>
        internal static UInt48 FromBytes(byte[] data, long start = 0, bool isLittleEndian = true)
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
                new UInt48((UInt64)
                    (
                    (data[start + 0] <<  0) |
                    (data[start + 1] <<  8) |
                    (data[start + 2] << 16) |
                    (data[start + 3] << 24) |
                    (data[start + 4] << 32) |
                    (data[start + 5] << 40)
                    )) :
                new UInt48((UInt32)
                    (
                    (data[start + 5] <<  0) |
                    (data[start + 4] <<  8) |
                    (data[start + 3] << 16) |
                    (data[start + 2] << 24) |
                    (data[start + 1] << 32) |
                    (data[start + 0] << 40)
                    ));
        }
        /// <summary>
        /// <para>Преобразовать значение <see cref="UInt48"/> в поток байт</para>
        /// </summary>
        /// <param name="isLittleEndian">Порядок байтов значения в потоке</param>
        /// <returns>Результирующий поток</returns>
        internal byte[] GetBytes(bool isLittleEndian = true)
        {
            var res = new byte[Size];

            if (isLittleEndian)
            {
                res[0] = (byte)((_Value >>  0) & 0xff);
                res[1] = (byte)((_Value >>  8) & 0xff);
                res[2] = (byte)((_Value >> 16) & 0xff);
                res[3] = (byte)((_Value >> 24) & 0xff);
                res[4] = (byte)((_Value >> 32) & 0xff);
                res[5] = (byte)((_Value >> 40) & 0xff);
            }
            else
            {
                res[5] = (byte)((_Value >>  0) & 0xff);
                res[4] = (byte)((_Value >>  8) & 0xff);
                res[3] = (byte)((_Value >> 16) & 0xff);
                res[2] = (byte)((_Value >> 24) & 0xff);
                res[1] = (byte)((_Value >> 32) & 0xff);
                res[0] = (byte)((_Value >> 40) & 0xff);
            }
            return res;
        }
        #endregion Потоковые преобразования
        #region Преобразования
        #region To UInt48
        /// <summary>
        /// Преобразовать <see cref="Byte"/> в <see cref="UInt48"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator UInt48(Byte value)
            => new(value);
        /// <summary>
        /// Преобразовать <see cref="SByte"/> в <see cref="UInt48"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator UInt48(SByte value)
            => new((Byte)value);
        /// <summary>
        /// Преобразовать <see cref="UInt16"/> в <see cref="UInt48"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator UInt48(UInt16 value)
            => new(value);
        /// <summary>
        /// Преобразовать <see cref="Int16"/> в <see cref="UInt48"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator UInt48(Int16 value)
            => new((UInt16)value);
        /// <summary>
        /// Преобразовать <see cref="UInt24"/> в <see cref="UInt48"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator UInt48(UInt24 value)
            => new(value);
        /// <summary>
        /// Преобразовать <see cref="UInt32"/> в <see cref="UInt48"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator UInt48(UInt32 value)
            => new(value);
        /// <summary>
        /// Преобразовать <see cref="Int32"/> в <see cref="UInt48"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator UInt48(Int32 value)
            => new((UInt32)value);
        /// <summary>
        /// Преобразовать <see cref="UInt64"/> в <see cref="UInt48"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator UInt48(UInt64 value)
            => new(value);
        #endregion To UInt48
        #region From UInt48
        /// <summary>
        /// Преобразовать <see cref="UInt48"/> в <see cref="Byte"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator Byte(UInt48 value)
            => (Byte)value._Value;
        /// <summary>
        /// Преобразовать <see cref="UInt48"/> в <see cref="SByte"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator SByte(UInt48 value)
            => (SByte)value._Value;
        /// <summary>
        /// Преобразовать <see cref="UInt48"/> в <see cref="UInt16"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator UInt16(UInt48 value)
            => (UInt16)value._Value;
        /// <summary>
        /// Преобразовать <see cref="UInt48"/> в <see cref="Int16"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator Int16(UInt48 value)
            => (Int16)value._Value;
        /// <summary>
        /// Преобразовать <see cref="UInt48"/> в <see cref="UInt32"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator UInt32(UInt48 value)
            => (UInt32)value._Value;
        /// <summary>
        /// Преобразовать <see cref="UInt48"/> в <see cref="Int32"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator Int32(UInt48 value)
            => (Int32)value._Value;
        /// <summary>
        /// Преобразовать <see cref="UInt48"/> в <see cref="UInt64"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator UInt64(UInt48 value)
            => value._Value;
        /// <summary>
        /// Преобразовать <see cref="UInt48"/> в <see cref="UInt64"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator Int64(UInt48 value)
            => (Int64)value._Value;
        #endregion From UInt48
        #endregion Преобразования
        #region IComparable
        /// <inheritdoc/>
        public int CompareTo(object obj) =>
            _Value.CompareTo(obj);
        #endregion IComparable
        #region IComparable<UInt48>
        /// <inheritdoc/>
        public int CompareTo(UInt48 other) =>
            _Value.CompareTo(other._Value);
        #endregion IComparable<UInt48>
        #region IEquatable<UInt48>
        /// <inheritdoc/>
        public bool Equals(UInt48 other) =>
            _Value.Equals(other._Value);
        /// <inheritdoc/>
        public override bool Equals(object obj) =>
            obj.Equals(this);
        /// <inheritdoc/>
        public override int GetHashCode() =>
            _Value.GetHashCode();
        #endregion IEquatable<UInt48>
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
        public static bool operator ==(UInt48 left, UInt48 right) =>
            left._Value == right._Value;
        /// <inheritdoc/>
        public static bool operator !=(UInt48 left, UInt48 right) =>
            left._Value != right._Value;
        #endregion Equals operators
        #region Compare operators
        /// <inheritdoc/>
        public static bool operator >(UInt48 left, UInt48 right) =>
            left._Value > right._Value;
        /// <inheritdoc/>
        public static bool operator >=(UInt48 left, UInt48 right) =>
            left._Value >= right._Value;
        /// <inheritdoc/>
        public static bool operator <(UInt48 left, UInt48 right) =>
            left._Value < right._Value;
        /// <inheritdoc/>
        public static bool operator <=(UInt48 left, UInt48 right) =>
            left._Value <= right._Value;
        #endregion Compare operators
    }
}
