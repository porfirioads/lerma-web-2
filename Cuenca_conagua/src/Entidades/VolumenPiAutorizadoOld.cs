using Cuenca_conagua.src.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuenca_conagua.src.Entidades
{
    public class VolumenPiAutorizadoOld: VolumenPiOld
    {
        /// <summary>
        /// Devuelve la instancia de la entidad con el identificador dado.
        /// </summary>
        public static VolumenPiOld Find(string ciclo)
        {
            return ConexionBD.GetVolumenPiOld(ciclo, ConexionBD.VOL_PI_AUTORIZADO);
        }

        /// <summary>
        /// Inserta o actualiza la entidad en la base de datos.
        /// </summary>
        public bool Save()
        {
            if (Find(Ciclo) == null)
            {
                return ConexionBD.InsertarVolumenPiOld(this,
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
        public static List<VolumenPiOld> All()
        {
            return ConexionBD.GetAllVolumenPiOld(ConexionBD.VOL_PI_AUTORIZADO);
        }
    }
}