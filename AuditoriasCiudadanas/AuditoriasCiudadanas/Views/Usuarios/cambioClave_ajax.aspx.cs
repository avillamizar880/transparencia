using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class cambioClave_ajax : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string clave_ant = "";
            string clave_new = "";
            int id_usuario = 0;
            string outTxt = "";

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("clave_ant")){
                    clave_ant = HttpUtility.UrlDecode(Request.Params.GetValues("clave_ant")[0].ToString());
                }
                if (pColl.AllKeys.Contains("clave_new"))
                {
                    clave_new = HttpUtility.UrlDecode(Request.Params.GetValues("clave_new")[0].ToString());
                }
                if (pColl.AllKeys.Contains("id_usuario") && !string.IsNullOrEmpty(Request.Params.GetValues("id_usuario")[0].ToString()))
                {
                    id_usuario = Convert.ToInt16(Request.Params.GetValues("id_usuario")[0].ToString());
                }
            }

            App_Code.funciones func =new App_Code.funciones();
            string hash_clave_new=func.SHA256Encripta(clave_new);
            string hash_clave_ant = func.SHA256Encripta(clave_ant);
            AuditoriasCiudadanas.Controllers.UsuariosController datos = new AuditoriasCiudadanas.Controllers.UsuariosController();
            outTxt = datos.CambiarClave(id_usuario, hash_clave_ant,hash_clave_new);
            Response.Write(outTxt);
        }
    }
}