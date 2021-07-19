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
        /// <param name="context">Контекст хранения двоичных данных в потоке</param>
        /// <param name="stream">Исходный поток данных</param>
        void Load(IBinaryContext context, Stream stream);
        /// <summary>
        /// <para>Загрузить данные из двоичного потока</para>
        /// </summary>
        /// <param name="context">Контекст хранения двоичных данных в потоке</param>
        /// <param name="stream">Исходный поток данных</param>
        Task LoadAsync(IBinaryContext context, Stream stream);
    }
}
