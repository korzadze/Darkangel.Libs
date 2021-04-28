using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darkangel.IntegerX
{
    /// <summary>
    /// <para>Вспомогательные утилиты для целочисленных операций</para>
    /// </summary>
    public static partial class IntegerX
    {
        /// <summary>
        /// <para>Получить размер целочисленного типа в терминах библиотеки</para>
        /// </summary>
        /// <param name="type">Целочисленный тип</param>
        /// <returns>Размер значения типа или -1, для неизвестных типов</returns>
        public static int GetSize(Type type)
        {
            return type.FullName switch
            {
                "System.Byte" => IntegerXHelpers.UInt8_ByteSize,
                "System.SByte" => IntegerXHelpers.Int8_ByteSize,
                "System.UInt16" => IntegerXHelpers.UInt16_ByteSize,
                "System.Int16" => IntegerXHelpers.Int16_ByteSize,
                "Darkangel.IntegerX.UInt24" => IntegerXHelpers.UInt24_ByteSize,
                "System.UInt32" => IntegerXHelpers.UInt32_ByteSize,
                "System.Int32" => IntegerXHelpers.Int32_ByteSize,
                "Darkangel.IntegerX.UInt48" => IntegerXHelpers.UInt48_ByteSize,
                "System.UInt64" => IntegerXHelpers.UInt64_ByteSize,
                "System.Int64" => IntegerXHelpers.Int64_ByteSize,
                _ => -1,
            };
        }
        /// <summary>
        /// <para>Получить размер целочисленного типа в терминах библиотеки</para>
        /// </summary>
        /// <typeparam name="T">Целочисленный тип</typeparam>
        /// <returns>Размер значения типа или -1, для неизвестных типов</returns>
        public static int GetSize<T>()
        {
            return GetSize(typeof(T));
        }
    }
}
