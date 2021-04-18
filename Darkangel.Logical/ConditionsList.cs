using System;
using System.Collections;
using System.Collections.Generic;

namespace Darkangel.Logical
{
    /// <summary>
    /// <para>Список объектов, поддерживающих логические состояния</para>
    /// </summary>
    /// <typeparam name="T">тип объекта списка</typeparam>
    /// <remarks>2021-04-18</remarks>
    public abstract class ConditionsList<T> : IConditionalObject, IEnumerable<T>
        where T : IConditionalObject
    {
        /// <summary>
        /// <para>Список объектов</para>
        /// </summary>
        protected List<T> _List = new();
        /// <summary>
        /// <para>Проверка списка на наличие объектов</para>
        /// </summary>
        public bool IsEmpty => _List.Count < 1;
        /// <inheritdoc/>
        public virtual bool IsTrueIn(object state)
        {
            if (IsEmpty) return true;

            var Result = _List[0].IsTrueIn(state);

            for (var i = 1; i < _List.Count; i++)
            {
                Result = ProceedOp(Result, _List[i].IsTrueIn(state));
            }

            return Result;
        }
        /// <summary>
        /// <para>Логический оператор, применяемый к объектам списка</para>
        /// </summary>
        /// <param name="val1">Первый объект</param>
        /// <param name="val2">Второй объект</param>
        /// <returns>Результат логической операции</returns>
        protected abstract bool ProceedOp(bool val1, bool val2);
        /// <summary>
        /// <para>Перечисление объектов в списке</para>
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() =>
            ((IEnumerable<T>)_List).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            ((IEnumerable)_List).GetEnumerator();

        /// <summary>
        /// <para>Конструктор по-умолчанию</para>
        /// </summary>
        public ConditionsList() : base() { }
        /// <summary>
        /// <para>Конструктор из списка объектов</para>
        /// </summary>
        /// <param name="objs">Список элементов</param>
        public ConditionsList(params T[] objs) : base() =>
            AddRange(objs);
        /// <summary>
        /// <para>Конструктор из списка объектов</para>
        /// </summary>
        /// <param name="objs">Список элементов</param>
        public ConditionsList(IEnumerable<T> objs) : base() =>
            AddRange(objs);
        /// <summary>
        /// <para>Добавление объекта к списку</para>
        /// </summary>
        /// <param name="obj">Добавляемый объект</param>
        public void Add(T obj)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = obj ?? throw new ArgumentNullException(nameof(obj));
#endif
            #endregion Проверка аргументов
            _List.Add(obj);
        }
        /// <summary>
        /// <para>Добавить список объектов к текущему списку</para>
        /// </summary>
        /// <param name="objs">Добавляемая коллекция объектов</param>
        public void AddRange(IEnumerable<T> objs)
        {
            #region Проверка аргументов
#if CHECK_ARGS
            _ = objs ?? throw new ArgumentNullException(nameof(objs));
#endif
            #endregion Проверка аргументов
            _List.AddRange(objs);
        }
        /// <summary>
        /// <para>Удалить объект по его индексу из списка</para>
        /// </summary>
        /// <param name="index">Индекс удаляемого объекта</param>
        public void RemoveAt(int index)
        {
            if ((index < 0) || (index >= _List.Count))
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            _List.RemoveAt(index);
        }
        /// <summary>
        /// <para>Количество объектов в списке</para>
        /// </summary>
        public int Count =>
            _List.Count;
        /// <summary>
        /// <para>Предоставляет доступ к объектам списка по индексу</para>
        /// </summary>
        /// <param name="index">Индекс объекта в списке</param>
        /// <returns>Элемент списка</returns>
        public T this[int index] => _List[index];
        /// <summary>
        /// <para>Очистка списка</para>
        /// </summary>
        public void Clear() =>
            _List.Clear();
    }
}
