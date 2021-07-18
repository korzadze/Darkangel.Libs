using System.IO;
using System.Threading.Tasks;

namespace Darkangel.IO
{
    /// <summary>
    /// <para>Интерфейс объекта, хранящего свои данные в двоичном потоке</para>
    /// </summary>
    public interface IBinaryLoadable
    {
        /// <summary>
        /// <para>Загрузить данные из двоичного потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток данных</param>
        /// <param name="offset">Смещение в потоке</param>
        /// <returns>Размер загруженных данных</returns>
        long Load(byte[] stream, long offset);
        /// <summary>
        /// <para>Загрузить данные из двоичного потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток данных</param>
        /// <param name="offset">Смещение в потоке</param>
        /// <returns>Размер загруженных данных</returns>
        Task<long> LoadAsync(byte[] stream, long offset);
        /// <summary>
        /// <para>Загрузить данные из двоичного потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток данных</param>
        void Load(Stream stream);
        /// <summary>
        /// <para>Загрузить данные из двоичного потока</para>
        /// </summary>
        /// <param name="stream">Исходный поток данных</param>
        Task LoadAsync(Stream stream);
    }
}
