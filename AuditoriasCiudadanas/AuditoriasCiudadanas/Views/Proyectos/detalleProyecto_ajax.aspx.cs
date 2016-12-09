using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class detalleProyecto_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_proyecto = "00";
            string outTxt = "";
            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("id_proyecto"))
            {
                id_proyecto = Request.Params.GetValues("id_proyecto")[0].ToString();
            }

            AuditoriasCiudadanas.Controllers.ProyectosController datos = new AuditoriasCiudadanas.Controllers.ProyectosController();
            outTxt = datos.obtInfoProyecto(id_proyecto);
            Response.Write(outTxt);
            Response.End();
        }
    }
}