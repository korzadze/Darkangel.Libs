using System;
using System.IO;
using System.Runtime.Serialization;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Неизвестный идентификатор дополнительных данных</para>
    /// </summary>
    public class InvalidZipExtraDataIdException : FileLoadException
    {
        /// <inheritdoc/>
        public InvalidZipExtraDataIdException() { }
        /// <inheritdoc/>
        public InvalidZipExtraDataIdException(string message) : base(message) { }
        /// <inheritdoc/>
        public InvalidZipExtraDataIdException(string message, Exception innerException) : base(message, innerException) { }
        /// <inheritdoc/>
        protected InvalidZipExtraDataIdException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// <para>Создать экземляр <see cref="InvalidZipExtraDataIdException"/> с указанием ошибочного идентификатора</para>
        /// </summary>
        /// <param name="id">Идентификатор, вызвавший ошибку</param>
        public InvalidZipExtraDataIdException(int id) : base(string.Format(StringResources.InvalidZipRecordIdMessageFormat, id)) { }
    }
}
