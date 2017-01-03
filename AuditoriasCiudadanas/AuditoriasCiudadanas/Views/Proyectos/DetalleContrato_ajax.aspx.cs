using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class DetalleContrato_ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string NumCtto = "";
            string outTxt = "";

            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("NumCtto"))
            {
                NumCtto = Request.Params.GetValues("NumCtto")[0].ToString();
            }

            AuditoriasCiudadanas.Controllers.ProyectosController datos = new AuditoriasCiudadanas.Controllers.ProyectosController();
            outTxt = datos.obtContratosProyecto(NumCtto);
            Response.Write(outTxt);
            Response.End();
        }
    }
}