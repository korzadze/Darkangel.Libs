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
    /// <para>Подпись записи ZIP-архива</para>
    /// </summary>
    public sealed class ZipRecordSignature : ZipRecord
    {
        private UInt32 _Signature = 0;
        /// <inheritdoc/>
        public override long Id => _Signature;
        /// <inheritdoc/>
        public override void Load(Stream stream)
        {
            base.Load(stream);
            _Signature = stream.ReadUInt32(isLittleEndian: true);
        }
    }
}
