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
    /// Entidad que representa un registro de la tabla 
    /// 'almacenamiento_historico_chapala'.
    /// </summary>
    public class AlmacenamientoHistoricoChapala : IComparable<AlmacenamientoHistoricoChapala>, IJsonable
    {
        private DateTime fecha;
        private double almacenamiento;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public double Almacenamiento
        {
            get { return almacenamiento; }
            set { almacenamiento = value; }
        }

        /// <summary>
        /// Devuelve la instancia de la entidad con el identificador dado.
        /// </summary>
        /// <param name="fecha">
        /// Es el valor del campo que identifica al registro.
        /// </param>
        /// <returns>
        /// La instancia de la entidad o null si no se encontró un registro con
        /// el identificador dado.
        /// </returns>
        public static AlmacenamientoHistoricoChapala Find(DateTime fecha)
        {
            return ConexionBD.GetAlmacenamientoHistoricoChapala(fecha);
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
            if (Find(fecha) == null)
            {
                return ConexionBD.InsertarAlmacenamientoHistoricoChapala(this);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Devuelve todas las instancias de la entidad en la base de datos.
        /// </summary>
        /// <returns>
        /// La lista de las entidades.
        /// </returns>
        public static List<AlmacenamientoHistoricoChapala> All()
        {
            return ConexionBD.GetAllAlmacenamientoHistoricoChapala();
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
            json.Append("fecha: '").Append(DateConversion
                .ConvertDateTimeMonthDayString(fecha)).Append("', ");
            json.Append("almacenamiento: ").Append(almacenamiento).Append("");
            json.Append("}");
            return json.ToString();
        }

        public int CompareTo(AlmacenamientoHistoricoChapala other)
        {
            return fecha.CompareTo(other.fecha);
        }
    }
}