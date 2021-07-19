namespace Darkangel.IO
{
    /// <summary>
    /// <para>Описание хранения значений с плавающей точкой в двоичном потоке</para>
    /// </summary>
    public interface IFloatContext
    {
        /// <summary>
        /// <para>Формат хранения значений с плавающей точкой</para>
        /// </summary>
        FloatStoreFormat StoreFormat { get; }
    }
}
