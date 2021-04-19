using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Список публичных ключей</para>
    /// </summary>
    public class PublicKeyHashList: IEnumerable<KeyHash>
    {
        internal PublicKeyHashList() { }
        internal long DataSize => Count * HSize;
        /*{
            get
            {
                var size = 0;
                foreach(var key in _Data)
                {
                    size += key.DataSize;
                }
                return size;
            }
        }*/
        private KeyHash[] _Data = null;
        /// <summary>
        /// <para>Количество элементов в списке</para>
        /// </summary>
        public long Count => _Data?.LongLength ?? 0;
        private int HSize = 0;
        internal void Load(Stream stream, long rcount, int hsize)
        {
            HSize = hsize;
            _Data = new KeyHash[rcount];
            for (var i = 0L; i < rcount; i++)
            {
                _Data[i] = new KeyHash(stream, HSize);
            }
        }
        /// <inheritdoc/>
        public IEnumerator<KeyHash> GetEnumerator() =>
            ((IEnumerable<KeyHash>)_Data).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() =>
            ((IEnumerable)_Data).GetEnumerator();
    }
}
