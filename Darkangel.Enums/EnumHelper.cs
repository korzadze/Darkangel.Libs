using System;
using System.Reflection;
using System.Globalization;
using System.Linq;

namespace Darkangel.Enums
{
    /// <summary>
    /// <para>Утилиты для работы с перечислениями</para>
    /// </summary>
    public static partial class EnumHelper
    {
        private static readonly CultureInfo _Culture = CultureInfo.InvariantCulture;
#pragma warning disable IDE0060 // Удалите неиспользуемый параметр
        private static bool CanBeABitValue<T>(T value)
#pragma warning restore IDE0060 // Удалите неиспользуемый параметр
        {
            var valueType = typeof(T);
            return
                valueType.IsBitsetEnum() ||
                valueType.Equals(typeof(Byte)) ||
                valueType.Equals(typeof(SByte)) ||
                valueType.Equals(typeof(Int16)) ||
                valueType.Equals(typeof(UInt16)) ||
                valueType.Equals(typeof(Int32)) ||
                valueType.Equals(typeof(UInt32)) ||
                valueType.Equals(typeof(Int64)) ||
                valueType.Equals(typeof(UInt64));
        }

        /// <summary>
        /// Является ли тип значения битовым перечислением
        /// </summary>
        /// <param name="type">Проверяемый тип</param>
        /// <returns>Результат проверки</returns>
        /// <remarks>2021-04-18</remarks>
        public static bool IsBitsetEnum(this Type type) =>
            (
                type != null &&
                type.IsEnum &&
                type.GetCustomAttributes<FlagsAttribute>().Any()
            );
        /// <summary>
        /// Является ли тип значения битовым перечислением
        /// </summary>
        /// <typeparam name="T">Тип перечисления</typeparam>
        /// <returns>Результат проверки</returns>
        /// <remarks>2021-04-18</remarks>
        public static bool IsBitsetEnum<T>()
            where T : Enum => IsBitsetEnum(typeof(T));
        /// <summary>
        /// Является ли тип значения битовым перечислением
        /// </summary>
        /// <param name="val">Значение типа</param>
        /// <returns>Результат проверки</returns>
        /// <remarks>2021-04-18</remarks>
        public static bool IsBitsetEnum(this Enum val) =>
            IsBitsetEnum(val.GetType());

        /// <summary>
        /// <para>Проверить установку всех указанных флагов в значении</para>
        /// </summary>
        /// <typeparam name="T">Тип значения <see cref="Enum"/></typeparam>
        /// <typeparam name="TFlag">Тип значения флага</typeparam>
        /// <param name="value">Проверяемое значение</param>
        /// <param name="flags">Флаги</param>
        /// <returns>Результат проверки</returns>
        /// <remarks>2021-04-18</remarks>
        public static bool IsSet<T, TFlag>(this T value, TFlag flags)
            where T : Enum
            where TFlag : IConvertible
        {
            #region Check arguments
#if CHECK_ARGS
            if (!CanBeABitValue(value))
            {
                throw new InvalidCastException(StringResources.IsNotBitsetError);
            }
#endif
            #endregion
            var v = (value as IConvertible)?.ToUInt64(_Culture) ?? 0;
            var f = flags?.ToUInt64(_Culture) ?? 0;

            return (v & f) == f;
        }
        /// <summary>
        /// <para>Проверить установку любого из указанных флагов в значении</para>
        /// </summary>
        /// <typeparam name="T">Тип значения <see cref="Enum"/></typeparam>
        /// <typeparam name="TFlag">Тип значения флага</typeparam>
        /// <param name="value">Проверяемое битовое значение</param>
        /// <param name="flags">Флаги</param>
        /// <returns>Результат проверки</returns>
        /// <remarks>2021-04-18</remarks>
        public static bool IsSetAny<T, TFlag>(this T value, TFlag flags)
            where T : Enum
            where TFlag : IConvertible
        {
            #region Check arguments
#if CHECK_ARGS
            if (!CanBeABitValue(value))
            {
                throw new InvalidCastException(StringResources.IsNotBitsetError);
            }
#endif
            #endregion
            var v = (value as IConvertible)?.ToUInt64(_Culture) ?? 0;
            var f = flags?.ToUInt64(_Culture) ?? 0;

            return (v & f) != 0;
        }
        /// <summary>
        /// <para>Установить флаги в значении</para>
        /// </summary>
        /// <typeparam name="T">Тип значения <see cref="Enum"/></typeparam>
        /// <typeparam name="TFlag">Тип значения флага</typeparam>
        /// <param name="value">Исходное битовое значение</param>
        /// <param name="flags">Флаги</param>
        /// <returns>Новое значение битовой маски</returns>
        /// <remarks>2021-04-18</remarks>
        public static T Set<T, TFlag>(this T value, TFlag flags)
            where T : Enum
            where TFlag : IConvertible
        {
            #region Check arguments
#if CHECK_ARGS
            if (!CanBeABitValue(value))
            {
                throw new InvalidCastException(StringResources.IsNotBitsetError);
            }
#endif
            #endregion
            var v = (value as IConvertible)?.ToUInt64(_Culture) ?? 0;
            var f = flags?.ToUInt64(_Culture) ?? 0;

            return EnumConverter<T>.Convert(v | f);
        }
        /// <summary>
        /// <para>Сбросить флаги в значении</para>
        /// </summary>
        /// <typeparam name="T">Тип значения <see cref="Enum"/></typeparam>
        /// <typeparam name="TFlag">Тип значения флага</typeparam>
        /// <param name="value">Исходное значение</param>
        /// <param name="flags">Флаги</param>
        /// <returns>Новое значение битовой маски</returns>
        /// <remarks>2021-04-18</remarks>
        public static T Unset<T, TFlag>(this T value, TFlag flags)
            where T : Enum
            where TFlag : IConvertible
        {
            #region Check arguments
#if CHECK_ARGS
            if (!CanBeABitValue(value))
            {
                throw new InvalidCastException(StringResources.IsNotBitsetError);
            }
#endif
            #endregion
            var v = (value as IConvertible)?.ToUInt64(_Culture) ?? 0;
            var f = flags?.ToUInt64(_Culture) ?? 0;

            return EnumConverter<T>.Convert(v ^ f);
        }
        /// <summary>
        /// <para>Получить все элементы перечисления</para>
        /// </summary>
        /// <typeparam name="T">Тип элемента перечисления</typeparam>
        /// <returns>Массив значений перечисления</returns>
        /// <remarks>2021-04-18</remarks>
        public static T[] GetAllEnumValues<T>()
            where T : Enum =>
            Enum.GetValues(typeof(T))
                .OfType<T>()
                .ToArray();
    }
}
