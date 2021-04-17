using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>X509 Certificate ID and Signature for individual file</para>
    /// </summary>
    public class IndividualX509Certificate : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0015;
        /// <inheritdoc/>
        public override int DataSize => throw new System.NotImplementedException();
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            throw new System.NotImplementedException();
        }
        /*
        TData     TSize    Signature Data
         */
    }
}
