namespace Darkangel.Zip
{
    /// <summary>
    /// <para>X509 Certificate ID and Signature for individual file</para>
    /// </summary>
    public class IndividualX509Certificate : BytestreamExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0015;
        /*
        TData     TSize    Signature Data
        */
    }
}
