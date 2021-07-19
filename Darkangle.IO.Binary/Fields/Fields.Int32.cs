using Darkangel.IntegerX;
using System.IO;
using System.Threading.Tasks;

namespace Darkangel.IO
{
    public static partial class Fields
    {
        /// <summary>
        /// <para>Поле типа <see cref="System.Int32"/></para>
        /// </summary>
        public class Int32 : BinaryField<System.Int32>
        {
            private const int Size = 4;
            /// <inheritdoc/>
            public override long GetSize(IBinaryContext context)
            {
                return Size;
            }
            /// <inheritdoc/>
            public override async Task LoadAsync(IBinaryContext context, Stream stream)
            {
                Value = await stream.LoadInt32Async(context.IsLittleEndian);
            }
            /// <inheritdoc/>
            public override async Task StoreAsync(IBinaryContext context, Stream stream)
            {
                await stream.StoreAsync(Value, context.IsLittleEndian);
            }
        }
    }
}
