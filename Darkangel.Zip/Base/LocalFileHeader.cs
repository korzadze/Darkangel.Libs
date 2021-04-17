using Darkangel.IntegerX;
using System;
using System.Collections.Generic;
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
        #region Фикисрованная часть
        private UInt16 _VersionNeededToExtract;
        private UInt16 _GeneralPurposeBitFlag;
        private UInt16 _CompressionMethod;
        private UInt16 _LastModFileTime;
        private UInt16 _LastModFileDate;
        private UInt32 _Сrc32;
        private UInt32 _CompressedSize;
        private UInt32 _UncompressedSize;
        private UInt16 _FileNameLength;
        private UInt16 ExtraFieldLength;
        #endregion Фикисрованная часть
        #region Переменная часть
        //private byte[] _FileName;
        private ZipExtraFieldCollection _ExtraFields = new ZipExtraFieldCollection();
        #endregion Переменная часть

    }
}
