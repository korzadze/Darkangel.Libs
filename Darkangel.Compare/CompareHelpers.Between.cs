using System;

namespace Darkangel.Compare
{
    public static partial class CompareHelpers
    {
        /// <summary>
        /// <para>Проверка, что значение находится между границами</para>
        /// </summary>
        /// <typeparam name="T">Тип значения</typeparam>
        /// <param name="value">Проверяемое значение</param>
        /// <param name="min">Нижняя граница</param>
        /// <param name="max">Верхняя граница</param>
        /// <param name="inclusive">Включать границы в сравнение или нет</param>
        /// <returns>Результат проверки</returns>
        /// <remarks>2021-04-18</remarks>
        public static bool Between<T>(this T value, T min, T max, bool inclusive = true)
            where T: IComparable =>
            (inclusive)?
                (value.CompareTo(min) >= 0 && value.CompareTo(max) <= 0):
                (value.CompareTo(min) > 0 && value.CompareTo(max) < 0);
        /// <summary>
        /// <para>Проверка, что значение находится между границами (исключая границы)</para>
        /// </summary>
        /// <typeparam name="T">Тип значения</typeparam>
        /// <param name="value">Проверяемое значение</param>
        /// <param name="min">Нижняя граница</param>
        /// <param name="max">Верхняя граница</param>
        /// <returns>Результат проверки</returns>
        /// <remarks>2021-04-18</remarks>
        public static bool BetweenEx<T>(this T value, T min, T max)
            where T : IComparable =>
            Between(value, min, max, true);
        /// <summary>
        /// <para>Проверка, что значение находится между границами (включая границы)</para>
        /// </summary>
        /// <typeparam name="T">Тип значения</typeparam>
        /// <param name="value">Проверяемое значение</param>
        /// <param name="min">Нижняя граница</param>
        /// <param name="max">Верхняя граница</param>
        /// <returns>Результат проверки</returns>
        /// <remarks>2021-04-18</remarks>
        public static bool BetweenInc<T>(this T value, T min, T max)
            where T : IComparable =>
            Between(value, min, max, true);
    }
}
