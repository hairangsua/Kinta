using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    public static class NghiPhep
    {
        private static decimal ConvertTick2Day(long ticks)
        {
            return Math.Abs(Math.Floor(ticks / (24M * 60 * 60 * 10000000)));
        }

        public static decimal GetSoNgayNghi(string fromDateType, string toDateType, DateTime fromDate, DateTime toDate)
        {
            decimal soNgay = 0;
            if (fromDate.Date <= DateTime.MinValue || toDate.Date <= DateTime.MinValue)
            {
                return soNgay;
            }

            if (fromDate.Date > toDate.Date)
            {
                return soNgay;
            }

            if (fromDateType == Constant.BUOI_CHIEU && fromDate.DayOfWeek == DayOfWeek.Saturday)
            {
                return soNgay;
            }
            if (toDateType == Constant.BUOI_CHIEU && toDate.DayOfWeek == DayOfWeek.Saturday)
            {
                return soNgay;
            }

            if (toDate.DayOfWeek == DayOfWeek.Sunday || fromDate.DayOfWeek == DayOfWeek.Sunday)
            {
                return soNgay;
            }

            if (fromDate.Date == toDate.Date)
            {
                if (fromDateType == Constant.BUOI_CHIEU && toDateType == Constant.BUOI_SANG)
                {
                    return 0;
                }

                if (fromDateType == toDateType)
                {
                    return 0.5M;
                }

                if (fromDateType == Constant.BUOI_SANG && toDateType == Constant.BUOI_CHIEU)
                {
                    return 1;
                }
            }


            for (DateTime day = fromDate; day <= toDate; day = day.AddDays(1))
            {
                if (day.Date == fromDate.Date)
                {
                    if (fromDateType == Constant.BUOI_SANG)
                    {
                        if (day.DayOfWeek == DayOfWeek.Saturday)
                        {
                            soNgay += 0.5M;
                        }
                        else
                        {
                            soNgay += 1;
                        }

                    }
                    else if (fromDateType == Constant.BUOI_CHIEU)
                    {
                        soNgay += 0.5M;
                    }
                    continue;
                }

                if (day.Date == toDate.Date)
                {
                    if (day.DayOfWeek == DayOfWeek.Saturday)
                    {
                        if (toDateType == Constant.BUOI_SANG)
                        {
                            soNgay += 0.5M;
                        }
                    }
                    else
                    {
                        if (toDateType == Constant.BUOI_SANG)
                        {
                            soNgay += 0.5M;
                        }
                        else if (toDateType == Constant.BUOI_CHIEU)
                        {
                            soNgay += 1;
                        }
                    }

                    continue;
                }

                if (day.DayOfWeek == DayOfWeek.Saturday)
                {
                    soNgay += 0.5M;
                    continue;
                }
                if (day.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }

                soNgay += 1;
            }

            return soNgay;
        }

        public static class Constant
        {
            public const string BUOI_SANG = "BUOI_SANG";

            public const string BUOI_CHIEU = "BUOI_CHIEU";
        }
    }
}
