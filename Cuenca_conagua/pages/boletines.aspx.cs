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
    /// Esta clase contiene el código de la página de los boletines.
    /// </summary>
    public partial class boletines : System.Web.UI.Page
    {
        /// <summary>
        /// Se ejecuta cuando la página se carga.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionItemsManager.HideIfNotSession(Session, linkSubirDatos);
        }
    }
}