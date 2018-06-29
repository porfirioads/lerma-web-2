﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using Excel;
using Cuenca_conagua.src.Entidades;
using System.Globalization;

namespace Cuenca_conagua.src.Utilidades
{
    /// <summary>
    /// Esta clase se encarga de la lectura y escritura de los archivos de 
    /// informacion de la cuenca (archivos de excel).
    /// </summary>
    public class ExcelFileIO
    {
        /// <summary>
        /// Lee un archivo de excel y devuelve una lista con cada una de las 
        /// filas del archivo.
        /// </summary>
        /// <param name="excelFilename">
        /// El nombre del archivo de excel a leer.
        /// </param>
        /// <param name="sheetIndex">
        /// El indice de la hoja del archivo a leer.
        /// </param>
        /// <returns>
        /// Lista con el contenido de las filas.
        /// </returns>
        public static DataRowCollection ReadExcel(string excelFilename, int sheetIndex = 0)
        {
            DataSet result = new DataSet();
            StringBuilder a = new StringBuilder();

            if (excelFilename.EndsWith(".xlsx") || excelFilename.EndsWith(".xlsx"))
            {
                FileStream stream = File.Open(excelFilename, FileMode.Open,
                                    FileAccess.Read);
                IExcelDataReader excelReader = ExcelReaderFactory
                    .CreateOpenXmlReader(stream);
                result = excelReader.AsDataSet();
                excelReader.Close();
                stream.Close();
                return result.Tables[sheetIndex].Rows;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Lee los registros de la precipitacion media del archivo de excel
        /// correspondiente.
        /// </summary>
        public static List<PrecipitacionMedia> ReadPrecipitacionMedia(string excelFilename)
        {
            List<PrecipitacionMedia> precipitacionesMedias = new List<PrecipitacionMedia>();
            DataRowCollection rows = ReadExcel(excelFilename);
            if (rows != null)
            {
                PrecipitacionMedia pm;
                int filasIgnoradas = 5;
                for (int i = filasIgnoradas; i < rows.Count; i++)
                {
                    if (rows[i][0].ToString().Length == 0)
                    {
                        break;
                    }
                    pm = new PrecipitacionMedia();
                    pm.Ciclo = rows[i][0].ToString();
                    pm.Nov = double.Parse(rows[i][1].ToString(), CultureInfo.InvariantCulture);
                    pm.Dic = double.Parse(rows[i][2].ToString(), CultureInfo.InvariantCulture);
                    pm.Ene = double.Parse(rows[i][3].ToString(), CultureInfo.InvariantCulture);
                    pm.Feb = double.Parse(rows[i][4].ToString(), CultureInfo.InvariantCulture);
                    pm.Mar = double.Parse(rows[i][5].ToString(), CultureInfo.InvariantCulture);
                    pm.Abr = double.Parse(rows[i][6].ToString(), CultureInfo.InvariantCulture);
                    pm.May = double.Parse(rows[i][7].ToString(), CultureInfo.InvariantCulture);
                    pm.Jun = double.Parse(rows[i][8].ToString(), CultureInfo.InvariantCulture);
                    pm.Jul = double.Parse(rows[i][9].ToString(), CultureInfo.InvariantCulture);
                    pm.Ago = double.Parse(rows[i][10].ToString(), CultureInfo.InvariantCulture);
                    pm.Sep = double.Parse(rows[i][11].ToString(), CultureInfo.InvariantCulture);
                    pm.Oct = double.Parse(rows[i][12].ToString(), CultureInfo.InvariantCulture);
                    precipitacionesMedias.Add(pm);
                    Logger.AddToLog(pm.ToJSON(), true);
                }
            }
            return precipitacionesMedias;
        }

        /// <summary>
        /// Lee los registros del escurrimiento anual del archivo de excel
        /// correspondiente.
        /// </summary>
        public static List<EscurrimientoAnual> ReadEscurrimientoAnual(
            string excelFilename)
        {
            List<EscurrimientoAnual> escurrimientosAnuales
                = new List<EscurrimientoAnual>();
            DataRowCollection rows = ReadExcel(excelFilename);
            if (rows != null)
            {
                EscurrimientoAnual es;
                int filasIgnoradas = 3;
                for (int i = 0; i < filasIgnoradas; i++)
                {
                    String str = "";
                    for (int j = 0; j < rows[i].ItemArray.Length; j++)
                    {
                        str += rows[i].ItemArray[j] + ",";
                    }
                    Logger.AddToLog(str, true);
                }
                for (int i = filasIgnoradas; i < rows.Count; i++)
                {
                    String str = "";
                    for (int j = 0; j < rows[i].ItemArray.Length; j++)
                    {
                        str += rows[i].ItemArray[j] + ",";
                    }
                    Logger.AddToLog(str, true);
                    //Logger.AddToLog("Primera: " + rows[i][0].ToString(), true);
                    if (rows[i][0].ToString().Replace(" ", "").Length == 0)
                    {
                        break;
                    }
                    es = new EscurrimientoAnual();
                    es.Ciclo = rows[i][0].ToString();
                    es.Alzate = double.Parse(rows[i][1].ToString(), CultureInfo.InvariantCulture);
                    es.Ramirez = double.Parse(rows[i][2].ToString(), CultureInfo.InvariantCulture);
                    es.Tepetitlan = double.Parse(rows[i][3].ToString(), CultureInfo.InvariantCulture);
                    es.Tepuxtepec = double.Parse(rows[i][4].ToString(), CultureInfo.InvariantCulture);
                    es.Solis = double.Parse(rows[i][5].ToString(), CultureInfo.InvariantCulture);
                    es.Begona = double.Parse(rows[i][6].ToString(), CultureInfo.InvariantCulture);
                    es.Ameche = double.Parse(rows[i][7].ToString(), CultureInfo.InvariantCulture);
                    es.Pericos = double.Parse(rows[i][8].ToString(), CultureInfo.InvariantCulture);
                    es.Yuriria = double.Parse(rows[i][9].ToString(), CultureInfo.InvariantCulture);
                    es.Salamanca = double.Parse(rows[i][10].ToString(), CultureInfo.InvariantCulture);
                    es.Adjuntas = double.Parse(rows[i][11].ToString(), CultureInfo.InvariantCulture);
                    es.Angulo = double.Parse(rows[i][12].ToString(), CultureInfo.InvariantCulture);
                    es.Corrales = double.Parse(rows[i][13].ToString(), CultureInfo.InvariantCulture);
                    es.Yurecuaro = double.Parse(rows[i][14].ToString(), CultureInfo.InvariantCulture);
                    es.Duero = double.Parse(rows[i][15].ToString(), CultureInfo.InvariantCulture);
                    es.Zula = double.Parse(rows[i][16].ToString(), CultureInfo.InvariantCulture);
                    es.Chapala = double.Parse(rows[i][17].ToString(), CultureInfo.InvariantCulture);
                    escurrimientosAnuales.Add(es);
                    Logger.AddToLog(es.ToJSON(), true);
                }
            }
            return escurrimientosAnuales;
        }

        /// <summary>
        /// Lee los registros de almacenamientos históricos de chapala del 
        /// archivo de excel correspondiente.
        /// </summary>
        public static List<AlmacenamientoHistoricoChapala> ReadAlmacenamientoHistoricoChapala(
            string nombreArchivo)
        {
            List<AlmacenamientoHistoricoChapala> almacenamientos =
                new List<AlmacenamientoHistoricoChapala>();

            DataRowCollection rows = ReadExcel(nombreArchivo);

            Logger.AddToLog(nombreArchivo, true);

            if (rows != null)
            {
                AlmacenamientoHistoricoChapala alm;
                int filasIgnoradas = 3;

                for (int i = filasIgnoradas; i < rows.Count; i++)
                {
                    if (rows[i][0].ToString().Replace(" ", "").Length == 0)
                    {
                        break;
                    }

                    alm = new AlmacenamientoHistoricoChapala();
                    alm.Fecha = DateUtils.ConvertSqlDateToDateTime(rows[i][0].ToString());
                    alm.Almacenamiento = double.Parse(rows[i][1].ToString(), CultureInfo.InvariantCulture);
                    almacenamientos.Add(alm);
                    Logger.AddToLog(alm.ToJSON(), true);
                }
            }

            Logger.AddToLog("Se leyeron " + almacenamientos.Count +
                " almacenamientos históricos de chapala del archivo de Excel",
                true);

            return almacenamientos;
        }

        /// <summary>
        /// Lee los registros de almacenamientos principales del archivo de 
        /// excel correspondiente.
        /// </summary>
        public static List<AlmacenamientoPrincipal> ReadAlmacenamientoPrincipal(string nombreArchivo)
        {
            List<AlmacenamientoPrincipal> almacenamientos =
                new List<AlmacenamientoPrincipal>();

            DataRowCollection rows = ReadExcel(nombreArchivo, 0);

            if (rows != null)
            {
                AlmacenamientoPrincipal alm;
                int filasIgnoradas = 4;

                for (int i = filasIgnoradas; i < rows.Count; i++)
                {
                    if (rows[i][0].ToString().Replace(" ", "").Length == 0)
                    {
                        break;
                    }

                    alm = new AlmacenamientoPrincipal();
                    alm.Anio = rows[i][0].ToString();
                    alm.Alzate = double.Parse(rows[i][1].ToString(), CultureInfo.InvariantCulture);
                    alm.Ramirez = double.Parse(rows[i][2].ToString(), CultureInfo.InvariantCulture);
                    alm.Tepetitlan = double.Parse(rows[i][3].ToString(), CultureInfo.InvariantCulture);
                    alm.Tepuxtepec = double.Parse(rows[i][4].ToString(), CultureInfo.InvariantCulture);
                    alm.Solis = double.Parse(rows[i][5].ToString(), CultureInfo.InvariantCulture);
                    alm.Yuriria = double.Parse(rows[i][6].ToString(), CultureInfo.InvariantCulture);
                    alm.Allende = double.Parse(rows[i][7].ToString(), CultureInfo.InvariantCulture);
                    alm.MOcampo = double.Parse(rows[i][8].ToString(), CultureInfo.InvariantCulture);
                    alm.Purisima = double.Parse(rows[i][9].ToString(), CultureInfo.InvariantCulture);
                    alm.Chapala = double.Parse(rows[i][10].ToString(), CultureInfo.InvariantCulture);
                    almacenamientos.Add(alm);
                    Logger.AddToLog(alm.ToJSON(), true);
                }

            }

            Logger.AddToLog("Se leyeron " + almacenamientos.Count +
                " almacenamientos principales del archivo de Excel", true);

            return almacenamientos;
        }

        /// <summary>
        /// Lee los registros de algun tipo de volumen DR del archivo de excel
        /// correspondiente.
        /// </summary>
        private static List<VolumenDr> ReadVolumenDr(
            string excelFilename, int sheetIndex)
        {
            List<VolumenDr> volumenes = new List<VolumenDr>();
            DataRowCollection rows = ReadExcel(excelFilename, sheetIndex);
            if (rows != null)
            {
                VolumenDr vol;
                int filasIgnoradas = 2;
                for (int i = filasIgnoradas; i < rows.Count; i++)
                {
                    if (!IsFilaVolumenValida(rows[i], 9)) break;
                    else
                    {
                        vol = new VolumenDr();
                        vol.Ciclo = rows[i][0].ToString();
                        vol.Dr033 = double.Parse(rows[i][1].ToString(), CultureInfo.InvariantCulture);
                        vol.Dr045 = double.Parse(rows[i][2].ToString(), CultureInfo.InvariantCulture);
                        vol.Dr011 = double.Parse(rows[i][3].ToString(), CultureInfo.InvariantCulture);
                        vol.Dr085 = double.Parse(rows[i][4].ToString(), CultureInfo.InvariantCulture);
                        vol.Dr087 = double.Parse(rows[i][5].ToString(), CultureInfo.InvariantCulture);
                        vol.Dr022 = double.Parse(rows[i][6].ToString(), CultureInfo.InvariantCulture);
                        vol.Dr061 = double.Parse(rows[i][7].ToString(), CultureInfo.InvariantCulture);
                        vol.Dr024 = double.Parse(rows[i][8].ToString(), CultureInfo.InvariantCulture);
                        vol.Dr013 = double.Parse(rows[i][9].ToString(), CultureInfo.InvariantCulture);
                        volumenes.Add(vol);
                        Logger.AddToLog(vol.ToJSON(), true);
                    }
                }

            }
            return volumenes;
        }

        /// <summary>
        /// Lee los registros del volumen DR autorizado del archivo de excel
        /// correspondiente.
        /// </summary>
        public static List<VolumenDr> ReadVolumenDrAutorizado(
            string excelFilename)
        {
            return ReadVolumenDr(excelFilename, 0);
        }

        /// <summary>
        /// Lee los registros del volumen DR asignado del archivo de excel
        /// correspondiente.
        /// </summary>
        /// <param name="excelFilename">
        /// Es el nombre del archivo de excel donde vienen los datos.
        /// </param>
        /// <returns>
        /// Una lista con los registros del volumen asignado.
        /// </returns>
        public static List<VolumenDr> ReadVolumenDrAsignado(
            string excelFilename)
        {
            return ReadVolumenDr(excelFilename, 1);
        }

        /// <summary>
        /// Lee los registros del volumen DR utilizado del archivo de excel
        /// correspondiente.
        /// </summary>
        /// <param name="excelFilename">
        /// Es el nombre del archivo de excel donde vienen los datos.
        /// </param>
        /// <returns>
        /// Una lista con los registros del volumen utilizado.
        /// </returns>
        public static List<VolumenDr> ReadVolumenDrUtilizado(
            string excelFilename)
        {
            return ReadVolumenDr(excelFilename, 2);
        }

        /// <summary>
        /// Lee los registros de algun tipo de volumen PI del archivo de excel
        /// correspondiente.
        /// </summary>
        /// <param name="excelFilename">
        /// Es el nombre del archivo de excel donde vienen los datos.
        /// </param>
        /// <param name="sheetIndex">
        /// Es el indice de la hoja de donde se van a extraer los datos.
        /// </param>
        /// <returns>
        /// Una lista con los registros del volumen.
        /// </returns>
        private static List<VolumenPi> ReadVolumenPi(
            string excelFilename, int sheetIndex)
        {
            List<VolumenPi> volumenes = new List<VolumenPi>();
            DataRowCollection rows = ReadExcel(excelFilename, sheetIndex);
            if (rows != null)
            {
                VolumenPi vol;
                int filasIgnoradas = 2;
                for (int i = filasIgnoradas; i < rows.Count; i++)
                {
                    if (!IsFilaVolumenValida(rows[i], 15)) break;
                    else
                    {
                        vol = new VolumenPi();
                        vol.Ciclo = rows[i][0].ToString();
                        vol.PiAlzate = double.Parse(rows[i][1].ToString(), CultureInfo.InvariantCulture);
                        vol.PiRamirez = double.Parse(rows[i][2].ToString(), CultureInfo.InvariantCulture);
                        vol.PiTepetitlan = double.Parse(rows[i][3].ToString(), CultureInfo.InvariantCulture);
                        vol.PiTepuxtepec = double.Parse(rows[i][4].ToString(), CultureInfo.InvariantCulture);
                        vol.PiSolis = double.Parse(rows[i][5].ToString(), CultureInfo.InvariantCulture);
                        vol.PiBegona = double.Parse(rows[i][6].ToString(), CultureInfo.InvariantCulture);
                        vol.PiQueretaro = double.Parse(rows[i][7].ToString(), CultureInfo.InvariantCulture);
                        vol.PiPericos = double.Parse(rows[i][8].ToString(), CultureInfo.InvariantCulture);
                        vol.PiAdjuntas = double.Parse(rows[i][9].ToString(), CultureInfo.InvariantCulture);
                        vol.PiAngulo = double.Parse(rows[i][10].ToString(), CultureInfo.InvariantCulture);
                        vol.PiCorrales = double.Parse(rows[i][11].ToString(), CultureInfo.InvariantCulture);
                        vol.PiYurecuaro = double.Parse(rows[i][12].ToString(), CultureInfo.InvariantCulture);
                        vol.PiDuero = double.Parse(rows[i][13].ToString(), CultureInfo.InvariantCulture);
                        vol.PiZula = double.Parse(rows[i][14].ToString(), CultureInfo.InvariantCulture);
                        vol.PiChapala = double.Parse(rows[i][15].ToString(), CultureInfo.InvariantCulture);
                        volumenes.Add(vol);
                        Logger.AddToLog(vol.ToJSON(), true);
                    }
                }

            }
            return volumenes;
        }

        /// <summary>
        /// Lee los registros del volumen PI autorizado del archivo de excel
        /// correspondiente.
        /// </summary>
        /// <param name="excelFilename">
        /// Es el nombre del archivo de excel donde vienen los datos.
        /// </param>
        /// <returns>
        /// Una lista con los registros del volumen autorizado.
        /// </returns>
        public static List<VolumenPi> ReadVolumenPiAutorizado(
            string excelFilename)
        {
            return ReadVolumenPi(excelFilename, 3);
        }

        /// <summary>
        /// Lee los registros del volumen PI asignado del archivo de excel
        /// correspondiente.
        /// </summary>
        /// <param name="excelFilename">
        /// Es el nombre del archivo de excel donde vienen los datos.
        /// </param>
        /// <returns>
        /// Una lista con los registros del volumen asignado.
        /// </returns>
        public static List<VolumenPi> ReadVolumenPiAsignado(
            string excelFilename)
        {
            return ReadVolumenPi(excelFilename, 4);
        }

        /// <summary>
        /// Lee los registros del volumen PI utilizado del archivo de excel
        /// correspondiente.
        /// </summary>
        /// <param name="excelFilename">
        /// Es el nombre del archivo de excel donde vienen los datos.
        /// </param>
        /// <returns>
        /// Una lista con los registros del volumen utilizado.
        /// </returns>
        public static List<VolumenPi> ReadVolumenPiUtilizado(
            string excelFilename)
        {
            return ReadVolumenPi(excelFilename, 5);
        }

        /// <summary>
        /// Determina si una fila del volumen DR corresponde a un ciclo y tiene
        /// datos.
        /// </summary>
        /// <param name="row">
        /// Es la fila a analizar.
        /// </param>
        /// <param name="dataCols">
        /// Es la cantidad de filas donde debe haber datos
        /// </param>
        /// <returns></returns>
        private static bool IsFilaVolumenValida(DataRow row, int dataCols)
        {
            if (row[0].ToString().Replace(" ", "").Length == 0)
                return false;
            if (row[0].ToString().Replace(" ", "").ToLower().Equals("promedio"))
                return false;
            for (int i = 1; i < dataCols; i++)
                if (row[i].ToString().Replace(" ", "").Length > 0)
                    return true;
            return false;
        }

        /// <summary>
        /// Lee los registros de lluvia anual por estación del archivo de excel
        /// correspondiente.
        /// </summary>
        /// <param name="excelFilename">
        /// Es el nombre del archivo de excel donde vienen los datos.
        /// </param>
        /// <returns>
        /// Una lista con los de lluvia anual por estación.
        /// </returns>
        public static List<LluviaAnualEstacion> ReadLluviaAnualEstacion(
            string excelFilename)
        {
            List<LluviaAnualEstacion> lluviasAnuales = new List<LluviaAnualEstacion>();
            DataRowCollection rows = ReadExcel(excelFilename);

            if (rows != null)
            {
                LluviaAnualEstacion lae;
                int filasIgnoradas = 2;

                for (int i = filasIgnoradas; i < rows.Count; i++)
                {
                    if (rows[i][0].ToString().Length == 0)
                        break;

                    lae = new LluviaAnualEstacion();

                    lae.Ciclo = rows[i][0].ToString();
                    lae.LaeCelaya = double.Parse(rows[i][1].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeGuanajuato = double.Parse(rows[i][2].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeIrapuato = double.Parse(rows[i][3].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeAdjuntas = double.Parse(rows[i][4].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeLeon = double.Parse(rows[i][5].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaePPenuelitas = double.Parse(rows[i][6].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaePSolis = double.Parse(rows[i][7].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeSanFelipe = double.Parse(rows[i][8].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeSanLuisDeLaPaz = double.Parse(rows[i][9].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeYuriria = double.Parse(rows[i][10].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeChapala = double.Parse(rows[i][11].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeFuerte = double.Parse(rows[i][12].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeTule = double.Parse(rows[i][13].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeTizapan = double.Parse(rows[i][14].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeYurecuaro = double.Parse(rows[i][15].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeAtlacomulco = double.Parse(rows[i][16].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeTolucaRectoria = double.Parse(rows[i][17].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeChincua = double.Parse(rows[i][18].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeCuitzeoAu = double.Parse(rows[i][19].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeMelchorOcampo = double.Parse(rows[i][20].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeMorelia = double.Parse(rows[i][21].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeTepuxtepec = double.Parse(rows[i][22].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeZacapu = double.Parse(rows[i][23].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeZamora = double.Parse(rows[i][24].ToString(),
                        CultureInfo.InvariantCulture);
                    lae.LaeQueretaroObs = double.Parse(rows[i][25].ToString(),
                        CultureInfo.InvariantCulture);
                    lluviasAnuales.Add(lae);
                    Logger.AddToLog(lae.ToJSON(), true);
                }
            }

            return lluviasAnuales;
        }
    }
}