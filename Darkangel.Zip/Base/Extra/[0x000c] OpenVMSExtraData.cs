namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Дополнительные данные OpenVMS</para>
    /// </summary>
    public class OpenVMSExtraData : BytestreamExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x000c;
        /*
         CRC        4 bytes    32-bit CRC for remainder of the block
         Tag1       2 bytes    OpenVMS attribute tag value #1
         Size1      2 bytes    Size of attribute #1, in bytes
         (var)      Size1      Attribute #1 data
         .
         .
         .
         TagN       2 bytes    OpenVMS attribute tag value #N
         SizeN      2 bytes    Size of attribute #N, in bytes
         (var)      SizeN      Attribute #N data
        */
    }
}
