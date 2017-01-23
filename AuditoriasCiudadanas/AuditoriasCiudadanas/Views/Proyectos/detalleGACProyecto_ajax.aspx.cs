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
            string id_usuario = "";
            int id_usuario_aux = 0;
            string opcion = "";
            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("opcion"))
            {
                opcion = Request.Params.GetValues("opcion")[0].ToString();
            }
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
            if (!string.IsNullOrEmpty(opcion))
            {
                if (opcion.Equals("CANT"))
                {
                    AuditoriasCiudadanas.Controllers.ProyectosController datos = new AuditoriasCiudadanas.Controllers.ProyectosController();
                    outTxt = datos.obtGACProyectoCant(bpin_proyecto, id_usuario_aux);
                }
            }
            else { 
                AuditoriasCiudadanas.Controllers.ProyectosController datos = new AuditoriasCiudadanas.Controllers.ProyectosController();
                outTxt = datos.obtGACProyecto(bpin_proyecto, id_usuario_aux);
            }
           
            Response.Write(outTxt);
            Response.End();
        }
    }
}