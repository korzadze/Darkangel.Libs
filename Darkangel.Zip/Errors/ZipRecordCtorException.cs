using System;
using System.Runtime.Serialization;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Тип записи должен иметь конструктор без параметров</para>
    /// </summary>
    public class ZipRecordCtorException : Exception
    {
        /// <inheritdoc/>
        public ZipRecordCtorException() { }
        /// <inheritdoc/>
        public ZipRecordCtorException(string message) : base(message) { }
        /// <inheritdoc/>
        public ZipRecordCtorException(string message, Exception innerException) : base(message, innerException) { }
        /// <inheritdoc/>
        protected ZipRecordCtorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
    /// <summary>
    /// <para>Тип дополнительных данных должен иметь конструктор без параметров</para>
    /// </summary>
    public class ExtraFieldCtorException : Exception
    {
        /// <inheritdoc/>
        public ExtraFieldCtorException() { }
        /// <inheritdoc/>
        public ExtraFieldCtorException(string message) : base(message) { }
        /// <inheritdoc/>
        public ExtraFieldCtorException(string message, Exception innerException) : base(message, innerException) { }
        /// <inheritdoc/>
        protected ExtraFieldCtorException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
