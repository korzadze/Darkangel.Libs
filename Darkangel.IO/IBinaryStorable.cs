using System.IO;
using System.Threading.Tasks;

namespace Darkangel.IO
{
    /// <summary>
    /// <para>Интерфейс объекта, сохраняющего свои данные в двоичном потоке</para>
    /// </summary>
    public interface IBinaryStorable
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
        /// <param name="offset">Смещение в потоке</param>
        /// <returns>Размер сохраненных данных</returns>
        Task<long> StoreAsync(byte[] stream, long offset);
        /// <summary>
        /// <para>Сохранить данные в двоичном потоке</para>
        /// </summary>
        /// <param name="stream">Целевой поток данных</param>
        void Store(Stream stream);
        /// <summary>
        /// <para>Сохранить данные в двоичном потоке</para>
        /// </summary>
        /// <param name="stream">Целевой поток данных</param>
        Task StoreAsync(Stream stream);
    }
}
