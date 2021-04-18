using System;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Digital signature</para>
    /// </summary>
    public class DigitalSignature : ZipRecord
    {
        /// <inheritdoc/>
        public override UInt32 Id => 0x05054b50;
        /// <inheritdoc/>
        public override void Load(ZipFile file)
        {
            base.Load(file);
            throw new NotImplementedException();
        }
        /*
        size of data                    2 bytes
        signature data (variable size)
        */
    }
}
