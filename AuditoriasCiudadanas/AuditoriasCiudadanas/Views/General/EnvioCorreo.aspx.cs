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
        protected void Page_Load(object sender, EventArgs e)
        {
            string cuerpo = String.Empty;
            string destinatario = String.Empty;
            string asunto = String.Empty;

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;
                //string nombre,string email,string celular,string hash_clave,int idperfil,int id_departamento,int id_municipio
                //HttpContext.Current.Request.RequestType
                if (pColl.AllKeys.Contains("cuerpo"))
                {
                    cuerpo = pColl.Get("cuerpo").ToString();
                }
                if (pColl.AllKeys.Contains("destinatario"))
                {

                    destinatario = pColl.Get("destinatario").ToString();
                    //nombre = pColl.GetValues("nombre")[0].ToString();
                }
                if (pColl.AllKeys.Contains("asunto"))
                {
                    //Request["asunto"]
                    asunto = pColl.Get("asunto").ToString();
                }
                //Request.Form["asunto"];
                AuditoriasCiudadanas.Controllers.CorreoController.envCorreoNet(cuerpo, destinatario, null, null, asunto);
            }
        }
    }
}