using Darkangel.IntegerX;
using System;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Расширенная информация режима ZIP64</para>
    /// </summary>
    public class Zip64ExtendedInformation : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0001;
        /// <inheritdoc/>
        public override long DataSize => _DataSize;
        private const int _DataSize = 36;
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            if (_DataSize > size)
            {
                throw new InvalidZipExtraDataSizeException(size, _DataSize);
            }
            OriginalSize = stream.ReadUInt64(isLittleEndian: true);
            CompressedSize = stream.ReadUInt64(isLittleEndian: true);
            RelativeHeaderOffset = stream.ReadUInt64(isLittleEndian: true);
            StartDiskNumber = stream.ReadUInt32(isLittleEndian: true);
        }
        /// <summary>
        /// <para>Размер неупакованных данных.</para>
        /// </summary>
        public UInt64 OriginalSize { get; private set; }
        /// <summary>
        /// <para>Размер упакованных данных</para>
        /// </summary>
        public UInt64 CompressedSize { get; private set; }
        /// <summary>
        /// <para>Смещение локального заголовка файла</para>
        /// </summary>
        public UInt64 RelativeHeaderOffset { get; private set; }
        /// <summary>
        /// <para>Номер диска, на котором начинаются данные файла</para>
        /// </summary>
        public UInt32 StartDiskNumber { get; private set; }
    }
}
