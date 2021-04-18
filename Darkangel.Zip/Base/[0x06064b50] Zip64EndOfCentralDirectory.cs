using System;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Zip64 end of central directory record</para>
    /// </summary>
    public class Zip64EndOfCentralDirectory : ZipRecord
    {
        /// <inheritdoc/>
        public override UInt32 Id => 0x06064b50;
        /// <inheritdoc/>
        public override void Load(ZipFile file)
        {
            base.Load(file);
            throw new NotImplementedException();
        }
        /*
        size of zip64 end of central
        directory record                8 bytes
        version made by                 2 bytes
        version needed to extract       2 bytes
        number of this disk             4 bytes
        number of the disk with the 
        start of the central directory  4 bytes
        total number of entries in the
        central directory on this disk  8 bytes
        total number of entries in the
        central directory               8 bytes
        size of the central directory   8 bytes
        offset of start of central
        directory with respect to
        the starting disk number        8 bytes
        zip64 extensible data sector    (variable size)
        */
    }
}
