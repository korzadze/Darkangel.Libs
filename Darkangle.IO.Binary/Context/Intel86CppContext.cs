using System.Text;

namespace Darkangel.IO
{
    /// <summary>
    /// <para>Контекст хранения двоичных данных для C/C++ Intel x86</para>
    /// </summary>
    public class Intel86DefaultContext : IBinaryContext
    {
        /// <inheritdoc/>
        public bool IsLittleEndian => true;
        private class Intel86CppContext_Integer : IInetegerContext { }
        private static readonly IInetegerContext _IntCtx = new Intel86CppContext_Integer();
        /// <inheritdoc/>
        public IInetegerContext Integer => _IntCtx;
        private class Intel86CppContext_Float : IFloatContext
        {
            public FloatStoreFormat StoreFormat => FloatStoreFormat.IEEE754;
        }
        private static readonly IFloatContext _FloatCtx = new Intel86CppContext_Float();
        /// <inheritdoc/>
        public IFloatContext Float => _FloatCtx;
        private class Intel86CppContext_String : IStringContext
        {
            public long PreffixSize => 0;
            public char Terminator => '\0';
            public char PaddingChar => '\0';
            public Encoding Encoding => Encoding.ASCII;
        }
        private readonly IStringContext _StrCtx = new Intel86CppContext_String();
        /// <inheritdoc/>
        public IStringContext String => _StrCtx;
    }
}
