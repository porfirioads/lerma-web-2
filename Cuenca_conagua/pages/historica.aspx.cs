using Cuenca_conagua.src.Entidades;
using Cuenca_conagua.src.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            CargarPrecipitacionesJS();
            CargarEscurrimientosJS();
            CargarVolumenesJS();
            CargarLluviasAnualesEstacionJS();
            CargarAlmacenamientosPrincipalesJS();
            CargarAlmacenamientoHistoricoChapalaJS();
            */
            //yourList.Cast<IMyInterface>().ToList()

            List<PrecipitacionMedia> precipitaciones = PrecipitacionMedia.All();
            precipitaciones.Sort();
            CargarListEntidadJs(precipitaciones.Cast<IJsonable>().ToList(),
                "regPrecipitacion", scrPrecAnual);

            List<LluviaAnualEstacion> lluviasAnuales = LluviaAnualEstacion.All();
            lluviasAnuales.Sort();
            CargarListEntidadJs(lluviasAnuales.Cast<IJsonable>().ToList(),
                "regLluviaAnualEstacion", srcLluviaAnualEstacion);

            List<EscurrimientoAnual> escurrimientos = EscurrimientoAnual.All();
            escurrimientos.Sort();
            CargarListEntidadJs(escurrimientos.Cast<IJsonable>().ToList(),
                "regEscurrimiento", scrEscurrimiento);

            List<AlmacenamientoPrincipal> almacenamientosPrincipales = AlmacenamientoPrincipal.All();
            almacenamientosPrincipales.Sort();
            CargarListEntidadJs(almacenamientosPrincipales.Cast<IJsonable>().ToList(),
                "regAlmacenamientosPrincipales", srcAlmacenamientosPrincipales);

            List<VolumenDrAsignado> volDrAsignados = VolumenDrAsignado.All();
            volDrAsignados.Sort();
            CargarListEntidadJs(volDrAsignados.Cast<IJsonable>().ToList(),
                "volDrAsignados", scrVolumenes, true);

            List<VolumenDrAutorizado> volDrAutorizados = VolumenDrAutorizado.All();
            volDrAutorizados.Sort();
            CargarListEntidadJs(volDrAutorizados.Cast<IJsonable>().ToList(),
                "volDrAutorizados", scrVolumenes, true);

            List<VolumenDrUtilizado> volDrUtilizados = VolumenDrUtilizado.All();
            volDrUtilizados.Sort();
            CargarListEntidadJs(volDrUtilizados.Cast<IJsonable>().ToList(),
                "volDrUtilizados", scrVolumenes, true);

            List<VolumenPiAsignado> volPiAsignados = VolumenPiAsignado.All();
            volPiAsignados.Sort();
            CargarListEntidadJs(volPiAsignados.Cast<IJsonable>().ToList(),
                "volPiAsignados", scrVolumenes, true);

            List<VolumenPiAutorizado> volPiAutorizados = VolumenPiAutorizado.All();
            volPiAutorizados.Sort();
            CargarListEntidadJs(volPiAutorizados.Cast<IJsonable>().ToList(),
                "volPiAutorizados", scrVolumenes, true);

            List<VolumenPiUtilizado> volPiUtilizados = VolumenPiUtilizado.All();
            volPiUtilizados.Sort();
            CargarListEntidadJs(volPiUtilizados.Cast<IJsonable>().ToList(),
                "volPiUtilizados", scrVolumenes, true);

        }

        private void CargarListEntidadJs(List<IJsonable> listaEntidades,
            string nombreVariableJs, HtmlGenericControl srcControl,
            bool append = false)
        {
            if (listaEntidades != null)
            {
                StringBuilder json = new StringBuilder();
                json.Append("[");

                foreach (IJsonable entidad in listaEntidades)
                {
                    json.Append(entidad.ToJSON()).Append(",");
                }

                json.Remove(json.Length - 1, 1);
                json.Append("]");

                if (append)
                {
                    srcControl.InnerHtml += "var " + nombreVariableJs + " = " +
                    json.ToString() + ";";
                }
                else
                {
                    srcControl.InnerHtml = "var " + nombreVariableJs + " = " +
                    json.ToString() + ";";
                }

            }
        }
    }
}