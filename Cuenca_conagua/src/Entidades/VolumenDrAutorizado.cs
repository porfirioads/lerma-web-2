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
        /// <param name="ciclo">
        /// Es el valor del campo que identifica al registro.
        /// </param>
        /// <returns>
        /// La instancia de la entidad o null si no se encontró un registro con
        /// el identificador dado.
        /// </returns>
        public static VolumenDrAutorizado Find(string ciclo)
        {
            VolumenDr v = ConexionBD.GetVolumenDr(ciclo, ConexionBD.VOL_DR_AUTORIZADO);
            return v == null ? null : v.ToVolumenDrAutorizado();
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

        public static List<VolumenDr> All()
        {
            return ConexionBD.GetAllVolumenDr(ConexionBD.VOL_DR_AUTORIZADO);
        }
    }
}