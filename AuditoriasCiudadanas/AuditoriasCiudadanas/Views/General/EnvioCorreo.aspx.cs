using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.General
{
    public partial class EnvioCorreo : System.Web.UI.Page
    {


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
                    CodigoBPIN.Value = pColl.Get("CodigoBPIN").ToString();
                }
                if (pColl.AllKeys.Contains("idTipoAudiencia"))
                {
                    idTipoAudiencia.Value = pColl.Get("idTipoAudiencia").ToString();
                }
                if (pColl.AllKeys.Contains("numeroGrupo"))
                {
                    numeroGrupo.Value = pColl.Get("numeroGrupo").ToString();
                }


                if (idTipoAudiencia.Value == "0") {
                    TituloPagina.InnerHtml = "Invitar a hacer parte del grupo auditor ciudadano "+ numeroGrupo.Value ;
                    asunto.Value= "Invitación a hacer parte del grupo auditor ciudadano " + numeroGrupo.Value;
                }
            }
            }
        }
}