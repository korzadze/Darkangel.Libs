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
        /// <summary>
        /// <para>Добавить описание к документу, если его нет</para>
        /// </summary>
        /// <param name="doc">XML документ</param>
        /// <param name="version">Версия XML</param>
        /// <param name="encoding">Кодировка</param>
        /// <param name="standalone">Игнорировать правила markup DTD</param>
        /// <returns>Исходный XML документ</returns>
        public static XmlDocument AddDeclaration(this XmlDocument doc, string version = null, string encoding = null, string standalone = null)
        {
            version ??= "1.0";
            encoding ??= "utf-8";
            standalone ??= "yes";
            if (doc.ChildNodes.Count > 0)
            {//Есть элементы
                if (doc.FirstChild is XmlDeclaration)
                {// Уже есть декларация
                    return doc;
                }
                else
                {//Еще нет декларации
                    var decl = doc.CreateXmlDeclaration(version, encoding, standalone);
                    doc.InsertBefore(decl, doc.FirstChild);
                    return doc;
                }
            }
            else
            {//Нет элементов
                var decl = doc.CreateXmlDeclaration(version, encoding, standalone);
                doc.AppendChild(decl);
                return doc;
            }
        }
    }
}
