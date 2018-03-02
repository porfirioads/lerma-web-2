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

                    Logger.AddToLog("TipoArchivo: " + tipo, true);
                    string savedFileName = SaveFile(file, tipoArchivo.Value);
                    
                    if(tipo == "datos")
                    {
                        IngresarBaseDatos(savedFileName);
                    }
                }
            }
            else
            {
                Response.Redirect("login_admin.aspx");
            }
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
            string path = "../";
            string fileName = file.FileName;


            if (tipo.Equals("boletin"))
            {
                FileManager.crearCarpetasFaltantes("uploaded_files/boletines");
                path = "../uploaded_files/boletines";
            }
            else if(tipo.Equals("reglamentacion"))
            {
                FileManager.crearCarpetasFaltantes("uploaded_files/reglamentacion");
                path = "../uploaded_files/reglamentacion";
            }
            else if (tipo.Equals("datos"))
            {
                FileManager.crearCarpetasFaltantes("uploaded_files/datos");
                path = "../uploaded_files/datos";
            }

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

            Logger.AddToLog("Agregar " + archivoSinRuta, true);

            if (archivoSinRuta.StartsWith("Lluvia_media_anual"))
            {
                IngresarPrecipitacionBD(nombreArchivo);
            }
            else if (archivoSinRuta.StartsWith("Escurrimiento_anual"))
            {
                IngresarEscurrimientoBD(nombreArchivo);
            }
            else if (archivoSinRuta.StartsWith("Volumenes_DR_PI"))
            {
                IngresarVolumenesBD(nombreArchivo);
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
            List<PrecipitacionMedia> precipitaciones
                    = ExcelFileIO.ReadPrecipitacionMedia(nombreArchivo);

            foreach (PrecipitacionMedia pm in precipitaciones)
            {
                Logger.AddToLog("Precipitación: " + pm.Ciclo + ", "
                    + pm.Nov + ", " + pm.Dic + ", " + pm.Ene + ", "
                     + pm.Feb + ", " + pm.Mar + ", " + pm.Abr + ", "
                      + pm.May + ", " + pm.Jun + ", " + pm.Jul + ", "
                       + pm.Ago + ", " + pm.Sep + ", " + pm.Oct, true);
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
                //Logger.AddToLog(ea.ToString(), true);
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
            List<VolumenDrAsignado> volsDrAsignados = ExcelFileIO
                .ReadVolumenDrAsignado(nombreArchivo);
            List<VolumenDrAutorizado> volsDrAutorizados = ExcelFileIO
                .ReadVolumenDrAutorizado(nombreArchivo);
            List<VolumenDrUtilizado> volsDrUtilizados = ExcelFileIO
                .ReadVolumenDrUtilizado(nombreArchivo);
            List<VolumenPiAsignado> volsPiAsignados = ExcelFileIO
                .ReadVolumenPiAsignado(nombreArchivo);
            List<VolumenPiAutorizado> volsPiAutorizados = ExcelFileIO
                .ReadVolumenPiAutorizado(nombreArchivo);
            List<VolumenPiUtilizado> volsPiUtilizados = ExcelFileIO
                .ReadVolumenPiUtilizado(nombreArchivo);

            foreach (VolumenDrAsignado volAs in volsDrAsignados)
            {
                if (volAs.Save())
                {
                    Logger.AddToLog("Volumen DR Asignado: " + volAs.Ciclo + " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen DR Asignado: " + volAs.Ciclo + " no guardado", true);
                }
            }

            foreach (VolumenDrAutorizado volAu in volsDrAutorizados)
            {
                if (volAu.Save())
                {
                    Logger.AddToLog("Volumen DR Autorizado: " + volAu.Ciclo + " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen DR Autorizado: " + volAu.Ciclo + " no guardado", true);
                }
            }

            foreach (VolumenDrUtilizado volUt in volsDrUtilizados)
            {
                if (volUt.Save())
                {
                    Logger.AddToLog("Volumen DR Utilizado: " + volUt.Ciclo + " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen DR Utilizado: " + volUt.Ciclo + " no guardado", true);
                }
            }

            foreach (VolumenPiAsignado volAs in volsPiAsignados)
            {
                if (volAs.Save())
                {
                    Logger.AddToLog("Volumen PI asignado: " + volAs.Ciclo + " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen PI asignado: " + volAs.Ciclo + " no guardado", true);
                }
            }

            foreach (VolumenPiAutorizado volAu in volsPiAutorizados)
            {
                if (volAu.Save())
                {
                    Logger.AddToLog("Volumen PI autorizado: " + volAu.Ciclo + " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen PI autorizado: " + volAu.Ciclo + " no guardado", true);
                }
            }

            foreach (VolumenPiUtilizado volUt in volsPiUtilizados)
            {
                if (volUt.Save())
                {
                    Logger.AddToLog("Volumen PI utilizado: " + volUt.Ciclo + " guardado", true);
                }
                else
                {
                    Logger.AddToLog("Volumen PI utilizado: " + volUt.Ciclo + " no guardado", true);
                }
            }
        }

        /// <summary>
        /// Cierra la sesion del usuario logueado acutualmente.
        /// </summary>
        protected void Logout(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("login_admin.aspx");
        }
    }
}