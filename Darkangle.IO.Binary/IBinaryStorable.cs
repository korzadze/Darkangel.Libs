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
        /// <param name="context">Контекст хранения двоичных данных в потоке</param>
        /// <param name="stream">Целевой поток данных</param>
        void Store(IBinaryContext context, Stream stream);
        /// <summary>
        /// <para>Сохранить данные в двоичном потоке</para>
        /// </summary>
        /// <param name="context">Контекст хранения двоичных данных в потоке</param>
        /// <param name="stream">Целевой поток данных</param>
        Task StoreAsync(IBinaryContext context, Stream stream);
    }
}
