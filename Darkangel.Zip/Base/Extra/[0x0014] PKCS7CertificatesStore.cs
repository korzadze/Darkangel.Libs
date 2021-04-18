namespace Darkangel.Zip
{
    /// <summary>
    /// <para>PKCS#7 Store for X.509 Certificates</para>
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
