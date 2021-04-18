using Darkangel.IO;
using System;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>IBM S/390 (Z390), AS/400 (I400) compressed attributes</para>
    /// </summary>
    public class AS400СompressedAttributes : BytestreamExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0066;
    }
}
