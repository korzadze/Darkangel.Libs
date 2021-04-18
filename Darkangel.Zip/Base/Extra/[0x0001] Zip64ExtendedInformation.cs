using Darkangel.IntegerX;
using System;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Zip64 extended information</para>
    /// </summary>
    public class Zip64ExtendedInformation : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0001;
        /// <inheritdoc/>
        public override int DataSize => _DataSize;
        private const int _DataSize = 36;
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            if (_DataSize > size)
            {
                throw new InvalidZipExtraDataSizeException(size, _DataSize);
            }
            OriginalSize = stream.ReadUInt64(isLittleEndian: true);
            CompressedSize = stream.ReadUInt64(isLittleEndian: true);
            RelativeHeaderOffset = stream.ReadUInt64(isLittleEndian: true);
            DiskStartNumber = stream.ReadUInt32(isLittleEndian: true);
        }
        /// <summary>
        /// Original uncompressed file size
        /// </summary>
        public UInt64 OriginalSize { get; private set; }
        /// <summary>
        /// Size of compressed data
        /// </summary>
        public UInt64 CompressedSize { get; private set; }
        /// <summary>
        /// Offset of local header record
        /// </summary>
        public UInt64 RelativeHeaderOffset { get; private set; }
        /// <summary>
        /// Number of the disk on which this file starts
        /// </summary>
        public UInt32 DiskStartNumber { get; private set; }
    }
}
