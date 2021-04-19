namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Дополнительная информация о кодировке текста</para>
    /// </summary>
    public class ExtendedLanguageEncoding : BytestreamExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0008;
    }

}
