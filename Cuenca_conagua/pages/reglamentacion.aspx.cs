using Cuenca_conagua.src.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Cuenca_conagua.pages
{
    /// <summary>
    /// Esta clase contiene el código de la página de reglamentación.
    /// </summary>
    public partial class reglamentacion : System.Web.UI.Page
    {
        private const string REGLAMENTACION_PATH = "uploaded_files/reglamentacion";

        /// <summary>
        /// Se ejecuta cuando la página se carga.
        /// </summary>
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadReglamentacion();
        }

        /// <summary>
        /// Carga los archivos de reglamentación como links
        /// </summary>
        private void LoadReglamentacion()
        {
            FileManager.crearCarpetasFaltantes(REGLAMENTACION_PATH);

            string[] files = FileManager.getArchivosEnDirectorioRelative(
                REGLAMENTACION_PATH);

            for (int i = 0; i < files.Length; i++)
            {
                HtmlTableRow row = new HtmlTableRow();
                AddLinkCellToRow(row, files[i]);
                reglamentacionTable.Rows.Add(row);
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
    }
}