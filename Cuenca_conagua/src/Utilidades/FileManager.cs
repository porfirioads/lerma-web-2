using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Cuenca_conagua.src.Utilidades
{
    /// <summary>
    /// Esta clase tiene métodos para el manejo de archivos y directorios
    /// </summary>
    public class FileManager
    {
        /// <summary>
        /// Crea las carpetas faltantes de un path dado
        /// </summary>
        /// <param name="relativePath">
        /// Es el path a partir del cual se realizará el proceso, debe ser 
        /// relativo al directorio raiz del proyecto (.)
        /// </param>
        public static void crearCarpetasFaltantes(string relativePath)
        {
            string path = HttpContext.Current.Server.MapPath("../" +
                relativePath);
            Directory.CreateDirectory(path);
        }

        /// <summary>
        /// Lista los paths absolutos de los archivos de un path dado
        /// </summary>
        /// <param name="relativePath">
        /// Es el path a partir del cual se realizará el proceso, debe ser 
        /// relativo al directorio raiz del proyecto (.)
        /// </param>
        public static string[] getArchivosEnDirectorioAbsolute(string relativePath)
        {
            string path = HttpContext.Current.Server.MapPath("../" +
                relativePath);

            FileManager.crearCarpetasFaltantes(relativePath);

            string[] files = Directory.GetFiles(path);

            return files;
        }

        /// <summary>
        /// Lista los paths relativos de los archivos de un path dado
        /// </summary>
        /// <param name="relativePath">
        /// Es el path a partir del cual se realizará el proceso, debe ser 
        /// relativo al directorio raiz del proyecto (.)
        /// </param>
        public static string[] getArchivosEnDirectorioRelative(string relativePath)
        {
            string[] files = getArchivosEnDirectorioAbsolute(relativePath);

            for (int i = 0; i < files.Length; i++)
            {
                files[i] = "../" + relativePath + "/" +
                    ExtractFilename(files[i]);
            }

            return files;
        }

        /// <summary>
        /// Extrae el nombre del archivo a partir de un path completo
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns></returns>
        public static string ExtractFilename(string filepath)
        {
            // If path ends with a "\", it's a path only so return String.Empty.
            if (filepath.Trim().EndsWith(@"\"))
            {
                Logger.AddToLog(filepath + " termina con \\", true);
                return String.Empty;
            }

            // Determine where last backslash is.
            int position = filepath.LastIndexOf('\\');

            // If there is no backslash, assume that this is a filename.
            if (position == -1)
            {
                Logger.AddToLog(filepath + " no tiene \\", true);
                return filepath;
            }
            else
            {
                Logger.AddToLog(filepath + " tiene \\", true);
                // Determine whether file exists using filepath.
                return filepath.Substring(position + 1);
            }
        }
    }
}