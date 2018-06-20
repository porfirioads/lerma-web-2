using Cuenca_conagua.src.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Cuenca_conagua.src.Entidades
{
    public class AlmacenamientoPrincipal : IComparable<AlmacenamientoPrincipal>
    {
        private string anio;
        private double alzate;
        private double ramirez;
        private double tepetitlan;
        private double tepuxtepec;
        private double solis;
        private double yuriria;
        private double allende;
        private double mOcampo;
        private double purisima;
        private double chapala;

        public string Anio
        {
            get { return anio; }
            set { anio = value; }
        }

        public double Alzate
        {
            get { return alzate; }
            set { alzate = value; }
        }

        public double Ramirez
        {
            get { return ramirez; }
            set { ramirez = value; }
        }

        public double Tepetitlan
        {
            get { return tepetitlan; }
            set { tepetitlan = value; }
        }

        public double Tepuxtepec
        {
            get { return tepuxtepec; }
            set { tepuxtepec = value; }
        }

        public double Solis
        {
            get { return solis; }
            set { solis = value; }
        }

        public double Yuriria
        {
            get { return yuriria; }
            set { yuriria = value; }
        }

        public double Allende
        {
            get { return allende; }
            set { allende = value; }
        }

        public double MOcampo
        {
            get { return mOcampo; }
            set { mOcampo = value; }
        }

        public double Purisima
        {
            get { return purisima; }
            set { purisima = value; }
        }

        public double Chapala
        {
            get { return chapala; }
            set { chapala = value; }
        }

        /// <summary>
        /// Devuelve la instancia de la entidad con el identificador dado.
        /// </summary>
        /// <param name="anio">
        /// Es el valor del campo que identifica al registro.
        /// </param>
        /// <returns>
        /// La instancia de la entidad o null si no se encontró un registro con
        /// el identificador dado.
        /// </returns>
        public static AlmacenamientoPrincipal Find(string anio)
        {
            return ConexionBD.GetAlmacenamientoPrincipal(anio);
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
            if (Find(anio) == null)
            {
                return ConexionBD.InsertarAlmacenamientoPrincipal(this);
            }
            else
            {
                return false;
            }
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
            json.Append("{\n");
            json.Append("anio: '").Append(anio).Append("',\n");
            json.Append("alzate: ").Append(alzate).Append(",\n");
            json.Append("ramirez: ").Append(ramirez).Append(",\n");
            json.Append("tepetitlan: ").Append(tepetitlan).Append(",\n");
            json.Append("tepuxtepec: ").Append(tepuxtepec).Append(",\n");
            json.Append("solis: ").Append(solis).Append(",\n");
            json.Append("yuriria: ").Append(yuriria).Append(",\n");
            json.Append("allende: ").Append(allende).Append(",\n");
            json.Append("m_ocampo: ").Append(mOcampo).Append(",\n");
            json.Append("purisima: ").Append(purisima).Append(",\n");
            json.Append("chapala: ").Append(chapala).Append("\n");
            json.Append("}");
            return json.ToString();
        }

        /// <summary>
        /// Devuelve todas las instancias de la entidad en la base de datos.
        /// </summary>
        /// <returns>
        /// La lista de las entidades.
        /// </returns>
        public static List<AlmacenamientoPrincipal> All()
        {
            return ConexionBD.GetAllAlmacenamientoPrincipal();
        }

        public int CompareTo(AlmacenamientoPrincipal other)
        {
            string thisAnio = anio.Substring(4);
            string otherAnio = other.anio.Substring(4);

            if (thisAnio.StartsWith("9") && !otherAnio.StartsWith("9"))
            {
                return -1;
            }
            else if (!thisAnio.StartsWith("9") && otherAnio.StartsWith("9"))
            {
                return 1;
            }
            else
            {
                return thisAnio.CompareTo(otherAnio);
            }
        }
    }
}