using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Policy Decryption Key Record</para>
    /// </summary>
    public class PolicyDecryptionKey : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0021;
        /// <inheritdoc/>
        public override int DataSize => throw new System.NotImplementedException();
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            throw new System.NotImplementedException();
        }
    }

}
