using Darkangel.IntegerX;
using System.IO;
using System.Threading.Tasks;

namespace Darkangel.IO
{
    public static partial class Fields
    {
        /// <summary>
        /// <para>Поле типа <see cref="System.Int16"/></para>
        /// </summary>
        public class Int16 : BinaryField<System.Int16>
        {
            private const int Size = 2;
            /// <inheritdoc/>
            public override long GetSize(IBinaryContext context)
            {
                return Size;
            }
            /// <inheritdoc/>
            public override async Task LoadAsync(IBinaryContext context, Stream stream)
            {
                Value = await stream.LoadInt16Async(context.IsLittleEndian);
            }
            /// <inheritdoc/>
            public override async Task StoreAsync(IBinaryContext context, Stream stream)
            {
                await stream.StoreAsync(Value, context.IsLittleEndian);
            }
        }
    }
}
