using Cuenca_conagua.src.BaseDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Cuenca_conagua.src.Entidades
{
    public class LluviaAnualEstacion
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

        public string Ciclo { get => ciclo; set => ciclo = value; }
        public double LaeCelaya { get => laeCelaya; set => laeCelaya = value; }
        public double LaeGuanajuato { get => laeGuanajuato; set => laeGuanajuato = value; }
        public double LaeIrapuato { get => laeIrapuato; set => laeIrapuato = value; }
        public double LaeAdjuntas { get => laeAdjuntas; set => laeAdjuntas = value; }
        public double LaeLeon { get => laeLeon; set => laeLeon = value; }
        public double LaePPenuelitas { get => laePPenuelitas; set => laePPenuelitas = value; }
        public double LaePSolis { get => laePSolis; set => laePSolis = value; }
        public double LaeSanFelipe { get => laeSanFelipe; set => laeSanFelipe = value; }
        public double LaeSanLuisDeLaPaz { get => laeSanLuisDeLaPaz; set => laeSanLuisDeLaPaz = value; }
        public double LaeYuriria { get => laeYuriria; set => laeYuriria = value; }
        public double LaeChapala { get => laeChapala; set => laeChapala = value; }
        public double LaeFuerte { get => laeFuerte; set => laeFuerte = value; }
        public double LaeTule { get => laeTule; set => laeTule = value; }
        public double LaeTizapan { get => laeTizapan; set => laeTizapan = value; }
        public double LaeYurecuaro { get => laeYurecuaro; set => laeYurecuaro = value; }
        public double LaeAtlacomulco { get => laeAtlacomulco; set => laeAtlacomulco = value; }
        public double LaeTolucaRectoria { get => laeTolucaRectoria; set => laeTolucaRectoria = value; }
        public double LaeChincua { get => laeChincua; set => laeChincua = value; }
        public double LaeCuitzeoAu { get => laeCuitzeoAu; set => laeCuitzeoAu = value; }
        public double LaeMelchorOcampo { get => laeMelchorOcampo; set => laeMelchorOcampo = value; }
        public double LaeMorelia { get => laeMorelia; set => laeMorelia = value; }
        public double LaeTepuxtepec { get => laeTepuxtepec; set => laeTepuxtepec = value; }
        public double LaeZacapu { get => laeZacapu; set => laeZacapu = value; }
        public double LaeZamora { get => laeZamora; set => laeZamora = value; }
        public double LaeQueretaroObs { get => laeQueretaroObs; set => laeQueretaroObs = value; }

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
        /// Obtiene la representación en string del objeto.
        /// </summary>
        /// <returns>
        /// El string del objeto.
        /// </returns>
        public override string ToString()
        {
            return string.Format("Ciclo: {0, -10}. LaeCelaya: {1, -20}, " +
                "LaeGuanajuato: {2, -20}, LaeIrapuato: {3, -20}, " + 
                "LaeAdjuntas: {4, -20}, LaeLeon: {5, -20}, " + 
                "LaePPenuelitas: {6, -20}, LaePSolis: {7, -20}, " + 
                "LaeSanFelipe: {8, -20}, LaeSanLuisDeLaPaz: {9, -20}, " + 
                "LaeYuriria: {10, -20}, LaeChapala: {11, -20}, " + 
                "LaeFuerte: {12, -20}, LaeTule: {13, -20}, " +
                "LaeTizapan: {14, -20}, LaeYurecuaro: {15, -20}, " + 
                "LaeAtlacomulco: {16, -20}, LaeTolucaRectoria: {17, -20}, " +
                "LaeChincua: {18, -20}, LaeCuitzeoAu: {19, -20}, " +
                "LaeMelchorOcampo: {20, -20}, LaeMorelia: {21, -20}, " + 
                "LaeTepuxtepec: {22, -20}, LaeZacapu: {23, -20}, " +
                "LaeZamora: {24, -20}, LaeQueretaroObs: {25, -20}, " + 
                "media: {26, -20}", ciclo, laeCelaya, laeGuanajuato, 
                laeIrapuato, laeAdjuntas, laeLeon, LaePPenuelitas, laePSolis,
                laeSanFelipe, laeSanLuisDeLaPaz, laeYuriria, laeChapala,
                laeFuerte, laeTule, laeTizapan, laeYurecuaro, laeAtlacomulco,
                laeTolucaRectoria, laeChincua, laeCuitzeoAu, laeMelchorOcampo,
                laeMorelia, laeTepuxtepec, laeZacapu, laeZamora, 
                laeQueretaroObs, Media);
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
            json.Append("laeCelaya: ").Append(laeCelaya).Append(", ");
            json.Append("laeGuanajuato: ").Append(laeGuanajuato).Append(", ");
            json.Append("laeIrapuato: ").Append(laeIrapuato).Append(", ");
            json.Append("laeAdjuntas: ").Append(laeAdjuntas).Append(", ");
            json.Append("laeLeon: ").Append(laeLeon).Append(", ");
            json.Append("laePPenuelitas: ").Append(laePPenuelitas).Append(", ");
            json.Append("laePSolis: ").Append(laePSolis).Append(", ");
            json.Append("laeSanFelipe: ").Append(laeSanFelipe).Append(", ");
            json.Append("laeSanLuisDeLaPaz: ").Append(laeSanLuisDeLaPaz).Append(", ");
            json.Append("laeYuriria: ").Append(laeYuriria).Append(", ");
            json.Append("laeChapala: ").Append(laeChapala).Append(", ");
            json.Append("laeFuerte: ").Append(laeFuerte).Append(", ");
            json.Append("laeTule: ").Append(laeTule).Append(", ");
            json.Append("laeTizapan: ").Append(laeTizapan).Append(", ");
            json.Append("laeYurecuaro: ").Append(laeYurecuaro).Append(", ");
            json.Append("laeAtlacomulco: ").Append(laeAtlacomulco).Append(", ");
            json.Append("laeTolucaRectoria: ").Append(laeTolucaRectoria).Append(", ");
            json.Append("laeChincua: ").Append(laeChincua).Append(", ");
            json.Append("laeCuitzeoAu: ").Append(laeCuitzeoAu).Append(", ");
            json.Append("laeMelchorOcampo: ").Append(laeMelchorOcampo).Append(", ");
            json.Append("laeMorelia: ").Append(laeMorelia).Append(", ");
            json.Append("laeTepuxtepec: ").Append(laeTepuxtepec).Append(", ");
            json.Append("laeZacapu: ").Append(laeZacapu).Append(", ");
            json.Append("laeZamora: ").Append(laeZamora).Append(", ");
            json.Append("laeQueretaroObs: ").Append(laeQueretaroObs).Append(", ");
            json.Append("}");
            return json.ToString();
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