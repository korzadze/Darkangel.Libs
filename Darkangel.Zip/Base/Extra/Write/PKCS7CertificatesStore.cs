using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>PKCS#7 Store for X.509 Certificates</para>
    /// </summary>
    public class PKCS7CertificatesStore : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0014;
        /// <inheritdoc/>
        public override int DataSize => throw new System.NotImplementedException();
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            throw new System.NotImplementedException();
        }
    }
    /*
        TData     TSize    Data about the store
     */
}
