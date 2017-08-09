using Cuenca_conagua.src.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Cuenca_conagua.src.Entidades
{
    /// <summary>
    /// Representa un registro de la precipitacion media
    /// </summary>
    public class PrecipitacionMedia : IComparable<PrecipitacionMedia>
    {
        private string ciclo;
        private double nov;
        private double dic;
        private double ene;
        private double feb;
        private double mar;
        private double abr;
        private double may;
        private double jun;
        private double jul;
        private double ago;
        private double sep;
        private double oct;

        /// <summary>
        /// Obtiene o establece el valor de ciclo.
        /// </summary>
        public string Ciclo
        {
            get
            {
                return ciclo;
            }

            set
            {
                ciclo = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de nov.
        /// </summary>
        public double Nov
        {
            get
            {
                return nov;
            }

            set
            {
                nov = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de dic.
        /// </summary>
        public double Dic
        {
            get
            {
                return dic;
            }

            set
            {
                dic = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de ene.
        /// </summary>
        public double Ene
        {
            get
            {
                return ene;
            }

            set
            {
                ene = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de feb.
        /// </summary>
        public double Feb
        {
            get
            {
                return feb;
            }

            set
            {
                feb = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de mar.
        /// </summary>
        public double Mar
        {
            get
            {
                return mar;
            }

            set
            {
                mar = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de abr.
        /// </summary>
        public double Abr
        {
            get
            {
                return abr;
            }

            set
            {
                abr = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de may.
        /// </summary>
        public double May
        {
            get
            {
                return may;
            }

            set
            {
                may = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de jun.
        /// </summary>
        public double Jun
        {
            get
            {
                return jun;
            }

            set
            {
                jun = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de jul.
        /// </summary>
        public double Jul
        {
            get
            {
                return jul;
            }

            set
            {
                jul = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de ago.
        /// </summary>
        public double Ago
        {
            get
            {
                return ago;
            }

            set
            {
                ago = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de sep.
        /// </summary>
        public double Sep
        {
            get
            {
                return sep;
            }

            set
            {
                sep = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de oct.
        /// </summary>
        public double Oct
        {
            get
            {
                return oct;
            }

            set
            {
                oct = value;
            }
        }

        /// <summary>
        /// Obtiene la suma de todos los meses.
        /// </summary>
        public double Total
        {
            get
            {
                return nov + dic + ene + feb + mar + abr + may + jun + jul + ago
                + sep + oct;
            }
        }

        /// <summary>
        /// Obtiene la representación en string del objeto.
        /// </summary>
        /// <returns>
        /// El string del objeto.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Ciclo: {0, -10}. nov: {1, -20}, " +
                "dic: {2, -20}, ene: {3, -20}, feb: {4, -20}, mar: {5, -20}, "
                + "abr: {6, -20}, may: {7, -20}, jun: {8, -20}, jul: {9, -20}, "
                + "ago: {10, -20}, sep: {11, -20}, oct: {12, -20}, "
                + "total: {13, -20}", ciclo, nov, dic, ene, feb, mar, abr, may,
                jun, jul, ago, sep, oct, Total);
        }

        /// <summary>
        /// Devuelve la instancia de la entidad con el identificador dado.
        /// </summary>
        /// <param name="ciclo">
        /// Es el valor del campo que identifica al registro.
        /// </param>
        /// <returns>
        /// La instancia de la entidad o null si no se encontró un registro con
        /// el identificador dado.
        /// </returns>
        public static PrecipitacionMedia Find(string ciclo)
        {
            return ConexionBD.GetPrecipitacionMedia(ciclo);
        }

        /// <summary>
        /// Inserta o actualiza la entidad en la base de datos.
        /// </summary>
        /// <returns>
        /// true si la entidad fue insertada o actualizada correctamente o false
        /// si no se pudo guardar.
        /// </returns>
        public bool Save()
        {
            if (Find(ciclo) == null)
            {
                return ConexionBD.InsertarPrecipitacionMedia(this);
            }
            else
            {
                // TODO Implementar update
                return false;
            }
        }

        /// <summary>
        /// Devuelve todas las instancias de la entidad en la base de datos.
        /// </summary>
        /// <returns>
        /// La lista de las entidades.
        /// </returns>
        public static List<PrecipitacionMedia> All()
        {
            return ConexionBD.GetAllPrecipitacionMedia();
        }

        /// <summary>
        /// Genera la representación en JSON del objeto.
        /// </summary>
        /// <returns>
        /// Una cadena con el JSON.
        /// </returns>
        public string ToJSON()
        {
            StringBuilder json = new StringBuilder();
            json.Append("{");
            json.Append("ciclo: ").Append("'").Append(ciclo).Append("'").Append(", ");
            json.Append("nov: ").Append(nov).Append(", ");
            json.Append("dic: ").Append(dic).Append(", ");
            json.Append("ene: ").Append(ene).Append(", ");
            json.Append("feb: ").Append(feb).Append(", ");
            json.Append("mar: ").Append(mar).Append(", ");
            json.Append("abr: ").Append(abr).Append(", ");
            json.Append("may: ").Append(may).Append(", ");
            json.Append("jun: ").Append(jun).Append(", ");
            json.Append("jul: ").Append(jul).Append(", ");
            json.Append("ago: ").Append(ago).Append(", ");
            json.Append("sep: ").Append(sep).Append(", ");
            json.Append("oct: ").Append(oct).Append(", ");
            json.Append("total: ").Append(Total);
            json.Append("}");
            return json.ToString();
        }

        /// <summary>
        /// Compara una PrecipitacionMedia con otra.
        /// </summary>
        /// <param name="other">
        /// Es la PrecipitacionMedia con la que se va a comparar la actual.
        /// </param>
        /// <returns>
        /// Un número negativo si la PrecipitacionMedia actual es menor, un 
        /// número positivo si la PrecipitacionMedia actual es mayor, o 0 si 
        /// son iguales.
        /// </returns>
        public int CompareTo(PrecipitacionMedia other)
        {
            if (ciclo.StartsWith("9") && !other.ciclo.StartsWith("9"))
            {
                return -1;
            }
            else if (!ciclo.StartsWith("9") && other.ciclo.StartsWith("9"))
            {
                return 1;
            }
            else
            {
                return ciclo.CompareTo(other.ciclo);
            }
        }
    }
}