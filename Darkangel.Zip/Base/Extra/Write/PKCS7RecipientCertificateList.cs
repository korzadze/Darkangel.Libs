using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>PKCS#7 Encryption Recipient Certificate List</para>
    /// </summary>
    public class PKCS7RecipientCertificateList : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0019;
        /// <inheritdoc/>
        public override int DataSize => throw new System.NotImplementedException();
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            throw new System.NotImplementedException();
        }
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
