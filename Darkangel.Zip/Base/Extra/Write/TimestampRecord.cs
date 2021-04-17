using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Timestamp record</para>
    /// </summary>
    public class TimestampRecord : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0020;
        /// <inheritdoc/>
        public override int DataSize => throw new System.NotImplementedException();
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            throw new System.NotImplementedException();
        }
    }

}
