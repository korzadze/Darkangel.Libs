using System.Threading.Tasks;

namespace Darkangel.IO
{
    /// <summary>
    /// <para>Интерфейс объекта, с возможностью загрузки и сохранения данных
    /// в двоичных потоках</para>
    /// </summary>
    public interface IBinaryObject : IBinaryStorable, IBinaryLoadable
    {
        /// <summary>
        /// <para>Получить размер объекта в потоке</para>
        /// </summary>
        /// <returns>Размер объекта в потоке</returns>
        long GetSize();
        /// <summary>
        /// <para>Получить размер объекта в потоке</para>
        /// </summary>
        /// <returns>Размер объекта в потоке</returns>
        Task<long> GetSizeAsync();
    }
}
