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
            string bpin_proyecto = "";
            string outTxt = "";
            string id_usuario = "";
            int id_usuario_aux = 0;
            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("id_proyecto"))
            {
                bpin_proyecto = Request.Params.GetValues("id_proyecto")[0].ToString();
            }
            if (pColl.AllKeys.Contains("id_usuario"))
            {
                id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                if (!string.IsNullOrEmpty(id_usuario)) {
                    id_usuario_aux = Convert.ToInt16(id_usuario);
                }

            }
            if (!string.IsNullOrEmpty(bpin_proyecto))
            {
                Session["bpinProyecto"] = bpin_proyecto;
            }
            AuditoriasCiudadanas.Controllers.ProyectosController datos = new AuditoriasCiudadanas.Controllers.ProyectosController();
            outTxt = datos.obtInfoProyecto(bpin_proyecto,id_usuario_aux);
            Response.Write(outTxt);
            Response.End();
        }
    }
}