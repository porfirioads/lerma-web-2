using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Cuenca_conagua.src.Utilidades;

namespace Cuenca_conagua.pages
{
    public partial class esqueleto : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionItemsManager.HideIfNotSession(Session, linkSubirDatos);
            SessionItemsManager.HideIfNotSession(Session, linkRestitucion);
        }
    }
}