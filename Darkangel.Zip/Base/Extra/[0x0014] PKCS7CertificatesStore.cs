namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Хранилище PKCS#7 для сертификатов X.509</para>
    /// </summary>
    public class PKCS7CertificatesStore : BytestreamExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0014;
        /*
            TData     TSize    Data about the store
         */
    }
}
