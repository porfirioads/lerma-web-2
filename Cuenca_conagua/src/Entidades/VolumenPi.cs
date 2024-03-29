﻿using Cuenca_conagua.src.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Cuenca_conagua.src.Entidades
{
    /// <summary>
    /// Es la clase padre para los volumenes autorizados, asignados y 
    /// utilizados de las PI.
    /// </summary>
    public class VolumenPi : IComparable<VolumenPi>, IJsonable
    {
        private string ciclo;
        private double piAlzate;
        private double piRamirez;
        private double piTepetitlan;
        private double piTepuxtepec;
        private double piSolis;
        private double piBegona; // La Begoña
        private double piQueretaro;
        private double piPericos;
        private double piAdjuntas;
        private double piAngulo;
        private double piCorrales;
        private double piYurecuaro;
        private double piDuero;
        private double piZula;
        private double piChapala;

        /// <summary>
        /// Obtiene o establece el valor de ciclo.
        /// </summary>
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

        /// <summary>
        /// Obtiene o establece el valor de piAlzate.
        /// </summary>
        public double PiAlzate
        {
            get
            {
                return piAlzate;
            }

            set
            {
                piAlzate = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de piRamirez.
        /// </summary>
        public double PiRamirez
        {
            get
            {
                return piRamirez;
            }

            set
            {
                piRamirez = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de piTepetitlan.
        /// </summary>
        public double PiTepetitlan
        {
            get
            {
                return piTepetitlan;
            }

            set
            {
                piTepetitlan = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de piTepuxtepec.
        /// </summary>
        public double PiTepuxtepec
        {
            get
            {
                return piTepuxtepec;
            }

            set
            {
                piTepuxtepec = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de piSolis.
        /// </summary>
        public double PiSolis
        {
            get
            {
                return piSolis;
            }

            set
            {
                piSolis = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de piBegona.
        /// </summary>
        public double PiBegona
        {
            get
            {
                return piBegona;
            }

            set
            {
                piBegona = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de piQueretaro.
        /// </summary>
        public double PiQueretaro
        {
            get
            {
                return piQueretaro;
            }

            set
            {
                piQueretaro = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de piPericos.
        /// </summary>
        public double PiPericos
        {
            get
            {
                return piPericos;
            }

            set
            {
                piPericos = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de piAdjuntas.
        /// </summary>
        public double PiAdjuntas
        {
            get
            {
                return piAdjuntas;
            }

            set
            {
                piAdjuntas = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de piAngulo.
        /// </summary>
        public double PiAngulo
        {
            get
            {
                return piAngulo;
            }

            set
            {
                piAngulo = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de piCorrales.
        /// </summary>
        public double PiCorrales
        {
            get
            {
                return piCorrales;
            }

            set
            {
                piCorrales = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de piYurecuaro.
        /// </summary>
        public double PiYurecuaro
        {
            get
            {
                return piYurecuaro;
            }

            set
            {
                piYurecuaro = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de piDuero.
        /// </summary>
        public double PiDuero
        {
            get
            {
                return piDuero;
            }

            set
            {
                piDuero = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de piZula.
        /// </summary>
        public double PiZula
        {
            get
            {
                return piZula;
            }

            set
            {
                piZula = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de piChapala.
        /// </summary>
        public double PiChapala
        {
            get
            {
                return piChapala;
            }

            set
            {
                piChapala = value;
            }
        }

        /// <summary>
        /// Obtiene el valor de la suma de todos los PI.
        /// </summary>
        public double Total
        {
            get
            {
                return piAlzate + piRamirez + piTepetitlan + piTepuxtepec
                + piSolis + piBegona + piQueretaro + piPericos + piAdjuntas
                + piAngulo + piCorrales + piYurecuaro + piDuero + piZula
                + piChapala;
            }
        }

        /// <summary>
        /// Convierte a una instancia de VolumenPiAsignado.
        /// </summary>
        /// <returns>
        /// La instancia de VolumenPiAsignado.
        /// </returns>
        public VolumenPiAsignado ToVolumenPiAsignado()
        {
            VolumenPiAsignado vol = new VolumenPiAsignado();
            SetVolumenPiAttributes(vol);
            return vol;
        }

        /// <summary>
        /// Convierte a una instancia de VolumenPiAutorizado.
        /// </summary>
        /// <returns>
        /// La instancia de VolumenPiAutorizado.
        /// </returns>
        public VolumenPiAutorizado ToVolumenPiAutorizado()
        {
            VolumenPiAutorizado vol = new VolumenPiAutorizado();
            SetVolumenPiAttributes(vol);
            return vol;
        }

        /// <summary>
        /// Convierte a una instancia de VolumenPiUtilizado.
        /// </summary>
        /// <returns>
        /// La instancia de VolumenPiUtilizado.
        /// </returns>
        public VolumenPiUtilizado ToVolumenPiUtilizado()
        {
            VolumenPiUtilizado vol = new VolumenPiUtilizado();
            SetVolumenPiAttributes(vol);
            return vol;
        }

        private void SetVolumenPiAttributes(VolumenPi vol)
        {
            vol.Ciclo = ciclo;
            vol.PiAlzate = PiAlzate;
            vol.PiRamirez = piRamirez;
            vol.PiTepetitlan = piTepetitlan;
            vol.PiTepuxtepec = piTepuxtepec;
            vol.PiSolis = piSolis;
            vol.PiBegona = piBegona;
            vol.PiQueretaro = piQueretaro;
            vol.PiPericos = piPericos;
            vol.PiAdjuntas = piAdjuntas;
            vol.PiAngulo = piAngulo;
            vol.PiCorrales = piCorrales;
            vol.PiYurecuaro = piYurecuaro;
            vol.PiDuero = piDuero;
            vol.PiZula = piZula;
            vol.PiChapala = piChapala;
        }

        /// <summary>
        /// Genera la representación en JSON del objeto.
        /// </summary>
        /// <returns>
        /// Una cadena con el JSON.
        /// </returns>
        public string ToJSON()
        {
            StringBuilder json = new StringBuilder();
            json.Append("{\n    ");
            json.Append("ciclo: ").Append("'").Append(ciclo).Append("'").Append(",\n    ");
            json.Append("piAlzate: ").Append(piAlzate).Append(",\n    ");
            json.Append("piRamirez: ").Append(piRamirez).Append(",\n    ");
            json.Append("piTepetitlan: ").Append(piTepetitlan).Append(",\n    ");
            json.Append("piTepuxtepec: ").Append(piTepuxtepec).Append(",\n    ");
            json.Append("piSolis: ").Append(piSolis).Append(",\n    ");
            json.Append("piBegona: ").Append(piBegona).Append(",\n    ");
            json.Append("piQueretaro: ").Append(piQueretaro).Append(",\n    ");
            json.Append("piPericos: ").Append(piPericos).Append(",\n    ");
            json.Append("piAdjuntas: ").Append(piAdjuntas).Append(",\n    ");
            json.Append("piAngulo: ").Append(piAngulo).Append(",\n    ");
            json.Append("piCorrales: ").Append(piCorrales).Append(",\n    ");
            json.Append("piYurecuaro: ").Append(piYurecuaro).Append(",\n    ");
            json.Append("piDuero: ").Append(piDuero).Append(",\n    ");
            json.Append("piZula: ").Append(piZula).Append(",\n    ");
            json.Append("piChapala: ").Append(piChapala).Append(",\n    ");
            json.Append("total: ").Append(Total).Append("\n");
            json.Append("}");
            return json.ToString();
        }

        /// <summary>
        /// Compara un VolumenPi con otro.
        /// </summary>
        /// <param name="other">
        /// Es el VolumenPi con el que se va a comparar el actual.
        /// </param>
        /// <returns>
        /// Un número negativo si el VolumenPi actual es menor, un número 
        /// positivo si el VolumenPi actual es mayor, o 0 si son iguales.
        /// </returns>
        public int CompareTo(VolumenPi other)
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