using System;

namespace Darkangel
{
    /// <summary>
    /// <para>Опция коммандной строки</para>
    /// </summary>
    public class CommandLineSwitch
    {
        /// <summary>
        /// <para>Короткое имя опции (-o [value])</para>
        /// </summary>
        public readonly char ShortName;
        /// <summary>
        /// <para>Длинное имя опции (--opt[=value])</para>
        /// </summary>
        public readonly string LongName;
        /// <summary>
        /// <para>Флаги опции</para>
        /// </summary>
        public readonly OptionFlags Flags;
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
        /// <param name="ShortName">Короткое имя опции</param>
        /// <param name="Flags">Флаги опции</param>
        /// <param name="Tag">Тэг опции</param>
        /// <param name="Help">Подсказка для опции</param>
        public CommandLineSwitch(char ShortName, OptionFlags Flags, object Tag = null, string Help = null):
            this(ShortName, null, Flags, Tag, Help)
        {

        }
        /// <summary>
        /// <para>Конструктор экземпляра класса</para>
        /// </summary>
        /// <param name="LongName">Длинное имя опции</param>
        /// <param name="Flags">Флаги опции</param>
        /// <param name="Tag">Тэг опции</param>
        /// <param name="Help">Подсказка для опции</param>
        public CommandLineSwitch(string LongName, OptionFlags Flags, object Tag = null, string Help = null):
            this('\0', LongName, Flags, Tag, Help)
        {

        }
        /// <summary>
        /// <para>Конструктор экземпляра класса</para>
        /// </summary>
        /// <param name="ShortName">Короткое имя опции</param>
        /// <param name="LongName">Длинное имя опции</param>
        /// <param name="Flags">Флаги опции</param>
        /// <param name="Tag">Тэг опции</param>
        /// <param name="Help">Подсказка для опции</param>
        public CommandLineSwitch(char ShortName = '\0', string LongName = null, OptionFlags Flags = OptionFlags.ValueDenied, object Tag = null, string Help = null)
        {
            if ((ShortName == '\0') && (LongName is null))
            {
                throw new ArgumentNullException(nameof(LongName));
            }
            if (this.Flags.HasFlag(OptionFlags.NonOption))
            {
                throw new ArgumentOutOfRangeException(nameof(Flags));
            }
            this.ShortName = ShortName;
            this.LongName = LongName;
            this.Flags = Flags;
            this.Tag = Tag;
            this.Help = Help;
        }

        internal CommandLineSwitch()
        {
            ShortName = '\0';
            LongName = null;
            Flags = OptionFlags.NonOption;
            Tag = null;
            Help = null;
        }
    }
}
