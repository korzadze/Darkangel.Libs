using System;

namespace Darkangel.CLib
{
    /// <summary>
    /// <para>Указатель на область байт (C/C++)</para>
    /// </summary>
    /// <remarks>thread unsafe</remarks>
    public sealed class PByte : CPtr<byte>
    {
        /// <inheritdoc/>
        public PByte(byte[] data, long offset) : base(data, offset) { }
        /// <inheritdoc/>
        public PByte(CPtr<byte> ptr, long offset = 0) : base(ptr, offset) { }
        /// <inheritdoc/>
        [Obsolete]
        private PByte() : base() { }
        /// <summary>
        /// <para>Увеличить указатель на указанное значение</para>
        /// </summary>
        /// <param name="ptr">Исходный указатель</param>
        /// <param name="increment">Приращение (количество элементов)</param>
        /// <returns>Новый указательна вектор</returns>
        public static PByte operator +(PByte ptr, long increment) =>
            new(ptr, increment);
        /// <summary>
        /// <para>Уменьшить указатель на указанное значение</para>
        /// </summary>
        /// <param name="ptr">Исходный указатель</param>
        /// <param name="decrement">Уменьшение (количество элементов)</param>
        /// <returns>Новый указательна вектор</returns>
        public static PByte operator -(PByte ptr, long decrement) =>
            new(ptr, -decrement);
        /// <summary>
        /// <para>Получить указатель на начало вектора</para>
        /// </summary>
        /// <param name="data">Вектор значений</param>
        /// <returns>Указатель на вектор</returns>
        public static implicit operator PByte(byte[] data) =>
            new(data, 0);
        /// <summary>
        /// <para>Получить разность указателей</para>
        /// </summary>
        /// <param name="ptr1"></param>
        /// <param name="ptr2"></param>
        /// <returns>Разность указателей</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static long operator -(PByte ptr1, PByte ptr2)
        {
            if (!ReferenceEquals(ptr1._Data, ptr2._Data))
            {
                throw new InvalidOperationException();
            }
            return ptr1._Offset - ptr2._Offset;
        }
        /// <summary>
        /// <para>Уменьшить указатель на 1</para>
        /// </summary>
        /// <param name="ptr"></param>
        /// <returns></returns>
        public static PByte operator --(PByte ptr)
        {
            return new(ptr, -1);
        }
        /// <summary>
        /// <para>Увеличить указатель на 1</para>
        /// </summary>
        /// <param name="ptr">Указатель</param>
        /// <returns></returns>
        public static PByte operator ++(PByte ptr)
        {
            return new(ptr, 1);
        }
        /// <summary>
        /// <para>Создать копию объекта</para>
        /// </summary>
        /// <returns>Копия указателя</returns>
        public new PByte Clone()
        {
            return new(this);
        }
    }
}
