using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class addDescripcionTecnica_ajax : App_Code.PageSession
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string bpin_proyecto = "";
            string titulo = "";
            string descripcion = "";
            int id_usuario_aux = 0;
            string id_usuario = "";

            string outTxt = "";
            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("bpin_proyecto"))
            {
                bpin_proyecto = Request.Params.GetValues("bpin_proyecto")[0].ToString();
            }
            if (pColl.AllKeys.Contains("titulo"))
            {
                titulo = Request.Params.GetValues("titulo")[0].ToString();
            }
            if (pColl.AllKeys.Contains("texto"))
            {
                descripcion = Request.Params.GetValues("texto")[0].ToString();
            }
            if (pColl.AllKeys.Contains("id_usuario"))
            {
                id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                if (!string.IsNullOrEmpty(id_usuario)) {
                    id_usuario_aux = Convert.ToInt16(id_usuario);
                }
            }

            AuditoriasCiudadanas.Controllers.ProyectosController datos = new AuditoriasCiudadanas.Controllers.ProyectosController();
            outTxt = datos.addDescTecnica(bpin_proyecto, titulo, descripcion, id_usuario_aux);
            Response.Write(outTxt);
            Response.End();
        }
    }
}