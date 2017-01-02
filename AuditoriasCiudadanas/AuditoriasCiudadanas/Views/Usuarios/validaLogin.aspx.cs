using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class validaLogin : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string email = "";
            string clave = "";
            string outTxt = "";
            string hash_aux = "";
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("email"))
                {
                    email = Request.Params.GetValues("email")[0].ToString();
                }
                if (pColl.AllKeys.Contains("clave"))
                {
                    clave = Request.Params.GetValues("clave")[0].ToString();
                    
                }
                AuditoriasCiudadanas.App_Code.funciones func = new App_Code.funciones();
                hash_aux = func.SHA256Encripta(clave);

                AuditoriasCiudadanas.Controllers.UsuariosController validaInfo = new AuditoriasCiudadanas.Controllers.UsuariosController();
                outTxt = validaInfo.ValidaLogin(email, hash_aux);
                string[] separador = new string[] {"<||>"};
                var result = outTxt.Split(separador, StringSplitOptions.None);
                Session["nombre"] = result[4].Split(new string[] { " " }, StringSplitOptions.None)[0].ToUpper();
                if (result[0].Equals("1")) { 
                    //usuario activo
                    Session["idUsuario"] = result[1];
                    Session["idPerfil"]=result[2];
                    Session["idRol"] = result[3];

                } 
                Response.Write(outTxt);
               Response.End();
            }
        }
    }
}