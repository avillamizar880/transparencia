using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class EnvioFacebook : System.Web.UI.Page
    {
        string CodigoBPIN = String.Empty;
        string destinatario = String.Empty;
        string idTipoAudiencia = String.Empty;
        string asunto = String.Empty;
        string numeroGrupo = "0";

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "GET")
            {
                NameValueCollection pColl = Request.Params;

                if (pColl.AllKeys.Contains("CodigoBPIN"))
                {
                    CodigoBPIN = pColl.Get("CodigoBPIN").ToString();
                }
                if (pColl.AllKeys.Contains("idTipoAudiencia"))
                {
                    idTipoAudiencia = pColl.Get("idTipoAudiencia").ToString();
                }
                if (pColl.AllKeys.Contains("numeroGrupo"))
                {
                    numeroGrupo = pColl.Get("numeroGrupo").ToString();
                }


                if (idTipoAudiencia == "0") {
                    Response.Write(AuditoriasCiudadanas.Controllers.EnvioCorreosController.obtHTMLCorreo(Convert.ToInt32(idTipoAudiencia), CodigoBPIN, Convert.ToInt16( numeroGrupo)));
                }
            }
            }
        }
}