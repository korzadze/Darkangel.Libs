using Darkangel.IntegerX;
using Darkangel.IO;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Central directory file header</para>
    /// </summary>
    public class CentralDirectoryFileHeader : ZipRecord
    {
        /// <inheritdoc/>
        public override long DataSize => FixedPartSize + VariablePartSize;
        private const long FixedPartSize = 42;
        private long VariablePartSize =>
            _FileNameLength + _ExtraFieldLength + _FileCommentLength;
        /// <inheritdoc/>
        public override UInt32 Id => 0x02014b50;
        /// <summary>
        /// <para>Version made by (see <see cref="Zip.VersionMadeBy"/>)</para>
        /// </summary>
        public UInt16 VersionMadeBy { get; private set; }
        /// <summary>
        /// <para>Minimal version needed to extract file (see <see cref="Zip.VersionNeededToExtract"/>)</para>
        /// </summary>
        public UInt16 VersionNeededToExtract { get; private set; }
        /// <summary>
        /// <para>General purpose bit flag (see <see cref="Zip.GeneralPurposeBitFlags"/>)</para>
        /// </summary>
        public UInt16 GeneralPurposeBitFlags { get; private set; }
        /// <summary>
        /// <para>Compression method</para>
        /// </summary>
        public CompressionMethod CompressionMethod { get; private set; }
        /// <summary>
        /// <para>Время последнего изменения файла (см. <seealso cref="Darkangel.DateTimeX.MsDos.ToDateTime"/>)</para>
        /// </summary>
        public UInt16 LastFileModTime { get; private set; }
        /// <summary>
        /// <para>Дата последнего изменения файла (см. <seealso cref="Darkangel.DateTimeX.MsDos.ToDateTime"/>)</para>
        /// </summary>
        public UInt16 LastFileModDate { get; private set; }
        /// <summary>
        /// <para>Контрольная сумма</para>
        /// </summary>
        public UInt32 Crc32;
        /// <summary>
        /// <para>Размер сжатых данных</para>
        /// </summary>
        public UInt32 CompressedSize { get; private set; }
        /// <summary>
        /// <para>Исходный размер данных</para>
        /// </summary>
        public UInt32 UncompressedSize { get; private set; }
        private UInt16 _FileNameLength;
        private UInt16 _ExtraFieldLength;
        private UInt16 _FileCommentLength;
        /// <summary>
        /// <para>The number of the disk on which this file begins.</para>
        /// </summary>
        /// <remarks>
        /// <para>If an archive is in ZIP64 format and the value in this field is 0xFFFF, the size will be in the corresponding 4 byte zip64 extended information extra field. (see <see cref="Zip64ExtendedInformation"/>)</para>
        /// </remarks>
        public UInt16 StartDiskNumber { get; private set; }
        public UInt16 InternalFileAttributes { get; private set; }
        public UInt32 ExternalFileAttributes { get; private set; }
        /// <summary>
        /// <para>Смещение <see cref="LocalFileHeader"/> относительно </para>
        /// </summary>
        public UInt32 RelativeOffsetOfLocalHeader { get; private set; }
        /// <summary>
        /// <para>Имя файла</para>
        /// </summary>
        public string FileName { get; private set; }
        /// <summary>
        /// <para>Дополнительные данные о записи</para>
        /// </summary>
        public ZipExtraFieldCollection ExtraFields { get; private set; } = new();
        /// <summary>
        /// <para>Коментарий к файлу</para>
        /// </summary>
        public string FileComment { get; private set; }
        /// <inheritdoc/>
        public override void Load(ZipFile file)
        {
            base.Load(file);

            VersionMadeBy = file.Stream.ReadUInt16(isLittleEndian: true);
            VersionNeededToExtract = file.Stream.ReadUInt16(isLittleEndian: true);
            GeneralPurposeBitFlags = file.Stream.ReadUInt16(isLittleEndian: true);
            CompressionMethod = (CompressionMethod)file.Stream.ReadUInt16(isLittleEndian: true);
            LastFileModTime = file.Stream.ReadUInt16(isLittleEndian: true);
            LastFileModDate = file.Stream.ReadUInt16(isLittleEndian: true);
            Crc32 = file.Stream.ReadUInt32(isLittleEndian: true);
            CompressedSize = file.Stream.ReadUInt32(isLittleEndian: true);
            UncompressedSize = file.Stream.ReadUInt32(isLittleEndian: true);
            _FileNameLength = file.Stream.ReadUInt16(isLittleEndian: true);
            _ExtraFieldLength = file.Stream.ReadUInt16(isLittleEndian: true);
            _FileCommentLength = file.Stream.ReadUInt16(isLittleEndian: true);
            StartDiskNumber = file.Stream.ReadUInt16(isLittleEndian: true);
            InternalFileAttributes = file.Stream.ReadUInt16(isLittleEndian: true);
            ExternalFileAttributes = file.Stream.ReadUInt32(isLittleEndian: true);
            RelativeOffsetOfLocalHeader = file.Stream.ReadUInt32(isLittleEndian: true);

            var f = new GeneralPurposeBitFlags(GeneralPurposeBitFlags, CompressionMethod);
            var e = (f.IsUTF8Encoding) ? (Encoding.UTF8) : (Encoding.ASCII);

            FileName = GetString(file.Stream.ReadBytes(_FileNameLength), encoding: e);
            ExtraFields.Load(file, _ExtraFieldLength);
            FileComment = GetString(file.Stream.ReadBytes(_FileCommentLength), encoding: e);
        }
    }
}
