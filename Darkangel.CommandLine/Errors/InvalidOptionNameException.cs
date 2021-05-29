using System;
using System.Runtime.Serialization;

namespace Darkangel.CommandLine
{
    /// <summary>
    /// <para>Недопустимое имя опции</para>
    /// </summary>
    public class InvalidOptionNameException : CommandLineInitException
    {
        /// <inheritdoc/>
        public InvalidOptionNameException() { }
        /// <inheritdoc/>
        public InvalidOptionNameException(string message) : base(message) { }
        /// <inheritdoc/>
        public InvalidOptionNameException(string message, Exception innerException) : base(message, innerException) { }
        /// <inheritdoc/>
        protected InvalidOptionNameException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
