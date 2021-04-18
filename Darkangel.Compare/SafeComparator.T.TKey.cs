using System;

namespace Darkangel.Compare
{
    /// <summary>
    /// <para>Безопасный (с проверкой "пустых" значений) класс для сравниения значения с ключем</para>
    /// </summary>
    /// <typeparam name="T">Тип значения</typeparam>
    /// <typeparam name="TKey">Тип ключа</typeparam>
    /// <remarks>2021-04-18</remarks>
    public class SafeComparator<T, TKey>: IComparator<T, TKey>
		where T : IComparable<TKey>
    {
		/// <inheritdoc/>
		public int CompareValues(T val, TKey key)
        {
			if (typeof(T).IsValueType)
			{ // Левое значение не может быть "пустым"
				return val.CompareTo(key); // Оставляем сравнение на долю реализатора типа
			}
			else
			{ // Левое значение может быть "пустым"
				if (val is null)
				{ // и, таки, "пустое": ищем другие варианты сравнения
					if (key is null)
					{
						return 0; // Два "пустых" значения равны
					}
					else
					{
						if (key is IComparable<T> cmp)
						{
							return -cmp.CompareTo(val);
						}
						else
						{
							// Приплыли... вариантов сравнения больше нет!
							// Будем проще: null < not_null
							return -1;
						}
					}
				}
				else
				{
					return val.CompareTo(key); // Оставляем сравнение на долю реализатора типа
				}
			}
		}
	}
}
