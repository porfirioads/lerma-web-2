using System;
using System.Collections.Generic;
using System.Linq;
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