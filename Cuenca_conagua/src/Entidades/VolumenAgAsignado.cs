using Cuenca_conagua.src.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuenca_conagua.src.Entidades
{
    public class VolumenAgAsignado: VolumenAg
    {
        public static VolumenAg Find(string ciclo)
        {
            return ConexionBD.GetVolumenAg(ciclo, ConexionBD.VOL_AG_ASIGNADO);
        }

        public bool Save()
        {
            if (Find(Ciclo) == null)
            {
                return ConexionBD.InsertarVolumenAg(this,
                    ConexionBD.VOL_AG_ASIGNADO);
            }
            else
            {
                return false;
            }
        }

        public static List<VolumenAg> All()
        {
            return ConexionBD.GetAllVolumenAg(ConexionBD.VOL_AG_ASIGNADO);
        }
    }
}