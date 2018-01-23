using System;
using Cuenca_conagua.src.Utilidades;

namespace Cuenca_conagua.pages
{
    public partial class test_aspx: System.Web.UI.Page
    {
        protected void btnExample_OnClick(object sender, EventArgs e)
        {
            Logger.AddToLog("BtnExample OnClick", true);
        }
    }
}