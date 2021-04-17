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
            _OriginalSize = stream.ReadUInt64(isLittleEndian: true);
            _CompressedSize = stream.ReadUInt64(isLittleEndian: true); ;
            _RelativeHeaderOffset = stream.ReadUInt64(isLittleEndian: true); ;
            _DiskStartNumber = stream.ReadUInt32(isLittleEndian: true); ;
        }
        /*
        Original Size            8 bytes    Original uncompressed file size
        Compressed Size          8 bytes    Size of compressed data
        Relative Header Offset   8 bytes    Offset of local header record 
        Disk Start Number        4 bytes    Number of the disk on which this file starts 
         */
        private UInt64 _OriginalSize;
        private UInt64 _CompressedSize;
        private UInt64 _RelativeHeaderOffset;
        private UInt32 _DiskStartNumber;
        /// <summary>
        /// Original uncompressed file size
        /// </summary>
        public UInt64 OriginalSize => _OriginalSize;
        /// <summary>
        /// Size of compressed data
        /// </summary>
        public UInt64 CompressedSize => _CompressedSize;
        /// <summary>
        /// Offset of local header record
        /// </summary>
        public UInt64 RelativeHeaderOffset => _RelativeHeaderOffset;
        /// <summary>
        /// Number of the disk on which this file starts
        /// </summary>
        public UInt32 DiskStartNumber => _DiskStartNumber;
    }
}
