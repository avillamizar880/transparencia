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
            if (!string.IsNullOrEmpty(email))
            {
                AuditoriasCiudadanas.Controllers.UsuariosController datos_usu = new AuditoriasCiudadanas.Controllers.UsuariosController();
                outTxt = datos_usu.ValidaEmail(email);
                var resultado = outTxt.Split(separador, StringSplitOptions.None);
                id_usuario = resultado[0];
                if (!string.IsNullOrEmpty(id_usuario))
                {
                    hdIdUsuario.Value = id_usuario;
                    Random rnd = new Random();
                    int cont = rnd.Next(1000, 1000001);
                    AuditoriasCiudadanas.App_Code.funciones func = new App_Code.funciones();
                    string cod_aux = func.SHA256Encripta(cont.ToString());

                    string outCod = datos_usu.updCodigoVerifica(Convert.ToInt16(id_usuario), cod_aux);
                    var result_upd = outCod.Split(separador, StringSplitOptions.None);
                    if (result_upd[0].Equals("0"))
                    {
                        hash_verifica = cod_aux;
                        if (!string.IsNullOrEmpty(hash_verifica))
                        {
                            hash_codigo = hash_verifica.Substring(0, 6);
                            //envio correo con codigo verificacion
                            AuditoriasCiudadanas.Controllers.EnvioCorreosController datos = new AuditoriasCiudadanas.Controllers.EnvioCorreosController();
                            outTxt = datos.notificaCodigoOlvido(email, hash_codigo);

                            var result = outTxt.Split(separador, StringSplitOptions.None);
                            cod_error = result[0];
                            msg_error = result[1];
                            if (cod_error.Equals("0"))
                            {
                                //envio de correo exitoso
                                divConfirmaEnvio.Visible = true;
                            }
                            else
                            {
                                divConfirmaEnvio.Visible = false;
                                textoVerificaError.InnerText = msg_error;
                            }

                        }
                        else
                        {
                            divConfirmaEnvio.Visible = false;
                            textoVerificaError.InnerText = "Error en consulta: código de verificacion no generado";

                        }
                    }
                    else {
                        divConfirmaEnvio.Visible = false;
                        textoVerificaError.InnerText = "Error en consulta: código de verificacion no generado";


                    }

                    


                }
                else {
                    divConfirmaEnvio.Visible = false;
                    textoVerificaError.InnerText = "No existe un usuario activo para el correo digitado";

                }


                


            }
            else {
                divConfirmaEnvio.Visible = false;
                textoVerificaError.InnerText = "Debe ingresar un email válido";

            }



        }
    }
}