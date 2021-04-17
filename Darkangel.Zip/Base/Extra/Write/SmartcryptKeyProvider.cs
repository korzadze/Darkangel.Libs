using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Smartcrypt Key Provider Record</para>
    /// </summary>
    public class SmartcryptKeyProvider : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0022;
        /// <inheritdoc/>
        public override int DataSize => throw new System.NotImplementedException();
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            throw new System.NotImplementedException();
        }
    }

}
