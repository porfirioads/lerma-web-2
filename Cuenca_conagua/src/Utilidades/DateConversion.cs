using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Cuenca_conagua.src.Utilidades
{
    public class DateConversion
    {
        public static DateTime ConvertSqlDateToDateTime(string sqlDate)
        {
            return Convert.ToDateTime(sqlDate);
        }

        public static string ConvertDateTimeToSqlDate(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public static string ConvertDateTimeMonthDayString(DateTime dateTime)
        {
            return dateTime.ToString("MMM-yyyy", CultureInfo.InvariantCulture);
        }
    }
}