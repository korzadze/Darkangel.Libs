using Darkangel.IntegerX;
using System;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Strong Encryption Header</para>
    /// </summary>
    public class StrongEncryptionHeader : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0017;
        /// <inheritdoc/>
        public override long DataSize => 8 + CertData.DataSize;
        /// <summary>
        /// <para>Format definition for this record</para>
        /// </summary>
        public UInt16 Format { get; private set; }
        /// <summary>
        /// <para>Encryption algorithm identifier</para>
        /// </summary>
        public UInt16 AlgID { get; private set; }
        /// <summary>
        /// <para>Bit length of encryption key</para>
        /// </summary>
        public UInt16 Bitlen { get; private set; }
        /// <summary>
        /// <para>Processing flags</para>
        /// </summary>
        public UInt16 Flags { get; private set; }
        /// <summary>
        /// <para>Certificate decryption extra field data</para>
        /// </summary>
        public CertificateData CertData { get; private set; } = new();

        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            Format = stream.LoadUInt16(isLittleEndian: true);
            AlgID = stream.LoadUInt16(isLittleEndian: true);
            Bitlen = stream.LoadUInt16(isLittleEndian: true);
            Flags = stream.LoadUInt16(isLittleEndian: true);
            CertData.Load(stream);
        }
    }
}
