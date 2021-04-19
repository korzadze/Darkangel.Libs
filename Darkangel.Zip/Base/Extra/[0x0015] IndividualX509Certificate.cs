namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Идентификатор сертификата X.509 и подпись для индивидуального файла</para>
    /// </summary>
    public class IndividualX509Certificate : BytestreamExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0015;
        /*
        TData     TSize    Signature Data
        */
    }
}
