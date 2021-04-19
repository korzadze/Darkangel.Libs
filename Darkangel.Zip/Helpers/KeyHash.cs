using Darkangel.IO;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Хеш ключа</para>
    /// </summary>
    public class KeyHash
    {
        private readonly byte[] _Data;
        internal int DataSize => _Data?.Length ?? 0;
        internal KeyHash(Stream stream, int hsize)
        {
            _Data = stream.ReadBytes(hsize);
        }
        /// <summary>
        /// <para>Прочитать хеш ключа</para>
        /// </summary>
        /// <returns>Хеш ключа</returns>
        public byte[] GetKey() => (byte[])_Data.Clone();
    }
}
