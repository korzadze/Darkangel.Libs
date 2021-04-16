using System;
using System.IO;

namespace Darkangel.Compression
{
    /// <summary>
    /// <para></para>
    /// </summary>
    public interface ICompressor
    {
        /// <summary>
        /// <para></para>
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] Compress(byte[] data);
        /// <summary>
        /// <para></para>
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public byte[] Decompress(byte[] data);
        /// <summary>
        /// <para></para>
        /// </summary>
        /// <param name="inStream"></param>
        /// <param name="outStream"></param>
        /// <returns></returns>
        public long Compress(Stream inStream, Stream outStream);
        /// <summary>
        /// <para></para>
        /// </summary>
        /// <param name="inStream"></param>
        /// <param name="outStream"></param>
        /// <returns></returns>
        public byte[] Decompress(Stream inStream, Stream outStream);
    }
}
