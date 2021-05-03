using System;
using System.Xml;

namespace Darkangel.Xml
{
    public static partial class XmlHelpers
    {
        /// <summary>
        /// <para>Добавить дочерний элемент к корневому</para>
        /// </summary>
        /// <param name="root"><para>Корневой элемент</para></param>
        /// <param name="childName"><para>Имя дочернего элемента</para></param>
        /// <returns><para>Добавленый дочерний элемент</para></returns>
        /// <remarks>2021-04-18</remarks>
        public static XmlElement AddChild(this XmlElement root, string childName)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = root ?? throw new ArgumentNullException(nameof(root));
            _ = childName ?? throw new ArgumentNullException(nameof(childName));
#endif
            #endregion Проверка аргументов
            XmlElement child = root.OwnerDocument.CreateElement(childName);
            root.AppendChild(child);
            return child;
        }
        /// <summary>
        /// <para>Добавить дочерний элемент к корневому</para>
        /// </summary>
        /// <param name="root"><para>Корневой элемент</para></param>
        /// <param name="qualifiedName"><para>Полное имя элемента.</para><para>Если имя содержит двоеточие, свойство Prefix отражает часть имени, предшествующую ему, а свойство LocalName — ту часть, которая следует за двоеточием. Полное имя не может содержать префикс "xmlns".</para></param>
        /// <param name="namespaceUri"><para>Универсальный код ресурса (URI) пространства имен элемента.</para></param>
        /// <returns><para>Добавленый дочерний элемент</para></returns>
        /// <remarks>2021-04-18</remarks>
        public static XmlElement AddChild(this XmlElement root, string qualifiedName, string namespaceUri)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = root ?? throw new ArgumentNullException(nameof(root));
            _ = qualifiedName ?? throw new ArgumentNullException(nameof(qualifiedName));
#endif
            #endregion Проверка аргументов
            XmlElement child = root.OwnerDocument.CreateElement(qualifiedName, namespaceUri);
            root.AppendChild(child);
            return child;
        }
        /// <summary>
        /// <para>Добавить дочерний элемент к корневому</para>
        /// </summary>
        /// <param name="root"><para>Корневой элемент</para></param>
        /// <param name="prefix">Префикс нового элемента (если имеется). String.Empty равнозначно значению null.</param>
        /// <param name="localName">Локальное имя дочернего элемента.</param>
        /// <param name="namespaceUri"><para>Универсальный код ресурса (URI) пространства имен элемента.</para></param>
        /// <returns><para>Добавленый дочерний элемент</para></returns>
        /// <remarks>2021-04-18</remarks>
        public static XmlElement AddChild(this XmlElement root, string prefix, string localName, string namespaceUri)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = root ?? throw new ArgumentNullException(nameof(root));
            _ = localName ?? throw new ArgumentNullException(nameof(localName));
#endif
            #endregion Проверка аргументов
            XmlElement child = root.OwnerDocument.CreateElement(prefix, localName, namespaceUri);
            root.AppendChild(child);
            return child;
        }
        /// <summary>
        /// <para>Добавить элемент к документу</para>
        /// </summary>
        /// <param name="doc"><para>XML документ</para></param>
        /// <param name="childName"><para>Имя дочернего элемента</para></param>
        /// <returns><para>Добавленый дочерний элемент</para></returns>
        /// <remarks>2021-04-18</remarks>
        public static XmlElement AddChild(this XmlDocument doc, string childName)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = doc ?? throw new ArgumentNullException(nameof(doc));
            _ = childName ?? throw new ArgumentNullException(nameof(childName));
#endif
            #endregion Проверка аргументов
            XmlElement child = doc.CreateElement(childName);
            doc.AppendChild(child);
            return child;
        }
        /// <summary>
        /// <para>Добавить элемент к документу</para>
        /// </summary>
        /// <param name="doc"><para>XML документ</para></param>
        /// <param name="qualifiedName"><para>Полное имя элемента.</para><para>Если имя содержит двоеточие, свойство Prefix отражает часть имени, предшествующую ему, а свойство LocalName — ту часть, которая следует за двоеточием. Полное имя не может содержать префикс "xmlns".</para></param>
        /// <param name="namespaceUri"><para>Универсальный код ресурса (URI) пространства имен элемента.</para></param>
        /// <returns><para>Добавленый дочерний элемент</para></returns>
        /// <remarks>2021-04-18</remarks>
        public static XmlElement AddChild(this XmlDocument doc, string qualifiedName, string namespaceUri)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = doc ?? throw new ArgumentNullException(nameof(doc));
            _ = qualifiedName ?? throw new ArgumentNullException(nameof(qualifiedName));
#endif
            #endregion Проверка аргументов
            XmlElement child = doc.CreateElement(qualifiedName, namespaceUri);
            doc.AppendChild(child);
            return child;
        }
        /// <summary>
        /// <para>Добавить элемент к документу</para>
        /// </summary>
        /// <param name="doc"><para>XML документ</para></param>
        /// <param name="prefix">Префикс нового элемента (если имеется). String.Empty равнозначно значению null.</param>
        /// <param name="localName">Локальное имя дочернего элемента.</param>
        /// <param name="namespaceUri"><para>Универсальный код ресурса (URI) пространства имен элемента.</para></param>
        /// <returns><para>Добавленый дочерний элемент</para></returns>
        /// <remarks>2021-04-18</remarks>
        public static XmlElement AddChild(this XmlDocument doc, string prefix, string localName, string namespaceUri)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = doc ?? throw new ArgumentNullException(nameof(doc));
            _ = localName ?? throw new ArgumentNullException(nameof(localName));
#endif
            #endregion Проверка аргументов
            XmlElement child = doc.CreateElement(prefix, localName, namespaceUri);
            doc.AppendChild(child);
            return child;
        }
    }
}
