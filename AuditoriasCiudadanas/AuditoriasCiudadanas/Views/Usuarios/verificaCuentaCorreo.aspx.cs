using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AuditoriasCiudadanas.Views.Usuarios
{
    public partial class verificaCuentaCorreo : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "GET")
            {
                //string nombre,string email,string celular,string hash_clave,int idperfil,int id_departamento,int id_municipio
                string idUsuario = "";
                string outTxt = "";
                string keyUsu = "";
                string cod_error = "";
                string msg_error = "";
                NameValueCollection pColl = Request.Params;

                AuditoriasCiudadanas.Controllers.EnvioCorreosController datos_url = new AuditoriasCiudadanas.Controllers.EnvioCorreosController();
                string url_local = datos_url.obtUrlLocal();
                btnVerificaCuenta.HRef = url_local + "/Principal";

                if (pColl.AllKeys.Contains("keyUsu"))
                {
                    keyUsu = Request.Params.GetValues("keyUsu")[0].ToString();
                }

                AuditoriasCiudadanas.Controllers.UsuariosController datos = new AuditoriasCiudadanas.Controllers.UsuariosController();
                DataTable dtInfo = datos.obtDatosUsuarioByHash(keyUsu);
                if (dtInfo.Rows.Count > 0)
                {
                    string email = dtInfo.Rows[0]["email"].ToString().Trim();
                    string estado = dtInfo.Rows[0]["Estado"].ToString().Trim();
                    string id_usuario_cre = dtInfo.Rows[0]["IdUsuario"].ToString().Trim();
                    string id_perfil = dtInfo.Rows[0]["IdPerfil"].ToString().Trim();
                    if (estado.Equals("CREADO"))
                    {
                        //activar usuario
                        if (!string.IsNullOrEmpty(id_usuario_cre))
                        {
                            string[] separador = new string[] { "<||>" };   
                            outTxt = datos.activarCuentaUsuario(Convert.ToInt16(id_usuario_cre));
                            var result = outTxt.Split(separador, StringSplitOptions.None);
                            cod_error = result[0];
                            msg_error = result[1];
                            if (cod_error.Equals("0"))
                            {
                                AuditoriasCiudadanas.Controllers.EnvioCorreosController func_correo = new AuditoriasCiudadanas.Controllers.EnvioCorreosController();
                                outTxt = func_correo.notificaCredencialesCorreo(email, idUsuario,id_perfil);

                                result = outTxt.Split(separador, StringSplitOptions.None);
                                cod_error = result[0];
                                msg_error = result[1];
                                if (cod_error.Equals("0"))
                                {
                                    textoVerifica.InnerHtml = "Gracias por verificar su cuenta, hemos enviado las credenciales al correo registrado.";
                                    Session["idUsuario"] = id_usuario_cre;
                                    Random r = new Random(DateTime.Now.Millisecond);
                                    string key_opc = r.Next(10000, 99999).ToString();
                                    if (id_perfil.Equals("2"))
                                    {
                                        //ciudadano: llena encuesta de caracterizacion
                                        //btnVerificaCuenta.HRef = url_local + "/Principal?opc=" + key_opc;
                                        btnVerificaCuenta.HRef = url_local + "/Principal";
                                        divPasosRegistro.Visible = true;
                                    }
                                    else {
                                        btnVerificaCuenta.HRef = url_local + "/Principal";
                                        divPasosRegistro.Visible = false;
                                    }
                                   
                                }
                                else
                                {
                                    textoVerifica.InnerHtml = "Ha ocurrido un error al enviar credenciales:" + msg_error;
                                }
                            }
                            else {

                                textoVerifica.InnerHtml = "Ha ocurrido un error al activar cuenta de Usuario:" + msg_error;
                            }
                                
                        }
                        else {
                            textoVerifica.InnerHtml = "Verificación errónea, usuario no existente";
                        }
                       
                    }
                    else
                    {
                        textoVerifica.InnerHtml = "Verificación errónea, el usuario no se encuentra en estado: " + "CREADO";
                    }

                }
                else {
                    textoVerifica.InnerHtml = "Verificación errónea, sin información de usuario";
                }
            }
        }
    }
}