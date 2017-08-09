﻿using Cuenca_conagua.src.BaseDatos;
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
        /// <param name="ciclo">
        /// Es el valor del campo que identifica al registro.
        /// </param>
        /// <returns>
        /// La instancia de la entidad o null si no se encontró un registro con
        /// el identificador dado.
        /// </returns>
        public static VolumenPiAutorizado Find(string ciclo)
        {
            VolumenPi v = ConexionBD.GetVolumenPi(ciclo, ConexionBD.VOL_PI_AUTORIZADO);
            return v == null ? null : v.ToVolumenPiAutorizado();
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
        /// <returns>
        /// La lista de las entidades.
        /// </returns>
        public static List<VolumenPiAutorizado> All()
        {
            return ToVolumenPiAutorizadoList(ConexionBD
                .GetAllVolumenPi(ConexionBD.VOL_PI_AUTORIZADO));
        }
    }
}