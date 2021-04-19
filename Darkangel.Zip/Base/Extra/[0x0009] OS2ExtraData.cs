using Darkangel.IntegerX;
using Darkangel.IO;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Дополнительная информация OS/2</para>
    /// </summary>
    public partial class OS2ExtraData : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0009;
        /// <inheritdoc/>
        public override long DataSize => 10 + (_Data?.LongLength ?? 0);
        private byte[] _Data;
        /// <summary>
        /// <para>Прочитать данные записи</para>
        /// </summary>
        /// <returns>Данные записи в упакованном виде</returns>
        public byte[] GetData() =>
            (byte[])_Data.Clone();
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            BSize = stream.ReadUInt32(isLittleEndian: true);
            CType = stream.ReadUInt16(isLittleEndian: true);
            EACRC = stream.ReadUInt32(isLittleEndian: true);
            _Data = stream.ReadBytes(BSize);
        }
        /// <summary>
        /// <para>Размер распакованных данных</para>
        /// </summary>
        public long BSize { get; private set; }
        /// <summary>
        /// <para>Тип сжатия данных</para>
        /// </summary>
        public int CType { get; private set; }
        /// <summary>
        /// <para>Контрольная сумма распакованных данных</para>
        /// </summary>
        public long EACRC { get; private set; }
    }
}
