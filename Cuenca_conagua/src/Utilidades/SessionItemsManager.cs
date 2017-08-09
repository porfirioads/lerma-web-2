using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI.HtmlControls;

namespace Cuenca_conagua.src.Utilidades
{
    /// <summary>
    /// Esta clase contiene métodos para realizar determinadas acciones que
    /// tienen que ver con las sesiones en ASP.NET, como mostrar u ocultar
    /// información dependiendo si hay sesiones iniciadas y quién las inició.
    /// </summary>
    public class SessionItemsManager
    {
        /// <summary>
        /// Oculta el elemento html pasado como parámetro si no existe una
        /// sesión de usuario iniciada.
        /// </summary>
        /// <param name="sesion">
        /// Es manejador de sesiones de donde se verificará si un usuario ha
        /// iniciado sesión.
        /// </param>
        /// <param name="elemento">
        /// Es el elemento html que se va a ocultar si no hay una sesión 
        /// inciada, son los elementos que no se muestran a los usuarios no
        /// registrados, como la pestaña para subir información al sistema.
        /// </param>
        public static void HideIfNotSession(HttpSessionState sesion, HtmlAnchor elemento)
        {
            if (sesion["usuario"] == null)
            {
                Logger.AddToLog("sesion inactiva", true);
                elemento.Attributes["class"] = "hidden";
            }
            else
            {
                Logger.AddToLog("sesion activa", true);
            }
        }
    }
}