using Darkangel.Compare;
using System;
using System.Collections.Generic;

namespace Darkangel.Collections
{
    public static partial class CollectionHelper
	{
		/// <summary>
		/// <para>Поиск item в сортированом списке sortedList.</para>
		/// <para>Если эквивалентное значение не найдено, то index содержит позицию,
		/// где оно должно быть (или, куда можно его вставить).</para>
		/// <para>В противном случае index содержит позицию в списке искомого значения</para>
		/// </summary>
		/// <typeparam name="T">Тип значения элемента списка</typeparam>
		/// <param name="sortedList">Список значений, отсортированных по возростанию
		/// (в противном случае результат неопределен)</param>
		/// <param name="item">Искомое значение</param>
		/// <param name="hasDuplicate">Содержит ли список дублирующиеся значения</param>
		/// <returns><para>Результат поиска значения.</para>
		/// <para>Если true, то index содержит индекс ключа в списке.</para>
		/// <para>Если false, то index содержит индекс возможного расположения ключа в списке</para></returns>
		/// <remarks>2021-04-18</remarks>
		public static SearchResult Search<T>(this IList<T> sortedList, T item, bool hasDuplicate = false)
			where T : IComparable
		{
#if CHECK_ARGS
			_ = sortedList ?? throw new ArgumentNullException(nameof(sortedList));
#endif
			var l = 0;
			var h = sortedList.Count - 1;
			var res = false;
#if SAFE_COMPARE
			IComparator<T> cmp = new SafeComparator<T>();
#else
			IComparator<T> cmp = new UnsafeComparator<T>();
#endif
			while (l <= h)
			{
				var i = (l + h) >> 1;
				var c = cmp.CompareValues(sortedList[i], item);
				if (c < 0)
				{
					l = i + 1;
				}
				else
				{
					h = i - 1;
					if (c == 0)
					{
						res = true;
						if (!hasDuplicate)
							l = i;
					}
				}
			}
			return new SearchResult() { IsFound = res, Index = l };
		}
		/// <summary>
		/// <para>Поиск item по ключу key в сортированом по ключу списке sortedList.</para>
		/// <para>Если ключ не найден, то index содержит позицию, где объект с таким ключем должен быть.</para>
		/// <para>В противном случае index содержит позицию в списке искомого объекта</para>
		/// </summary>
		/// <typeparam name="T">Тип значения элемента списка</typeparam>
		/// <typeparam name="TKey">Тип ключа поиска</typeparam>
		/// <param name="sortedList">Список значений, сортированных по ключу в возростающем порядке
		/// (в противном случае результат неопределен)</param>
		/// <param name="key">Ключ поиска</param>
		/// <param name="hasDuplicate">Содержит ли список дублирующиеся значения</param>
		/// <returns><para>Результат поиска значения.</para>
		/// <para>Если true, то index содержит индекс ключа в списке.</para>
		/// <para>Если false, то index содержит индекс возможного расположения ключа в списке</para></returns>
		/// <remarks>2021-04-18</remarks>
		public static SearchResult Search<T, TKey>(this IList<T> sortedList, TKey key, bool hasDuplicate = false)
			where T : IComparable<TKey>
		{
			_ = sortedList ?? throw new ArgumentNullException(nameof(sortedList));

			var l = 0;
			var h = sortedList.Count - 1;
			var res = false;
#if SAFE_COMPARE
			IComparator<T, TKey> cmp = new SafeComparator<T, TKey>();
#else
			IComparator<T, TKey> cmp = new UnsafeComparator<T, TKey>();
#endif
			while (l <= h)
			{
				var i = (l + h) >> 1;
				var c = cmp.CompareValues(sortedList[i], key);
				if (c < 0)
				{
					l = i + 1;
				}
				else
				{
					h = i - 1;
					if (c == 0)
					{
						res = true;
						if (!hasDuplicate)
						{
							l = i;
						}
					}
				}
			}
			return new SearchResult() { IsFound = res, Index = l };
		}
	}
}
