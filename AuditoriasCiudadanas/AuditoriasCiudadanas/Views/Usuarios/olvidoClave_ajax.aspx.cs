using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class olvidoClave_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            string outTxt = "";
            string email = "";
            string cod_error = "";
            string msg_error = "";
            string hash_codigo = "";
            string id_usuario="";
            string hash_verifica = ""; 
            divConfirmaEnvio.Visible = false;
            divNotificaError.Visible = false;


            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                //string nombre,string email,string celular,string hash_clave,int idperfil,int id_departamento,int id_municipio
                NameValueCollection pColl = Request.Form;
                if (pColl.AllKeys.Contains("email"))
                {
                    email = Request.Params.GetValues("email")[0].ToString();
                }
            }

            string[] separador = new string[] { "<||>" };
            if (!string.IsNullOrEmpty(email)) {
                AuditoriasCiudadanas.Controllers.UsuariosController datos_usu = new AuditoriasCiudadanas.Controllers.UsuariosController();
                outTxt = datos_usu.ValidaEmail(email);
                var resultado = outTxt.Split(separador, StringSplitOptions.None);
                id_usuario = resultado[0];
                hash_verifica = resultado[1];
                hash_codigo = hash_verifica.Substring(0, 6);
            }

            hdIdUsuario.Value = id_usuario;

            AuditoriasCiudadanas.Controllers.EnvioCorreosController datos = new AuditoriasCiudadanas.Controllers.EnvioCorreosController();
            outTxt = datos.notificaCodigoOlvido(email, hash_codigo);
            var result = outTxt.Split(separador, StringSplitOptions.None);
            cod_error = result[0];
            msg_error = result[1];
            if (cod_error.Equals("0"))
            {
                //no hubo error envio de correo
                divConfirmaEnvio.Visible = true;
            }
            else {
                divConfirmaEnvio.Visible = false;
                textoVerificaError.InnerText = msg_error;
            }

        }
    }
}