using Cuenca_conagua.src.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Cuenca_conagua.src.Entidades
{
    /// <summary>
    /// Representa un registro del escurrimiento anual.
    /// </summary>
    public class EscurrimientoAnual : IComparable<EscurrimientoAnual>
    {
        private string ciclo;
        private double alzate;
        private double ramirez;
        private double tepetitlan;
        private double tepuxtepec;
        private double solis;
        private double begona; // begoña
        private double ameche;
        private double pericos;
        private double yuriria;
        private double salamanca;
        private double adjuntas;
        private double angulo;
        private double corrales;
        private double yurecuaro;
        private double duero;
        private double zula;
        private double chapala;

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
        /// Obtiene o establece el valor de alzate.
        /// </summary>
        public double Alzate
        {
            get
            {
                return alzate;
            }

            set
            {
                alzate = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de ramirez.
        /// </summary>
        public double Ramirez
        {
            get
            {
                return ramirez;
            }

            set
            {
                ramirez = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de tepetitlan.
        /// </summary>
        public double Tepetitlan
        {
            get
            {
                return tepetitlan;
            }

            set
            {
                tepetitlan = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de tepuxtepec.
        /// </summary>
        public double Tepuxtepec
        {
            get
            {
                return tepuxtepec;
            }

            set
            {
                tepuxtepec = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de solis.
        /// </summary>
        public double Solis
        {
            get
            {
                return solis;
            }

            set
            {
                solis = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de begona.
        /// </summary>
        public double Begona
        {
            get
            {
                return begona;
            }

            set
            {
                begona = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de ameche.
        /// </summary>
        public double Ameche
        {
            get
            {
                return ameche;
            }

            set
            {
                ameche = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de pericos.
        /// </summary>
        public double Pericos
        {
            get
            {
                return pericos;
            }

            set
            {
                pericos = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de yuriria.
        /// </summary>
        public double Yuriria
        {
            get
            {
                return yuriria;
            }

            set
            {
                yuriria = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de salamanca.
        /// </summary>
        public double Salamanca
        {
            get
            {
                return salamanca;
            }

            set
            {
                salamanca = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de adjuntas.
        /// </summary>
        public double Adjuntas
        {
            get
            {
                return adjuntas;
            }

            set
            {
                adjuntas = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de angulo.
        /// </summary>
        public double Angulo
        {
            get
            {
                return angulo;
            }

            set
            {
                angulo = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de corrales.
        /// </summary>
        public double Corrales
        {
            get
            {
                return corrales;
            }

            set
            {
                corrales = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de yurecuaro.
        /// </summary>
        public double Yurecuaro
        {
            get
            {
                return yurecuaro;
            }

            set
            {
                yurecuaro = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de duero.
        /// </summary>
        public double Duero
        {
            get
            {
                return duero;
            }

            set
            {
                duero = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de zula.
        /// </summary>
        public double Zula
        {
            get
            {
                return zula;
            }

            set
            {
                zula = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de chapala.
        /// </summary>
        public double Chapala
        {
            get
            {
                return chapala;
            }

            set
            {
                chapala = value;
            }
        }

        /// <summary>
        /// Obtiene el valor de la suma de todas las subcuenas.
        /// </summary>
        public double Total
        {
            get
            {
                return alzate + ramirez + tepetitlan + tepuxtepec + solis + begona
                + ameche + pericos + yuriria + salamanca + adjuntas + angulo
                + corrales + yurecuaro + duero + zula + chapala;
            }
        }

        /// <summary>
        /// Busca el registro de escurrimiento anual para el ciclo dado.
        /// </summary>
        /// <param name="ciclo">
        /// Es el ciclo a buscar.
        /// </param>
        /// <returns>
        /// La instancia del escurrimiento anual o null si no se encontro
        /// ningun registro para el ciclo dado.
        /// </returns>
        public static EscurrimientoAnual Find(string ciclo)
        {
            return ConexionBD.GetEscurrimientoAnual(ciclo);
        }

        /// <summary>
        /// Guarda o actualiza la instancia del escurrimiento anual actual.
        /// </summary>
        /// <returns>
        /// true si el registro fue guardado correctamente o false si no se
        /// pudo guardar.
        /// </returns>
        public bool Save()
        {
            if (Find(ciclo) == null)
            {
                return ConexionBD.InsertarEscurrimientoAnual(this);
            }
            else
            {
                // TODO Implementar update
                return false;
            }
        }

        /// <summary>
        /// Obtiene todos los registros del escurrimiento anual.
        /// </summary>
        /// <returns>
        /// Una lista con los registros o null si no existen registros de
        /// escurrimiento anual en la base de datos.
        /// </returns>
        public static List<EscurrimientoAnual> All()
        {
            return ConexionBD.GetAllEscurrimientoAnual();
        }

        /// <summary>
        /// Genera la representacion en String del objeto.
        /// </summary>
        /// <returns>
        /// Una cadena con el String.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Ciclo: {0}, alzate: {1, -10}, "
                + "ramirez: {2, -10}, tepetitlan: {3, -10}, "
                + "tepuxtepec: {4, -10}, solis: {5, -10}, begoña: {6, -10}, "
                + "ameche: {7, -10}, pericos: {8, -10}, yuriria: {9, -10}, "
                + "salamanca: {10, -10}, adjuntas: {11, -10}, "
                + "angulo: {12, -10}, corrales: {13, -10}, "
                + "yurecuaro: {14, -10}, duero: {15, -10}, zula: {16, -10}, "
                + "chapala: {17, -10}, total: {18, -10}", ciclo, alzate,
                ramirez, tepetitlan, tepuxtepec, solis, begona, ameche, pericos,
                yuriria, salamanca, adjuntas, angulo, corrales, yurecuaro,
                duero, zula, chapala, Total);
        }

        /// <summary>
        /// Genera la representacion en JSON del objeto.
        /// </summary>
        /// <returns>
        /// Una cadena con el JSON.
        /// </returns>
        public string ToJSON()
        {
            StringBuilder json = new StringBuilder();
            json.Append("{");
            json.Append("ciclo: ").Append("'").Append(ciclo).Append("'").Append(", ");
            json.Append("alzate: ").Append(alzate).Append(", ");
            json.Append("ramirez: ").Append(ramirez).Append(", ");
            json.Append("tepetitlan: ").Append(tepetitlan).Append(", ");
            json.Append("tepuxtepec: ").Append(tepuxtepec).Append(", ");
            json.Append("solis: ").Append(solis).Append(", ");
            json.Append("begona: ").Append(begona).Append(", ");
            json.Append("ameche: ").Append(ameche).Append(", ");
            json.Append("pericos: ").Append(pericos).Append(", ");
            json.Append("yuriria: ").Append(yuriria).Append(", ");
            json.Append("salamanca: ").Append(salamanca).Append(", ");
            json.Append("adjuntas: ").Append(adjuntas).Append(", ");
            json.Append("angulo: ").Append(angulo).Append(", ");
            json.Append("corrales: ").Append(corrales).Append(", ");
            json.Append("yurecuaro: ").Append(yurecuaro).Append(", ");
            json.Append("duero: ").Append(duero).Append(", ");
            json.Append("zula: ").Append(zula).Append(", ");
            json.Append("chapala: ").Append(chapala).Append(", ");
            json.Append("total: ").Append(Total);
            json.Append("}");
            return json.ToString();
        }

        /// <summary>
        /// Compara un EscurrimientoAnual con otro.
        /// </summary>
        /// <param name="other">
        /// Es el EscurrimientoAnual con el que se va a comparar el actual.
        /// </param>
        /// <returns>
        /// Un número negativo si el EscurrimientoAnual actual es menor, un 
        /// número positivo si el EscurrimientoAnual actual es mayor, o 0 si 
        /// son iguales.
        /// </returns>
        public int CompareTo(EscurrimientoAnual other)
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