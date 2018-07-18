using Cuenca_conagua.src.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuenca_conagua.src.Entidades
{
    public class VolumenAgAutorizado: VolumenAg
    {
        public static VolumenAg Find(string ciclo)
        {
            return ConexionBD.GetVolumenAg(ciclo, ConexionBD.VOL_AG_AUTORIZADO);
        }

        public bool Save()
        {
            if (Find(Ciclo) == null)
            {
                return ConexionBD.InsertarVolumenAg(this,
                    ConexionBD.VOL_AG_AUTORIZADO);
            }
            else
            {
                return false;
            }
        }

        public static List<VolumenAg> All()
        {
            return ConexionBD.GetAllVolumenAg(ConexionBD.VOL_AG_AUTORIZADO);
        }
    }
}