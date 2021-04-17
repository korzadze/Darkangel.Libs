using Darkangel.IO;
using System;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>X.509 Certificate ID for Central Directory</para>
    /// </summary>
    public class CentralDirectoryX509Certificate : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0016;
        /// <inheritdoc/>
        public override int DataSize => throw new System.NotImplementedException();
        private byte[] _Data;
        /// <summary>
        /// <para>This field contains the information about which certificate in the PKCS#7 store was used to sign the central directory structure.</para>
        /// <para>When the Central Directory Encryption feature is enabled for a ZIP file, this record will appear in the Archive Extra Data Record, otherwise it will appear in the first central directory record.</para>
        /// </summary>
        public byte[] Data => (byte[])_Data.Clone();
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            _Data = stream.ReadBytes(size);
        }
    }
}
