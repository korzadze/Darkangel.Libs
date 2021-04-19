namespace Darkangel.Zip
{
    /// <summary>
    /// <para>PKWARE's authentication</para>
    /// </summary>
    public class AVInfo : BytestreamExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0007;
    }
}
