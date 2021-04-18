using System;
using System.Runtime.Serialization;

namespace Darkangel
{
    /// <summary>
    /// <para>Ошибка обработки аргументов командной строки</para>
    /// </summary>
    public class CommandlineParseException : CommandLineException
    {
        /// <inheritdoc/>
        public CommandlineParseException() { }
        /// <inheritdoc/>
        public CommandlineParseException(string message) : base(message) { }
        /// <inheritdoc/>
        public CommandlineParseException(string message, Exception innerException) : base(message, innerException) { }
        /// <inheritdoc/>
        protected CommandlineParseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
