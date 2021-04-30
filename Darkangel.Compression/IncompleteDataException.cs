using System;
using System.Runtime.Serialization;

namespace Darkangel.Compression
{
    /// <summary>
    /// <para>Не полные данные</para>
    /// </summary>
    public class IncompleteDataException : Exception
    {
        /// <inheritdoc/>
        public IncompleteDataException() { }
        /// <inheritdoc/>
        public IncompleteDataException(string message) : base(message) { }
        /// <inheritdoc/>
        public IncompleteDataException(string message, Exception innerException) : base(message, innerException) { }
        /// <inheritdoc/>
        protected IncompleteDataException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
