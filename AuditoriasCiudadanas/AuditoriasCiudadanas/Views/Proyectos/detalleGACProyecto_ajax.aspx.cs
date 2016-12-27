using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class detalleGACProyecto_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string bpin_proyecto = "";
            string outTxt = "";
            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("id_proyecto"))
            {
                bpin_proyecto = Request.Params.GetValues("id_proyecto")[0].ToString();
            }
            
            AuditoriasCiudadanas.Controllers.ProyectosController datos = new AuditoriasCiudadanas.Controllers.ProyectosController();
            outTxt = datos.obtGACProyecto(bpin_proyecto);
            Response.Write(outTxt);
            Response.End();
        }
    }
}