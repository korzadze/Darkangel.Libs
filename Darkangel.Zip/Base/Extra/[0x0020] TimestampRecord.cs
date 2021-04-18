namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Timestamp record</para>
    /// </summary>
    public class TimestampRecord : BytestreamExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0020;
    }

}
