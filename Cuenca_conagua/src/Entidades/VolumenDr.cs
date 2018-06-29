using Cuenca_conagua.src.BaseDatos;
using Cuenca_conagua.src.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Cuenca_conagua.src.Entidades
{
    /// <summary>
    /// Es la clase padre para los volumenes autorizados, asignados y 
    /// utilizados de los DR.
    /// </summary>
    public class VolumenDr : IComparable<VolumenDr>, IJsonable
    {
        private string ciclo;
        private double dr033;
        private double dr045;
        private double dr011;
        private double dr085;
        private double dr087;
        private double dr022;
        private double dr061;
        private double dr024;
        private double dr013;

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
        /// Obtiene o establece el valor de dr033.
        /// </summary>
        public double Dr033
        {
            get
            {
                return dr033;
            }

            set
            {
                dr033 = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de dr045.
        /// </summary>
        public double Dr045
        {
            get
            {
                return dr045;
            }

            set
            {
                dr045 = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de dr011.
        /// </summary>
        public double Dr011
        {
            get
            {
                return dr011;
            }

            set
            {
                dr011 = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de dr085.
        /// </summary>
        public double Dr085
        {
            get
            {
                return dr085;
            }

            set
            {
                dr085 = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de dr087.
        /// </summary>
        public double Dr087
        {
            get
            {
                return dr087;
            }

            set
            {
                dr087 = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de dr022.
        /// </summary>
        public double Dr022
        {
            get
            {
                return dr022;
            }

            set
            {
                dr022 = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de dr061.
        /// </summary>
        public double Dr061
        {
            get
            {
                return dr061;
            }

            set
            {
                dr061 = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de dr024.
        /// </summary>
        public double Dr024
        {
            get
            {
                return dr024;
            }

            set
            {
                dr024 = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de dr013.
        /// </summary>
        public double Dr013
        {
            get
            {
                return dr013;
            }

            set
            {
                dr013 = value;
            }
        }

        /// <summary>
        /// Obtiene el valor de la suma de todos los DR.
        /// </summary>
        public double Total
        {
            get
            {
                return dr033 + dr045 + dr011 + dr085 + dr087 + dr022 + dr061
                + dr024 + dr013;
            }
        }

        /// <summary>
        /// Convierte a una instancia de VolumenDrAsignado.
        /// </summary>
        /// <returns>
        /// La instancia de VolumenDrAsignado.
        /// </returns>
        public VolumenDrAsignado ToVolumenDrAsignado()
        {
            VolumenDrAsignado v = new VolumenDrAsignado();
            v.Ciclo = ciclo;
            v.Dr033 = dr033;
            v.Dr045 = dr045;
            v.Dr011 = dr011;
            v.Dr085 = dr085;
            v.Dr087 = dr087;
            v.Dr022 = dr022;
            v.Dr061 = dr061;
            v.Dr024 = dr024;
            v.Dr013 = dr013;
            return v;
        }

        /// <summary>
        /// Convierte a una instancia de VolumenDrAutorizado.
        /// </summary>
        /// <returns>
        /// La instancia de VolumenDrAutorizado.
        /// </returns>
        public VolumenDrAutorizado ToVolumenDrAutorizado()
        {
            VolumenDrAutorizado v = new VolumenDrAutorizado();
            v.Ciclo = ciclo;
            v.Dr033 = dr033;
            v.Dr045 = dr045;
            v.Dr011 = dr011;
            v.Dr085 = dr085;
            v.Dr087 = dr087;
            v.Dr022 = dr022;
            v.Dr061 = dr061;
            v.Dr024 = dr024;
            v.Dr013 = dr013;
            return v;
        }

        /// <summary>
        /// Convierte a una instancia de VolumenDrUtilizado.
        /// </summary>
        /// <returns>
        /// La instancia de VolumenDrUtilizado.
        /// </returns>
        public VolumenDrUtilizado ToVolumenDrUtilizado()
        {
            VolumenDrUtilizado v = new VolumenDrUtilizado();
            v.Ciclo = ciclo;
            v.Dr033 = dr033;
            v.Dr045 = dr045;
            v.Dr011 = dr011;
            v.Dr085 = dr085;
            v.Dr087 = dr087;
            v.Dr022 = dr022;
            v.Dr061 = dr061;
            v.Dr024 = dr024;
            v.Dr013 = dr013;
            return v;
        }

        /// <summary>
        /// Convierte una lista de VolumenDr a una lista de VolumenDrUtilizado
        /// </summary>
        /// <param name="listGenerica">
        /// Es la lista de VolumenDr a convertir.
        /// </param>
        /// <returns>
        /// La lista de VolumenDrUtilizado.
        /// </returns>
        public static List<VolumenDrUtilizado> ToVolumenDrUtilizadoList(
            List<VolumenDr> listGenerica)
        {
            List<VolumenDrUtilizado> volDrUt = new List<VolumenDrUtilizado>();
            foreach (VolumenDr vdr in listGenerica)
            {
                volDrUt.Add(vdr.ToVolumenDrUtilizado());
            }
            return volDrUt;
        }

        /// <summary>
        /// Convierte una lista de VolumenDr a una lista de VolumenDrAutorizado
        /// </summary>
        /// <param name="listGenerica">
        /// Es la lista de VolumenDr a convertir.
        /// </param>
        /// <returns>
        /// La lista de VolumenDrAutorizado.
        /// </returns>
        public static List<VolumenDrAutorizado> ToVolumenDrAutorizadoList(
            List<VolumenDr> listGenerica)
        {
            List<VolumenDrAutorizado> volDrAu = new List<VolumenDrAutorizado>();
            foreach (VolumenDr vdr in listGenerica)
            {
                volDrAu.Add(vdr.ToVolumenDrAutorizado());
            }
            return volDrAu;
        }

        /// <summary>
        /// Convierte una lista de VolumenDr a una lista de VolumenDrAsignado
        /// </summary>
        /// <param name="listGenerica">
        /// Es la lista de VolumenDr a convertir.
        /// </param>
        /// <returns>
        /// La lista de VolumenDrAsignado.
        /// </returns>
        public static List<VolumenDrAsignado> ToVolumenDrAsigndoList(
            List<VolumenDr> listGenerica)
        {
            List<VolumenDrAsignado> volDrAs = new List<VolumenDrAsignado>();
            foreach (VolumenDr vdr in listGenerica)
            {
                volDrAs.Add(vdr.ToVolumenDrAsignado());
            }
            return volDrAs;
        }

        public const int MENORES = 100000;
        public const int MAYORES = 100001;

        public static void filtrarVolumenesDr(
            List<VolumenDr> volumenes, string ciclo, int comparador)
        {
            VolumenDr volComparador = new VolumenDr();
            volComparador.Ciclo = ciclo;
            List<VolumenDr> volumenesToDelete = new List<VolumenDr>();

            foreach (VolumenDr volumen in volumenes)
            {
                if (comparador == MENORES && volumen.CompareTo(volComparador) >= 0)
                    volumenesToDelete.Add(volumen);
                else if (comparador == MAYORES && volumen.CompareTo(volComparador) <= 0)
                    volumenesToDelete.Add(volumen);
            }

            foreach (VolumenDr toDelete in volumenesToDelete)
            {
                Logger.AddToLog(toDelete.ciclo + " is not" + (comparador == MAYORES ? " > " : " < ") + ciclo, true);
                volumenes.Remove(toDelete);
            }
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
            json.Append("{\n    ");
            json.Append("ciclo: ").Append("'").Append(ciclo).Append("'").Append(",\n    ");
            json.Append("dr033: ").Append(dr033).Append(",\n    ");
            json.Append("dr045: ").Append(dr045).Append(",\n    ");
            json.Append("dr011: ").Append(dr011).Append(",\n    ");
            json.Append("dr085: ").Append(dr085).Append(",\n    ");
            json.Append("dr087: ").Append(dr087).Append(",\n    ");
            json.Append("dr022: ").Append(dr022).Append(",\n    ");
            json.Append("dr061: ").Append(dr061).Append(",\n    ");
            json.Append("dr024: ").Append(dr024).Append(",\n    ");
            json.Append("dr013: ").Append(dr013).Append(",\n    ");
            json.Append("total: ").Append(Total).Append("\n");
            json.Append("}");
            return json.ToString();
        }

        public override string ToString()
        {
            return ToJSON();
        }

        /// <summary>
        /// Compara un VolumenDr con otro.
        /// </summary>
        /// <param name="other">
        /// Es el VolumenDr con el que se va a comparar el actual.
        /// </param>
        /// <returns>
        /// Un número negativo si el VolumenDr actual es menor, un número 
        /// positivo si el VolumenDr actual es mayor, o 0 si son iguales.
        /// </returns>
        public int CompareTo(VolumenDr other)
        {
            if (DateUtils.AnioMenorAl2000(ciclo) && !DateUtils.AnioMenorAl2000(other.ciclo))
            {
                return -1;
            }
            else if (!DateUtils.AnioMenorAl2000(ciclo) && DateUtils.AnioMenorAl2000(other.ciclo))
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