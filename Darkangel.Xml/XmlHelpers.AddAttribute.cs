using System;
using System.Xml;

namespace Darkangel.Xml
{
    public static partial class XmlHelpers
    {
        /// <summary>
        /// <para>Добавить элементу атрибут</para>
        /// </summary>
        /// <param name="element"><para>Родительский элемент</para></param>
        /// <param name="name"><para>Полное имя атрибута.</para><para>Если имя содержит двоеточие, свойство Prefix отражает часть имени, предшествующую ему, а свойство LocalName — ту часть, которая следует за первым двоеточием. Свойство NamespaceURI остается пустым, если префикс не является распознаваемым встроенным префиксом, например xmlns. В этом случае NamespaceURI имеет значение http://www.w3.org/2000/xmlns/.</para></param>
        /// <param name="value"><para>Значение атрибута (если имеется).</para></param>
        /// <returns><para>Родительский элемент</para></returns>
        /// <remarks>2021-04-18</remarks>
        public static XmlElement AddAttribute(this XmlElement element, string name, string value = null)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = element ?? throw new ArgumentNullException(nameof(element));
            _ = name ?? throw new ArgumentNullException(nameof(name));
#endif
            #endregion Проверка аргументов
            var attr = element.OwnerDocument.CreateAttribute(name);
            if (value != null)
            {
                attr.Value = value;
            }
            element.Attributes.Append(attr);
            return element;
        }
        /// <summary>
        /// <para>Добавить элементу атрибут</para>
        /// </summary>
        /// <param name="element"><para>Родительский элемент</para></param>
        /// <param name="qualifiedName"><para>Полное имя атрибута.<para></para>Если имя содержит двоеточие, свойство Prefix отражает часть имени, предшествующую ему, а свойство LocalName — ту часть, которая следует за двоеточием.</para></param>
        /// <param name="namespaceUri"><para>URI пространства имен атрибута. Если полное имя содержит префикс xmlns, то этот параметр должен иметь значение http://www.w3.org/2000/xmlns/.</para></param>
        /// <param name="value"><para>Значение атрибута (если имеется).</para></param>
        /// <returns><para>Родительский элемент</para></returns>
        /// <remarks>2021-04-18</remarks>
        public static XmlElement AddAttribute(this XmlElement element, string qualifiedName, string namespaceUri, string value = null)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = element ?? throw new ArgumentNullException(nameof(element));
            _ = qualifiedName ?? throw new ArgumentNullException(nameof(qualifiedName));
#endif
            #endregion Проверка аргументов
            var attr = element.OwnerDocument.CreateAttribute(qualifiedName, namespaceUri);
            if (value != null)
            {
                attr.Value = value;
            }
            element.Attributes.Append(attr);
            return element;
        }
        /// <summary>
        /// <para>Добавить элементу атрибут</para>
        /// </summary>
        /// <param name="element"><para>Родительский элемент</para></param>
        /// <param name="prefix"><para>Префикс атрибута (если имеется).</para><para>String.Empty равносильно значению null.</para></param>
        /// <param name="localName"><para>Локальное имя атрибута.</para></param>
        /// <param name="namespaceUri"><para>URI пространства имен атрибута (если имеется).</para><para>String.Empty равносильно значению null.</para><para>Если значение параметра prefix равно xmlns, этот параметр должен иметь значение http://www.w3.org/2000/xmlns/. В противном случае возникает исключение.</para></param>
        /// <param name="value"><para>Значение атрибута (если имеется).</para></param>
        /// <returns><para>Родительский элемент</para></returns>
        /// <remarks>2021-04-18</remarks>
        public static XmlElement AddAttribute(this XmlElement element, string prefix, string localName, string namespaceUri, string value = null)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = element ?? throw new ArgumentNullException(nameof(element));
            _ = localName ?? throw new ArgumentNullException(nameof(localName));
#endif
            #endregion Проверка аргументов
            var attr = element.OwnerDocument.CreateAttribute(prefix, localName, namespaceUri);
            if (value != null)
            {
                attr.Value = value;
            }
            element.Attributes.Append(attr);
            return element;
        }
    }
}
