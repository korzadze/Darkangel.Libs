using System;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Patch Descriptor</para>
    /// </summary>
    public class PatchDescriptor : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x000f;
        /// <inheritdoc/>
        public override int DataSize => throw new NotImplementedException();
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            throw new NotImplementedException();
        }
        /*
        Version   2 bytes  Version of the descriptor
        Flags     4 bytes  Actions and reactions (see below) 
        OldSize   4 bytes  Size of the file about to be patched 
        OldCRC    4 bytes  32-bit CRC of the file to be patched 
        NewSize   4 bytes  Size of the resulting file 
        NewCRC    4 bytes  32-bit CRC of the resulting file 
         */
    }
}
