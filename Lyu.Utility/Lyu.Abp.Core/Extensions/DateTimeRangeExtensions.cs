using System;
using Abp.Timing;

namespace Lyu.Core.Extensions
{
    public static class DateTimeRangeExtensions
    {
        private static DateTime Now { get { return Clock.Now; } }
        /// <summary>
        /// 获取 上周的时间范围
        /// </summary>
        public static DateTimeRange LastWeek
        {
            get
            {
                DateTime now = Now;
                DayOfWeek[] weeks =
                {
                    DayOfWeek.Monday,
                    DayOfWeek.Tuesday,
                    DayOfWeek.Wednesday,
                    DayOfWeek.Thursday,
                    DayOfWeek.Friday,
                    DayOfWeek.Saturday,
                    DayOfWeek.Sunday
                };
                int index = Array.IndexOf(weeks, now.DayOfWeek);
                return new DateTimeRange(now.Date.AddDays(-index - 7), now.Date.AddDays(-index).AddMilliseconds(-1));
            }
        }

        /// <summary>
        /// 获取 本周的时间范围
        /// </summary>
        public static DateTimeRange ThisWeek
        {
            get
            {
                DateTime now = DateTime.Now;
                DayOfWeek[] weeks =
                {
                    DayOfWeek.Monday,
                    DayOfWeek.Tuesday,
                    DayOfWeek.Wednesday,
                    DayOfWeek.Thursday,
                    DayOfWeek.Friday,
                    DayOfWeek.Saturday,
                    DayOfWeek.Sunday
                };
                int index = Array.IndexOf(weeks, now.DayOfWeek);
                return new DateTimeRange(now.Date.AddDays(-index), now.Date.AddDays(7 - index).AddMilliseconds(-1));
            }
        }

        /// <summary>
        /// 获取 下周的时间范围
        /// </summary>
        public static DateTimeRange NextWeek
        {
            get
            {
                DateTime now = DateTime.Now;
                DayOfWeek[] weeks =
                {
                    DayOfWeek.Monday,
                    DayOfWeek.Tuesday,
                    DayOfWeek.Wednesday,
                    DayOfWeek.Thursday,
                    DayOfWeek.Friday,
                    DayOfWeek.Saturday,
                    DayOfWeek.Sunday
                };
                int index = Array.IndexOf(weeks, now.DayOfWeek);
                return new DateTimeRange(now.Date.AddDays(-index + 7), now.Date.AddDays(14 - index).AddMilliseconds(-1));
            }
        }
    }
}