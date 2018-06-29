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

            CargarVolumenesDr();

            List<VolumenPi> volPiAsignados = VolumenPiAsignado.All();
            volPiAsignados.Sort();
            CargarListEntidadJs(volPiAsignados.Cast<IJsonable>().ToList(),
                "volPiAsignados", scrVolumenes, true);

            List<VolumenPi> volPiAutorizados = VolumenPiAutorizado.All();
            volPiAutorizados.Sort();
            CargarListEntidadJs(volPiAutorizados.Cast<IJsonable>().ToList(),
                "volPiAutorizados", scrVolumenes, true);

            List<VolumenPi> volPiUtilizados = VolumenPiUtilizado.All();
            volPiUtilizados.Sort();
            CargarListEntidadJs(volPiUtilizados.Cast<IJsonable>().ToList(),
                "volPiUtilizados", scrVolumenes, true);

            List<AlmacenamientoHistoricoChapala> almHistoricosChapala = AlmacenamientoHistoricoChapala.All();
            almHistoricosChapala.Sort();
            CargarListEntidadJs(almHistoricosChapala.Cast<IJsonable>().ToList(),
                "almHistoricosChapala", srcAlmHistoricosChapala);
        }

        private void CargarVolumenesDr()
        {
            List<VolumenDr> volDrAsignados = VolumenDrAsignado.All();
            volDrAsignados.Sort();
            VolumenDr.FiltrarVolumenesDr(volDrAsignados, "03-04", 
                VolumenDr.MAYORES);
            CargarListEntidadJs(volDrAsignados.Cast<IJsonable>().ToList(),
                "volDrAsignadosActual", scrVolumenes, true);

            List<VolumenDr> volDrAsignadosOld = VolumenDrAsignado.All();
            volDrAsignadosOld.Sort();
            VolumenDr.FiltrarVolumenesDr(volDrAsignadosOld, "04-05", 
                VolumenDr.MENORES);
            CargarListEntidadJs(volDrAsignadosOld.Cast<IJsonable>().ToList(),
                "volDrAsignadosOld", scrVolumenes, true);

            List<VolumenDr> volDrAutorizados = VolumenDrAutorizado.All();
            volDrAutorizados.Sort();
            VolumenDr.FiltrarVolumenesDr(volDrAutorizados, "03-04", 
                VolumenDr.MAYORES);
            CargarListEntidadJs(volDrAutorizados.Cast<IJsonable>().ToList(),
                "volDrAutorizadosActual", scrVolumenes, true);

            List<VolumenDr> volDrAutorizadosOld = VolumenDrAutorizado.All();
            volDrAutorizadosOld.Sort();
            VolumenDr.FiltrarVolumenesDr(volDrAutorizadosOld, "04-05", 
                VolumenDr.MENORES);
            CargarListEntidadJs(volDrAutorizadosOld.Cast<IJsonable>().ToList(),
                "volDrAutorizadosOld", scrVolumenes, true);

            List<VolumenDr> volDrUtilizados = VolumenDrUtilizado.All();
            volDrUtilizados.Sort();
            VolumenDr.FiltrarVolumenesDr(volDrUtilizados, "03-04",
                VolumenDr.MAYORES);
            CargarListEntidadJs(volDrUtilizados.Cast<IJsonable>().ToList(),
                "volDrUtilizadosActual", scrVolumenes, true);

            List<VolumenDr> volDrUtilizadosOld = VolumenDrUtilizado.All();
            volDrUtilizadosOld.Sort();
            VolumenDr.FiltrarVolumenesDr(volDrUtilizadosOld, "04-05",
                VolumenDr.MENORES);
            CargarListEntidadJs(volDrUtilizadosOld.Cast<IJsonable>().ToList(),
                "volDrUtilizadosOld", scrVolumenes, true);

            /*
            Logger.AddToLog("ASIGNADOS: " + string.Join(",\n", volDrAsignados), true);
            Logger.AddToLog("ASIGNADOS OLD: " + string.Join(",\n", volDrAsignadosOld), true);
            Logger.AddToLog("AUTORIZADOS: " + string.Join(",\n", volDrAutorizados), true);
            Logger.AddToLog("AUTORIZADOS OLD: " + string.Join(",\n", volDrAutorizadosOld), true);
            Logger.AddToLog("UTILIZADOS: " + string.Join(",\n", volDrUtilizados), true);
            Logger.AddToLog("UTILIZADOS OLD: " + string.Join(",\n", volDrUtilizadosOld), true);
            */
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

                if (json.ToString().EndsWith(",")) {
                    json.Remove(json.Length - 1, 1);
                }

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