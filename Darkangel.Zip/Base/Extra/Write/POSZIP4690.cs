using System;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>POSZIP 4690</para>
    /// </summary>
    public class POSZIP4690 : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x4690;
        /// <inheritdoc/>
        public override int DataSize => throw new NotImplementedException();
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            throw new NotImplementedException();
        }
    }
}
