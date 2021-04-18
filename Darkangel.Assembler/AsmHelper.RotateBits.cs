using System;

//Готово
namespace Darkangel.Assembler
{
    /// <summary>
    /// <para>Реализация низкоуровневых операций</para>
    /// </summary>
    public static class AsmHelper
    {
        /// <summary>
        /// <para>Реализация ассемблерной команды ROL/ROR: вращение битов значения.</para>
        /// <para>Биты, уходящие из числа с одной стороны, добавляются с другой</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="bits"><para>Количество бит.</para><para>Если значение больше нуля, то биты вращаются влево, иначе - вправо</para></param>
        /// <returns>Результат операции</returns>
        public static Byte RotateBits(this Byte value, int bits)
        {
            const int ValueBits = 8;

            var count = Math.Abs(bits) % ValueBits;
            if (count == 0) return value;
            if (bits > 0) // ROL
            {
                return (byte)((value << count) | (value >> (ValueBits - count)));
            }
            else // ROR
            {
                return (byte)((value << (ValueBits - count)) | (value >> count));
            }
        }
        /// <summary>
        /// <para>Реализация ассемблерной команды ROL/ROR: вращение битов значения.</para>
        /// <para>Биты, уходящие из числа с одной стороны, добавляются с другой</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="bits"><para>Количество бит.</para><para>Если значение больше нуля, то биты вращаются влево, иначе - вправо</para></param>
        /// <returns>Результат операции</returns>
        public static UInt16 RotateBits(this UInt16 value, int bits)
        {
            const int ValueBits = 16;

            var count = Math.Abs(bits) % ValueBits;
            if (count == 0) return value;
            if (bits > 0) // ROL
            {
                return (byte)((value << count) | (value >> (ValueBits - count)));
            }
            else // ROR
            {
                return (byte)((value << (ValueBits - count)) | (value >> count));
            }
        }
        /// <summary>
        /// <para>Реализация ассемблерной команды ROL/ROR: вращение битов значения.</para>
        /// <para>Биты, уходящие из числа с одной стороны, добавляются с другой</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="bits"><para>Количество бит.</para><para>Если значение больше нуля, то биты вращаются влево, иначе - вправо</para></param>
        /// <returns>Результат операции</returns>
        public static UInt32 RotateBits(this UInt32 value, int bits)
        {
            const int ValueBits = 32;

            var count = Math.Abs(bits) % ValueBits;
            if (count == 0) return value;
            if (bits > 0) // ROL
            {
                return (byte)((value << count) | (value >> (ValueBits - count)));
            }
            else // ROR
            {
                return (byte)((value << (ValueBits - count)) | (value >> count));
            }
        }
        /// <summary>
        /// <para>Реализация ассемблерной команды ROL/ROR: вращение битов значения.</para>
        /// <para>Биты, уходыщие из числа с одной стороны, добавляются с другой</para>
        /// </summary>
        /// <param name="value">Исходное значение</param>
        /// <param name="bits"><para>Количество бит.</para><para>Если значение больше нуля, то биты вращаются влево, иначе - вправо</para></param>
        /// <returns>Результат операции</returns>
        public static UInt64 RotateBits(this UInt64 value, int bits)
        {
            const int ValueBits = 64;

            var count = Math.Abs(bits) % ValueBits;
            if (count == 0) return value;
            if (bits > 0) // ROL
            {
                return (byte)((value << count) | (value >> (ValueBits - count)));
            }
            else // ROR
            {
                return (byte)((value << (ValueBits - count)) | (value >> count));
            }
        }
    }
}
