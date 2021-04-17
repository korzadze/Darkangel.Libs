using System;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Archive extra data record</para>
    /// </summary>
    public class ArchiveDecryption : ZipRecord
    {
        /// <inheritdoc/>
        public override long Id => 0x08064b50;
        /// <inheritdoc/>
        public override void Load(Stream stream)
        {
            base.Load(stream);
            throw new NotImplementedException();
        }
        //extra field length              4 bytes
        //extra field data(variable size)
    }
}
