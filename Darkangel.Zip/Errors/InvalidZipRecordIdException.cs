using System;
using System.IO;
using System.Runtime.Serialization;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Неизвестный идентификатор записи</para>
    /// </summary>
    public class InvalidZipRecordIdException : FileLoadException
    {
        /// <inheritdoc/>
        public InvalidZipRecordIdException() { }
        /// <inheritdoc/>
        public InvalidZipRecordIdException(string message) : base(message) { }
        /// <inheritdoc/>
        public InvalidZipRecordIdException(string message, Exception innerException) : base(message, innerException) { }
        /// <inheritdoc/>
        protected InvalidZipRecordIdException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// <para>Создать экземляр <see cref="InvalidZipRecordIdException"/> с указанием ошибочного идентификатора</para>
        /// </summary>
        /// <param name="id">Идентификатор записи, вызвавший ошибку</param>
        public InvalidZipRecordIdException(long id) : base(string.Format(StringResources.InvalidZipRecordIdMessageFormat, id)) { }
    }
}
