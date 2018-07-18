using Cuenca_conagua.src.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cuenca_conagua.src.Entidades
{
    public class VolumenGtAsignado : VolumenGt
    {
        public static VolumenGt Find(string ciclo)
        {
            return ConexionBD.GetVolumenGt(ciclo, ConexionBD.VOL_GT_ASIGNADO);
        }

        public bool Save()
        {
            if (Find(Ciclo) == null)
            {
                return ConexionBD.InsertarVolumenGt(this,
                    ConexionBD.VOL_GT_ASIGNADO);
            }
            else
            {
                return false;
            }
        }

        public static List<VolumenGt> All()
        {
            return ConexionBD.GetAllVolumenGt(ConexionBD.VOL_GT_ASIGNADO);
        }
    }
}