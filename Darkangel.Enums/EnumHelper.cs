﻿using System;
using System.Reflection;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace Darkangel.Enums
{
    /// <summary>
    /// <para>Утилиты для работы с перечислениями</para>
    /// </summary>
    public static partial class EnumHelper
    {
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
        public static bool IsBitsetEnum(this Type type) =>
            (
                type != null &&
                type.IsEnum &&
                type.GetCustomAttributes<FlagsAttribute>().Any()
            );
        /// <summary>
        /// Является ли тип значения битовым перечислением
        /// </summary>
        /// <param name="val">Значение типа</param>
        /// <returns>Результат проверки</returns>
        public static bool IsBitsetEnum(this Enum val)
        {
            return IsBitsetEnum(val.GetType());
        }

        internal static class EnumConverter<T>
            where T : Enum
        {
            public static readonly Func<ulong, T> Convert = GenerateConverter();

            public static Func<ulong, T> GenerateConverter()
            {
                var parameter = Expression.Parameter(typeof(ulong));
                var dynamicMethod = Expression.Lambda<Func<ulong, T>>(
                    Expression.Convert(parameter, typeof(T)),
                    parameter);
                return dynamicMethod.Compile();
            }
        }
        /// <summary>
        /// <para>Проверить установку всех указанных флагов в значении</para>
        /// </summary>
        /// <typeparam name="T">Тип значения <see cref="Enum"/></typeparam>
        /// <param name="value">Проверяемое значение</param>
        /// <param name="flags">Флаги</param>
        /// <returns>Результат проверки</returns>
        public static bool IsSet<T>(this T value, T flags)
            where T : Enum
        {
            #region Check arguments
#if CHECK_ARGS
            if (!CanBeABitValue(value))
            {
                throw new InvalidCastException(StringResources.IsNotBitsetError);
            }
#endif
            #endregion
            var v = (value as IConvertible)?.ToUInt64(CultureInfo.CurrentCulture) ?? 0;
            var f = (flags as IConvertible)?.ToUInt64(CultureInfo.CurrentCulture) ?? 0;

            return (v & f) == f;
        }
        /// <summary>
        /// <para>Проверить установку любого из указанных флагов в значении</para>
        /// </summary>
        /// <typeparam name="T">Тип значения <see cref="Enum"/></typeparam>
        /// <param name="value">Проверяемое битовое значение</param>
        /// <param name="flags">Флаги</param>
        /// <returns>Результат проверки</returns>
        public static bool IsSetAny<T>(this T value, T flags)
            where T : Enum
        {
            #region Check arguments
#if CHECK_ARGS
            if (!CanBeABitValue(value))
            {
                throw new InvalidCastException(StringResources.IsNotBitsetError);
            }
#endif
            #endregion
            var v = (value as IConvertible)?.ToUInt64(CultureInfo.CurrentCulture) ?? 0;
            var f = (flags as IConvertible)?.ToUInt64(CultureInfo.CurrentCulture) ?? 0;

            return (v & f) != 0;
        }
        /// <summary>
        /// <para>Установить флаги в значении</para>
        /// </summary>
        /// <typeparam name="T">Тип значения <see cref="Enum"/></typeparam>
        /// <param name="value">Исходное битовое значение</param>
        /// <param name="flags">Флаги</param>
        /// <returns>Новое значение битовой маски</returns>
        public static T Set<T>(this T value, T flags)
            where T : Enum
        {
            #region Check arguments
#if CHECK_ARGS
            if (!CanBeABitValue(value))
            {
                throw new InvalidCastException(StringResources.IsNotBitsetError);
            }
#endif
            #endregion
            var v = (value as IConvertible)?.ToUInt64(CultureInfo.CurrentCulture) ?? 0;
            var f = (flags as IConvertible)?.ToUInt64(CultureInfo.CurrentCulture) ?? 0;

            return EnumConverter<T>.Convert(v | f);
        }
        /// <summary>
        /// <para>Сбросить флаги в значении</para>
        /// </summary>
        /// <typeparam name="T">Тип значения <see cref="Enum"/></typeparam>
        /// <param name="value">Исходное значение</param>
        /// <param name="flags">Флаги</param>
        /// <returns>Новое значение битовой маски</returns>
        public static T Unset<T>(this T value, T flags)
            where T : Enum
        {
            #region Check arguments
#if CHECK_ARGS
            if (!CanBeABitValue(value))
            {
                throw new InvalidCastException(StringResources.IsNotBitsetError);
            }
#endif
            #endregion
            var v = (value as IConvertible)?.ToUInt64(CultureInfo.CurrentCulture) ?? 0;
            var f = (flags as IConvertible)?.ToUInt64(CultureInfo.CurrentCulture) ?? 0;

            return EnumConverter<T>.Convert(v ^ f);
        }
        /// <summary>
        /// <para>Получить все элементы перечисления</para>
        /// </summary>
        /// <typeparam name="T">Тип элемента перечисления</typeparam>
        /// <returns>Массив значений перечисления</returns>
        public static T[] GetAllEnumValues<T>()
            where T : Enum
        {
            return Enum.GetValues(typeof(T))
                .OfType<T>()
                .ToArray();
        }
    }
}
