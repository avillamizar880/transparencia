using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class delGrupoAuditor_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                string id_grupo = "";
                string id_usuario = "";
                string bpin_proyecto = "";
                int id_grupo_aux = 0;
                int id_usuario_aux = 0;
                string outTxt = "";

                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("id_grupo"))
                {
                    id_grupo = Request.Params.GetValues("id_grupo")[0].ToString();
                    if (!string.IsNullOrEmpty(id_grupo))
                    {
                        id_grupo_aux = Convert.ToInt16(id_grupo);
                    }
                }
                if (pColl.AllKeys.Contains("id_usuario"))
                {
                    id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                    if (!string.IsNullOrEmpty(id_usuario))
                    {
                        id_usuario_aux = Convert.ToInt16(id_usuario);
                    }
                }
                if (pColl.AllKeys.Contains("bpin_proyecto"))
                {
                    bpin_proyecto = Request.Params.GetValues("bpin_proyecto")[0].ToString();
                }
                if (!string.IsNullOrEmpty(id_usuario) && !string.IsNullOrEmpty(bpin_proyecto))
                {
                    AuditoriasCiudadanas.Controllers.UsuariosController datosUsuario = new AuditoriasCiudadanas.Controllers.UsuariosController();
                    outTxt = datosUsuario.retirarseGrupoAuditor(id_usuario_aux, id_grupo_aux);
                }
                else
                {
                    outTxt = "-1<||>Datos incompletos";
                }

                Response.Write(outTxt);
                Response.End();
            }
        }
    }
}