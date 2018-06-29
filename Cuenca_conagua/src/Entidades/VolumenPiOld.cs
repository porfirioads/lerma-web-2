using Cuenca_conagua.src.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Cuenca_conagua.src.Entidades
{
    public class VolumenPiOld
    {
        private string ciclo;
        private double piAltoLerma;
        private double piRioQueretaro;
        private double piBajio;
        private double piAnguloDuero;
        private double piBajoLerma;

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

        public double PiAltoLerma
        {
            get
            {
                return piAltoLerma;
            }

            set
            {
                piAltoLerma = value;
            }
        }

        public double PiRioQueretaro
        {
            get
            {
                return piRioQueretaro;
            }

            set
            {
                piRioQueretaro = value;
            }
        }

        public double PiBajio
        {
            get
            {
                return piBajio;
            }

            set
            {
                piBajio = value;
            }
        }

        public double PiAnguloDuero
        {
            get
            {
                return piAnguloDuero;
            }

            set
            {
                piAnguloDuero = value;
            }
        }

        public double PiBajoLerma
        {
            get
            {
                return piBajoLerma;
            }

            set
            {
                piBajoLerma = value;
            }
        }

        public double Total
        {
            get
            {
                return piAltoLerma + piRioQueretaro + piBajio + piAnguloDuero +
                    piBajoLerma;
            }
        }

        public string ToJSON()
        {
        StringBuilder json = new StringBuilder();
            json.Append("{\n    ");
            json.Append("ciclo: ").Append("'").Append(ciclo).Append("'").Append(",\n    ");
            json.Append("piAltoLerma: ").Append(piAltoLerma).Append(",\n    ");
            json.Append("piRioQueretaro: ").Append(piRioQueretaro).Append(",\n    ");
            json.Append("piBajio: ").Append(piBajio).Append(",\n    ");
            json.Append("piAnguloDuero: ").Append(piAnguloDuero).Append(",\n    ");
            json.Append("piBajoLerma: ").Append(piBajoLerma).Append(",\n    ");
            json.Append("total: ").Append(Total).Append("\n");
            json.Append("}");
            return json.ToString();
        }

        public int CompareTo(VolumenPiOld other)
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
    }
}