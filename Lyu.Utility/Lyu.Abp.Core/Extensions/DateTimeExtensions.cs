using System;

namespace Lyu.Core.Extensions
{
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 获取时间相对唯一字符串
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="milsec">是否使用毫秒</param>
        /// <returns></returns>
        public static string ToUniqueString(this DateTime dateTime, bool milsec = false)
        {
            int sedonds = dateTime.Hour * 3600 + dateTime.Minute * 60 + dateTime.Second;
            string value = string.Format("{0}{1}{2}", dateTime.ToString("yy"), dateTime.DayOfYear, sedonds);
            return milsec ? value + dateTime.ToString("fff") : value;
        }
    }
}