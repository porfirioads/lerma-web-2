using Cuenca_conagua.src.Utilidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Cuenca_conagua.pages
{
    /// <summary>
    /// Esta clase contiene el código de la página de los boletines.
    /// </summary>
    public partial class boletines : System.Web.UI.Page
    {
        private const string BOLETINES_PATH = "uploaded_files/boletines";

        /// <summary>
        /// Se ejecuta cuando la página se carga.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            LogBoletinesList();
            LoadBoletines();
        }

        /// <summary>
        /// Carga los boletines como links
        /// </summary>
        private void LoadBoletines()
        {
            FileManager.crearCarpetasFaltantes(BOLETINES_PATH);

            string[] files = FileManager.getArchivosEnDirectorioRelative(
                BOLETINES_PATH);

            int mitad = files.Length / 2;

            for (int i = 0; i < mitad; i++)
            {
                HtmlTableRow row = new HtmlTableRow();
                AddLinkCellToRow(row, files[i]);
                AddLinkCellToRow(row, files[i + mitad]);
                boletinesTable.Rows.Add(row);
            }

            if (mitad * 2 < files.Length)
            {
                HtmlTableRow row = new HtmlTableRow();
                AddLinkCellToRow(row, files[files.Length - 1]);
                boletinesTable.Rows.Add(row);
            }
        }

        /// <summary>
        /// Agrega un link como celda de una fila de una tabla
        /// </summary>
        /// <param name="row">
        /// Es la fila de la tabla donde se agregará la celda
        /// </param>
        /// <param name="filePath">
        /// Es la ruta a donde apuntará el link
        /// </param>
        private void AddLinkCellToRow(HtmlTableRow row, string filePath)
        {
            HtmlTableCell cell = new HtmlTableCell();
            HtmlAnchor anchor = new HtmlAnchor();
            anchor.Attributes["class"] = "btn btn-white btn-100";
            anchor.Attributes["href"] = filePath;
            anchor.Attributes["target"] = "_blank";
            string filename = FileManager.ExtractFilename(filePath.Replace(
                '/', '\\'));
            Logger.AddToLog("Filename: " + filename, true);
            anchor.InnerHtml = filename;
            cell.Controls.Add(anchor);
            row.Cells.Add(cell);
        }

        /// <summary>
        /// Lista los boletines y los escribe en el log
        /// </summary>
        private void LogBoletinesList()
        {
            string[] files = FileManager.getArchivosEnDirectorioRelative(
                BOLETINES_PATH);
            Logger.AddToLog("Archivos en " + BOLETINES_PATH, true);
            Logger.AddToLog("Hay " + files.Length + " archivos", true);

            foreach (string file in files)
            {
                Logger.AddToLog(file, true);
            }
        }
    }
}