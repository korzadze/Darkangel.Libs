using System;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>UNIX extra data</para>
    /// </summary>
    public class UNIXExtraData : BytestreamExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x000d;
        /*
        Atime       4 bytes       File last access time
        Mtime       4 bytes       File last modification time
        Uid         2 bytes       File user ID
        Gid         2 bytes       File group ID
        (var)       variable      Variable length data field
         */
    }
}
