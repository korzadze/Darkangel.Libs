using Darkangel.IO;
using System;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Объект, для хранения информации о нереализованном типе дополнительных данных</para>
    /// </summary>
    public sealed class UnknownZipExtraField : ZipExtraField
    {
        /// <summary>
        /// <para>Конструктор экземляра <see cref="UnknownZipExtraField"/></para>
        /// </summary>
        /// <param name="id">Идентификатор неизвестных данных</param>
        internal UnknownZipExtraField(int id)
        {
            _Id = id;
        }

        private readonly int _Id;
        private byte[] _Data;
        /// <inheritdoc/>
        public override int Id => _Id;
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
