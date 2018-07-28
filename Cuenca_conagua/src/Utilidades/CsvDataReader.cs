using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Cuenca_conagua.src.Entidades;
using LumenWorks.Framework.IO.Csv;

namespace Cuenca_conagua.src.Utilidades
{
    public class CsvDataReader
    {
        public static List<Dictionary<string, string>> ReadCsv(string filename)
        {
            List<Dictionary<string, string>> data = new List<Dictionary<string, string>>();

            using (CsvReader csv = new CsvReader(new StreamReader(filename), true))
            {
                int fieldCount = csv.FieldCount;
                string[] headers = csv.GetFieldHeaders();

                Logger.AddToLog("Csv filename: " + filename, true);
                Logger.AddToLog("Csv fields: " + fieldCount, true);
                Logger.AddToLog("Csv headers: " + string.Join(", ", headers), true);

                while (csv.ReadNextRecord())
                {
                    string[] record = new string[fieldCount];
                    csv.CopyCurrentRecordTo(record);
                    Logger.AddToLog("Csv row: " + string.Join(", ", record), true);

                    data.Add(new Dictionary<string, string>());

                    for (int i = 0; i < fieldCount; i++)
                        data[data.Count - 1].Add(headers[i], record[i]);
                }
            }

            return data;
        }

        public static List<PrecipitacionMedia> ReadPrecipitacionMediaCsv(string filename)
        {
            List<Dictionary<string, string>> data = ReadCsv(filename);
            Logger.AddToLog(DictListToJsonString(data), true);
            List<PrecipitacionMedia> precs = new List<PrecipitacionMedia>();

            foreach (Dictionary<string, string> prec in data)
            {
                PrecipitacionMedia p = new PrecipitacionMedia();
                p.Ciclo = prec["ciclo"];
                p.Nov = double.Parse(prec["nov"]);
                p.Dic = double.Parse(prec["dic"]);
                p.Ene = double.Parse(prec["ene"]);
                p.Feb = double.Parse(prec["feb"]);
                p.Mar = double.Parse(prec["mar"]);
                p.Abr = double.Parse(prec["abr"]);
                p.May = double.Parse(prec["may"]);
                p.Jun = double.Parse(prec["jun"]);
                p.Jul = double.Parse(prec["jul"]);
                p.Ago = double.Parse(prec["ago"]);
                p.Sep = double.Parse(prec["sep"]);
                p.Oct = double.Parse(prec["oct"]);
                precs.Add(p);
            }

            return precs;
        }

        public static List<EscurrimientoAnual> ReadEscurrimientoAnual(string filename)
        {
            List<Dictionary<string, string>> data = ReadCsv(filename);
            Logger.AddToLog(DictListToJsonString(data), true);
            List<EscurrimientoAnual> escs = new List<EscurrimientoAnual>();

            foreach (Dictionary<string, string> prec in data)
            {
                EscurrimientoAnual e = new EscurrimientoAnual();
                e.Ciclo = prec["ciclo"];
                e.Alzate = double.Parse(prec["alzate"]);
                e.Ramirez = double.Parse(prec["ramirez"]);
                e.Tepetitlan = double.Parse(prec["tepetitlan"]);
                e.Tepuxtepec = double.Parse(prec["tepuxtepec"]);
                e.Solis = double.Parse(prec["solis"]);
                e.Begona = double.Parse(prec["begona"]);
                e.Ameche = double.Parse(prec["ameche"]);
                e.Pericos = double.Parse(prec["pericos"]);
                e.Yuriria = double.Parse(prec["yuriria"]);
                e.Salamanca = double.Parse(prec["salamanca"]);
                e.Adjuntas = double.Parse(prec["adjuntas"]);
                e.Angulo = double.Parse(prec["angulo"]);
                e.Corrales = double.Parse(prec["corrales"]);
                e.Yurecuaro = double.Parse(prec["yurecuaro"]);
                e.Duero = double.Parse(prec["duero"]);
                e.Zula = double.Parse(prec["zula"]);
                e.Chapala = double.Parse(prec["chapala"]);
                escs.Add(e);
            }

            return escs;
        }

        public static List<LluviaAnualEstacion> ReadLluviaAnualEstacion(string filename)
        {
            List<Dictionary<string, string>> data = ReadCsv(filename);
            Logger.AddToLog(DictListToJsonString(data), true);
            List<LluviaAnualEstacion> lluvias = new List<LluviaAnualEstacion>();

            foreach (Dictionary<string, string> lluvia in data)
            {
                LluviaAnualEstacion l = new LluviaAnualEstacion();
                l.Ciclo = lluvia["ciclo"];
                l.LaeCelaya = double.Parse(lluvia["laeCelaya"]);
                l.LaeGuanajuato = double.Parse(lluvia["laeGuanajuato"]);
                l.LaeIrapuato = double.Parse(lluvia["laeIrapuato"]);
                l.LaeAdjuntas = double.Parse(lluvia["laeAdjuntas"]);
                l.LaeLeon = double.Parse(lluvia["laeLeon"]);
                l.LaePPenuelitas = double.Parse(lluvia["laePPenuelitas"]);
                l.LaePSolis = double.Parse(lluvia["laePSolis"]);
                l.LaeSanFelipe = double.Parse(lluvia["laeSanFelipe"]);
                l.LaeSanLuisDeLaPaz = double.Parse(lluvia["laeSanLuisDeLaPaz"]);
                l.LaeYuriria = double.Parse(lluvia["laeYuriria"]);
                l.LaeChapala = double.Parse(lluvia["laeChapala"]);
                l.LaeFuerte = double.Parse(lluvia["laeFuerte"]);
                l.LaeTule = double.Parse(lluvia["laeTule"]);
                l.LaeTizapan = double.Parse(lluvia["laeTizapan"]);
                l.LaeYurecuaro = double.Parse(lluvia["laeYurecuaro"]);
                l.LaeAtlacomulco = double.Parse(lluvia["laeAtlacomulco"]);
                l.LaeTolucaRectoria = double.Parse(lluvia["laeTolucaRectoria"]);
                l.LaeChincua = double.Parse(lluvia["laeChincua"]);
                l.LaeCuitzeoAu = double.Parse(lluvia["laeCuitzeoAu"]);
                l.LaeMelchorOcampo = double.Parse(lluvia["laeMelchorOcampo"]);
                l.LaeMorelia = double.Parse(lluvia["laeMorelia"]);
                l.LaeTepuxtepec = double.Parse(lluvia["laeTepuxtepec"]);
                l.LaeZacapu = double.Parse(lluvia["laeZacapu"]);
                l.LaeZamora = double.Parse(lluvia["laeZamora"]);
                l.LaeQueretaroObs = double.Parse(lluvia["laeQueretaroObs"]);
                lluvias.Add(l);
            }

            return lluvias;
        }

        public static List<AlmacenamientoPrincipal> ReadAlmacenamientoPrincipal(string filename)
        {
            List<Dictionary<string, string>> data = ReadCsv(filename);
            Logger.AddToLog(DictListToJsonString(data), true);
            List<AlmacenamientoPrincipal> alms = new List<AlmacenamientoPrincipal>();

            foreach (Dictionary<string, string> alm in data)
            {
                AlmacenamientoPrincipal a = new AlmacenamientoPrincipal();
                a.Anio = alm["anio"];
                a.Alzate = double.Parse(alm["alzate"]);
                a.Ramirez = double.Parse(alm["ramirez"]);
                a.Tepetitlan = double.Parse(alm["tepetitlan"]);
                a.Tepuxtepec = double.Parse(alm["tepuxtepec"]);
                a.Solis = double.Parse(alm["solis"]);
                a.Yuriria = double.Parse(alm["yuriria"]);
                a.Allende = double.Parse(alm["allende"]);
                a.MOcampo = double.Parse(alm["m_ocampo"]);
                a.Purisima = double.Parse(alm["purisima"]);
                a.Chapala = double.Parse(alm["chapala"]);
                alms.Add(a);
            }

            return alms;
        }

        public static List<AlmacenamientoHistoricoChapala> ReadAlmacenamientoHistoricoChapala(string filename)
        {
            List<Dictionary<string, string>> data = ReadCsv(filename);
            Logger.AddToLog(DictListToJsonString(data), true);
            List<AlmacenamientoHistoricoChapala> alms = new List<AlmacenamientoHistoricoChapala>();

            foreach (Dictionary<string, string> alm in data)
            {
                AlmacenamientoHistoricoChapala a = new AlmacenamientoHistoricoChapala();
                a.Fecha = DateUtils.ConvertSqlDateToDateTime(alm["fecha"]);
                a.Almacenamiento = double.Parse(alm["almacenamiento"]);
                alms.Add(a);
            }

            return alms;
        }

        public static List<VolumenAg> ReadVolumenAg(string filename)
        {
            List<Dictionary<string, string>> data = ReadCsv(filename);
            Logger.AddToLog(DictListToJsonString(data), true);
            List<VolumenAg> vols = new List<VolumenAg>();

            foreach (Dictionary<string, string> vol in data)
            {
                VolumenAg v = new VolumenAg();
                v.Ciclo = vol["ciclo"];
                v.Volumen = double.Parse(vol["volumen"]);
                vols.Add(v);
            }

            return vols;
        }

        public static List<VolumenGt> ReadVolumenGt(string filename)
        {
            List<Dictionary<string, string>> data = ReadCsv(filename);
            Logger.AddToLog(DictListToJsonString(data), true);
            List<VolumenGt> vols = new List<VolumenGt>();

            foreach (Dictionary<string, string> vol in data)
            {
                VolumenGt v = new VolumenGt();
                v.Ciclo = vol["ciclo"];
                v.Volumen = double.Parse(vol["volumen"]);
                vols.Add(v);
            }

            return vols;
        }

        public static List<VolumenDr> ReadVolumenDr(string filename)
        {
            List<Dictionary<string, string>> data = ReadCsv(filename);
            Logger.AddToLog(DictListToJsonString(data), true);
            List<VolumenDr> vols = new List<VolumenDr>();

            foreach (Dictionary<string, string> vol in data)
            {
                VolumenDr v = new VolumenDr();
                v.Ciclo = vol["ciclo"];
                v.Dr033 = double.Parse(vol["dr033"]);
                v.Dr045 = double.Parse(vol["dr045"]);
                v.Dr011 = double.Parse(vol["dr011"]);
                v.Dr085 = double.Parse(vol["dr085"]);
                v.Dr087 = double.Parse(vol["dr087"]);
                v.Dr022 = double.Parse(vol["dr022"]);
                v.Dr061 = double.Parse(vol["dr061"]);
                v.Dr024 = double.Parse(vol["dr024"]);
                v.Dr013 = double.Parse(vol["dr013"]);
                vols.Add(v);
            }

            return vols;
        }

        public static List<VolumenPi> ReadVolumenPi(string filename)
        {
            List<Dictionary<string, string>> data = ReadCsv(filename);
            Logger.AddToLog(DictListToJsonString(data), true);
            List<VolumenPi> vols = new List<VolumenPi>();

            foreach (Dictionary<string, string> vol in data)
            {
                VolumenPi v = new VolumenPi();
                v.Ciclo = vol["ciclo"];
                v.PiAlzate = double.Parse(vol["piAlzate"]);
                v.PiRamirez = double.Parse(vol["piRamirez"]);
                v.PiTepetitlan = double.Parse(vol["piTepetitlan"]);
                v.PiTepuxtepec = double.Parse(vol["piTepuxtepec"]);
                v.PiSolis = double.Parse(vol["piSolis"]);
                v.PiBegona = double.Parse(vol["piBegona"]);
                v.PiQueretaro = double.Parse(vol["piQueretaro"]);
                v.PiPericos = double.Parse(vol["piPericos"]);
                v.PiAdjuntas = double.Parse(vol["piAdjuntas"]);
                v.PiAngulo = double.Parse(vol["piAngulo"]);
                v.PiCorrales = double.Parse(vol["piCorrales"]);
                v.PiYurecuaro = double.Parse(vol["piYurecuaro"]);
                v.PiDuero = double.Parse(vol["piDuero"]);
                v.PiZula = double.Parse(vol["piZula"]);
                v.PiChapala = double.Parse(vol["piChapala"]);
                vols.Add(v);
            }

            return vols;
        }

        public static List<VolumenPiOld> ReadVolumenPiOld(string filename)
        {
            List<Dictionary<string, string>> data = ReadCsv(filename);
            Logger.AddToLog(DictListToJsonString(data), true);
            List<VolumenPiOld> vols = new List<VolumenPiOld>();

            foreach (Dictionary<string, string> vol in data)
            {
                VolumenPiOld v = new VolumenPiOld();
                v.Ciclo = vol["ciclo"];
                v.PiAltoLerma = double.Parse(vol["piAltoLerma"]);
                v.PiRioQueretaro = double.Parse(vol["piRioQueretaro"]);
                v.PiBajio = double.Parse(vol["piBajio"]);
                v.PiAnguloDuero = double.Parse(vol["piAnguloDuero"]);
                v.PiBajoLerma = double.Parse(vol["piBajoLerma"]);
                vols.Add(v);
            }

            return vols;
        }

        private static string DictListToJsonString(List<Dictionary<string, string>> obj)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n[\n    ");

            foreach (Dictionary<string, string> o in obj)
            {
                IEnumerable<string> enumerable = o.Select(
                    d => string.Format("\"{0}\": {1}", d.Key, d.Value));
                string oJson = "{\n        " + string.Join(",\n        ",
                    enumerable) + "\n    }";
                sb.Append(oJson).Append(",\n    ");
            }

            sb.Remove(sb.Length - 6, 6);
            sb.Append("\n]");
            return sb.ToString();
        }
    }
}