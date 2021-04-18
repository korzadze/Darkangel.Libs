using System;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Central directory file header</para>
    /// </summary>
    public class CentralDirectoryFileHeader : ZipRecord
    {
        /// <inheritdoc/>
        public override UInt32 Id => 0x02014b50;
        /// <inheritdoc/>
        public override void Load(ZipFile file)
        {
            base.Load(file);
            throw new NotImplementedException();
        }
        /*
        version made by                 2 bytes
        version needed to extract       2 bytes
        general purpose bit flag        2 bytes
        compression method              2 bytes
        last mod file time              2 bytes
        last mod file date              2 bytes
        crc-32                          4 bytes
        compressed size                 4 bytes
        uncompressed size               4 bytes
        file name length                2 bytes
        extra field length              2 bytes
        file comment length             2 bytes
        disk number start               2 bytes
        internal file attributes        2 bytes
        external file attributes        4 bytes
        relative offset of local header 4 bytes

        file name (variable size)
        extra field (variable size)
        file comment (variable size)
        */
    }
}
