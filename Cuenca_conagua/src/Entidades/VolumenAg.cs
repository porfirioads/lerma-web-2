using Cuenca_conagua.src.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Cuenca_conagua.src.Entidades
{
    public class VolumenAg: IComparable<VolumenAg>, IJsonable
    {
        private string ciclo;
        private double volumen;

        public string Ciclo
        {
            get
            {
                return ciclo;
            }

            set
            {
                ciclo = value;
            }
        }

        public double Volumen
        {
            get
            {
                return volumen;
            }

            set
            {
                volumen = value;
            }
        }

        public int CompareTo(VolumenAg other)
        {
            if (DateUtils.AnioMenorAl2000(ciclo) && !DateUtils.AnioMenorAl2000(other.ciclo))
            {
                return -1;
            }
            else if (!DateUtils.AnioMenorAl2000(ciclo) && DateUtils.AnioMenorAl2000(other.ciclo))
            {
                return 1;
            }
            else
            {
                return ciclo.CompareTo(other.ciclo);
            }
        }

        public string ToJSON()
        {
            StringBuilder json = new StringBuilder();
            json.Append("{\n    ");
            json.Append("ciclo: ").Append("'").Append(ciclo).Append("'").Append(",\n    ");
            json.Append("volumen: ").Append(volumen).Append("\n");
            json.Append("}");
            return json.ToString();
        }

        public VolumenAgAsignado ToVolumenAgAsignado()
        {
            VolumenAgAsignado vol = new VolumenAgAsignado();
            SetVolumenAgAttributes(vol);
            return vol;
        }

        public VolumenAgAutorizado ToVolumenAgAutorizado()
        {
            VolumenAgAutorizado vol = new VolumenAgAutorizado();
            SetVolumenAgAttributes(vol);
            return vol;
        }

        public VolumenAgUtilizado ToVolumenAgUtilizado()
        {
            VolumenAgUtilizado vol = new VolumenAgUtilizado();
            SetVolumenAgAttributes(vol);
            return vol;
        }

        private void SetVolumenAgAttributes(VolumenAg vol)
        {
            vol.Ciclo = ciclo;
            vol.volumen = volumen;
        }
    }
}