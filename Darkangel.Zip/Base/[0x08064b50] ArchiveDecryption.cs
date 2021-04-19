using System;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Archive extra data record</para>
    /// </summary>
    public class ArchiveDecryption : ZipRecord
    {
        /// <inheritdoc/>
        public override long DataSize => throw new NotImplementedException();
        /// <inheritdoc/>
        public override UInt32 Id => 0x08064b50;
        /// <inheritdoc/>
        public override void Load(ZipFile file)
        {
            base.Load(file);
            throw new NotImplementedException();
        }
        //extra field length              4 bytes
        //extra field data(variable size)
    }
}
