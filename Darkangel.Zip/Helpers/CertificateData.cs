using Darkangel.IntegerX;
using System;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Certificate decryption extra field data</para>
    /// </summary>
    public class CertificateData
    {
        internal CertificateData() { }
        internal long DataSize => 8 + SRList.DataSize;
        /// <summary>
        /// <para>Количество получателей.</para>
        /// </summary>
        public UInt32 RCount { get; private set; } = 0;
        /// <summary>
        /// <para>Хеш алгоритм (см. <see cref="HashAlgorithm"/>)</para>
        /// </summary>
        public UInt16 HashAlg { get; private set; } = 0;
        /// <summary>
        /// <para>Размер хешированного открытого ключа.</para>
        /// </summary>
        public UInt16 HSize { get; private set; } = 0;
        /// <summary>
        /// <para>Список хешированых публичных ключей для каждого предполагаемого получателя.</para>
        /// </summary>
        public PublicKeyHashList SRList { get; private set; } = new();
        internal void Load(Stream stream)
        {
            RCount = stream.ReadUInt32(isLittleEndian: true);
            HashAlg = stream.ReadUInt16(isLittleEndian: true);
            HSize = stream.ReadUInt16(isLittleEndian: true);
            SRList.Load(stream, RCount, HSize);
        }
    }
}
