using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Strong Encryption Header</para>
    /// </summary>
    public class StrongEncryptionHeader : BytestreamExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0017;
        /*
        Format    2 bytes  Format definition for this record
        AlgID     2 bytes  Encryption algorithm identifier
        Bitlen    2 bytes  Bit length of encryption key
        Flags     2 bytes  Processing flags
        CertData  TSize-8  Certificate decryption extra field data
                           (refer to the explanation for CertData
                            in the section describing the 
                            Certificate Processing Method under 
                            the Strong Encryption Specification)
         */
    }
}
