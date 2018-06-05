using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class detalleGestionProyecto_ajax : App_Code.PageSession
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
                string id_grupo = "";
                string id_usuario = "";
                string bpin_proyecto = "";
                int id_grupo_aux = 0;
                int id_usuario_aux = 0;
                string outTxt = "";

                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("id_grupo")){
                    id_grupo = Request.Params.GetValues("id_grupo")[0].ToString();
                    if (!string.IsNullOrEmpty(id_grupo))
                    {
                        id_grupo_aux = Convert.ToInt16(id_grupo);
                    }
                }
                if (pColl.AllKeys.Contains("id_usuario")){
                    id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                    if (!string.IsNullOrEmpty(id_usuario))
                    {
                        id_usuario_aux = Convert.ToInt16(id_usuario);
                    }
                }
                if (pColl.AllKeys.Contains("bpin_proyecto")){
                    bpin_proyecto = Request.Params.GetValues("bpin_proyecto")[0].ToString();
                }

            AuditoriasCiudadanas.Controllers.ProyectosController datos = new AuditoriasCiudadanas.Controllers.ProyectosController();
            outTxt = datos.obtGestionProyecto(bpin_proyecto, id_grupo_aux, id_usuario_aux);
            Response.Write(outTxt);
            Response.End();
        }
    }
}