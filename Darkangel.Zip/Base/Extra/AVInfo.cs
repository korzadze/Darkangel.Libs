using Darkangel.IO;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>AV Info</para>
    /// </summary>
    public class AVInfo : ZipExtraField
    {
        private byte[] _Data;
        /// <inheritdoc/>
        public override int Id => 0x0007;
        /// <inheritdoc/>
        public override int DataSize => _Data?.Length ?? 0;
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            _Data = stream.ReadBytes(size);
        }
        /// <summary>
        /// <para>Получить данные неизвестного поля в сыром виде</para>
        /// </summary>
        /// <returns>Данные поля</returns>
        public byte[] GetData()
        {
            return (byte[])_Data.Clone();
        }
    }
}
