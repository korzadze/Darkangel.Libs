using Darkangel.IntegerX;
using Darkangel.IO;
using Darkangel.DateTimeX;
using System;
using System.Text;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Локальный заголовок файла</para>
    /// </summary>
    public class LocalFileHeader : ZipRecord
    {
        /// <inheritdoc/>
        public override long DataSize => throw new NotImplementedException();

        private static readonly UInt32 SignatureValue = 0x04034b50;
        /// <inheritdoc/>
        public override UInt32 Id => SignatureValue;
        #region Фикисрованная часть
        /// <summary>
        /// <para>Минимальная версия API, необходимая для распаковки данных</para>
        /// </summary>
        public UInt16 VersionNeededToExtract { get; protected set; }
        /// <summary>
        /// <para>Флаги общего назначения</para>
        /// </summary>
        public UInt16 GeneralPurposeBitFlags { get; protected set; }
        /// <summary>
        /// <para>Метод упаковки</para>
        /// </summary>
        public CompressionMethod CompressionMethod { get; protected set; }
        /// <summary>
        /// <para>Время последнего изменения файла (см. <seealso cref="Darkangel.DateTimeX.MsDos.ToDateTime"/>)</para>
        /// </summary>
        public UInt16 LastModFileTime { get; private set; }
        /// <summary>
        /// <para>Дата последнего изменения файла (см. <seealso cref="Darkangel.DateTimeX.MsDos.ToDateTime"/>)</para>
        /// </summary>
        public UInt16 LastModFileDate { get; private set; }
        /// <summary>
        /// <para>Контрольная сумма</para>
        /// </summary>
        public long Сrc32 { get; protected set; }
        /// <summary>
        /// <para>Размер упакованных данных</para>
        /// </summary>
        public long CompressedSize { get; protected set; }
        /// <summary>
        /// <para>Размер распакованных данных</para>
        /// </summary>
        public long UncompressedSize { get; protected set; }
        #endregion Фикисрованная часть
        #region Переменная часть
        /// <summary>
        /// <para>Имя файла</para>
        /// </summary>
        public string FileName { get; protected set; }
        /// <summary>
        /// <para>Дополнительная информация о файле</para>
        /// </summary>
        public ZipExtraFieldCollection ExtraFields { get; private set; } = new();
        #endregion Переменная часть
        /// <inheritdoc/>
        public override void Load(ZipFile file)
        {
            base.Load(file);
            #region Фикисрованная часть
            VersionNeededToExtract = file.Stream.LoadUInt16(isLittleEndian: true);
            GeneralPurposeBitFlags = file.Stream.LoadUInt16(isLittleEndian: true);
            CompressionMethod = (CompressionMethod)file.Stream.LoadUInt16(isLittleEndian: true);
            LastModFileTime = file.Stream.LoadUInt16(isLittleEndian: true);
            LastModFileDate = file.Stream.LoadUInt16(isLittleEndian: true);
            Сrc32 = file.Stream.LoadUInt32(isLittleEndian: true);
            CompressedSize = file.Stream.LoadUInt32(isLittleEndian: true);
            UncompressedSize = file.Stream.LoadUInt32(isLittleEndian: true);
            var _FileNameLength = file.Stream.LoadUInt16(isLittleEndian: true);
            var _ExtraFieldLength = file.Stream.LoadUInt16(isLittleEndian: true);
            #endregion Фикисрованная часть
            #region Переменная часть
            var nameBuf = file.Stream.ReadBytes(_FileNameLength);
            var f = new GeneralPurposeBitFlags(GeneralPurposeBitFlags, CompressionMethod);
            var e = (f.IsUTF8Encoding) ? (Encoding.UTF8) : (Encoding.ASCII);
            FileName = GetString(nameBuf, encoding: e);
            ExtraFields.Load(file, _ExtraFieldLength);
            #endregion Переменная часть
        }
        /// <summary>
        /// <para>Распаковать данные в файл</para>
        /// </summary>
        /// <param name="fileName">Имя целевого файла</param>
        public void ExtractTo(string fileName)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// <para>Распаковать данные в поток</para>
        /// </summary>
        /// <param name="outStream">Целевой поток</param>
        public void ExtractTo(Stream outStream)
        {
            throw new NotImplementedException();
        }
    }
}
