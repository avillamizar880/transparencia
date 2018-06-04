using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class RegistrarCompromisos : App_Code.PageSession
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string id_usuario = "";
            string id_audiencia = "";
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("id_usuario"))
                {
                    id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                }
                if (pColl.AllKeys.Contains("id_audiencia"))
                {
                    id_audiencia = Request.Params.GetValues("id_audiencia")[0].ToString();

                }



                hdIdAudiencia.Value = id_audiencia;
                hdIdUsuario.Value = id_usuario;

            }
        }
    }
}