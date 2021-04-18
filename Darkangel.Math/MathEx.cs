using Darkangel.Compare;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Darkangel
{
	/// <summary>
	/// <para>Дополнительные математические утилиты</para>
	/// </summary>
    public static class MathEx
    {
		/// <summary>
		/// <para>Максимальное значение из списка</para>
		/// </summary>
		/// <typeparam name="T">Тип значения, поддерживающий <see cref="IComparable"/></typeparam>
		/// <param name="values">Список значений</param>
		/// <returns>Масимальное значение из списка</returns>
		/// <exception cref="ArgumentNullException"/>
		/// <remarks>2021-04-18</remarks>
		public static T Max<T>(this IEnumerable<T> values)
			where T : IComparable
			=> Max(values.ToArray());
		/// <summary>
		/// <para>Миниимальное значение из списка</para>
		/// </summary>
		/// <typeparam name="T">Тип значения, поддерживающий <see cref="IComparable"/></typeparam>
		/// <param name="values">Список значений</param>
		/// <returns>Минимальное значение из списка</returns>
		/// <exception cref="ArgumentNullException"/>
		/// <remarks>2021-04-18</remarks>
		public static T Min<T>(this IEnumerable<T> values)
			where T : IComparable
			=> Min(values.ToArray());
		/// <summary>
		/// <para>Максимальное значение из списка</para>
		/// </summary>
		/// <typeparam name="T">Тип значения, поддерживающий <see cref="IComparable"/></typeparam>
		/// <param name="values">Список значений</param>
		/// <returns>Масимальное значение из списка</returns>
		/// <exception cref="ArgumentNullException"/>
		/// <remarks>2021-04-18</remarks>
		public static T Max<T>(params T[] values)
			where T: IComparable
        {
			#region Check arguments
#if CHECK_ARGS
			if ((values == null) || (values.Length < 1))
			{
				throw new ArgumentNullException(nameof(values));
			}
#endif
			#endregion Check arguments

			var res = values[0];
#if SAFE_COMPARE
			IComparator<T> cmp = new SafeComparator<T>();
#else
			IComparator<T> cmp = new UnsafeComparator<T>();
#endif
			for (var i = 1L; i < values.LongLength; i++)
			{
				if (cmp.CompareValues(res, values[i]) < 0)
				{
					res = values[i];

				}
			}
			return res;
		}
		/// <summary>
		/// <para>Миниимальное значение из списка</para>
		/// </summary>
		/// <typeparam name="T">Тип значения, поддерживающий <see cref="IComparable"/></typeparam>
		/// <param name="values">Список значений</param>
		/// <returns>Минимальное значение из списка</returns>
		/// <exception cref="ArgumentNullException"/>
		/// <remarks>2021-04-18</remarks>
		public static T Min<T>(params T[] values)
			where T : IComparable
		{
			#region Check arguments
#if CHECK_ARGS
			if ((values == null) || (values.Length < 1))
			{
				throw new ArgumentNullException(nameof(values));
			}
#endif
			#endregion Check arguments

			var res = values[0];
#if SAFE_COMPARE
			IComparator<T> cmp = new SafeComparator<T>();
#else
			IComparator<T> cmp = new UnsafeComparator<T>();
#endif
			for (var i = 1L; i < values.LongLength; i++)
			{
				if (cmp.CompareValues(res, values[i]) > 0)
				{
					res = values[i];
				}
			}
			return res;
		}
	}
}
