using Cuenca_conagua.src.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuenca_conagua.src.Entidades
{
    /// <summary>
    /// Representa un registro del volumen autorizado de las PI.
    /// </summary>
    public class VolumenPiAutorizado : VolumenPi
    {
        /// <summary>
        /// Devuelve la instancia de la entidad con el identificador dado.
        /// </summary>
        public static VolumenPi Find(string ciclo)
        {
            return ConexionBD.GetVolumenPi(ciclo, ConexionBD.VOL_PI_AUTORIZADO);
        }

        /// <summary>
        /// Inserta o actualiza la entidad en la base de datos.
        /// </summary>
        public bool Save()
        {
            if (Find(Ciclo) == null)
            {
                return ConexionBD.InsertarVolumenPi(this,
                    ConexionBD.VOL_PI_AUTORIZADO);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Devuelve todas las instancias de la entidad en la base de datos.
        /// </summary>
        public static List<VolumenPi> All()
        {
            return ConexionBD.GetAllVolumenPi(ConexionBD.VOL_PI_AUTORIZADO);
        }
    }
}