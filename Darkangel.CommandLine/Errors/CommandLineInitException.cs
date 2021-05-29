using System;
using System.Runtime.Serialization;

namespace Darkangel.CommandLine
{
    /// <summary>
    /// <para>Ошибка инициализации списка опций</para>
    /// </summary>
    public class CommandLineInitException : CommandLineException
    {
        /// <inheritdoc/>
        public CommandLineInitException() { }
        /// <inheritdoc/>
        public CommandLineInitException(string message) : base(message) { }
        /// <inheritdoc/>
        public CommandLineInitException(string message, Exception innerException) : base(message, innerException) { }
        /// <inheritdoc/>
        protected CommandLineInitException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
