namespace Darkangel.IO
{
    /// <summary>
    /// <para>Контекст хранения данных в двоичном потоке</para>
    /// </summary>
    public interface IBinaryContext
    {
        /// <summary>
        /// <para>Порядок хранения байт в потоке</para>
        /// <list type="table">
        /// <item>True: от младшего к старшему</item>
        /// <item>False: от старшего к младшему</item>
        /// </list>
        /// </summary>
        bool IsLittleEndian { get; }
        /// <summary>
        /// <para>Описание хранения целочисленных значений в двоичном потоке</para>
        /// </summary>
        IInetegerContext Integer { get; }
        /// <summary>
        /// <para>Описание хранения значений с плавающей точкой в двоичном потоке</para>
        /// </summary>
        IFloatContext Float { get; }
        /// <summary>
        /// <para>Описание хранения строковых значений в двоичном потоке</para>
        /// </summary>
        IStringContext String { get; }
    }
}
