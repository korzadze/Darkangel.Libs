using System;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>NTFS extra data</para>
    /// </summary>
    public class NTFSExtraData : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x000a;
        /// <inheritdoc/>
        public override int DataSize => throw new NotImplementedException();
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            throw new NotImplementedException();
        }
        /*
        Reserved   4 bytes    Reserved for future use
        Tag1       2 bytes    NTFS attribute tag value #1
        Size1      2 bytes    Size of attribute #1, in bytes
        (var)      Size1      Attribute #1 data
         .
         .
         .
         TagN       2 bytes    NTFS attribute tag value #N
         SizeN      2 bytes    Size of attribute #N, in bytes
         (var)      SizeN      Attribute #N data

       For NTFS, values for Tag1 through TagN are as follows:
       (currently only one set of attributes is defined for NTFS)

         Tag        Size       Description
         -----      ----       -----------
         0x0001     2 bytes    Tag for attribute #1 
         Size1      2 bytes    Size of attribute #1, in bytes
         Mtime      8 bytes    File last modification time
         Atime      8 bytes    File last access time
         Ctime      8 bytes    File creation time
         */
    }
}
