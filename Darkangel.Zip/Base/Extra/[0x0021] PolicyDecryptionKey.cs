namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Policy Decryption Key Record</para>
    /// </summary>
    public class PolicyDecryptionKey : BytestreamExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0021;
    }
}
