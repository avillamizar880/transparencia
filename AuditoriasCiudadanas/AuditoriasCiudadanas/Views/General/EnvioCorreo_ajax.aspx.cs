using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Proyectos
{
    public partial class EnvioCorreo_ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CodigoBPIN = String.Empty;
            string destinatario = String.Empty;
            string idTipoAudiencia = String.Empty;
            string asunto = String.Empty;
            int numeroGrupo = 0;
            //string asunto = String.Empty;

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;

                if (pColl.AllKeys.Contains("CodigoBPIN"))
                {
                    CodigoBPIN = pColl.Get("CodigoBPIN").ToString();

                }
                if (pColl.AllKeys.Contains("destinatario"))
                {

                    destinatario = pColl.Get("destinatario").ToString();

                }
                if (pColl.AllKeys.Contains("idTipoAudiencia"))
                {

                    idTipoAudiencia = pColl.Get("idTipoAudiencia").ToString();
          
                }
                if (pColl.AllKeys.Contains("numeroGrupo"))
                {
                   
                    numeroGrupo = Convert.ToInt32( pColl.Get("numeroGrupo").ToString());
                }
                if (pColl.AllKeys.Contains("asunto"))
                {
                   
                    asunto = pColl.Get("asunto").ToString();
                }


                Response.Write(AuditoriasCiudadanas.Controllers.EnvioCorreosController.enviarCorreo(Convert.ToInt32(idTipoAudiencia), CodigoBPIN, numeroGrupo, destinatario, asunto));
            }
        }
    }
}