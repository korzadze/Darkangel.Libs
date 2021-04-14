using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Darkangel.IntegerX
{
    /// <summary>
    /// 3-байтное беззнаковое целое
    /// </summary>
    [Serializable]
    [ComVisible(false)]
    public struct UInt24 : IComparable, IComparable<UInt24>, IEquatable<UInt24>, IFormattable, IConvertible
    {
        private const UInt32 ValueMask = 0xffffff;
        private readonly UInt32 _Value;

        /// <summary>
        /// <para>Размер значения <see cref="UInt24"/> в байтах</para>
        /// </summary>
        public const int Size = 3;

        #region Конструкторы
        private UInt24(UInt64 val)
            => _Value = unchecked((UInt32)(val & ValueMask));
        private UInt24(UInt32 val)
            => _Value = val & ValueMask;
        private UInt24(UInt16 val)
            => _Value = val;
        private UInt24(Byte val)
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
        internal static UInt24 FromBytes(byte[] data, long start = 0, bool isLittleEndian = true)
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
                new UInt24((UInt32)
                    (
                    (data[start + 0] << 0) |
                    (data[start + 1] << 8) |
                    (data[start + 2] << 16)
                    )) :
                new UInt24((UInt32)
                    (
                    (data[start + 2] << 0) |
                    (data[start + 1] << 8) |
                    (data[start + 0] << 16)
                    ));
        }
        /// <summary>
        /// <para>Преобразовать значение <see cref="UInt24"/> в поток байт</para>
        /// </summary>
        /// <param name="isLittleEndian">Порядок байтов значения в потоке</param>
        /// <returns>Результирующий поток</returns>
        internal byte[] GetBytes(bool isLittleEndian = true)
        {
            var res = new byte[Size];

            if (isLittleEndian)
            {
                res[0] = (byte)((_Value >> 0) & 0xff);
                res[1] = (byte)((_Value >> 8) & 0xff);
                res[2] = (byte)((_Value >> 16) & 0xff);
            }
            else
            {
                res[2] = (byte)((_Value >> 0) & 0xff);
                res[1] = (byte)((_Value >> 8) & 0xff);
                res[0] = (byte)((_Value >> 16) & 0xff);
            }
            return res;
        }
        #endregion Потоковые преобразования
        #region Преобразования значений
        /// <summary>
        /// Преобразовать <see cref="Byte"/> в <see cref="UInt24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator UInt24(Byte value)
            => new(value);
        /// <summary>
        /// Преобразовать <see cref="SByte"/> в <see cref="UInt24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator UInt24(SByte value)
            => new((Byte)value);
        /// <summary>
        /// Преобразовать <see cref="UInt16"/> в <see cref="UInt24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator UInt24(UInt16 value)
            => new(value);
        /// <summary>
        /// Преобразовать <see cref="Int16"/> в <see cref="UInt24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator UInt24(Int16 value)
            => new((UInt16)value);
        /// <summary>
        /// Преобразовать <see cref="UInt32"/> в <see cref="UInt24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator UInt24(UInt32 value)
            => new(value);
        /// <summary>
        /// Преобразовать <see cref="Int32"/> в <see cref="UInt24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator UInt24(Int32 value)
            => new((UInt32)value);
        /// <summary>
        /// Преобразовать <see cref="UInt48"/> в <see cref="UInt24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator UInt24(UInt48 value)
            => new(value);
        /// <summary>
        /// Преобразовать <see cref="UInt64"/> в <see cref="UInt24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator UInt24(UInt64 value)
            => new(value);
        /// <summary>
        /// Преобразовать <see cref="Int64"/> в <see cref="UInt24"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator UInt24(Int64 value)
            => new((UInt64)value);
        /// <summary>
        /// Преобразовать <see cref="UInt24"/> в <see cref="Byte"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator Byte(UInt24 value)
            => (Byte)value._Value;
        /// <summary>
        /// Преобразовать <see cref="UInt24"/> в <see cref="SByte"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator SByte(UInt24 value)
            => (SByte)value._Value;
        /// <summary>
        /// Преобразовать <see cref="UInt24"/> в <see cref="UInt16"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static explicit operator UInt16(UInt24 value)
            => (UInt16)value._Value;
        /// <summary>
        /// Преобразовать <see cref="UInt24"/> в <see cref="UInt32"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator UInt32(UInt24 value)
            => value._Value;
        /// <summary>
        /// Преобразовать <see cref="UInt24"/> в <see cref="UInt64"/>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        public static implicit operator UInt64(UInt24 value)
            => value._Value;
        #endregion Преобразования значений
        #region IComparable
        /// <inheritdoc/>
        public int CompareTo(object obj) =>
            _Value.CompareTo(obj);
        #endregion IComparable
        #region IComparable<UInt24>
        /// <inheritdoc/>
        public int CompareTo(UInt24 other) =>
            _Value.CompareTo(other._Value);
        #endregion IComparable<UInt24>
        #region IEquatable<UInt24>
        /// <inheritdoc/>
        public bool Equals(UInt24 other) =>
            _Value.Equals(other._Value);
        /// <inheritdoc/>
        public override bool Equals(object obj) =>
            obj.Equals(this);
        /// <inheritdoc/>
        public override int GetHashCode() =>
            _Value.GetHashCode();
        #endregion IEquatable<UInt24>
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
        public bool ToBoolean(IFormatProvider provider) =>
            ((IConvertible)_Value).ToBoolean(provider);
        /// <inheritdoc/>
        public byte ToByte(IFormatProvider provider) =>
            ((IConvertible)_Value).ToByte(provider);
        /// <inheritdoc/>
        public char ToChar(IFormatProvider provider) =>
            ((IConvertible)_Value).ToChar(provider);
        /// <inheritdoc/>
        public DateTime ToDateTime(IFormatProvider provider) =>
            ((IConvertible)_Value).ToDateTime(provider);
        /// <inheritdoc/>
        public decimal ToDecimal(IFormatProvider provider) =>
            ((IConvertible)_Value).ToDecimal(provider);
        /// <inheritdoc/>
        public double ToDouble(IFormatProvider provider) =>
            ((IConvertible)_Value).ToDouble(provider);
        /// <inheritdoc/>
        public short ToInt16(IFormatProvider provider) =>
            ((IConvertible)_Value).ToInt16(provider);
        /// <inheritdoc/>
        public int ToInt32(IFormatProvider provider) =>
            ((IConvertible)_Value).ToInt32(provider);
        /// <inheritdoc/>
        public long ToInt64(IFormatProvider provider) =>
            ((IConvertible)_Value).ToInt64(provider);
        /// <inheritdoc/>
        public sbyte ToSByte(IFormatProvider provider) =>
            ((IConvertible)_Value).ToSByte(provider);
        /// <inheritdoc/>
        public float ToSingle(IFormatProvider provider) =>
            ((IConvertible)_Value).ToSingle(provider);
        /// <inheritdoc/>
        public string ToString(IFormatProvider provider) =>
            ((IConvertible)_Value).ToString(provider);
        /// <inheritdoc/>
        public object ToType(Type conversionType, IFormatProvider provider) =>
            ((IConvertible)_Value).ToType(conversionType, provider);
        /// <inheritdoc/>
        public ushort ToUInt16(IFormatProvider provider) =>
            ((IConvertible)_Value).ToUInt16(provider);
        /// <inheritdoc/>
        public uint ToUInt32(IFormatProvider provider) =>
            ((IConvertible)_Value).ToUInt32(provider);
        /// <inheritdoc/>
        public ulong ToUInt64(IFormatProvider provider) =>
            ((IConvertible)_Value).ToUInt64(provider);
        #endregion IConvertible
        #region Equals operators
        /// <inheritdoc/>
        public static bool operator ==(UInt24 left, UInt24 right) =>
            left._Value == right._Value;
        /// <inheritdoc/>
        public static bool operator !=(UInt24 left, UInt24 right) =>
            left._Value != right._Value;
        #endregion Equals operators
        #region Compare operators
        /// <inheritdoc/>
        public static bool operator >(UInt24 left, UInt24 right) =>
            left._Value > right._Value;
        /// <inheritdoc/>
        public static bool operator >=(UInt24 left, UInt24 right) =>
            left._Value >= right._Value;
        /// <inheritdoc/>
        public static bool operator <(UInt24 left, UInt24 right) =>
            left._Value < right._Value;
        /// <inheritdoc/>
        public static bool operator <=(UInt24 left, UInt24 right) =>
            left._Value <= right._Value;
        #endregion Compare operators
    }
}
