using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

//Готово
namespace Darkangel.Collections
{
    /// <summary>
    /// <para>Набор элементов (аналог паскалевского 'set of ...')</para>
    /// <para>Для перечислений следует использовать класс <see cref="SetOfE{T}"/>, т.к. перечисления не реализуют интерфейс <see cref="IComparable{T}"/></para>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SetOf<T> : IEnumerable<T>
        where T : IComparable<T>
    {
		private void Add(T elem) => _List.Add(elem);

		private readonly HashSet<T> _List = new();
		/// <inheritdoc/>
		public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)_List).GetEnumerator();
		/// <inheritdoc/>
		IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable)_List).GetEnumerator();
		/// <summary>
		/// <para>Проверить наличие элемента в наборе</para>
		/// </summary>
		/// <param name="item">Искомый элемент</param>
		/// <returns>Результат поиска</returns>
		public bool this[T item] => Contains(item);
		/// <summary>
		/// <para>Конструктор пустого набора</para>
		/// </summary>
		public SetOf() { }
		/// <summary>
		/// <para>Создать набор из одного элемента</para>
		/// </summary>
		/// <param name="elem">Элемент набора</param>
		public SetOf(T elem)
		{
			Add(elem);
		}
		/// <summary>
		/// <para>Конструктор набора из списка элементов</para>
		/// </summary>
		/// <param name="items">Список элементов</param>
		public SetOf(IEnumerable<T> items)
		{
			foreach (var v in items)
			{
				Add(v);
			}
		}
		/// <summary>
		/// <para>Конструктор экземпляра из списка элементов</para>
		/// </summary>
		/// <param name="items">Список элементов</param>
		public SetOf(params T[] items) : this((IEnumerable<T>)items) { }
		/// <summary>
		/// <para>Проверка на наличие элемента в наборе</para>
		/// </summary>
		/// <param name="item">Искомый элемент</param>
		/// <returns>Результат проверки</returns>
		public bool Contains(T item) => _List.Contains(item);
		/// <summary>
		/// <para>Преобразовать набор в массив</para>
		/// </summary>
		/// <returns>Результирующий массив</returns>
		public T[] ToArray() => _List.ToArray();

		/// <summary>
		/// <para>Истина, если набор не содержит ни одного элемента</para>
		/// </summary>
		public bool IsEmpty => (_List.Count == 0);

		/// <summary>
		/// <para>Пересечение двух наборов</para>
		/// </summary>
		/// <param name="other">Второй набор</param>
		/// <returns>Новый набор, образованный из общих, для обоих наборов элементов</returns>
		public SetOf<T> Intersect(SetOf<T> other) // op *
		{
			#region Check arguments
#if CHECK_ARGS
			_ = other ?? throw new ArgumentNullException(nameof(other));
#endif
			#endregion
			var res = new SetOf<T>();
			foreach (var v in this)
			{
				if (other[v])
				{
					res.Add(v);
				}
			}
			return res;
		}
		/// <summary>
		/// <para>Объединение двух наборов</para>
		/// </summary>
		/// <param name="other">Второй набор</param>
		/// <returns>Новый набор, содержащий элементы обоих наборов</returns>
		public SetOf<T> Union(SetOf<T> other) // op +
		{
			#region Check arguments
#if CHECK_ARGS
			_ = other ?? throw new ArgumentNullException(nameof(other));
#endif
			#endregion
			var res = new SetOf<T>();
			foreach (var v in _List)
			{
				res.Add(v);
			}
			foreach (var v in other._List)
			{
				res.Add(v);
			}
			return res;
		}
		/// <summary>
		/// <para>Добавить элемент в набор</para>
		/// </summary>
		/// <param name="other"></param>
		/// <returns>Новый набор, содержащий добавленный элемент</returns>
		public SetOf<T> Union(T other) // op +
		{
			#region Check arguments
#if CHECK_ARGS
			_ = other ?? throw new ArgumentNullException(nameof(other));
#endif
			#endregion
			return new SetOf<T>(this)
			{
				other
			};
		}

		/// <summary>
		/// Разность наборов
		/// </summary>
		/// <param name="other">Второй набор</param>
		/// <returns>Новый набор, образованный из элементов исходного набора,
		/// отсутствующих во втором наборе</returns>
		public SetOf<T> Difference(SetOf<T> other) // op -
		{
			#region Check arguments
#if CHECK_ARGS
			_ = other ?? throw new ArgumentNullException(nameof(other));
#endif
			#endregion
			var res = new SetOf<T>();
			foreach (var val in _List)
			{
				if (!other._List.Contains(val))
				{
					res.Add(val);
				}
			}
			return res;
		}
		/// <summary>
		/// <para>Создать набор, не содержащий указанный элемент</para>
		/// </summary>
		/// <param name="other">Удаляемый элемент</param>
		/// <returns>Новый набор</returns>
		public SetOf<T> Difference(T other) // op -
		{
			#region Check arguments
#if CHECK_ARGS
			_ = other ?? throw new ArgumentNullException(nameof(other));
#endif
			#endregion
			var res = new SetOf<T>();
			foreach (var val in _List)
			{
				if (val.CompareTo(other) != 0)
				{
					res.Add(val);
				}
			}
			return res;
		}
		/// <summary>
		/// <para>Симметричная разность</para>
		/// </summary>
		/// <param name="other">Второй набор</param>
		/// <returns>Новый набор, состоящий из элементов уникальных,
		/// для каждого из исходных наборов</returns>
		public SetOf<T> SymmentricalDifference(SetOf<T> other) =>
			Difference(other).Union(other.Difference(this));
		/// <summary>
		/// <para>Сумма наборов</para>
		/// </summary>
		/// <param name="set1">Исходный набор</param>
		/// <param name="set2">Добавляемый набор</param>
		/// <returns>Новый набор, образованный из элементов обеих наборов</returns>
		public static SetOf<T> operator +(SetOf<T> set1, SetOf<T> set2) =>
			set1.Union(set2);
		/// <summary>
		/// <para>Добавить элемент в набор</para>
		/// </summary>
		/// <param name="set1">Исходный набор</param>
		/// <param name="elem">Добавляемый набор</param>
		/// <returns>Новый набор, образованный из элементов обеих наборов</returns>
		public static SetOf<T> operator +(SetOf<T> set1, T elem) =>
			set1.Union(elem);
		/// <summary>
		/// <para>Разность наборов</para>
		/// </summary>
		/// <param name="set1">Первый набор</param>
		/// <param name="set2">Второй набор</param>
		/// <returns>Новый набор, образованный из элементов исходного набора,
		/// отсутствующих во втором наборе</returns>
		public static SetOf<T> operator -(SetOf<T> set1, SetOf<T> set2) =>
			set1.Difference(set2);
		/// <summary>
		/// <para>Разность наборов</para>
		/// </summary>
		/// <param name="set1">Первый набор</param>
		/// <param name="val">Единичный набор(одиночное значение)</param>
		/// <returns>Новый набор, образованный из элементов исходного набора,
		/// отсутствующих во втором наборе</returns>
		public static SetOf<T> operator -(SetOf<T> set1, T val) =>
			set1.Difference(val);
		/// <summary>
		/// <para>Пересечение наборов</para>
		/// </summary>
		/// <param name="set1">Первый набор</param>
		/// <param name="set2">Второй набор</param>
		/// <returns>Новый набор, образованный из общих, для обоих наборов элементов</returns>
		public static SetOf<T> operator *(SetOf<T> set1, SetOf<T> set2) =>
			set1.Intersect(set2);
		/// <summary>
		/// <para>Преобразование набора в строку, разделенную CurrentCulture.TextInfo.ListSeparator.</para>
		/// </summary>
		/// <example>[element1,element2,...,elementN]</example>
		/// <returns>Строковое представление набора</returns>
		public override string ToString() =>
			ToString(CultureInfo.CurrentCulture.TextInfo.ListSeparator);
		/// <summary>
		/// <para>Преобразование набора в строку, разделенную последовательностью символов "sep".</para>
		/// </summary>
		/// <param name="sep"><para>Последовательность символов, разделяющая элементы набора.</para><para>По-умолчанию: ',' (запятая)</para></param>
		/// <example>[element1,element2,...,elementN]</example>
		/// <returns>Строковое представление набора</returns>
		public virtual string ToString(string sep) =>
			string.Format("[{0}]", string.Join(sep ?? ",", _List));
	}
}
