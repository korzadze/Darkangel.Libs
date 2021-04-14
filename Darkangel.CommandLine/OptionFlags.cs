using System;

namespace Darkangel
{
    /// <summary>
    /// <para>Допустимость наличия значения для опции</para>
    /// </summary>
    [Flags]
    public enum OptionFlags
    {
        /// <summary>
        /// <para>Параметр командной строки не является опцией</para>
        /// </summary>
        NonOption = 1 << 0,
        /// <summary>
        /// <para>Значение не допустимо</para>
        /// </summary>
        ValueDenied = 1 << 1,
        /// <summary>
        /// <para>Значение обязательно</para>
        /// </summary>
        ValueRequired = 1 << 2,
        /// <summary>
        /// <para>Значение допустимо</para>
        /// </summary>
        ValueOptional = ValueRequired | ValueDenied,
    }
}
