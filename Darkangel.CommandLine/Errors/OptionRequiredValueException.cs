using System;
using System.Runtime.Serialization;

namespace Darkangel
{
    /// <summary>
    /// <para>Опция должна содержать значение</para>
    /// </summary>
    public class OptionRequiredValueException : OptionValueException
    {
        /// <inheritdoc/>
        public OptionRequiredValueException() { }
        /// <inheritdoc/>
        public OptionRequiredValueException(string message) : base(message) { }
        /// <inheritdoc/>
        public OptionRequiredValueException(string message, Exception innerException) : base(message, innerException) { }
        /// <inheritdoc/>
        protected OptionRequiredValueException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
