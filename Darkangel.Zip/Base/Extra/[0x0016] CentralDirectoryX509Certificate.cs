namespace Darkangel.Zip
{
    /// <summary>
    /// <para>X.509 Certificate ID for Central Directory</para>
    /// </summary>
    public class CentralDirectoryX509Certificate : BytestreamExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0016;
    }
}
