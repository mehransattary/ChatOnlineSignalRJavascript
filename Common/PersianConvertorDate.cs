
using System.Globalization;

namespace Common.Utilities
{
    public static class PersianConvertorDate
    {
        public static string ToShamsi(this string value)
        {
            PersianCalendar pc=new PersianCalendar();
            return pc.GetYear(Convert.ToDateTime(value)) + "/" + pc.GetMonth(Convert.ToDateTime(value)).ToString("00") + "/" +
                   pc.GetDayOfMonth(Convert.ToDateTime(value)).ToString("00");
        }
        public static string ToShamsi(this DateTime value)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear((value)) + "/" + pc.GetMonth((value)).ToString("00") + "/" +
                   pc.GetDayOfMonth((value)).ToString("00");
        }

        //public static string ToTimeShamsi(this DateTime value)
        //{
        //    PersianCalendar pc = new PersianCalendar();
        //    return pc.GetHour((value)) + ":" + pc.GetMinute((value)) + ":" +
        //           pc.GetSecond((value));

        //}

        public static string ToStringTimePicker(this DateTime value)
        {

            //عصر
            if (value.Hour > 12)
            {
                int hours = value.Hour - 12;
                int minute = value.Minute;
                var time = $"{(hours < 12 ? ($"0{hours}") : hours)}:{minute} عصر";
                return time;
            }
            //صبح
            else
            {
                int hours = value.Hour;
                int minute = value.Minute;
                var time = $"{(hours < 12 ? ($"0{hours}") : hours)}:{minute}0  صبح";
                return time;
            }
            return "";
        }
    }
}