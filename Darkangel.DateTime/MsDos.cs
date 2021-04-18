namespace Darkangel.DateTime
{
    /// <summary>
    /// Утилиты для работы с форматами MS-DOS
    /// </summary>
    public static class MsDos
    {
        // YYYYYYYmmmmDDDDD HHHHHmmmmmmSSSSS
        private const int
            SecondsMask = 0x1f,
            SecondsShift = 0,
            MinutesMask = 0x3f,
            MinutesShift = 5,
            HoursMask = 0x1f,
            HoursShift = 11,
            DaysMask = 0x1f,
            DaysShift = 0,
            MonthsMask = 0x0f,
            MonthsShift = 5,
            YearsMask = 0x3f,
            YearsShift = 9;

        /// <summary>
        /// <para>Преобразовать дату и время из формата MS-DOS в <see cref="System.DateTime"/></para>
        /// <para>date: YYYYYYYmmmmDDDDD<br/>
        /// time: HHHHHmmmmmmSSSSS</para>
        /// </summary>
        /// <param name="date">Дата в формате MS-DOS</param>
        /// <param name="time">Время в формате MS-DOS</param>
        /// <returns>Дата и время в формате <see cref="System.DateTime"/></returns>
        /// <remarks>2021-04-18</remarks>
        public static System.DateTime ToDateTime(ushort date, ushort time) =>
            new (
                    ((date >> YearsShift) & YearsMask) + 1980,
                    ((date >> MonthsShift) & MonthsMask),
                    ((date >> DaysShift) & DaysMask),
                    ((time >> HoursShift) & HoursMask),
                    ((time >> MinutesShift) & MinutesMask),
                    ((time >> SecondsShift) & SecondsMask) * 2
                );
    }
}
