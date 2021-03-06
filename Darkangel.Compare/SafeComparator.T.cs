using System;

namespace Darkangel.Compare
{
    /// <summary>
    /// <para>Безопасный (с проверкой "пустых" значений) класс для сравнения двух значений</para>
    /// </summary>
    /// <typeparam name="T">Тип значений</typeparam>
    /// <remarks>2021-04-18</remarks>
    public class SafeComparator<T> : IComparator<T>
		where T : IComparable
	{
		/// <inheritdoc/>
		public int CompareValues(T val1, T val2)
		{
			if (typeof(T).IsValueType) // Может ли тип иметь "пустые" значения или нет
			{ // Не может
				return val1.CompareTo(val2); // Сравниваем два "не пустых" значения
			}
			else
			{ // Может
				if (val1 is null)
				{ //Если левое значение "пусто"
					if (val2 is null)
					{ //и правое значение "пусто"
						return 0; // то два "пустых" значения равны
					}
					else
					{ //а правое значение "не пусто"
						return -val2.CompareTo(val1); // Оставляем сравнение на долю реализатора типа
					}
				}
				else
				{ //Если левое значение не "пусто"
					return val1.CompareTo(val2); // Оставляем сравнение на долю реализатора типа
				}
			}
		}
	}
}
