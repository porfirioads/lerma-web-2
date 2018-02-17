using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Cuenca_conagua.src.Utilidades
{
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
        /// Lista los archivos de un path dado
        /// </summary>
        /// <param name="relativePath">
        /// Es el path a partir del cual se realizará el proceso, debe ser 
        /// relativo al directorio raiz del proyecto (.)
        /// </param>
        public static string[] getArchivosEnDirectorio(string relativePath)
        {
            string path = HttpContext.Current.Server.MapPath("../" +
                relativePath);
            string[] files = Directory.GetFiles(path);
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
                return String.Empty;
            }

            // Determine where last backslash is.
            int position = filepath.LastIndexOf('\\');

            // If there is no backslash, assume that this is a filename.
            if (position == -1)
            {
                // Determine whether file exists in the current directory.
                if (File.Exists(Environment.CurrentDirectory +
                    Path.DirectorySeparatorChar + filepath))
                {
                    return filepath;
                }
                else
                {
                    return String.Empty;
                }
            }
            else
            {
                // Determine whether file exists using filepath.
                if (File.Exists(filepath))
                {
                    // Return filename without file path.
                    return filepath.Substring(position + 1);
                }

                else
                {
                    return String.Empty;
                }
            }
        }
    }
}