using Darkangel.IntegerX;
using Darkangel.IO;
using System;
using System.Text;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>End of central directory record</para>
    /// </summary>
    public class EndOfCentralDirectory : ZipRecord
    {
        /// <inheritdoc/>
        public override long DataSize => throw new NotImplementedException();
        /// <inheritdoc/>
        public override UInt32 Id => 0x06054b50;
        /// <summary>
        /// <para>Number of this disk</para>
        /// </summary>
        public UInt16 DiskNumber { get; private set; }
        /// <summary>
        /// <para>Number of the disk with the start of the central directory</para>
        /// </summary>
        public UInt16 CDRStartDiskNumber { get; private set; }
        /// <summary>
        /// <para>Total number of entries in the central directory on this disk</para>
        /// </summary>
        public UInt16 CDREntriesCountOnDisk { get; private set; }
        /// <summary>
        /// <para>Total number of entries in the central directory</para>
        /// </summary>
        public UInt16 CDREntriesTotalCount { get; private set; }
        /// <summary>
        /// <para>Size of the central directory</para>
        /// </summary>
        public UInt32 CDRSize { get; private set; }
        /// <summary>
        /// <para>Offset of start of central directory with respect to the starting disk number</para>
        /// </summary>
        public UInt16 CDROffsetRelativeToFirstDisk { get; private set; }
        /*
         .ZIP file comment length        2 bytes
        */
        /// <summary>
        /// <para>.ZIP file comment</para>
        /// </summary>
        public string Comment { get; private set; }

        /// <inheritdoc/>
        public override void Load(ZipFile file)
        {
            base.Load(file);
            DiskNumber = file.Stream.ReadUInt16(isLittleEndian: true);
            CDRStartDiskNumber = file.Stream.ReadUInt16(isLittleEndian: true);
            CDREntriesCountOnDisk = file.Stream.ReadUInt16(isLittleEndian: true);
            CDREntriesTotalCount = file.Stream.ReadUInt16(isLittleEndian: true);
            CDRSize = file.Stream.ReadUInt32(isLittleEndian: true);
            var CommentSize = file.Stream.ReadUInt16(isLittleEndian: true);
            var nameBuf = file.Stream.ReadBytes(CommentSize);
            Comment = ZipRecord.GetString(nameBuf, encoding: Encoding.ASCII);
        }
    }
}
