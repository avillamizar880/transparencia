using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class restablecerPassword_ajax : System.Web.UI.Page
    {

        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Form;
                string clave_new = "";
                int id_usuario_aux=0;
                string outTxt = "";
                if (pColl.AllKeys.Contains("clave_new"))
                {
                    clave_new = HttpUtility.UrlDecode(Request.Params.GetValues("clave_new")[0].ToString());
                }
                if (pColl.AllKeys.Contains("id_usuario") && !string.IsNullOrEmpty(Request.Params.GetValues("id_usuario")[0].ToString()))
                {
                    id_usuario_aux = Convert.ToInt16(Request.Params.GetValues("id_usuario")[0].ToString());
                }

                App_Code.funciones func =new App_Code.funciones();
                string hash_clave_new=func.SHA256Encripta(clave_new);
                AuditoriasCiudadanas.Controllers.UsuariosController datos = new AuditoriasCiudadanas.Controllers.UsuariosController();
                outTxt = datos.CambiarClaveOlvido(id_usuario_aux, hash_clave_new);
                Response.Write(outTxt);
           }
       }
    }
}