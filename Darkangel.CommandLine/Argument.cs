namespace Darkangel.CommandLine
{
    /// <summary>
    /// <para>Аргумент командной строки</para>
    /// </summary>
    public class Argument
    {
        /// <summary>
        /// <para>Исходная опция командной строки или null, если аргумент не является опцией</para>
        /// </summary>
        public readonly Option Option;
        /// <summary>
        /// <para>Является ли аргумент опцией или это просто необработанное значение</para>
        /// </summary>
        public bool IsOption => Option != null;
        /// <summary>
        /// <para>Значение аргумента</para>
        /// </summary>
        public readonly string Value;
        /// <summary>
        /// <para>Имеется ли значение</para>
        /// </summary>
        public bool HasValue => Value != null;

        internal Argument(Option opt, string value)
        {
            Option = opt;
            Value = value;
        }
    }
}
