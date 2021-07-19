namespace Darkangel.IO
{
    /// <summary>
    /// <para>Базовый класс для полей двоичной структуры</para>
    /// </summary>
    /// <typeparam name="T">Тип значения поля</typeparam>
    public abstract class BinaryField<T> : BinaryData
        where T : struct
    {
        /// <summary>
        /// <para>Значение поля структуры</para>
        /// </summary>
        public T Value;
    }
}
