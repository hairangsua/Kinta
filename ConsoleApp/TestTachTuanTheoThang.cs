using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ConsoleApp
{
    public static class FirstDayOfWeekUtility
    {
        /// <summary>
        /// Returns the first day of the week that the specified
        /// date is in using the current culture. 
        /// </summary>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        {
            CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
            return GetFirstDayOfWeek(dayInWeek, defaultCultureInfo);
        }

        /// <summary>
        /// Returns the first day of the week that the specified date 
        /// is in. 
        /// </summary>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
        {
            DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
            DateTime firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }
    }

    public class TestTachTuanTheoThang
    {
        public static void Run()
        {
            var date = FirstDayOfWeekUtility.GetFirstDayOfWeek(new DateTime(2019, 2, 2));

             var w = GetRange(2019, 2);
        }

        public static List<Week> GetRange(int year, int month)
        {
            DateTime start = new DateTime(year, month, 1);

            DateTime end = new DateTime(year, month, DateTime.DaysInMonth(start.Year, start.Month));

            var weeks = new List<Week>();

            var startDate = DateTime.MinValue;
            var endDate = DateTime.MinValue;
            for (DateTime date = start; date <= end; date = date.AddDays(1))
            {
                startDate = start;

                if (date.DayOfWeek == DayOfWeek.Sunday)
                {
                    weeks.Add(new Week(date));
                }
            }

            return weeks;
        }

        public class Week
        {
            public DateTime Start { get; private set; }

            public DateTime End { get { return Start.AddDays(6); } }

            public Week(DateTime start)
            {
                Start = start;
            }
        }
    }
}
