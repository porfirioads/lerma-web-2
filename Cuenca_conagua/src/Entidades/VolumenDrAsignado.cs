using Cuenca_conagua.src.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Cuenca_conagua.src.Entidades
{
    /// <summary>
    /// Representa un registro del volumen asignado de los DR.
    /// </summary>
    public class VolumenDrAsignado : VolumenDr
    {
        /// <summary>
        /// Devuelve la instancia de la entidad con el identificador dado.
        /// </summary>
        public static VolumenDr Find(string ciclo)
        {
            return ConexionBD.GetVolumenDr(ciclo, ConexionBD.VOL_DR_ASIGNADO);
        }

        /// <summary>
        /// Inserta o actualiza la entidad en la base de datos.
        /// </summary>
        public bool Save()
        {
            if (Find(Ciclo) == null)
            {
                return ConexionBD.InsertarVolumenDr(this,
                    ConexionBD.VOL_DR_ASIGNADO);
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
            return ConexionBD.GetAllVolumenDr(ConexionBD.VOL_DR_ASIGNADO);
        }
    }
}