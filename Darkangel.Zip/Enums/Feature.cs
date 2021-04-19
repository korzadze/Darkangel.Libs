namespace Darkangel.Zip
{
    /// <summary>
    /// <para>ZIP archive features</para>
    /// </summary>
    public enum Feature
    {
        /// <summary>
        /// <para>Default value</para>
        /// </summary>
        Default,
        /// <summary>
        /// <para>File is a volume label</para>
        /// </summary>
        FileIsAVolumeLabel,
        /// <summary>
        /// <para>File is a folder (directory)</para>
        /// </summary>
        FileIsAFolder,
        /// <summary>
        /// <para>File is compressed using Deflate compression</para>
        /// </summary>
        CompressionDeflate,
        /// <summary>
        /// <para>File is encrypted using traditional PKWARE encryption</para>
        /// </summary>
        TraditionalEncryption,
        /// <summary>
        /// <para>File is compressed using Deflate64(tm)</para>
        /// </summary>
        CompressionDeflate64,
        /// <summary>
        /// <para>File is compressed using PKWARE DCL Implode</para>
        /// </summary>
        CompressionDCLImplode,
        /// <summary>
        /// <para>File is a patch data set</para>
        /// </summary>
        UsePatchDataSet,
        /// <summary>
        /// <para>File uses ZIP64 format extensions</para>
        /// </summary>
        ZIP64FormatExtensions,
        /// <summary>
        /// <para>File is compressed using BZIP2 compression</para>
        /// </summary>
        /// <remarks>
        /// <para>Early 7.x (pre-7.2) versions of PKZIP incorrectly set the version needed to extract for BZIP2 compression to be 5.0 when it SHOULD have been 4.6.</para>
        /// </remarks>
        CompressionBZIP2,
        /// <summary>
        /// <para>File is encrypted using DES</para>
        /// </summary>
        EncryptionDES,
        /// <summary>
        /// <para>File is encrypted using 3DES</para>
        /// </summary>
        Encryption3DES,
        /// <summary>
        /// <para>File is encrypted using original RC2 encryption</para>
        /// </summary>
        EncryptionOriginalRC2,
        /// <summary>
        /// <para>File is encrypted using RC4 encryption</para>
        /// </summary>
        EncryptionRC4,
        /// <summary>
        /// <para>File is encrypted using AES encryption</para>
        /// </summary>
        EncryptionAES,
        /// <summary>
        /// <para>File is encrypted using corrected RC2 encryption</para>
        /// </summary>
        /// <remarks>
        /// <para>Refer to the section on Strong Encryption Specification for additional information regarding RC2 corrections.</para>
        /// </remarks>
        EncryptionCorrectedRC2,
        /// <summary>
        /// <para>File is encrypted using corrected RC2-64 encryption</para>
        /// </summary>
        /// <remarks>
        /// <para>Refer to the section on Strong Encryption Specification for additional information regarding RC2 corrections.</para>
        /// </remarks>
        EncryptionCorrectedRC2_64,
        /// <summary>
        /// <para>File is encrypted using non-OAEP key wrapping</para>
        /// </summary>
        /// <remarks>
        /// <para>Certificate encryption using non-OAEP key wrapping is the intended
        /// mode of operation for all versions beginning with 6.1. Support for OAEP
        /// key wrapping MUST only be used for backward compatibility when sending
        /// ZIP files to be opened by versions of PKZIP older than 6.1 (5.0 or 6.0).</para>
        /// </remarks>
        EncryptionNonOAEPKeyWrapping,
        /// <summary>
        /// <para>Central directory encryption</para>
        /// </summary>
        CentralDirectoryEncryption,
        /// <summary>
        /// <para>File is compressed using LZMA</para>
        /// </summary>
        CompressionLZMA,
        /// <summary>
        /// <para>File is compressed using PPMd+</para>
        /// </summary>
        CompressionPPMd,
        /// <summary>
        /// <para>File is encrypted using Blowfish</para>
        /// </summary>
        EncryptionBlowfish,
        /// <summary>
        /// <para>File is encrypted using Twofish</para>
        /// </summary>
        EncryptionTwofish,
    }
}
