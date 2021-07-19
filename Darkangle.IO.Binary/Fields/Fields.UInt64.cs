using Darkangel.IntegerX;
using System.IO;
using System.Threading.Tasks;

namespace Darkangel.IO
{
    public static partial class Fields
    {
        /// <summary>
        /// <para>Поле типа <see cref="System.UInt64"/></para>
        /// </summary>
        public class UInt64 : BinaryField<System.UInt64>
        {
            private const int Size = 8;
            /// <inheritdoc/>
            public override long GetSize(IBinaryContext context)
            {
                return Size;
            }
            /// <inheritdoc/>
            public override async Task LoadAsync(IBinaryContext context, Stream stream)
            {
                Value = await stream.LoadUInt64Async(context.IsLittleEndian);
            }
            /// <inheritdoc/>
            public override async Task StoreAsync(IBinaryContext context, Stream stream)
            {
                await stream.StoreAsync(Value, context.IsLittleEndian);
            }
        }
    }
}
