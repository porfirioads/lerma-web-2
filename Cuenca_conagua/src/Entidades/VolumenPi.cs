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
    public class VolumenPi : IComparable<VolumenPi>
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
            VolumenPiAsignado v = new VolumenPiAsignado();
            v.Ciclo = ciclo;
            v.PiAlzate = PiAlzate;
            v.PiRamirez = piRamirez;
            v.PiTepetitlan = piTepetitlan;
            v.PiTepuxtepec = piTepuxtepec;
            v.PiSolis = piSolis;
            v.PiBegona = piBegona;
            v.PiQueretaro = piQueretaro;
            v.PiPericos = piPericos;
            v.PiAdjuntas = piAdjuntas;
            v.PiAngulo = piAngulo;
            v.PiCorrales = piCorrales;
            v.PiYurecuaro = piYurecuaro;
            v.PiDuero = piDuero;
            v.PiZula = piZula;
            v.PiChapala = piChapala;
            return v;
        }

        /// <summary>
        /// Convierte a una instancia de VolumenPiAutorizado.
        /// </summary>
        /// <returns>
        /// La instancia de VolumenPiAutorizado.
        /// </returns>
        public VolumenPiAutorizado ToVolumenPiAutorizado()
        {
            VolumenPiAutorizado v = new VolumenPiAutorizado();
            v.Ciclo = ciclo;
            v.PiAlzate = PiAlzate;
            v.PiRamirez = piRamirez;
            v.PiTepetitlan = piTepetitlan;
            v.PiTepuxtepec = piTepuxtepec;
            v.PiSolis = piSolis;
            v.PiBegona = piBegona;
            v.PiQueretaro = piQueretaro;
            v.PiPericos = piPericos;
            v.PiAdjuntas = piAdjuntas;
            v.PiAngulo = piAngulo;
            v.PiCorrales = piCorrales;
            v.PiYurecuaro = piYurecuaro;
            v.PiDuero = piDuero;
            v.PiZula = piZula;
            v.PiChapala = piChapala;
            return v;
        }

        /// <summary>
        /// Convierte a una instancia de VolumenPiUtilizado.
        /// </summary>
        /// <returns>
        /// La instancia de VolumenPiUtilizado.
        /// </returns>
        public VolumenPiUtilizado ToVolumenPiUtilizado()
        {
            VolumenPiUtilizado v = new VolumenPiUtilizado();
            v.Ciclo = ciclo;
            v.PiAlzate = PiAlzate;
            v.PiRamirez = piRamirez;
            v.PiTepetitlan = piTepetitlan;
            v.PiTepuxtepec = piTepuxtepec;
            v.PiSolis = piSolis;
            v.PiBegona = piBegona;
            v.PiQueretaro = piQueretaro;
            v.PiPericos = piPericos;
            v.PiAdjuntas = piAdjuntas;
            v.PiAngulo = piAngulo;
            v.PiCorrales = piCorrales;
            v.PiYurecuaro = piYurecuaro;
            v.PiDuero = piDuero;
            v.PiZula = piZula;
            v.PiChapala = piChapala;
            return v;
        }

        /// <summary>
        /// Convierte una lista de VolumenPi a una lista de VolumenPiAsignado
        /// </summary>
        /// <param name="listGenerica">
        /// Es la lista de VolumenPi a convertir.
        /// </param>
        /// <returns>
        /// La lista de VolumenPiAsignado.
        /// </returns>
        public static List<VolumenPiAsignado> ToVolumenPiAsignadoList(
            List<VolumenPi> listGenerica)
        {
            List<VolumenPiAsignado> volPiAs = new List<VolumenPiAsignado>();
            foreach (VolumenPi vpi in listGenerica)
            {
                volPiAs.Add(vpi.ToVolumenPiAsignado());
            }
            return volPiAs;
        }

        /// <summary>
        /// Convierte una lista de VolumenPi a una lista de VolumenPiAutorizado
        /// </summary>
        /// <param name="listGenerica">
        /// Es la lista de VolumenPi a convertir.
        /// </param>
        /// <returns>
        /// La lista de VolumenPiAutorizado.
        /// </returns>
        public static List<VolumenPiAutorizado> ToVolumenPiAutorizadoList(
            List<VolumenPi> listGenerica)
        {
            List<VolumenPiAutorizado> volPiAu = new List<VolumenPiAutorizado>();
            foreach (VolumenPi vpi in listGenerica)
            {
                volPiAu.Add(vpi.ToVolumenPiAutorizado());
            }
            return volPiAu;
        }

        /// <summary>
        /// Convierte una lista de VolumenPi a una lista de VolumenPiUtilizado
        /// </summary>
        /// <param name="listGenerica">
        /// Es la lista de VolumenPi a convertir.
        /// </param>
        /// <returns>
        /// La lista de VolumenPiUtilizado.
        /// </returns>
        public static List<VolumenPiUtilizado> ToVolumenPiUtilizadoList(
            List<VolumenPi> listGenerica)
        {
            List<VolumenPiUtilizado> volPiUt = new List<VolumenPiUtilizado>();
            foreach (VolumenPi vpi in listGenerica)
            {
                volPiUt.Add(vpi.ToVolumenPiUtilizado());
            }
            return volPiUt;
        }

        /// <summary>
        /// Genera la representación en string del objeto.
        /// </summary>
        /// <returns>
        /// La cadena que representa al objeto.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Ciclo: {0, -10}. P.I. Alzate: {1, -10}, "
                + "P.I. Ramirez: {2, -10}, P.I. Tepetitlan: {3, -10}, "
                + "P.I. Tepuxtepec: {4, -10}, P.I. Solis: {5, -10}"
                + "P.I. La Begoña: {6, -10}, P.I. Queretro: {7, -10}"
                + "P.I. Pericos: {8, -10}, P.I. Adjuntas: {9, -10}"
                + "P.I. Angulo: {10, -10}, P.I. Corrales: {11, -10}"
                + "P.I. Yurecuaro: {12, -10}, P.I. Duero: {13, -10}"
                + "P.I. Zula: {14, -10}, P.I. Solis: {15, -10}, "
                + "Total: {16, -10}", ciclo, piAlzate, piRamirez, piTepetitlan,
                piTepuxtepec, piSolis, piBegona, piQueretaro, piPericos,
                piAdjuntas, piAngulo, piCorrales, piYurecuaro, piDuero, piZula,
                piChapala, Total);
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
            json.Append("{");
            json.Append("ciclo: ").Append("'").Append(ciclo).Append("'").Append(", ");
            json.Append("piAlzate: ").Append(piAlzate).Append(", ");
            json.Append("piRamirez: ").Append(piRamirez).Append(", ");
            json.Append("piTepetitlan: ").Append(piTepetitlan).Append(", ");
            json.Append("piTepuxtepec: ").Append(piTepuxtepec).Append(", ");
            json.Append("piSolis: ").Append(piSolis).Append(", ");
            json.Append("piBegona: ").Append(piBegona).Append(", ");
            json.Append("piQueretaro: ").Append(piQueretaro).Append(", ");
            json.Append("piPericos: ").Append(piPericos).Append(", ");
            json.Append("piAdjuntas: ").Append(piAdjuntas).Append(", ");
            json.Append("piAngulo: ").Append(piAngulo).Append(", ");
            json.Append("piCorrales: ").Append(piCorrales).Append(", ");
            json.Append("piYurecuaro: ").Append(piYurecuaro).Append(", ");
            json.Append("piDuero: ").Append(piDuero).Append(", ");
            json.Append("piZula: ").Append(piZula).Append(", ");
            json.Append("piChapala: ").Append(piChapala).Append(", ");
            json.Append("total: ").Append(Total);
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
            if (ciclo.StartsWith("9") && !other.ciclo.StartsWith("9"))
            {
                return -1;
            }
            else if (!ciclo.StartsWith("9") && other.ciclo.StartsWith("9"))
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