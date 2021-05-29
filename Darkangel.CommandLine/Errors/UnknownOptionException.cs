using System;
using System.Runtime.Serialization;

namespace Darkangel.CommandLine
{
    /// <summary>
    /// <para>Неизвестная опция</para>
    /// </summary>
    public class UnknownOptionException : CommandlineParseException
    {
        /// <inheritdoc/>
        public UnknownOptionException() { }
        /// <inheritdoc/>
        public UnknownOptionException(string message) : base(message) { }
        /// <inheritdoc/>
        public UnknownOptionException(string message, Exception innerException) : base(message, innerException) { }
        /// <inheritdoc/>
        protected UnknownOptionException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
