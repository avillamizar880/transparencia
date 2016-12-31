using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class agregarInfoTecnica_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string bpin_proyecto = "";
            string titulo="";
            string descripcion="";
            string[] rutas={"",""};
            int id_usuario_aux = 0;

            string outTxt = "";
            NameValueCollection pColl = Request.Params;
            if (pColl.AllKeys.Contains("bpin_proyecto")){
                bpin_proyecto = Request.Params.GetValues("bpin_proyecto")[0].ToString();
            }
            if (pColl.AllKeys.Contains("titulo")){
                titulo = Request.Params.GetValues("titulo")[0].ToString();
            }
            if (pColl.AllKeys.Contains("descripcion")){
                descripcion = Request.Params.GetValues("descripcion")[0].ToString();
            }
            if (pColl.AllKeys.Contains("id_usuario")){
                id_usuario_aux = Convert.ToInt16(Request.Params.GetValues("id_usuario")[0].ToString());
            }

            AuditoriasCiudadanas.Controllers.ProyectosController datos = new AuditoriasCiudadanas.Controllers.ProyectosController();
            outTxt = datos.addInfoTecnica(bpin_proyecto, titulo, descripcion, rutas, id_usuario_aux);
            Response.Write(outTxt);
            Response.End();
      }
    }
}