namespace Darkangel.Compression.Dune92
{
    /// <summary>
    /// <para>Настройки упаковки/распаковки данных файла сохраненной игры Dune (1992)</para>
    /// </summary>
    public class SavegameCompressonSettings
    {
        /// <summary>
        /// <para>Контрольный код по-умолчанию</para>
        /// </summary>
        public const byte DefaultControlCode = 0xf7;
        /// <summary>
        /// <para>Максимальное количество последовательно-одинаковых значений, записываемых в поток без упаковки</para>
        /// </summary>
        public const int DefaultMaxUnrepeatedValueCount = 2;
        /// <summary>
        /// <para>Код начала последовательности RLE</para>
        /// </summary>
        public readonly byte ControlCode;
        /// <summary>
        /// <para>Максимальное количество последовательно-одинаковых значений, записываемых в поток без упаковки</para>
        /// </summary>
        public readonly byte MaxUnRLEValueCount;
        /// <summary>
        /// <para>Инициализация настроек по-умолчанию</para>
        /// </summary>
        public SavegameCompressonSettings() :
            this(DefaultControlCode, DefaultMaxUnrepeatedValueCount)
        { }
        /// <summary>
        /// <para>Инициализация настроек заданными значениями</para>
        /// </summary>
        /// <param name="code">Код начала последовательности RLE</param>
        /// <param name="maxUnrepeated">Максимальное количество последовательно-одинаковых значений, записываемых в поток без упаковки</param>
        public SavegameCompressonSettings(byte code, byte maxUnrepeated)
        {
            ControlCode = code;
            MaxUnRLEValueCount = maxUnrepeated;
        }
    }
}
