using System;
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
        public override int DataSize => throw new NotImplementedException();
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            throw new NotImplementedException();
        }
        /*
        BSize       4 bytes       Uncompressed Block Size
        CType       2 bytes       Compression type
        EACRC       4 bytes       CRC value for uncompress block
        (var)       variable      Compressed block
         */
    }
}
