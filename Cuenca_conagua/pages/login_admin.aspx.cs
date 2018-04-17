using Cuenca_conagua.src.Entidades;
using Cuenca_conagua.src.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cuenca_conagua.pages
{
    /// <summary>
    /// Esta clase contiene el código de la página de login.
    /// </summary>
    public partial class login_admin : System.Web.UI.Page
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
                if (Session["pageBeforeLogin"] == null)
                {
                    Response.Redirect("default.aspx");
                }
                else
                {
                    Response.Redirect(Session["pageBeforeLogin"].ToString());
                }
            }
        }

        /// <summary>
        /// Valida que el usuario y contrasena coincidan en la base de datos.
        /// </summary>
        /// <param name="nombreUsuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool ValidarUsuario(string nombreUsuario, string password)
        {
            Administrador admin = Administrador.Find(nombreUsuario);
            //Logger.AddToLog("Admin: " + (admin == null), true);
            if (admin == null)
            {
                return false;
            }
            else
            {
                return admin.Password.Equals(password);
            }
        }

        /// <summary>
        /// Se ejecuta se presiona el botón de iniciar sesión.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = Request.Form.Get("txtUsuario");
            string password = Request.Form.Get("txtPassword");
            if (usuario != null)
            {
                if (ValidarUsuario(usuario, password))
                {
                    Session["usuario"] = txtUsuario.Text;

                    if (Session["pageBeforeLogin"] == null)
                    {
                        Response.Redirect("default.aspx");
                    }
                    else
                    {
                        Response.Redirect(Session["pageBeforeLogin"].ToString());
                    }
                }
                else
                {
                    divErrorLogin.Attributes["class"] = "div-mensaje div-error";
                }
            }
        }

    }
}