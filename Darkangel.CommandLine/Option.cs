using System;

namespace Darkangel.CommandLine
{
    /// <summary>
    /// <para>Опция коммандной строки</para>
    /// </summary>
    public class Option
    {
        /// <summary>
        /// <para>Короткое имя опции (-o [value])</para>
        /// </summary>
        public readonly char? ShortName;
        /// <summary>
        /// <para>Длинное имя опции (--opt[=value])</para>
        /// </summary>
        public readonly string LongName;
        /// <summary>
        /// <para>Наличие значения у опции</para>
        /// </summary>
        public readonly OptionValueMode Mode;
        /// <summary>
        /// <para>Тэг опции (для упрощения выбора через switch)</para>
        /// </summary>
        public readonly object Tag;
        /// <summary>
        /// <para>Подсказка для опции</para>
        /// </summary>
        public readonly string Help;

        /// <summary>
        /// <para>Конструктор экземпляра класса</para>
        /// </summary>
        /// <param name="shortName">Короткое имя опции</param>
        /// <param name="mode">Флаги опции</param>
        /// <param name="tag">Тэг опции</param>
        /// <param name="help">Подсказка для опции</param>
        public Option(char shortName, OptionValueMode mode, object tag = null, string help = null):
            this(shortName, null, mode, tag, help) { }
        /// <summary>
        /// <para>Конструктор экземпляра класса</para>
        /// </summary>
        /// <param name="longName">Длинное имя опции</param>
        /// <param name="mode">Флаги опции</param>
        /// <param name="tag">Тэг опции</param>
        /// <param name="help">Подсказка для опции</param>
        public Option(string longName, OptionValueMode mode, object tag = null, string help = null):
            this(null, longName, mode, tag, help) { }
        /// <summary>
        /// <para>Конструктор экземпляра класса</para>
        /// </summary>
        /// <param name="shortName">Короткое имя опции</param>
        /// <param name="longName">Длинное имя опции</param>
        /// <param name="mode">Флаги опции</param>
        /// <param name="tag">Тэг опции</param>
        /// <param name="help">Подсказка для опции</param>
        public Option(char? shortName, string longName = null, OptionValueMode mode = OptionValueMode.ValueDenied, object tag = null, string help = null)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            if ((shortName is null) && (longName is null))
            {
                throw new InvalidOptionNameException();
            }
#endif
            #endregion Проверка аргументов
            ShortName = shortName;
            LongName = longName;
            Mode = mode;
            Tag = tag;
            Help = help;
        }
        /// <summary>
        /// <para>Добавить опции в список</para>
        /// </summary>
        /// <param name="opt1">Опция командной строки</param>
        /// <param name="opt2">Опция командной строки</param>
        /// <returns>Список опций командной строки</returns>
        public static OptionCollection operator +(Option opt1, Option opt2) =>
            new OptionCollection() + opt1 + opt2;

    }
}
