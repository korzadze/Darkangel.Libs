namespace Darkangel.CommandLine
{
    /// <summary>
    /// <para>Допустимость наличия значения для опции</para>
    /// </summary>
    /// <remarks>release</remarks>
    public enum OptionValueMode
    {
        /// <summary>
        /// <para>Значение не допустимо</para>
        /// </summary>
        ValueDenied,
        /// <summary>
        /// <para>Значение обязательно</para>
        /// </summary>
        ValueRequired,
        /// <summary>
        /// <para>Значение допустимо</para>
        /// </summary>
        ValueOptional,
    }
}
