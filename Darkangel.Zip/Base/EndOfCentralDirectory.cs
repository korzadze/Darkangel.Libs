using System;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>End of central directory record</para>
    /// </summary>
    public class EndOfCentralDirectory : ZipRecord
    {
        /// <inheritdoc/>
        public override long Id => 0x06054b50;
        /// <inheritdoc/>
        public override void Load(Stream stream)
        {
            base.Load(stream);
            throw new NotImplementedException();
        }
        /*
      number of this disk             2 bytes
      number of the disk with the
      start of the central directory  2 bytes
      total number of entries in the
      central directory on this disk  2 bytes
      total number of entries in
      the central directory           2 bytes
      size of the central directory   4 bytes
      offset of start of central
      directory with respect to
      the starting disk number        4 bytes
      .ZIP file comment length        2 bytes
      .ZIP file comment       (variable size)
        */
    }
}
