using System;
using System.Runtime.Serialization;

namespace Darkangel.CommandLine
{
    /// <summary>
    /// <para>Несоответствие <see cref="Option.Mode"/> и наличия/отсутствия значения</para>
    /// </summary>
    public class OptionValueException : CommandlineParseException
    {
        /// <inheritdoc/>
        public OptionValueException() { }
        /// <inheritdoc/>
        public OptionValueException(string message) : base(message) { }
        /// <inheritdoc/>
        public OptionValueException(string message, Exception innerException) : base(message, innerException) { }
        /// <inheritdoc/>
        protected OptionValueException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
