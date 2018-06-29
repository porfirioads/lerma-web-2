using Cuenca_conagua.src.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Cuenca_conagua.src.Entidades
{
    /// <summary>
    /// Representa un registro del volumen autorizado de los DR.
    /// </summary>
    public class VolumenDrAutorizado : VolumenDr
    {
        /// <summary>
        /// Devuelve la instancia de la entidad con el identificador dado.
        /// </summary>
        public static VolumenDrAutorizado Find(string ciclo)
        {
            VolumenDr v = ConexionBD.GetVolumenDr(ciclo, ConexionBD.VOL_DR_AUTORIZADO);
            return v == null ? null : v.ToVolumenDrAutorizado();
        }

        /// <summary>
        /// Inserta o actualiza la entidad en la base de datos.
        /// </summary>
        public bool Save()
        {
            if (Find(Ciclo) == null)
            {
                return ConexionBD.InsertarVolumenDr(this,
                    ConexionBD.VOL_DR_AUTORIZADO);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Devuelve todas las instancias de la entidad en la base de datos.
        /// </summary>
        public static List<VolumenDr> All()
        {
            return ConexionBD.GetAllVolumenDr(ConexionBD.VOL_DR_AUTORIZADO);
        }
    }
}