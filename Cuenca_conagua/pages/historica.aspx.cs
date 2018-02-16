using Cuenca_conagua.src.Entidades;
using Cuenca_conagua.src.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cuenca_conagua.pages
{
    /// <summary>
    /// Esta clase contiene el código de la página de información histórica.
    /// </summary>
    public partial class historica : System.Web.UI.Page
    {
        /// <summary>
        /// Se ejecuta cuando la página se carga.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
                
            CargarPrecipitacionesJS();
            CargarEscurrimientosJS();
            CargarVolumenesJS();
        }

        /// <summary>
        /// Carga los valores de las precipitaciones desde la base de datos para
        /// agregarlos a la página para su acceso por medio de Javascript.
        /// </summary>
        private void CargarPrecipitacionesJS()
        {
            List<PrecipitacionMedia> pms = PrecipitacionMedia.All();
            pms.Sort();
            if (pms != null)
            {
                StringBuilder json = new StringBuilder();
                json.Append("[");
                foreach (PrecipitacionMedia pm in pms)
                {
                    json.Append(pm.ToJSON()).Append(", ");
                }
                json.Remove(json.Length - 1, 1);
                json.Append("]");
                scrPrecAnual.InnerHtml = "var regPrecipitacion = " + json.ToString() + ";";
            }
        }

        /// <summary>
        /// Carga los valores de los escurrimientos desde la base de datos para
        /// agregarlos a la página para su acceso por medio de Javascript.
        /// </summary>
        private void CargarEscurrimientosJS()
        {
            List<EscurrimientoAnual> eas = EscurrimientoAnual.All();
            eas.Sort();
            if (eas != null)
            {
                if (eas.Count == 0)
                {
                    Logger.AddToLog("No escurrimientos", true);
                }
                StringBuilder json = new StringBuilder();
                json.Append("[");
                foreach (EscurrimientoAnual ea in eas)
                {
                    json.Append(ea.ToJSON()).Append(", ");
                }
                json.Remove(json.Length - 1, 1);
                json.Append("]");
                scrEscurrimiento.InnerHtml = "var regEscurrimiento = "
                    + json.ToString() + ";";
            }
        }

        /// <summary>
        /// Carga los valores de los volúmenes desde la base de datos para
        /// agregarlos a la página para su acceso por medio de Javascript.
        /// </summary>
        private void CargarVolumenesJS()
        {
            StringBuilder json = new StringBuilder();
            List<VolumenDrAsignado> volDrAsignados = VolumenDrAsignado.All();
            List<VolumenDrAutorizado> volDrAutorizados = VolumenDrAutorizado.All();
            List<VolumenDrUtilizado> volDrUtilizados = VolumenDrUtilizado.All();
            List<VolumenPiAsignado> volPiAsignados = VolumenPiAsignado.All();
            List<VolumenPiAutorizado> volPiAutorizados = VolumenPiAutorizado.All();
            List<VolumenPiUtilizado> volPiUtilizados = VolumenPiUtilizado.All();
            volDrAsignados.Sort();
            volDrAutorizados.Sort();
            volDrUtilizados.Sort();
            volPiAsignados.Sort();
            volPiAutorizados.Sort();
            volPiUtilizados.Sort();
            scrVolumenes.InnerHtml = "";
            if (volDrAsignados != null)
            {
                json.Clear();
                json.Append("[");
                foreach (VolumenDrAsignado vol in volDrAsignados)
                {
                    json.Append(vol.ToJSON()).Append(", ");
                }
                //json.Remove(json.Length - 1, 1);
                json.Append("]");
                scrVolumenes.InnerHtml += "var volDrAsignados = "
                    + json.ToString() + ";";
            }
            if (volDrAutorizados != null)
            {
                json.Clear();
                json.Append("[");
                foreach (VolumenDrAutorizado vol in volDrAutorizados)
                {
                    json.Append(vol.ToJSON()).Append(", ");
                }
               // json.Remove(json.Length - 1, 1);
                json.Append("]");
                scrVolumenes.InnerHtml += "var volDrAutorizados = "
                    + json.ToString() + ";";
            }
            if (volDrUtilizados != null)
            {
                json.Clear();
                json.Append("[");
                foreach (VolumenDrUtilizado vol in volDrUtilizados)
                {
                    json.Append(vol.ToJSON()).Append(", ");
                }
                //json.Remove(json.Length - 1, 1);
                json.Append("]");
                scrVolumenes.InnerHtml += "var volDrUtilizados = "
                    + json.ToString() + ";";
            }
            if (volPiAsignados != null)
            {
                json.Clear();
                json.Append("[");
                foreach (VolumenPiAsignado vol in volPiAsignados)
                {
                    json.Append(vol.ToJSON()).Append(", ");
                }
                //json.Remove(json.Length - 1, 1);
                json.Append("]");
                scrVolumenes.InnerHtml += "var volPiAsignados = "
                    + json.ToString() + ";";
            }
            if (volPiAutorizados != null)
            {
                json.Clear();
                json.Append("[");
                foreach (VolumenPiAutorizado vol in volPiAutorizados)
                {
                    json.Append(vol.ToJSON()).Append(", ");
                }
                //json.Remove(json.Length - 1, 1);
                json.Append("]");
                scrVolumenes.InnerHtml += "var volPiAutorizados = "
                    + json.ToString() + ";";
            }
            if (volPiUtilizados != null)
            {
                json.Clear();
                json.Append("[");
                foreach (VolumenPiUtilizado vol in volPiUtilizados)
                {
                    json.Append(vol.ToJSON()).Append(", ");
                }
                //json.Remove(json.Length - 1, 1);
                json.Append("]");
                scrVolumenes.InnerHtml += "var volPiUtilizados = "
                    + json.ToString() + ";";
            }
        }
    }
}