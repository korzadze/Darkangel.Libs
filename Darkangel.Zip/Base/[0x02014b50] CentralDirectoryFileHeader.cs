using Darkangel.IntegerX;
using Darkangel.IO;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Заголовок файла в центральной директории</para>
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
        #region Фикисрованная часть
        /// <summary>
        /// <para>Где упакован файл (see <see cref="Zip.VersionMadeBy"/>)</para>
        /// </summary>
        public UInt16 VersionMadeBy { get; private set; }
        /// <summary>
        /// <para>Минимальная версия API, неободимая для распаковки файла (see <see cref="Zip.VersionNeededToExtract"/>)</para>
        /// </summary>
        public UInt16 VersionNeededToExtract { get; private set; }
        /// <summary>
        /// <para>Флаги общего назначения (see <see cref="Zip.GeneralPurposeBitFlags"/>)</para>
        /// </summary>
        public UInt16 GeneralPurposeBitFlags { get; private set; }
        /// <summary>
        /// <para>Способ сжатия данных</para>
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
        /// <para>Номер диска, с которого начинается файл.</para>
        /// </summary>
        /// <remarks>
        /// <para>Если архив находится в формате ZIP64 и значение в этом поле
        /// равно 0xFFFF, размер хранится в соответствующем 4-байтовом дополнительном
        /// поле расширенной информации ZIP64. (see <see cref="Zip64ExtendedInformation"/>)</para>
        /// </remarks>
        public UInt16 StartDiskNumber { get; private set; }
        /// <summary>
        /// <para>Internal file attributes</para>
        /// </summary>
        /// <remarks>
        /// <para>Биты 1 и 2 зарезервированы PKWARE.</para>
        /// <para>Самый младший бит (0x0001) поля указывает, что файл явно является
        /// текстовым файлом. Если бит не установлен, то файл явно содержит двоичные
        /// данные. Остальные биты в версии 1.0 не используются.</para>
        /// <para>Второй бит (0x0002) поля указывает, что каждой логической записи
        /// предшествует 4-байтовое поле, указывающее размер записи. Поле размера
        /// записи хранится в формате little-endian. Этот флаг не зависит от текстовых
        /// управляющих символов и, если используется вместе с текстовыми данными,
        /// включает любые управляющие символы в общий размер записи. Это значение
        /// предоставляется для поддержки передачи данных мэйнфрейма.</para>
        /// </remarks>
        public UInt16 InternalFileAttributes { get; private set; }
        /// <summary>
        /// <para>Внешние атрибуты файла</para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Отображение внешних атрибутов зависит от хост-системы
        /// (см. <see cref="Zip.VersionMadeBy"/>). Для MS-DOS младший байт -
        /// это байт атрибута каталога MS-DOS. Если данные поступили из стандартного
        /// ввода, это поле обнуляется.
        /// </para>
        /// </remarks>
        public UInt32 ExternalFileAttributes { get; private set; }
        /// <summary>
        /// <para>Смещение <see cref="LocalFileHeader"/> относительно </para>
        /// </summary>
        public UInt32 RelativeOffsetOfLocalHeader { get; private set; }
        /// <summary>
        /// <para>Имя файла</para>
        /// </summary>
        #endregion Фикисрованная часть
        #region Переменная часть
        public string FileName { get; private set; }
        /// <summary>
        /// <para>Дополнительные данные о записи</para>
        /// </summary>
        public ZipExtraFieldCollection ExtraFields { get; private set; } = new();
        /// <summary>
        /// <para>Коментарий к файлу</para>
        /// </summary>
        public string FileComment { get; private set; }
        #endregion Переменная часть
        /// <inheritdoc/>
        public override void Load(ZipFile file)
        {
            base.Load(file);
            #region Фикисрованная часть
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
            #endregion Фикисрованная часть
            #region Переменная часть
            var f = new GeneralPurposeBitFlags(GeneralPurposeBitFlags, CompressionMethod);
            var e = (f.IsUTF8Encoding) ? (Encoding.UTF8) : (Encoding.ASCII);
            FileName = GetString(file.Stream.ReadBytes(_FileNameLength), encoding: e);
            ExtraFields.Load(file, _ExtraFieldLength);
            FileComment = GetString(file.Stream.ReadBytes(_FileCommentLength), encoding: e);
            #endregion Переменная часть
        }
        /// <summary>
        /// <para>Распаковать данные в файл</para>
        /// </summary>
        /// <param name="fileName">Имя целевого файла</param>
        public void ExtractTo(string fileName)
        {
            using FileStream outStream = File.OpenWrite(fileName);
            ExtractTo(outStream);
        }
        /// <summary>
        /// <para>Распаковать данные в поток</para>
        /// </summary>
        /// <param name="outStream">Целевой поток</param>
        public void ExtractTo(Stream outStream)
        {
            LocalFileHeader lfh = GetFile();
            if (lfh != null)
            {

            }
            throw new NotImplementedException();
        }
        /// <summary>
        /// <para>Найти локальную запись файла для записи центрального каталога</para>
        /// </summary>
        /// <returns></returns>
        public LocalFileHeader GetFile()
        {
            if (Owner.Stream == null)
            {
                return null;
            }

            throw new NotImplementedException();
        }
    }
}
