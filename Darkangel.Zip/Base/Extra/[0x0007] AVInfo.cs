using Darkangel.IO;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>AV Info</para>
    /// </summary>
    public class AVInfo : BytestreamExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0007;
    }
}
