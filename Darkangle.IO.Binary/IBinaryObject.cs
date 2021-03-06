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
        /// <param name="context">Контекст хранения двоичных данных в потоке</param>
        /// <returns>Размер объекта в потоке</returns>
        long GetSize(IBinaryContext context);
    }
}
