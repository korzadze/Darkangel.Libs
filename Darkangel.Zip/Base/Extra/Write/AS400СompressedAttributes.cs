using System;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>IBM S/390 (Z390), AS/400 (I400) compressed attributes</para>
    /// </summary>
    public class AS400СompressedAttributes : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0066;
        /// <inheritdoc/>
        public override int DataSize => throw new NotImplementedException();
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            throw new NotImplementedException();
        }
    }
}
