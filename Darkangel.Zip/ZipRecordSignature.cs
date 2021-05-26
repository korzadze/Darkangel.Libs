using Darkangel.IntegerX;
using System;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Подпись записи ZIP-архива</para>
    /// </summary>
    public sealed class ZipRecordSignature : ZipRecord
    {
        private UInt32 _Signature = 0;
        /// <inheritdoc/>
        public override UInt32 Id => _Signature;
        /// <inheritdoc/>
        public override long DataSize => 4;
        /// <inheritdoc/>
        public override void Load(ZipFile file)
        {
            base.Load(file);
            _Signature = file.Stream.LoadUInt32(isLittleEndian: true);
        }
    }
}
