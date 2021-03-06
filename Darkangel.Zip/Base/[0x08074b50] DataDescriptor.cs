using Darkangel.IntegerX;
using System;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Особая запись, без идентификатора, но с определенным местоположением</para>
    /// </summary>
    public class DataDescriptor : ZipRecord
    {
        /// <summary>
        /// <para>Не используется</para>
        /// </summary>
        public override UInt32 Id => 0x08074b50;
        /// <summary>
        /// <para>crc-32</para>
        /// </summary>
        public UInt32 Crc32 { get; private set; }
        /// <summary>
        /// <para>compressed size</para>
        /// </summary>
        public UInt32 CompressedSize { get; private set; }
        /// <summary>
        /// <para>uncompressed size</para>
        /// </summary>
        public UInt32 UncompressedSize { get; private set; }
        /// <inheritdoc/>
        public override long DataSize => 12;

        /// <inheritdoc/>
        public override void Load(ZipFile file)
        {
            base.Load(file);
            Crc32 = file.Stream.LoadUInt32(isLittleEndian: true);
            CompressedSize = file.Stream.LoadUInt32(isLittleEndian: true);
            UncompressedSize = file.Stream.LoadUInt32(isLittleEndian: true);
        }
    }
}
