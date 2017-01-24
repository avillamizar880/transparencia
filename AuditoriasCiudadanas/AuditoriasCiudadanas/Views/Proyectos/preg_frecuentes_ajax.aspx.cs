using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class preg_frecuentes_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection pColl = Request.Params;
            string outTxt = "";
           
            AuditoriasCiudadanas.Controllers.ValoracionController datos = new AuditoriasCiudadanas.Controllers.ValoracionController();
            outTxt = datos.obtCuestionarioAyuda();
            Response.Write(outTxt);
            Response.End();
        }
    }
}