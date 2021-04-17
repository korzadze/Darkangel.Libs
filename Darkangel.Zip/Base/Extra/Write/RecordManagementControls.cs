using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Record Management Controls</para>
    /// </summary>
    public class RecordManagementControls : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0018;
        /// <inheritdoc/>
        public override int DataSize => throw new System.NotImplementedException();
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            throw new System.NotImplementedException();
        }
        /*
          Tag1      2 bytes  Record control attribute 1
          Size1     2 bytes  Size of attribute 1, in bytes
          Data1     Size1    Attribute 1 data
          .
          .
          .
          TagN      2 bytes  Record control attribute N
          SizeN     2 bytes  Size of attribute N, in bytes
          DataN     SizeN    Attribute N data
         */
    }
}
