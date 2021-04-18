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
	/// </summary>
	/// <typeparam name="T">Тип значений перечисления унаследованный от <see cref="Enum"/></typeparam>
	/// <remarks>release</remarks>
	public class SetOfE<T> : IEnumerable<T>
		where T : Enum
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
		public SetOfE() { }
		/// <summary>
		/// <para>Создать набор из одного элемента</para>
		/// </summary>
		/// <param name="elem">Элемент набора</param>
		public SetOfE(T elem)
		{
			Add(elem);
		}
		/// <summary>
		/// <para>Конструктор набора из списка элементов</para>
		/// </summary>
		/// <param name="items">Список элементов</param>
		public SetOfE(IEnumerable<T> items)
		{
			#region Check arguments
#if CHECK_ARGS
			_ = items ?? throw new ArgumentNullException(nameof(items));
#endif
            #endregion
            foreach (var v in items)
			{
				Add(v);
			}
		}
		/// <summary>
		/// <para>Конструктор экземпляра из списка элементов</para>
		/// </summary>
		/// <param name="items">Список элементов</param>
		public SetOfE(params T[] items) : this((IEnumerable<T>)items) { }
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
		public SetOfE<T> Intersect(SetOfE<T> other) // op *
		{
			#region Check arguments
#if CHECK_ARGS
			_ = other ?? throw new ArgumentNullException(nameof(other));
#endif
			#endregion Check arguments
			var res = new SetOfE<T>();
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
		public SetOfE<T> Union(SetOfE<T> other) // op +
		{
			#region Check arguments
#if CHECK_ARGS
			_ = other ?? throw new ArgumentNullException(nameof(other));
#endif
			#endregion

			var res = new SetOfE<T>();
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
		public SetOfE<T> Union(T other) // op +
		{
			#region Check arguments
#if CHECK_ARGS
			_ = other ?? throw new ArgumentNullException(nameof(other));
#endif
			#endregion
			var res = new SetOfE<T>(this)
            {
                other
            };
            return res;
		}

		/// <summary>
		/// Разность наборов
		/// </summary>
		/// <param name="other">Второй набор</param>
		/// <returns>Новый набор, образованный из элементов исходного набора,
		/// отсутствующих во втором наборе</returns>
		public SetOfE<T> Difference(SetOfE<T> other) // op -
		{
			#region Check arguments
#if CHECK_ARGS
			_ = other ?? throw new ArgumentNullException(nameof(other));
#endif
			#endregion
			var res = new SetOfE<T>();
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
		public SetOfE<T> Difference(T other) // op -
		{
			#region Check arguments
#if CHECK_ARGS
			_ = other ?? throw new ArgumentNullException(nameof(other));
#endif
			#endregion
			var res = new SetOfE<T>();
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
		public SetOfE<T> SymmentricalDifference(SetOfE<T> other) =>
			Difference(other).Union(other.Difference(this));
		/// <summary>
		/// <para>Сумма наборов</para>
		/// </summary>
		/// <param name="set1">Исходный набор</param>
		/// <param name="set2">Добавляемый набор</param>
		/// <returns>Новый набор, образованный из элементов обеих наборов</returns>
		public static SetOfE<T> operator +(SetOfE<T> set1, SetOfE<T> set2) =>
			set1.Union(set2);
		/// <summary>
		/// <para>Добавить элемент в набор</para>
		/// </summary>
		/// <param name="set1">Исходный набор</param>
		/// <param name="elem">Добавляемый набор</param>
		/// <returns>Новый набор, образованный из элементов обеих наборов</returns>
		public static SetOfE<T> operator +(SetOfE<T> set1, T elem) =>
			set1.Union(elem);
		/// <summary>
		/// <para>Разность наборов</para>
		/// </summary>
		/// <param name="set1">Первый набор</param>
		/// <param name="set2">Второй набор</param>
		/// <returns>Новый набор, образованный из элементов исходного набора,
		/// отсутствующих во втором наборе</returns>
		public static SetOfE<T> operator -(SetOfE<T> set1, SetOfE<T> set2) =>
			set1.Difference(set2);
		/// <summary>
		/// <para>Разность наборов</para>
		/// </summary>
		/// <param name="set1">Первый набор</param>
		/// <param name="val">Единичный набор(одиночное значение)</param>
		/// <returns>Новый набор, образованный из элементов исходного набора,
		/// отсутствующих во втором наборе</returns>
		public static SetOfE<T> operator -(SetOfE<T> set1, T val) =>
			set1.Difference(val);
		/// <summary>
		/// <para>Пересечение наборов</para>
		/// </summary>
		/// <param name="set1">Первый набор</param>
		/// <param name="set2">Второй набор</param>
		/// <returns>Новый набор, образованный из общих, для обоих наборов элементов</returns>
		public static SetOfE<T> operator *(SetOfE<T> set1, SetOfE<T> set2) =>
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
