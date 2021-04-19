using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Флаги общего назначения</para>
    /// </summary>
    public class GeneralPurposeBitFlags
    {
#pragma warning disable IDE0051 // Удалите неиспользуемые закрытые члены
        private const int Bit0 = 1 << 0;
        private const int Bit1 = 1 << 1;
        private const int Bit2 = 1 << 2;
        private const int Bit3 = 1 << 3;
        private const int Bit4 = 1 << 4;
        private const int Bit5 = 1 << 5;
        private const int Bit6 = 1 << 6;
        private const int Bit7 = 1 << 7;
        private const int Bit8 = 1 << 8;
        private const int Bit9 = 1 << 9;
        private const int Bit10 = 1 << 10;
        private const int Bit11 = 1 << 11;
        private const int Bit12 = 1 << 12;
        private const int Bit13 = 1 << 13;
        private const int Bit14 = 1 << 14;
        private const int Bit15 = 1 << 15;
#pragma warning restore IDE0051 // Удалите неиспользуемые закрытые члены

        private readonly CompressionMethod _Method;
        private readonly UInt16 _FLags;
        /// <summary>
        /// <para>Raw value</para>
        /// </summary>
        public int FLags => _FLags;
        /// <summary>
        /// <para>Создать экземпляр класса</para>
        /// </summary>
        /// <param name="flags">Флаги</param>
        /// <param name="method">Используемый метод сжатия</param>
        public GeneralPurposeBitFlags(UInt16 flags, CompressionMethod method)
        {
            _Method = method;
            _FLags = flags;
        }
        /// <summary>
        /// <para>File is encrypted.</para>
        /// </summary>
        public bool IsEncrypted =>
            (_FLags & Bit0) != 0;

#pragma warning disable CS0618 // Тип или член устарел
        /// <summary>
        /// <para>[Implode]</para>
        /// <para>if set, indicates an 8K sliding dictionary was used.</para>
        /// <para>If clear, then a 4K sliding dictionary was used.</para>
        /// </summary>
        public bool Is8KSlidingDictionaryUsed =>
            (_Method == CompressionMethod.Implode) &&
            (_FLags & Bit1) != 0;
        /// <summary>
        /// <para>[Implode]</para>
        /// <para>If set, indicates 3 Shannon-Fano trees were used to encode the sliding dictionary output.</para>
        /// <para>If clear, then 2 Shannon-Fano trees were used.</para>
        /// </summary>
        public bool IsShannonFano3Used =>
            (_Method == CompressionMethod.Implode) &&
            (_FLags & Bit2) != 0;
#pragma warning restore CS0618 // Тип или член устарел

        /// <summary>
        /// <para>Deflating compression option</para>
        /// </summary>
        public DeflatingOption DeflatingOption =>
            ((_Method == CompressionMethod.Deflate) || (_Method == CompressionMethod.Deflate64)) ?
            ((DeflatingOption)(_FLags & (Bit1 | Bit2))) :
            (DeflatingOption.Unknown);
        /// <summary>
        /// <para>[LZMA]</para>
        /// <para>If set, indicates an end-of-stream (EOS) marker is used to mark the end of the compressed data stream.</para>
        /// <para>If clear, then an EOS marker is not present and the compressed data size must be known to extract.</para>
        /// </summary>
        public bool IsEosMarkerUsed =>
            (_Method == CompressionMethod.LZMA) &&
            (_FLags & Bit1) != 0;
        /// <summary>
        /// <para>If set, the fields crc-32, compressed size and uncompressed size are set to zero in the local header.</para><para>The correct values are put in the data descriptor immediately following the compressed data.</para><para>(Note: PKZIP version 2.04g for DOS only recognizes this bit for method 8(<see cref="CompressionMethod.Deflate"/>) compression, newer versions of PKZIP recognize this bit for any compression method.)</para>
        /// </summary>
        public bool IsCorrectValuesAtDataDescriptor =>
            (_FLags & Bit3) != 0;
        /// <summary>
        /// <para>If set, this indicates that the file is compressed patched data.</para>
        /// <para>(Note: Requires PKZIP version 2.70 or greater)</para>
        /// </summary>
        public bool IsCompressedPatch =>
            (_FLags & Bit5) != 0;
        /// <summary>
        /// <para>If set, you MUST set the version needed to extract value to at least
        /// 50 and you MUST also set bit 0.</para><para>If AES encryption 
        /// is used, the version needed to extract value MUST
        /// be at least 51.</para><para>See the section describing the Strong
        /// Encryption Specification for details.Refer to the
        /// section in this document entitled "Incorporating PKWARE 
        /// Proprietary Technology into Your Product" for more 
        /// information.</para>
        /// </summary>
        public bool IsStrongEncryption =>
            (_FLags & Bit6) != 0;
        /// <summary>
        /// <para>Language encoding (EFS).</para>
        /// <para>If set, the filename and comment fields for this file MUST be encoded using UTF-8. (see APPENDIX D)</para>
        /// </summary>
        public bool IsUTF8Encoding =>
            (_FLags & Bit11) != 0;
        /// <summary>
        /// <para>Indicate selected data values in the Local Header are masked to hide their actual values.</para>
        /// <para>See the section describing the Strong Encryption Specification for details.</para>
        /// <para>Refer to the section entitled "Incorporating PKWARE Proprietary Technology into Your Product" for more information.</para>
        /// </summary>
        public bool IsCDREncrypted =>
            (_FLags & Bit13) != 0;
    }
}
