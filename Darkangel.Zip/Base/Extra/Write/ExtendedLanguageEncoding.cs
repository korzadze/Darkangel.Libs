using System;
using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Extended language encoding data</para>
    /// </summary>
    public class ExtendedLanguageEncoding : ZipExtraField
    {
        /// <inheritdoc/>
        public override int Id => 0x0008;
        /// <inheritdoc/>
        public override int DataSize => throw new NotImplementedException();
        /// <inheritdoc/>
        public override void Load(Stream stream, int size)
        {
            throw new NotImplementedException();
        }
    }

}
