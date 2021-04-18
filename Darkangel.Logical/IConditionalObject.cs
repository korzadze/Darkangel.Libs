namespace Darkangel.Logical
{
    /// <summary>
    /// Интерфейс объекта, имеющего состояние истина/ложь
    /// </summary>
    /// <remarks>2021-04-18</remarks>
    public interface IConditionalObject
    {
        /// <summary>
        /// Переходит ли объект в состоянии Истина при статусе state
        /// </summary>
        /// <param name="state">Статус объекта</param>
        bool IsTrueIn(object state);
    }
}
