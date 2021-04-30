using System.IO;

namespace Darkangel.IO
{
    /// <summary>
    /// <para>Интерфейс объекта, хранящего свои данные в двоичном потоке</para>
    /// </summary>
    public interface IBinaryLoadable
    {
        /// <summary>
        /// <para>Сохранить данные в двоичном потоке</para>
        /// </summary>
        /// <param name="stream">Целевой поток данных</param>
        /// <param name="offset">Смещение в потоке</param>
        /// <returns>Размер сохраненных данных</returns>
        long Store(byte[] stream, long offset);
        /// <summary>
        /// <para>Сохранить данные в двоичном потоке</para>
        /// </summary>
        /// <param name="stream">Целевой поток данных</param>
        void Load(Stream stream);
    }
}
