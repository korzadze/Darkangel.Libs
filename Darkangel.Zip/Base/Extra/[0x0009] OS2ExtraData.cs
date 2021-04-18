using Darkangel.IntegerX;
using Darkangel.IO;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>OS/2 extra data</para>
    /// </summary>
    public partial class OS2ExtraData : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0009;
        /// <inheritdoc/>
        public override int DataSize => 10 + (_Data?.Length ?? 0);
        private byte[] _Data;
        /// <summary>
        /// <para>Compressed data</para>
        /// </summary>
        /// <returns></returns>
        public byte[] GetData() =>
            (byte[])_Data.Clone();
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            BSize = stream.ReadUInt32(isLittleEndian: true);
            CType = stream.ReadUInt16(isLittleEndian: true);
            EACRC = stream.ReadUInt32(isLittleEndian: true);
            _Data = stream.ReadBytes(BSize);
        }
        /// <summary>
        /// <para>Uncompressed Block Size</para>
        /// </summary>
        public long BSize { get; private set; }
        /// <summary>
        /// <para>Compression type</para>
        /// </summary>
        public int CType { get; private set; }
        /// <summary>
        /// <para>CRC value for uncompress block</para>
        /// </summary>
        public long EACRC { get; private set; }
    }
}
