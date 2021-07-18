using System;
using System.Linq.Expressions;

namespace Darkangel.Enums
{
    /// <summary>
    /// <para>Класс для конвертации шаблонных перечислений</para>
    /// </summary>
    /// <typeparam name="T">Тип перечисления</typeparam>
    public static class EnumConverter<T>
        where T : Enum
    {
        /// <summary>
        /// <para>Функция преобразования целочисленных значений в шаблонныое перечисление</para>
        /// </summary>
        public static readonly Func<ulong, T> Convert = GenerateConverter();

        internal static Func<ulong, T> GenerateConverter()
        {
            var parameter = Expression.Parameter(typeof(ulong));
            var dynamicMethod = Expression.Lambda<Func<ulong, T>>(
                Expression.Convert(parameter, typeof(T)),
                parameter);
            return dynamicMethod.Compile();
        }
    }
}
