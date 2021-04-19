using Darkangel.IO;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Заглушка для необработанных данных</para>
    /// </summary>
    public abstract class BytestreamExtraField : ZipExtraField
    {
        private byte[] _Data;
        /// <inheritdoc/>
        public override long DataSize => _Data?.Length ?? 0;
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
