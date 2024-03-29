﻿using Cuenca_conagua.src.Utilidades;
using System;
using System.Text;

namespace Cuenca_conagua.src.Entidades
{
    public class VolumenPiOld: IComparable<VolumenPiOld>, IJsonable
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

        public VolumenPiAutorizadoOld ToVolumenPiAutorizadoOld()
        {
            VolumenPiAutorizadoOld vol = new VolumenPiAutorizadoOld();
            SetVolumenPiOldAttributes(vol);
            return vol;
        }

        public VolumenPiUtilizadoOld ToVolumenPiUtilizadoOld()
        {
            VolumenPiUtilizadoOld vol = new VolumenPiUtilizadoOld();
            SetVolumenPiOldAttributes(vol);
            return vol;
        }

        private void SetVolumenPiOldAttributes(VolumenPiOld vol)
        {
            vol.Ciclo = ciclo;
            vol.PiAltoLerma = piAltoLerma;
            vol.PiRioQueretaro = piRioQueretaro;
            vol.PiBajio = piBajio;
            vol.PiAnguloDuero = piAnguloDuero;
            vol.PiBajoLerma = piBajoLerma;
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