namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Дополнительные данные NTFS</para>
    /// </summary>
    public class NTFSExtraData : BytestreamExtraField
    {
        /*
        /// <summary>
        /// <para>NTFS attribute tag</para>
        /// </summary>
        public class AttributeTag
        {
            internal AttributeTag() { }
        }
        /// <summary>
        /// <para>File time</para>
        /// </summary>
        public class FileTimeAttribute : AttributeTag
        {
            private const int _DataSize = 3 * 8;
            /// <summary>
            /// <para>File last modification time</para>
            /// </summary>
            public System.DateTime Mtime { get; private set; }
            /// <summary>
            /// <para>File last access time</para>
            /// </summary>
            public System.DateTime Atime { get; private set; }
            /// <summary>
            /// <para>File creation time</para>
            /// </summary>
            public System.DateTime Ctime { get; private set; }
            internal FileTimeAttribute() { }
            internal int Load(Stream stream, int size)
            {
                Mtime = System.DateTime.FromFileTimeUtc((long)stream.ReadUInt64());
                Atime = System.DateTime.FromFileTimeUtc((long)stream.ReadUInt64());
                Ctime = System.DateTime.FromFileTimeUtc((long)stream.ReadUInt64());
                return _DataSize;
            }
        }
        */
        /// <inheritdoc/>
        public override int Id => 0x000a;
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
