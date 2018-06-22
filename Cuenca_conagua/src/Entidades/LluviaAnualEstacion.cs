using Cuenca_conagua.src.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Cuenca_conagua.src.Entidades
{
    public class LluviaAnualEstacion: IComparable<LluviaAnualEstacion>
    {
        private string ciclo;
        private double laeCelaya;
        private double laeGuanajuato;
        private double laeIrapuato;
        private double laeAdjuntas;
        private double laeLeon;
        private double laePPenuelitas;
        private double laePSolis;
        private double laeSanFelipe;
        private double laeSanLuisDeLaPaz;
        private double laeYuriria;
        private double laeChapala;
        private double laeFuerte;
        private double laeTule;
        private double laeTizapan;
        private double laeYurecuaro;
        private double laeAtlacomulco;
        private double laeTolucaRectoria;
        private double laeChincua;
        private double laeCuitzeoAu;
        private double laeMelchorOcampo;
        private double laeMorelia;
        private double laeTepuxtepec;
        private double laeZacapu;
        private double laeZamora;
        private double laeQueretaroObs;

        public string Ciclo
        {
            get { return ciclo; }
            set { ciclo = value; }
        }

        public double LaeCelaya
        {
            get { return laeCelaya; }
            set { laeCelaya = value; }
        }

        public double LaeGuanajuato
        {
            get { return laeGuanajuato; }
            set { laeGuanajuato = value; }
        }

        public double LaeIrapuato
        {
            get { return laeIrapuato; }
            set { laeIrapuato = value; }
        }

        public double LaeAdjuntas
        {
            get { return laeAdjuntas; }
            set { laeAdjuntas = value; }
        }

        public double LaeLeon
        {
            get { return laeLeon; }
            set { laeLeon = value; }
        }

        public double LaePPenuelitas
        {
            get { return laePPenuelitas; }
            set { laePPenuelitas = value; }
        }

        public double LaePSolis
        {
            get { return laePSolis; }
            set { laePSolis = value; }
        }

        public double LaeSanFelipe
        {
            get { return laeSanFelipe; }
            set { laeSanFelipe = value; }
        }

        public double LaeSanLuisDeLaPaz
        {
            get { return laeSanLuisDeLaPaz; }
            set { laeSanLuisDeLaPaz = value; }
        }

        public double LaeYuriria
        {
            get { return laeYuriria; }
            set { laeYuriria = value; }
        }

        public double LaeChapala
        {
            get { return laeChapala; }
            set { laeChapala = value; }
        }

        public double LaeFuerte
        {
            get { return laeFuerte; }
            set { laeFuerte = value; }
        }

        public double LaeTule
        {
            get { return laeTule; }
            set { laeTule = value; }
        }

        public double LaeTizapan
        {
            get { return laeTizapan; }
            set { laeTizapan = value; }
        }

        public double LaeYurecuaro
        {
            get { return laeYurecuaro; }
            set { laeYurecuaro = value; }
        }

        public double LaeAtlacomulco
        {
            get { return laeAtlacomulco; }
            set { laeAtlacomulco = value; }
        }

        public double LaeTolucaRectoria
        {
            get { return laeTolucaRectoria; }
            set { laeTolucaRectoria = value; }
        }

        public double LaeChincua
        {
            get { return laeChincua; }
            set { laeChincua = value; }
        }

        public double LaeCuitzeoAu
        {
            get { return laeCuitzeoAu; }
            set { laeCuitzeoAu = value; }
        }

        public double LaeMelchorOcampo
        {
            get { return laeMelchorOcampo; }
            set { laeMelchorOcampo = value; }
        }

        public double LaeMorelia
        {
            get { return laeMorelia; }
            set { laeMorelia = value; }
        }

        public double LaeTepuxtepec
        {
            get { return laeTepuxtepec; }
            set { laeTepuxtepec = value; }
        }

        public double LaeZacapu
        {
            get { return laeZacapu; }
            set { laeZacapu = value; }
        }

        public double LaeZamora
        {
            get { return laeZamora; }
            set { laeZamora = value; }
        }

        public double LaeQueretaroObs
        {
            get { return laeQueretaroObs; }
            set { laeQueretaroObs = value; }
        }

        public double Media
        {
            get
            {
                return (laeCelaya + laeGuanajuato + laeIrapuato + laeAdjuntas +
                    laeLeon + LaePPenuelitas + laePSolis + laeSanFelipe +
                    laeSanLuisDeLaPaz + laeYuriria + laeChapala + laeFuerte +
                    laeTule + laeTizapan + laeYurecuaro + laeAtlacomulco +
                    laeTolucaRectoria + laeChincua + laeCuitzeoAu +
                    laeMelchorOcampo + laeMorelia + laeTepuxtepec +
                    laeZacapu + laeZamora + laeQueretaroObs) / 25;
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
            json.Append("{\n    ");
            json.Append("ciclo: ").Append("'").Append(ciclo).Append("'").Append(",\n    ");
            json.Append("laeCelaya: ").Append(laeCelaya).Append(",\n    ");
            json.Append("laeGuanajuato: ").Append(laeGuanajuato).Append(",\n    ");
            json.Append("laeIrapuato: ").Append(laeIrapuato).Append(",\n    ");
            json.Append("laeAdjuntas: ").Append(laeAdjuntas).Append(",\n    ");
            json.Append("laeLeon: ").Append(laeLeon).Append(",\n    ");
            json.Append("laePPenuelitas: ").Append(laePPenuelitas).Append(",\n    ");
            json.Append("laePSolis: ").Append(laePSolis).Append(",\n    ");
            json.Append("laeSanFelipe: ").Append(laeSanFelipe).Append(",\n    ");
            json.Append("laeSanLuisDeLaPaz: ").Append(laeSanLuisDeLaPaz).Append(",\n    ");
            json.Append("laeYuriria: ").Append(laeYuriria).Append(",\n    ");
            json.Append("laeChapala: ").Append(laeChapala).Append(",\n    ");
            json.Append("laeFuerte: ").Append(laeFuerte).Append(",\n    ");
            json.Append("laeTule: ").Append(laeTule).Append(",\n    ");
            json.Append("laeTizapan: ").Append(laeTizapan).Append(",\n    ");
            json.Append("laeYurecuaro: ").Append(laeYurecuaro).Append(",\n    ");
            json.Append("laeAtlacomulco: ").Append(laeAtlacomulco).Append(",\n    ");
            json.Append("laeTolucaRectoria: ").Append(laeTolucaRectoria).Append(",\n    ");
            json.Append("laeChincua: ").Append(laeChincua).Append(",\n    ");
            json.Append("laeCuitzeoAu: ").Append(laeCuitzeoAu).Append(",\n    ");
            json.Append("laeMelchorOcampo: ").Append(laeMelchorOcampo).Append(",\n    ");
            json.Append("laeMorelia: ").Append(laeMorelia).Append(",\n    ");
            json.Append("laeTepuxtepec: ").Append(laeTepuxtepec).Append(",\n    ");
            json.Append("laeZacapu: ").Append(laeZacapu).Append(",\n    ");
            json.Append("laeZamora: ").Append(laeZamora).Append(",\n    ");
            json.Append("laeQueretaroObs: ").Append(laeQueretaroObs).Append("\n");
            json.Append("}");
            return json.ToString();
        }

        /// <summary>
        /// Devuelve la instancia de la entidad con el identificador dado.
        /// </summary>
        /// <param name="ciclo">
        /// Es el valor del campo que identifica al registro.
        /// </param>
        /// <returns>
        /// La instancia de la entidad o null si no se encontró un registro con
        /// el identificador dado.
        /// </returns>
        public static LluviaAnualEstacion Find(string ciclo)
        {
            return ConexionBD.GetLluviaAnualEstacion(ciclo);
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
            if (Find(ciclo) == null)
            {
                return ConexionBD.InsertarLluviaAnualEstacion(this);
            }
            else
            {
                // TODO Implementar update
                return false;
            }
        }

        /// <summary>
        /// Devuelve todas las instancias de la entidad en la base de datos.
        /// </summary>
        /// <returns>
        /// La lista de las entidades.
        /// </returns>
        public static List<LluviaAnualEstacion> All()
        {
            return ConexionBD.GetAllLluviaAnualEstacion();
        }

        /// <summary>
        /// Compara una PrecipitacionMedia con otra.
        /// </summary>
        /// <param name="other">
        /// Es la PrecipitacionMedia con la que se va a comparar la actual.
        /// </param>
        /// <returns>
        /// Un número negativo si la PrecipitacionMedia actual es menor, un 
        /// número positivo si la PrecipitacionMedia actual es mayor, o 0 si 
        /// son iguales.
        /// </returns>
        public int CompareTo(LluviaAnualEstacion other)
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