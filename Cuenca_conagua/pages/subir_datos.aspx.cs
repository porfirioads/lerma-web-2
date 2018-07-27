using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Cuenca_conagua.src.Utilidades;
using Cuenca_conagua.src.Entidades;
//using Cuenca_conagua.src.BaseDatos;

namespace Cuenca_conagua.pages
{
    /// <summary>
    /// Esta clase contiene el código de la página de subir datos.
    /// </summary>
    public partial class subir_datos : System.Web.UI.Page
    {
        /// <summary>
        /// Se ejecuta cuando la página se carga.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null)
            {
                txtBienvenidaUsuario.InnerText = Session["usuario"].ToString();

                foreach (string s in Request.Files)
                {
                    HttpPostedFile file = Request.Files[s];
                    string tipo = tipoArchivo.Value;

                    string savedFileName = SaveFile(file, tipoArchivo.Value);

                    if (tipo == "datos")
                    {
                        IngresarBaseDatos(savedFileName);
                    }
                }
            }
            else
            {
                Session["pageBeforeLogin"] = "subir_datos.aspx";
                Response.Redirect("login_admin.aspx");
            }
        }

        private string GetPathForUploadedFile(string tipo)
        {
            string path = "";

            switch(tipo)
            {
                case "boletin":
                    path = "uploaded_files/boletines";
                    break;
                case "reglamentacion":
                    path = "uploaded_files/reglamentacion";
                    break;
                case "datos":
                    path = "uploaded_files/datos";
                    break;
                case "archivo_calculo":
                    path = "uploaded_files/restitucion/archivos_calculo";
                    break;
                case "presentacion_covi":
                    path = "uploaded_files/restitucion/presentacion_covi";
                    break;
                case "minuta_god":
                    path = "uploaded_files/minutas_GOD";
                    break;
            }

            return path;
        }

        /// <summary>
        /// Guarda el archivo recibido en el directorio correspondiente
        /// </summary>
        /// <param name="file">
        /// El archivo a subir
        /// </param>
        /// <param name="tipo">
        /// El tipo de archivo
        /// </param>
        /// <returns>
        /// Ubicación donde se guardó el archivo
        /// </returns>
        private string SaveFile(HttpPostedFile file, string tipo)
        {
            string fileName = file.FileName;
            string path = GetPathForUploadedFile(tipo);

            FileManager.crearCarpetasFaltantes(path);
            path = "../" + path;

            Logger.AddToLog(path, true);
            Logger.AddToLog("Tipo de archivo: " + tipo, true);

            string savedFileName = Path.Combine(Server.MapPath(path), fileName);
            file.SaveAs(savedFileName);

            return savedFileName;
        }

        /// <summary>
        /// Lee el archivo de excel subido al servidor y mete su informacion a 
        /// la base de datos.
        /// </summary>
        /// <param name="nombreArchivo">
        /// Es el nombre del archivo que contiene los datos que se colocaran en
        /// la base de datos.
        /// </param>
        protected void IngresarBaseDatos(string nombreArchivo)
        {
            string archivoSinRuta = nombreArchivo.Substring(nombreArchivo
                .LastIndexOf('\\') + 1);

            Logger.AddToLog("IngresarBaseDatos(" + archivoSinRuta + ")", true);

            if (archivoSinRuta.StartsWith("Lluvia_media_anual"))
                IngresarPrecipitacionBD(nombreArchivo);
            else if (archivoSinRuta.StartsWith("Escurrimiento_anual"))
                IngresarEscurrimientoBD(nombreArchivo);
            else if (archivoSinRuta.StartsWith("Lluvia_anual_estación"))
                IngresarLluviaAnualEstacion(nombreArchivo);
            else if (archivoSinRuta.StartsWith("Almacenamientos_principales"))
                IngresarAlmacenamientosPrincipalesBD(nombreArchivo);
            else if (archivoSinRuta.StartsWith("Almacenamiento_histórico_chapala"))
                IngresarAlmacenamientoHistoricoChapalaBD(nombreArchivo);

            // TODO Agregar archivos de volúmenes
        }

        /// <summary>
        /// Ingresa los registros de almacenamiento histórico de Chapala en 
        /// caso de que ese archivo sea el que se subió al servidor.
        /// </summary>
        /// <param name="nombreArchivo">
        /// Nombre del archivo de excel que contiene los datos.
        /// </param>
        private void IngresarAlmacenamientoHistoricoChapalaBD(string nombreArchivo)
        {
            Logger.AddToLog("IngresarAlmacenamientoHistoricoChapala", true);

            List<AlmacenamientoHistoricoChapala> almacenamientos = 
                ExcelFileIO.ReadAlmacenamientoHistoricoChapala(nombreArchivo);

            foreach (AlmacenamientoHistoricoChapala alm in almacenamientos)
            {
                if (alm.Save())
                {
                    Logger.AddToLog("Almacenamiento histórico de chapala: " + 
                        alm.Fecha + " agregado.", true);
                }
                else
                {
                    Logger.AddToLog("Almacenamiento histórico de chapala: " +
                        alm.Fecha + " no agregado.", true);
                }
            }
        }

        /// <summary>
        /// Ingresa los registros de almacenamientos principales en caso de 
        /// que ese archivo sea el que se subió al servidor.
        /// </summary>
        /// <param name="nombreArchivo">
        /// Nombre del archivo de excel que contiene los datos.
        /// </param>
        private void IngresarAlmacenamientosPrincipalesBD(string nombreArchivo)
        {
            Logger.AddToLog("IngresarAlmacenamientosPrincipales", true);

            List<AlmacenamientoPrincipal> almacenamientos = ExcelFileIO.
                ReadAlmacenamientoPrincipal(nombreArchivo);

            foreach (AlmacenamientoPrincipal alm in almacenamientos)
            {
                if (alm.Save())
                {
                    Logger.AddToLog("Almacenamiento principal: " + alm.Anio +
                        " agregado.", true);
                }
                else
                {
                    Logger.AddToLog("Almacenamiento principal: " + alm.Anio +
                        " no agregado.", true);
                }
            }
        }

        /// <summary>
        /// Ingresa los registros de la precipitacion en caso de que ese archivo
        /// sea el que se subio al servidor.
        /// </summary>
        /// <param name="nombreArchivo">
        /// Nombre del archivo de excel que contiene los datos.
        /// </param>
        protected void IngresarPrecipitacionBD(string nombreArchivo)
        {
            Logger.AddToLog("IngresarPrecipitacionBD", true);

            List<PrecipitacionMedia> precipitaciones = CsvDataReader
                .ReadPrecipitacionMediaCsv(nombreArchivo);

            foreach (PrecipitacionMedia pm in precipitaciones)
            {
                if (pm.Save())
                {
                    Logger.AddToLog("Precipitación: " + pm.Ciclo + " agregado.", true);
                }
                else
                {
                    Logger.AddToLog("Precipitación: " + pm.Ciclo + " no agregado.", true);
                }
            }
        }

        /// <summary>
        /// Ingresa los registros del escurrimiento en caso de que ese archivo
        /// sea el que se subio al servidor.
        /// </summary>
        /// <param name="nombreArchivo">
        /// Nombre del archivo de excel que contiene los datos.
        /// </param>
        protected void IngresarEscurrimientoBD(string nombreArchivo)
        {
            Logger.AddToLog("IngresarEscurrimientoBD", true);

            List<EscurrimientoAnual> escurrimientos
                    = ExcelFileIO.ReadEscurrimientoAnual(nombreArchivo);

            foreach (EscurrimientoAnual ea in escurrimientos)
            {
                if (ea.Save())
                {
                    Logger.AddToLog("Escurrimiento: " + ea.Ciclo + " agregado.",
                        true);
                }
                else
                {
                    Logger.AddToLog("Escurrimiento: " + ea.Ciclo
                        + " no agregado.", true);
                }
            }
        }

        /// <summary>
        /// Ingresa los registros de los volumenes en caso de que ese archivo
        /// sea el que se subio al servidor.
        /// </summary>
        /// <param name="nombreArchivo">
        /// Nombre del archivo de excel que contiene los datos.
        /// </param>
        protected void IngresarVolumenesBD(string nombreArchivo)
        {
            List<VolumenDr> volsDrAutorizados = ExcelFileIO
                .ReadVolumenDrAutorizado(nombreArchivo);

            foreach (VolumenDr volAu in volsDrAutorizados)
            {
                if (volAu.ToVolumenDrAsignado().Save())
                {
                    Logger.AddToLog("Volumen DR Autorizado: " + volAu.Ciclo + " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen DR Autorizado: " + volAu.Ciclo + " no guardado", true);
                }
            }

            List<VolumenDr> volsDrAsignados = ExcelFileIO
                .ReadVolumenDrAsignado(nombreArchivo);

            foreach (VolumenDr volAs in volsDrAsignados)
            {
                if (volAs.ToVolumenDrAsignado().Save())
                {
                    Logger.AddToLog("Volumen DR Asignado: " + volAs.Ciclo + " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen DR Asignado: " + volAs.Ciclo + " no guardado", true);
                }
            }

            List<VolumenDr> volsDrUtilizados = ExcelFileIO
                .ReadVolumenDrUtilizado(nombreArchivo);

            foreach (VolumenDr volUt in volsDrUtilizados)
            {
                if (volUt.ToVolumenDrAsignado().Save())
                {
                    Logger.AddToLog("Volumen DR Utilizado: " + volUt.Ciclo + " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen DR Utilizado: " + volUt.Ciclo + " no guardado", true);
                }
            }

            List<VolumenPi> volsPiAutorizados = ExcelFileIO
                .ReadVolumenPiAutorizado(nombreArchivo);

            foreach (VolumenPi volAu in volsPiAutorizados)
            {
                if (volAu.ToVolumenPiAutorizado().Save())
                {
                    Logger.AddToLog("Volumen PI autorizado: " + volAu.Ciclo + " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen PI autorizado: " + volAu.Ciclo + " no guardado", true);
                }
            }

            List<VolumenPi> volsPiAsignados = ExcelFileIO
                .ReadVolumenPiAsignado(nombreArchivo);

            foreach (VolumenPi volAs in volsPiAsignados)
            {
                if (volAs.ToVolumenPiAsignado().Save())
                {
                    Logger.AddToLog("Volumen PI asignado: " + volAs.Ciclo + " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen PI asignado: " + volAs.Ciclo + " no guardado", true);
                }
            }

            List<VolumenPi> volsPiUtilizados = ExcelFileIO
                .ReadVolumenPiUtilizado(nombreArchivo);

            foreach (VolumenPi volUt in volsPiUtilizados)
            {
                if (volUt.ToVolumenPiUtilizado().Save())
                {
                    Logger.AddToLog("Volumen PI utilizado: " + volUt.Ciclo + " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen PI utilizado: " + volUt.Ciclo + " no guardado", true);
                }
            }

            List<VolumenPiOld> volsPiOldAutorizados = ExcelFileIO
                .ReadVolumenPiOldAutorizado(nombreArchivo);

            foreach (VolumenPiOld volPiOld in volsPiOldAutorizados)
            {
                if(volPiOld.ToVolumenPiAutorizadoOld().Save())
                {
                    Logger.AddToLog("Volumen PI Old Autorizado: " + 
                        volPiOld.Ciclo + " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen PI Old Autorizado: " + 
                        volPiOld.Ciclo + " no guardado", true);
                }
            }

            List<VolumenPiOld> volsPiOldUtilizados = ExcelFileIO
                .ReadVolumenPiOldUtilizado(nombreArchivo);

            foreach (VolumenPiOld volPiOld in volsPiOldUtilizados)
            {
                if (volPiOld.ToVolumenPiUtilizadoOld().Save())
                {
                    Logger.AddToLog("Volumen PI Old Autorizado: " +
                        volPiOld.Ciclo + " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen PI Old Autorizado: " +
                        volPiOld.Ciclo + " no guardado", true);
                }
            }

            List<VolumenGt> volsGtAsignados = ExcelFileIO.ReadVolumenGtAsignado(nombreArchivo);

            Logger.AddToLog("Volúmenes GT Asignados", true);

            foreach (VolumenGt volGt in volsGtAsignados)
            {
                if(volGt.ToVolumenGtAsignado().Save())
                {
                    Logger.AddToLog("Volumen GT Asignado: " + volGt.Ciclo +
                        " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen GT Asignado: " + volGt.Ciclo +
                        " no guardado", true);
                }
            }

            List<VolumenGt> volsGtAutorizados = ExcelFileIO.ReadVolumenGtAutorizado(nombreArchivo);

            Logger.AddToLog("Volúmenes GT Autorizados", true);

            foreach (VolumenGt volGt in volsGtAutorizados)
            {
                if (volGt.ToVolumenGtAutorizado().Save())
                {
                    Logger.AddToLog("Volumen GT Asignado: " + volGt.Ciclo +
                        " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen GT Asignado: " + volGt.Ciclo +
                        " no guardado", true);
                }
            }

            List<VolumenGt> volsGtUtilizados = ExcelFileIO.ReadVolumenGtUtilizado(nombreArchivo);

            Logger.AddToLog("Volúmenes GT Utilizados", true);

            foreach (VolumenGt volGt in volsGtUtilizados)
            {
                if (volGt.ToVolumenGtUtilizado().Save())
                {
                    Logger.AddToLog("Volumen GT Asignado: " + volGt.Ciclo +
                        " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen GT Asignado: " + volGt.Ciclo +
                        " no guardado", true);
                }
            }

            List<VolumenAg> volsAgAsignados = ExcelFileIO.ReadVolumenAgAsignado(nombreArchivo);

            Logger.AddToLog("Volúmenes AG Asignados", true);

            foreach (VolumenAg volAg in volsAgAsignados)
            {
                if (volAg.ToVolumenAgAsignado().Save())
                {
                    Logger.AddToLog("Volumen AG Asignado: " + volAg.Ciclo +
                        " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen AG Asignado: " + volAg.Ciclo +
                        " no guardado", true);
                }
            }

            List<VolumenAg> volsAgAutorizados = ExcelFileIO.ReadVolumenAgAutorizado(nombreArchivo);

            Logger.AddToLog("Volúmenes Ag Autorizados", true);

            foreach (VolumenAg volAg in volsAgAutorizados)
            {
                if (volAg.ToVolumenAgAutorizado().Save())
                {
                    Logger.AddToLog("Volumen AG Asignado: " + volAg.Ciclo +
                        " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen AG Asignado: " + volAg.Ciclo +
                        " no guardado", true);
                }
            }

            List<VolumenAg> volsAgUtilizados = ExcelFileIO.ReadVolumenAgUtilizado(nombreArchivo);

            Logger.AddToLog("Volúmenes Ag Utilizados", true);

            foreach (VolumenAg volAg in volsAgUtilizados)
            {
                if (volAg.ToVolumenAgUtilizado().Save())
                {
                    Logger.AddToLog("Volumen AG Asignado: " + volAg.Ciclo +
                        " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen AG Asignado: " + volAg.Ciclo +
                        " no guardado", true);
                }
            }

            volsAgAsignados = VolumenAgAsignado.All();

            Logger.AddToLog("Volúmenes AG Asignados from DB", true);

            foreach (VolumenAg volAg in volsAgAsignados)
            {
                Logger.AddToLog(volAg.ToJSON(), true);
            }

            volsAgAutorizados = VolumenAgAutorizado.All();

            Logger.AddToLog("Volúmenes Ag Autorizados from DB", true);

            foreach (VolumenAg volAg in volsAgAutorizados)
            {
                Logger.AddToLog(volAg.ToJSON(), true);
            }

            volsAgUtilizados = VolumenAgUtilizado.All();

            Logger.AddToLog("Volúmenes Ag Utilizados from DB", true);

            foreach (VolumenAg volAg in volsAgUtilizados)
            {
                Logger.AddToLog(volAg.ToJSON(), true);
            }
        }

        /// <summary>
        /// Ingresa los registros de lluvia anual por estación en caso de que 
        /// ese archivo sea el que se subió al servidor.
        /// </summary>
        /// <param name="nombreArchivo">
        /// Nombre del archivo de excel que contiene los datos.
        /// </param>
        protected void IngresarLluviaAnualEstacion(string nombreArchivo)
        {
            Logger.AddToLog("IngresarLluviaAnualEstacion", true);

            List<LluviaAnualEstacion> lluvias =
                ExcelFileIO.ReadLluviaAnualEstacion(nombreArchivo);

            foreach (LluviaAnualEstacion lae in lluvias)
            {
                if (lae.Save())
                {
                    Logger.AddToLog("Lluvia anual por estación: " + lae.Ciclo +
                        " agregado.", true);
                }
                else
                {
                    Logger.AddToLog("Lluvia anual por estación: " + lae.Ciclo +
                        " no agregado.", true);
                }
            }
        }

        /// <summary>
        /// Cierra la sesion del usuario logueado acutualmente.
        /// </summary>
        protected void Logout(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Session["pageBeforeLogin"] = null;
            Response.Redirect("login_admin.aspx");
        }
    }
}