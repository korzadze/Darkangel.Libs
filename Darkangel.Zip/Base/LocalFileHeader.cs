using Darkangel.IntegerX;
using Darkangel.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Локальный заголовок файла</para>
    /// </summary>
    public class LocalFileHeader : ZipRecord
    {
        private static readonly UInt32 SignatureValue = 0x04034b50;
        /// <inheritdoc/>
        public override long Id => SignatureValue;
        /// <summary>
        /// <para>Минимальная версия API, необходимая для распаковки данных</para>
        /// </summary>
        public int VersionNeededToExtract { get; protected set; }
        /// <summary>
        /// <para>Флаги общего назначения</para>
        /// </summary>
        public GeneralPurposeBitFlags GeneralPurposeBitFlag { get; protected set; }
        /// <summary>
        /// <para>Метод упаковки</para>
        /// </summary>
        public CompressionMethod CompressionMethod { get; protected set; }
        /// <summary>s
        /// <para>Дата и время последнего изменения файла</para>
        /// </summary>
        public System.DateTime LastModFile { get; protected set; }
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
        /// <summary>
        /// <para>Имя файла</para>
        /// </summary>
        public string FileName { get; protected set; }
        /// <summary>
        /// <para>Дополнительная информация о файле</para>
        /// </summary>
        public ZipExtraFieldCollection ExtraFields { get; private set; } = new();
        #region Фикисрованная часть
        //private UInt16 _VersionNeededToExtract;
        //private UInt16 _GeneralPurposeBitFlag;
        //private UInt16 _CompressionMethod;
        //private UInt16 _LastModFileTime;
        //private UInt16 _LastModFileDate;
        //private UInt32 _Сrc32;
        //private UInt32 _CompressedSize;
        //private UInt32 _UncompressedSize;
        //private UInt16 _FileNameLength;
        //private UInt16 _ExtraFieldLength;
        #endregion Фикисрованная часть
        #region Переменная часть
        //private byte[] _FileName = new byte[_FileNameLength];
        //private byte[] _ExtraFields = new byte[_ExtraFieldLength];
        //private byte[] _CompressedData = new byte[_CompressedSize];
        #endregion Переменная часть
        /// <inheritdoc/>
        public override void Load(ZipFile file)
        {
            base.Load(file);
            #region Фикисрованная часть
            VersionNeededToExtract = file.Stream.ReadUInt16();
            var _GeneralPurposeBitFlag = file.Stream.ReadUInt16();
            CompressionMethod = (CompressionMethod)file.Stream.ReadUInt16();
            GeneralPurposeBitFlag = new(_GeneralPurposeBitFlag, CompressionMethod);
            var _LastModFileTime = file.Stream.ReadUInt16();
            var _LastModFileDate = file.Stream.ReadUInt16();
            LastModFile = Darkangel.DateTime.MsDos.ToDateTime(_LastModFileDate, _LastModFileTime);
            Сrc32 = file.Stream.ReadUInt32();
            CompressedSize = file.Stream.ReadUInt32();
            UncompressedSize = file.Stream.ReadUInt32();
            var _FileNameLength = file.Stream.ReadUInt16();
            var _ExtraFieldLength = file.Stream.ReadUInt16();
            #endregion Фикисрованная часть
            #region Переменная часть
            var nameBuf = file.Stream.ReadBytes(_FileNameLength);
            if (GeneralPurposeBitFlag.IsUTF8Encoding)
            {
                FileName = ZipRecord.GetString(nameBuf, encoding: Encoding.UTF8);
            }
            else
            {
                FileName = ZipRecord.GetString(nameBuf, encoding: Encoding.ASCII);
            }
            ExtraFields.Load(file, _ExtraFieldLength);
            #endregion Переменная часть
        }
    }
}
