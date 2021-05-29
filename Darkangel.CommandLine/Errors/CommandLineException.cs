using System;
using System.Runtime.Serialization;

namespace Darkangel.CommandLine
{
    /// <summary>
    /// <para>Ошибка командной строки</para>
    /// <para>Базовое исключение библиотеки</para>
    /// </summary>
    public class CommandLineException : Exception
    {
        /// <summary>
        /// <para>Создает новый экземпляр класса</para>
        /// </summary>
        public CommandLineException() { }
        /// <summary>
        /// <para>Создает новый экземпляр класса с указанным сообщением об ошибке.</para>
        /// </summary>
        /// <param name="message">Сообщение, описывающее ошибку.</param>
        public CommandLineException(string message) : base(message) { }
        /// <summary>
        /// <para>Создает новый экземпляр класса с указанным сообщением об ошибке и ссылкой на внутреннее исключение, вызвавшее данное исключение.</para>
        /// </summary>
        /// <param name="message">Сообщение, описывающее ошибку.</param>
        /// <param name="innerException">Исключение, вызвавшее текущее исключение, или пустая ссылка, если внутреннее исключение не задано.</param>
        public CommandLineException(string message, Exception innerException) : base(message, innerException) { }
        /// <summary>
        /// <para>Создает новый экземпляр класса с сериализованными данными.</para>
        /// </summary>
        /// <param name="info">Объект <see cref="SerializationInfo"/>, хранящий сериализованные данные объекта, относящиеся к выдаваемому исключению.</param>
        /// <param name="context">Объект <see cref="StreamingContext"/>, содержащий контекстные сведения об источнике или назначении.</param>
        protected CommandLineException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
