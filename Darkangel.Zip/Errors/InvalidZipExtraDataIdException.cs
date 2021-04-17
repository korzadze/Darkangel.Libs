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
    /// <summary>
    /// <para>Неверный размер дополнительных данных</para>
    /// </summary>
    public class InvalidZipExtraDataSizeException : FileLoadException
    {
        /// <inheritdoc/>
        public InvalidZipExtraDataSizeException() { }
        /// <inheritdoc/>
        public InvalidZipExtraDataSizeException(string message) : base(message) { }
        /// <inheritdoc/>
        public InvalidZipExtraDataSizeException(string message, Exception innerException) : base(message, innerException) { }
        /// <inheritdoc/>
        protected InvalidZipExtraDataSizeException(SerializationInfo info, StreamingContext context) : base(info, context) { }
        /// <summary>
        /// <para>Создать экземляр <see cref="InvalidZipExtraDataSizeException"/> с указанием размеровы</para>
        /// </summary>
        /// <param name="blockSize">Размер блока в архиве</param>
        /// <param name="recordSize">Размер записи</param>
        public InvalidZipExtraDataSizeException(int blockSize, int recordSize) : base(string.Format(StringResources.InvalidZipRecordSizeMessageFormat, blockSize, recordSize)) { }
    }
}
