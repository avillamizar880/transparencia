using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class crearUsuarios_ajax : App_Code.PageSession
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Crear usuario en bd
            string outTxt = "";
            string nombre = "";
            string email = "";
            string celular = "";
            string hash_clave = "auditorias123";
            string id_perfil = "";
            string hash_aux = "";
            string hash_codigo = "";
            string cod_error = "";
            string msg_error = "";
            string id_usuario = "";
            int id_usuario_aux = 0;


            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("id_perfil"))
                {
                    id_perfil = Request.Params.GetValues("id_perfil")[0].ToString();
                }
                if (pColl.AllKeys.Contains("nombre"))
                {
                    nombre = Request.Params.GetValues("nombre")[0].ToString();
                }
                if (pColl.AllKeys.Contains("email"))
                {
                    email = Request.Params.GetValues("email")[0].ToString();
                }
                if (pColl.AllKeys.Contains("celular"))
                {
                    celular = Request.Params.GetValues("celular")[0].ToString();
                }
            }
            AuditoriasCiudadanas.App_Code.funciones func = new App_Code.funciones();
            hash_aux = func.SHA256Encripta(hash_clave);

            AuditoriasCiudadanas.Controllers.UsuariosController datos = new AuditoriasCiudadanas.Controllers.UsuariosController();
            outTxt = datos.insercionOtros(nombre, email, celular, hash_aux, Convert.ToInt16(id_perfil));
            string[] separador = new string[] { "<||>" };
            var result = outTxt.Split(separador, StringSplitOptions.None);
            cod_error = result[0];
            msg_error = result[1];
            id_usuario = result[2];

            if (cod_error.Equals("0"))
            {
                //usuario creado
                if (!string.IsNullOrEmpty(id_usuario))
                {
                    //genera codigo hash para verificacion de cuenta
                    id_usuario_aux = Convert.ToInt16(id_usuario);
                    hash_codigo = func.SHA256Encripta(id_usuario);
                }
                //actualiza codigo de verificacion
                AuditoriasCiudadanas.Controllers.UsuariosController func_usu = new AuditoriasCiudadanas.Controllers.UsuariosController();
                outTxt = func_usu.updCodigoVerifica(id_usuario_aux, hash_codigo);
                result = outTxt.Split(separador, StringSplitOptions.None);
                cod_error = result[0];
                msg_error = result[1];
                if (cod_error.Equals("0"))
                {
                    //si no hubo error en actualizacion de codigo, se envia correo
                    AuditoriasCiudadanas.Controllers.EnvioCorreosController func_correo = new AuditoriasCiudadanas.Controllers.EnvioCorreosController();
                    outTxt = func_correo.verificaCuentaCorreo(email, hash_codigo);
                }
                Response.Write(outTxt);
            }
            else {
                outTxt = cod_error + "<||>" + msg_error;
                Response.Write(outTxt);
            }

        }
    }
}
