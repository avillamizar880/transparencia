using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class verificaCuenta : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            string outTxt = "";
            string email = "";
            string id_usuario = "";
            string cod_error = "";
            string msg_error = "";

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                //string nombre,string email,string celular,string hash_clave,int idperfil,int id_departamento,int id_municipio
                NameValueCollection pColl = Request.Form;
                
                if (pColl.AllKeys.Contains("email"))
                {
                    email = Request.Params.GetValues("email")[0].ToString();
                }
                if (pColl.AllKeys.Contains("id_usuario"))
                {
                    id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
                }
            }

            AuditoriasCiudadanas.Controllers.EnvioCorreosController datos = new AuditoriasCiudadanas.Controllers.EnvioCorreosController();
            outTxt = datos.verificaCuentaCorreo(email,id_usuario);

            string[] separador = new string[] { "<||>" };
            var result = outTxt.Split(separador, StringSplitOptions.None);
            cod_error = result[0];
            msg_error = result[1];
            if (cod_error.Equals("0"))
            {
                hdEnvio.Value = "OK";
            }
            else {
                hdEnvio.Value = msg_error;
            }

            //Response.Write(outTxt);
            //Response.End();

        }
    }
}