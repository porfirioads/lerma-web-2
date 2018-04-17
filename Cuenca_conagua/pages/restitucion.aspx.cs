using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cuenca_conagua.pages
{
    public partial class restitucion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Session["pageBeforeLogin"] = "restitucion.aspx";
                Response.Redirect("login_admin.aspx");
            }
        }
    }
}