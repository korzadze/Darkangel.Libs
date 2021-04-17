using System;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>ZIP Compression method</para>
    /// </summary>
    public enum CompressionMethod
    {
        /// <summary>
        /// <para>The file is stored (no compression)</para>
        /// </summary>
        NoCompression = 0,
        /// <summary>
        /// <para>The file is Shrunk</para>
        /// </summary>
        [Obsolete("Legacy algorithms and are no longer recommended for use when compressing files")]
        Shrunk = 1,
        /// <summary>
        /// <para>The file is Reduced with compression factor 1</para>
        /// </summary>
        [Obsolete("Legacy algorithms and are no longer recommended for use when compressing files")]
        Reduce1 = 2,
        /// <summary>
        /// <para>The file is Reduced with compression factor 2</para>
        /// </summary>
        [Obsolete("Legacy algorithms and are no longer recommended for use when compressing files")]
        Reduce2 = 3,
        /// <summary>
        /// <para>The file is Reduced with compression factor 3</para>
        /// </summary>
        [Obsolete("Legacy algorithms and are no longer recommended for use when compressing files")]
        Reduce3 = 4,
        /// <summary>
        /// <para>The file is Reduced with compression factor 4</para>
        /// </summary>
        [Obsolete("Legacy algorithms and are no longer recommended for use when compressing files")]
        Reduce4 = 5,
        /// <summary>
        /// <para>The file is Imploded</para>
        /// </summary>
        [Obsolete("Legacy algorithms and are no longer recommended for use when compressing files")]
        Implode = 6,
        /// <summary>
        /// <para>Reserved for Tokenizing compression algorithm</para>
        /// </summary>
        Tokenize = 7,
        /// <summary>
        /// <para>The file is Deflated</para>
        /// </summary>
        Deflate = 8,
        /// <summary>
        /// <para>Enhanced Deflating using Deflate64(tm)</para>
        /// </summary>
        Deflate64 = 9,
        /// <summary>
        /// <para>PKWARE Data Compression Library Imploding (old IBM TERSE)</para>
        /// </summary>
        OldIBMTerse = 10,
        /// <summary>
        /// <para>File is compressed using BZIP2 algorithm</para>
        /// </summary>
        BZip2 = 12,
        /// <summary>
        /// <para>LZMA</para>
        /// </summary>
        LZMA = 14,
        /// <summary>
        /// <para>IBM z/OS CMPSC Compression</para>
        /// </summary>
        IBMCMPSCCompression = 16,
        /// <summary>
        /// <para>File is compressed using IBM TERSE (new)</para>
        /// </summary>
        IBMTerse = 18,
        /// <summary>
        /// <para>IBM LZ77 z Architecture (PFS)</para>
        /// </summary>
        IBM_LZ77 = 19,
        /// <summary>
        /// <para>JPEG variant</para>
        /// </summary>
        JpegVariant = 96,
        /// <summary>
        /// <para>WavPack compressed data</para>
        /// </summary>
        WavPack = 97,
        /// <summary>
        /// <para>PPMd version I, Rev 1</para>
        /// </summary>
        PPMd_v1r1 = 98,
        /// <summary>
        /// <para>AE-x encryption marker (see APPENDIX E)</para>
        /// </summary>
        AEx = 99
    }
}
