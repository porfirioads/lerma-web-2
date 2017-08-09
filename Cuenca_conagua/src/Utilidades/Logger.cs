using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Cuenca_conagua.src.Utilidades
{
    /// <summary>
    /// Esta clase sirve para hacer registros de errores o informacion relevante
    /// para el desarrollador o administrador del servidor en un archivo de 
    /// texto.
    /// </summary>
    public class Logger
    {
        // Nombre del archivo donde se guardan los logs.
        private static string archivo = HttpContext.Current.Server.MapPath("~")
            + "/log/log.txt";

        /// <summary>
        /// Agrega un mensaje al archivo de logs.
        /// </summary>
        /// <param name="texto">
        /// Es el texto que se añadirá al archivo.
        /// </param>
        /// <param name="append">
        /// Determina si el nuevo log se añadirá al final del contenido del
        /// archivo o si lo sobreescribirá.
        /// </param>
        public static void AddToLog(string texto, bool append)
        {
            StreamWriter writer = new StreamWriter(archivo, append);
            writer.WriteLine(DateTime.Now.ToShortDateString() + " "
                + DateTime.Now.ToShortTimeString() + " => " + texto);
            writer.Close();
        }
    }
}