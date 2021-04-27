using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Darkangel.CLib
{
    /// <summary>
    /// <para>Указатель на область данных (C/C++)</para>
    /// </summary>
    /// <typeparam name="T">Тип значений вектора</typeparam>
    /// <remarks>thread unsafe</remarks>
    public class CPtr<T>
    {
        /// <summary>
        /// <para>Область данных</para>
        /// </summary>
        internal readonly T[] _Data = null;
        /// <summary>
        /// <para>Смещение от начала данных</para>
        /// </summary>
        internal readonly long _Offset = 0;
        /// <summary>
        /// <para>Расстояние от указателя до окончания области данных</para>
        /// </summary>
        public long Length => _Data.LongLength - _Offset;
        /// <summary>
        /// <para>Доступ к элементу вектора по индексу</para>
        /// </summary>
        /// <param name="offset">Смещение элемента</param>
        /// <returns>Значение элемента по указанному смещению</returns>
        public T this[long offset]
        {
            get
            {
                return _Data[_Offset + offset];
            }
            set
            {
                _Data[_Offset + offset] = value;
            }
        }
        /// <summary>
        /// <para>Конструктор, предотвращающий создание пустого указателя</para>
        /// </summary>
        /// <remarks>Не использовать</remarks>
        [Obsolete("Не используется")]
        protected CPtr() { }
        /// <summary>
        /// <para>Конструктор экземпляра <see cref="CPtr{T}"/></para>
        /// </summary>
        /// <param name="data">Исходный вектор значений</param>
        /// <param name="offset">Смещение элемента вектора значений</param>
        /// <exception cref="ArgumentNullException">Ссылка на данные не действительна</exception>
        /// <exception cref="ArgumentOutOfRangeException">Смещение выходит за пределы области данных</exception>
        public CPtr(T[] data, long offset)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if ((offset < 0) || (offset >= data.LongLength))
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
#endif
            #endregion Проверка аргументов
            _Data = data;
            _Offset = offset;
        }
        /// <summary>
        /// <para>Конструктор экземпляра <see cref="CPtr{T}"/></para>
        /// </summary>
        /// <param name="ptr">Указатель на вектор</param>
        /// <param name="offset">Смещение элемента относительно исходного указателя</param>
        /// <exception cref="ArgumentNullException">Исходный указатель не действителен</exception>
        /// <exception cref="ArgumentOutOfRangeException">Смещение выходит за пределы области данных</exception>
        public CPtr(CPtr<T> ptr, long offset = 0)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            if (ptr is null)
            {
                throw new ArgumentNullException(nameof(ptr));
            }
            if (((ptr._Offset + offset) < 0) || ((ptr._Offset + offset) >= ptr.Length))
            {
                throw new ArgumentOutOfRangeException(nameof(offset));
            }
#endif
            #endregion
            _Data = ptr._Data;
            _Offset = ptr._Offset + offset;
        }
        /// <summary>
        /// <para>Увеличить указатель на указанное значение</para>
        /// </summary>
        /// <param name="ptr">Исходный указатель</param>
        /// <param name="increment">Приращение (количество элементов)</param>
        /// <returns>Новый указательна вектор</returns>
        public static CPtr<T> operator +(CPtr<T> ptr, long increment) =>
            new(ptr, increment);
        /// <summary>
        /// <para>Уменьшить указатель на указанное значение</para>
        /// </summary>
        /// <param name="ptr">Исходный указатель</param>
        /// <param name="decrement">Уменьшение (количество элементов)</param>
        /// <returns>Новый указательна вектор</returns>
        public static CPtr<T> operator -(CPtr<T> ptr, long decrement) =>
            new(ptr, -decrement);
        /// <summary>
        /// <para>Получить указатель на начало вектора</para>
        /// </summary>
        /// <param name="data">Вектор значений</param>
        /// <returns>Указатель на вектор</returns>
        public static implicit operator CPtr<T>(T[] data) =>
            new(data, 0);
        /// <summary>
        /// <para>Получить разность указателей</para>
        /// </summary>
        /// <param name="ptr1"></param>
        /// <param name="ptr2"></param>
        /// <returns>Разность указателей</returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static long operator -(CPtr<T> ptr1, CPtr<T> ptr2)
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
        public static CPtr<T> operator --(CPtr<T> ptr)
        {
            return new(ptr, -1);
        }
        /// <summary>
        /// <para>Увеличить указатель на 1</para>
        /// </summary>
        /// <param name="ptr">Указатель</param>
        /// <returns></returns>
        public static CPtr<T> operator ++(CPtr<T> ptr)
        {
            return new(ptr, 1);
        }
        /// <summary>
        /// <para>Создать копию объекта</para>
        /// </summary>
        /// <returns>Копия указателя</returns>
        public CPtr<T> Clone()
        {
            return new(this);
        }
    }
}
