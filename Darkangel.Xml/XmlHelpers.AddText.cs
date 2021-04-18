using System;
using System.Xml;

namespace Darkangel.Xml
{
    public static partial class XmlHelpers
    {
        /// <summary>
        /// <para>Добавить текстовый элемент к родительскому</para>
        /// </summary>
        /// <param name="element"><para>Родительский элемент</para></param>
        /// <param name="text"><para>Текст</para></param>
        /// <returns><para>Родительский элемент</para></returns>
        /// <remarks>2021-04-18</remarks>
        public static XmlElement AddText(this XmlElement element, string text)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = element ?? throw new ArgumentNullException(nameof(element));
#endif
            #endregion Проверка аргументов
            var te = element.OwnerDocument.CreateTextNode(text);
            element.AppendChild(te);
            return element;
        }
    }
}
