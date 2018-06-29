using Cuenca_conagua.src.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Cuenca_conagua.src.Entidades
{
    /// <summary>
    /// Representa un registro del volumen utilizado de los DR.
    /// </summary>
    public class VolumenDrUtilizado : VolumenDr
    {
        /// <summary>
        /// Devuelve la instancia de la entidad con el identificador dado.
        /// </summary>
        public static VolumenDrUtilizado Find(string ciclo)
        {
            VolumenDr v = ConexionBD.GetVolumenDr(ciclo, ConexionBD.VOL_DR_UTILIZADO);
            return v == null ? null : v.ToVolumenDrUtilizado();
        }

        /// <summary>
        /// Inserta o actualiza la entidad en la base de datos.
        /// </summary>
        public bool Save()
        {
            if (Find(Ciclo) == null)
            {
                return ConexionBD.InsertarVolumenDr(this,
                    ConexionBD.VOL_DR_UTILIZADO);
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
            return ConexionBD.GetAllVolumenDr(ConexionBD.VOL_DR_UTILIZADO);
        }
    }
}