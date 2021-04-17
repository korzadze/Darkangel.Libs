using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Smartcrypt Policy Key Data Record</para>
    /// </summary>
    public class SmartcryptPolicyKey : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0023;
        /// <inheritdoc/>
        public override int DataSize => throw new System.NotImplementedException();
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            throw new System.NotImplementedException();
        }
    }

}
