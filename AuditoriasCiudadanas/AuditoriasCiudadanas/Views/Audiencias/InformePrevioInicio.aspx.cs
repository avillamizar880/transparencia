using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class RegistrarObservaciones : App_Code.PageSession
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string id_usuario = "";
            string id_proyecto = "";
            string id_grupo = "";

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("cod_bpin"))
                {
                    id_proyecto = Request.Params.GetValues("cod_bpin")[0].ToString();
                }
                else
                {
                    if (Session["bpinProyecto"] != null)
                    {
                        id_proyecto = Session["bpinProyecto"].ToString();
                    }
                }
                if (pColl.AllKeys.Contains("id_usuario"))
                {
                    id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                }
                else
                {
                    if (Session["idUsuario"] != null)
                    {
                        id_usuario = Session["idUsuario"].ToString();
                    }
                }
                if (pColl.AllKeys.Contains("id_grupo"))
                {
                    id_grupo = Request.Params.GetValues("id_grupo")[0].ToString();
                }


                hfidproyecto.Value = id_proyecto;
                hdIdUsuario.Value = id_usuario;
                hdIdGrupo.Value = id_grupo;
            }
        }
    }
}