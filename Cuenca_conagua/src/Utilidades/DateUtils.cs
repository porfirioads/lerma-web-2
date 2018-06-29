using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Cuenca_conagua.src.Utilidades
{
    public class DateUtils
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

        /// <summary>
        /// Determina si un año de dos cifras es menor al 2000.
        /// </summary>
        /// <param name="anioDosCifras">
        /// El año de dos cifras que se desea evaluar.
        /// </param>
        /// <returns>
        /// true si el año es menor al 2000 o false en caso contrario.
        /// </returns>
        public static bool AnioMenorAl2000(string anioDosCifras)
        {
            string[] primerDigitoAniosMenor2000 = { "5", "6", "7", "8", "9" };

            foreach (string primerDigito in primerDigitoAniosMenor2000)
            {
                if (anioDosCifras.StartsWith(primerDigito))
                {
                    return true;
                }
            }

            return false;
        }
    }
}