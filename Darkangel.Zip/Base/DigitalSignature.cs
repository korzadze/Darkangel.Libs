using System;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Digital signature</para>
    /// </summary>
    public class DigitalSignature : ZipRecord
    {
        /// <inheritdoc/>
        public override long Id => 0x05054b50;
        /// <inheritdoc/>
        public override void Load(Stream stream)
        {
            base.Load(stream);
            throw new NotImplementedException();
        }
        /*
        size of data                    2 bytes
        signature data (variable size)
        */
    }
}
