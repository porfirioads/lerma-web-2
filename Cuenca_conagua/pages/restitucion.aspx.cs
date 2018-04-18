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
    public partial class restitucion : System.Web.UI.Page
    {
        private const string ARCHIVOS_CALCULO_PATH = "uploaded_files/restitucion/archivos_calculo";
        private const string PRESENTACION_COVI_PATH = "uploaded_files/restitucion/presentacion_covi";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session["pageBeforeLogin"] = "restitucion.aspx";
                Response.Redirect("login_admin.aspx");
            }
            else
            {
                LoadArchivosCalculo();
                LoadPresentacionCovi();
            }
        }

        private void LoadPresentacionCovi()
        {
            FileManager.crearCarpetasFaltantes(ARCHIVOS_CALCULO_PATH);

            string[] files = FileManager.getArchivosEnDirectorioRelative(
                ARCHIVOS_CALCULO_PATH);

            for (int i = 0; i < files.Length; i++)
            {
                HtmlTableRow row = new HtmlTableRow();
                AddLinkCellToRow(row, files[i]);
                archivosCalculoTable.Rows.Add(row);
            }
        }

        private void LoadArchivosCalculo()
        {
            FileManager.crearCarpetasFaltantes(PRESENTACION_COVI_PATH);

            string[] files = FileManager.getArchivosEnDirectorioRelative(
                PRESENTACION_COVI_PATH);

            for (int i = 0; i < files.Length; i++)
            {
                HtmlTableRow row = new HtmlTableRow();
                AddLinkCellToRow(row, files[i]);
                presentacionCoviTable.Rows.Add(row);
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