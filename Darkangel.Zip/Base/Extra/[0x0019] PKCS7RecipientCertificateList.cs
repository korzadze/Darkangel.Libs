namespace Darkangel.Zip
{
    /// <summary>
    /// <para>PKCS#7 Encryption Recipient Certificate List</para>
    /// </summary>
    public class PKCS7RecipientCertificateList : BytestreamExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0019;
        /*
         TData     TSize    Data about the store

         TData:

         Value     Size     Description
         -----     ----     -----------
         Version   2 bytes  Format version number - MUST be 0x0001 at this time
         CStore    (var)    PKCS#7 data blob
         */
    }
}
