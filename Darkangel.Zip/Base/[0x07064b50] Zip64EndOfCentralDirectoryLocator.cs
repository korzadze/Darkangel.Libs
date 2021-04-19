using System;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Zip64 end of central directory locator</para>
    /// </summary>
    public class Zip64EndOfCentralDirectoryLocator : ZipRecord
    {
        /// <inheritdoc/>
        public override long DataSize => throw new NotImplementedException();
        /// <inheritdoc/>
        public override UInt32 Id => 0x07064b50;
        /// <inheritdoc/>
        public override void Load(ZipFile file)
        {
            base.Load(file);
            throw new NotImplementedException();
        }
        /*
      number of the disk with the
      start of the zip64 end of 
      central directory               4 bytes
      relative offset of the zip64
      end of central directory record 8 bytes
      total number of disks           4 bytes
        */
    }
}
