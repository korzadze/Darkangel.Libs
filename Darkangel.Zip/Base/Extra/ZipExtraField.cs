using System.IO;

namespace Darkangel.Zip
{
    /// <summary>
    /// <para>Базовый класс для объектов дополнительной информации</para>
    /// </summary>
    public abstract class ZipExtraField
    {
        /// <summary>
        /// <para>Идентификатор поля</para>
        /// </summary>
        public abstract int Id { get; }
        /// <summary>
        /// <para>Загрузить данные объекта из потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток</param>
        /// <param name="size">Размер данных, как он указан в архиве</param>
        public abstract void Load(Stream stream, int size);
        /// <summary>
        /// <para>Размер данных объекта</para>
        /// </summary>
        public abstract long DataSize { get; }
    }
}
