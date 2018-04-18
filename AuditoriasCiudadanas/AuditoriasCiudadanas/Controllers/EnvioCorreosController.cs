using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace AuditoriasCiudadanas.Controllers
{
    public class EnvioCorreosController
    {
        public static String  enviarCorreo(int idTipoAudiencia, string codigoBPIN, int numeroGrupo, string destinatario, string asunto) {
            string outTxt = "";
            string urlRedir = "";
            if (HttpContext.Current.Request.Url.IsDefaultPort){
                urlRedir = "http://" + HttpContext.Current.Request.Url.Host;
            }
            else{
                urlRedir = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port;
            }
            List<DataTable> datos=  Models.clsEnvioCorreos.obtenerHTML( idTipoAudiencia, codigoBPIN, numeroGrupo,urlRedir,1);
            if (datos.Count >0)
            {
                if (datos[datos.Count - 1].Rows.Count > 0 && datos[datos.Count - 1].Rows[0]["cod_error"].ToString() != "0")
                {
                    outTxt= datos[datos.Count - 1].Rows[0]["cod_error"].ToString() + "<||>" + datos[datos.Count - 1].Rows[0]["mensaje_error"].ToString();
                }
                else {
                    outTxt= App_Code.CorreoUtilidad.envCorreoNet(datos[datos.Count - 1].Rows[0]["mensajeHTML"].ToString(), destinatario, null, null, asunto, datos[0]);
                }
            }
            else
            {
                outTxt= "-1<||>Error en envío";
            }
            
            return outTxt;
        }

        public static string obtHTMLCorreo(int idTipoAudiencia, string codigoBPIN, int numeroGrupo) {
            string urlRedir = "";
            if (HttpContext.Current.Request.Url.IsDefaultPort)
            {
                urlRedir = "http://" + HttpContext.Current.Request.Url.Host;
            }
            else
            {
                urlRedir = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port;
            }
            List<DataTable> datos = Models.clsEnvioCorreos.obtenerHTML(idTipoAudiencia, codigoBPIN, numeroGrupo, urlRedir, 1);
            if (datos.Count > 0)
            {
                return datos[datos.Count - 1].Rows[0]["mensajeHTML"].ToString();
            }
            return "-1<||>Error en HTML";
        }

        public string obtUrlLocal() {
            string urlRedir = "";
            //var tipo_protocolo = HttpContext.Current.Request.Url.Scheme;
            //if (HttpContext.Current.Request.Url.IsDefaultPort)
            //{
            //    urlRedir = tipo_protocolo +  "//" + HttpContext.Current.Request.Url.Host;
            //}
            //else
            //{
            //    urlRedir = tipo_protocolo + "//" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port;
            //}
            urlRedir=ConfigurationManager.AppSettings["dominio_app"];


            return urlRedir;

    }

        public String verificaCuentaCorreo(string email,string idUsuario) {
            string outTxt = "";
            string mensaje = "";
            string url_img = obtUrlLocal();
            if (!string.IsNullOrEmpty(email)) {
                List<DataTable> listaInfo = new List<DataTable>();
                listaInfo = Models.clsEnvioCorreos.obtCuentaCorreo(1);
                DataTable dtConfig = listaInfo[0];
                if (dtConfig.Rows.Count >= 1)
                {
                    mensaje += "<html>";
                    mensaje += "<body style=\"font-family:Tahoma, Geneva, sans-serif\">";
                    mensaje += "<div class=\"green\" style=\"background-color:#00A69C; width:600px;  margin:0 auto; padding:25px 0px\">";
                    mensaje += "<table width=\"100%\" style=\"color:#fff\">";
                    mensaje += "<tr><td style=\"width:200px\"><img src=\"" + url_img + "/Content/img/iconEmail6.gif\" width=\"100%\" alt=\"Verifica tu cuenta\"/></td>";
                    mensaje += "<td style=\"text-align:center\"><h1>Verifica tu cuenta</h1>";
                    mensaje += "<img src=\"" + url_img + "/Content/img/iconEmail6_1.gif\" alt=\"Icono de verificar cuenta\"/>";
                    mensaje += "<p style=\"width:60%; margin:0 auto; text-align:center\">Usted se ha registrado para participar en el ";
                    mensaje += "aplicativo de auditorías ciudadanas, Para continuar debe verificar su cuenta</p><br />";
                      mensaje += "<a href=\"" + url_img + "/Views/Usuarios/verificaCuentaCorreo?keyUsu="+ idUsuario + "\" style=\"background-color:#2AA7DF; border-bottom:3px solid #278CB8; padding:5px 25px; color:#fff; font-weight:bold\">Clic aqu&iacute;</a>";
                    mensaje += "</td></tr></table></div></body></html>";
                    outTxt = App_Code.CorreoUtilidad.envCorreoNet(mensaje, email, null, null, "Verifica tu cuenta", dtConfig);
                }
                else {
                    outTxt = "-1<||>Configuracion de correo inválida";
                }
            }else{
                outTxt = "-1<||>Email destino inválido";
            }

            return outTxt;

        }


        public String notificaCredencialesCorreo(string email,string idUsuario,string id_perfil) {
            string outTxt = "";
            string mensaje = "";
            string url_img = obtUrlLocal();
            string txt_password = "";
            string txt_instrucciones = "";
            if (!string.IsNullOrEmpty(email)) {
                List<DataTable> listaInfo = new List<DataTable>();
                listaInfo = Models.clsEnvioCorreos.obtCuentaCorreo(1);
                DataTable dtConfig = listaInfo[0];
                if (dtConfig.Rows.Count >= 1)
                {
                    if (id_perfil.Equals("1") || id_perfil.Equals("4"))
                    {
                        //1: administrador 4:tecnico dnp (creados por administrador del sistema)
                        txt_password = "Contraseña: auditorias123";
                        txt_instrucciones = "Esta contraseña es provisional, recuerde cambiarla en el menú que lleva su nombre, opción: Cambiar clave.";
                    }
                    else { 
                        txt_password="Contraseña: La usada en su registro";
                        txt_instrucciones = "";
                    }
                    
                    mensaje +="<html>";
                    mensaje += "<body style=\"font-family:Tahoma, Geneva, sans-serif\">";
                    mensaje += "<div class=\"green\" style=\"background-color:#00A69C; width:600px;  margin:0 auto; padding:25px 0px\">";
                    mensaje += "<table width=\"100%\" style=\"color:#fff\">";
	                mensaje += "<tr><td style=\"width:200px\"><img src=\"" + url_img + "/Content/img/iconEmail6.gif\" width=\"100%\" alt=\"Verifica tu cuenta\"/></td>";
                    mensaje += "<td style=\"text-align:center\"><h1>Inicia Sesi&oacute;n <img src=\"" + url_img + "/Content/img/iconEmail10_1.gif\"/></h1>";
                    mensaje += "<p style=\"width:60%; margin:0 auto; text-align:center\">Bienvenido, ahora es parte de nuestro aplicativo.</p><br />";
                    mensaje += "<p style=\"text-decoration:none;color:#fff\">Usuario:" + email + "</p>";
                    mensaje += "<p>" + txt_password + "</p>";
                    mensaje += "<p>" + txt_instrucciones + "</p><br>";
                    mensaje +="<a href=\"" +  url_img + "/Principal\" style=\"background-color:#2AA7DF; border-bottom:3px solid #278CB8; padding:5px 25px; color:#fff; font-weight:bold\">Iniciar Sesi&oacute;n</a>";
                    mensaje += "</td></tr></table></div></body></html>";
                    outTxt = App_Code.CorreoUtilidad.envCorreoNet(mensaje, email, null, null, "Credenciales", dtConfig);
                }
                else {
                    outTxt = "-1<||>Configuracion de correo inválida";
                }
            
            }else{
                outTxt = "-1<||>Email destino inválido";
            }
            

            return outTxt;

        }


        public String proponeFechaCorreo(string email)
        {
            string outTxt = "";
            string mensaje = "";
            string url_local = obtUrlLocal();
            if (!string.IsNullOrEmpty(email))
            {
                List<DataTable> listaInfo = new List<DataTable>();
                listaInfo = Models.clsEnvioCorreos.obtCuentaCorreo(1);
                DataTable dtConfig = listaInfo[0];
                if (dtConfig.Rows.Count >= 1)
                {
                    mensaje += "<html>" ; 
                    mensaje += "<body style=\"font-family:Tahoma, Geneva, sans-serif\">";
                    mensaje += "<div class=\"green\" style=\"background-color:#8CBE43; width:600px;  margin:0 auto; padding:25px 0px\">";
                    mensaje += "<table width=\"100%\" style=\"color:#fff\">";
                    mensaje += "<tr><td style=\"width:200px\"><img src=\"" + url_local + "/Content/img/iconEmail7.gif\" width=\"100%\" alt=\"Proponer Fecha\"/></td>";
                    mensaje += "<td style=\"text-align:center\"><h1>Reunión Previa con Autoridades</h1>";
                    mensaje += "<p style=\"width:60%; margin:0 auto; text-align:justify\">Agende la reuni&oacute;n previa con autoridades. P&oacute;ngase de acuerdo con su grupo auditor ciudadano y proponga una fecha e inform&eacute;le a las autoridades.</p><br />";
                    mensaje +="<a href=\""+ url_local + "/Views/Audiencias/ProponerFechaReuPrevias" + "\" style=\"background-color:#2AA7DF; border-bottom:3px solid #278CB8; padding:5px 25px; color:#fff; font-weight:bold\">";
                    mensaje +="PROPONER FECHA</a>";
                    mensaje +="</td></tr></table></div></body></html>";
                    outTxt = App_Code.CorreoUtilidad.envCorreoNet(mensaje, email, null, null, "Reunión Previa con Autoridades", dtConfig);
                }
                else
                {
                    outTxt = "-1<||>Envio de correo inválida";
                }
            }
            else
            {
                outTxt = "-1<||>Email destino inválido";
            }

            return outTxt;

        }


        public String notificaUsuarioCreado(string email, string idUsuario)
        {
            string outTxt = "";
            string mensaje = "";
            string url_img = obtUrlLocal();
            if (!string.IsNullOrEmpty(email))
            {
                List<DataTable> listaInfo = new List<DataTable>();
                listaInfo = Models.clsEnvioCorreos.obtCuentaCorreo(1);
                DataTable dtConfig = listaInfo[0];
                if (dtConfig.Rows.Count >= 1)
                {
                    mensaje += "<html>";
                    mensaje += "<body style=\"font-family:Tahoma, Geneva, sans-serif\">";
                    mensaje += "<div class=\"green\" style=\"background-color:#00A69C; width:600px;  margin:0 auto; padding:25px 0px\">";
                    mensaje += "<table width=\"100%\" style=\"color:#fff\">";
                    mensaje += "<tr><td style=\"width:200px\"><img src=\"" + url_img + "/Content/img/iconEmail6.gif\" width=\"100%\" alt=\"Credenciales\"/></td>";
                    mensaje += "<td style=\"text-align:center\"><h1>Inicia Sesi&oacute;n <img src=\"" + url_img + "/Content/img/iconEmail10_1.gif\"/></h1>";
                    mensaje += "<p style=\"width:60%; margin:0 auto; text-align:center\">Bienvenido, ahora es parte de nuestro aplicativo.</p><br />";
                    mensaje += "<p style=\"text-decoration:none;color:#fff\">Usuario:" + email + "</p>";
                    mensaje += "<p>Contraseña: auditorias123</p><br><br>";
                    mensaje += "<p>Esta contraseña es provisional, recuerde cambiarla en el menú que lleva su nombre, opción: Cambiar clave.</p><br>";
                    mensaje += "<a href=\"" + url_img + "/Principal\" style=\"background-color:#2AA7DF; border-bottom:3px solid #278CB8; padding:5px 25px; color:#fff; font-weight:bold\">Iniciar Sesi&oacute;n</a>";
                    mensaje += "</td></tr></table></div></body></html>";
                    outTxt = App_Code.CorreoUtilidad.envCorreoNet(mensaje, email, null, null, "Verifica tu cuenta", dtConfig);
                }
                else
                {
                    outTxt = "-1<||>Configuracion de correo inválida";
                }

            }
            else
            {
                outTxt = "-1<||>Email destino inválido";
            }


            return outTxt;

        }

        public String notificaCodigoOlvido(string email,string codigo)
        {
            string outTxt = "";
            string mensaje = "";
            string url_img = obtUrlLocal();
            if (!string.IsNullOrEmpty(email))
            {
                List<DataTable> listaInfo = new List<DataTable>();
                listaInfo = Models.clsEnvioCorreos.obtCuentaCorreo(1);
                DataTable dtConfig = listaInfo[0];
                if (dtConfig.Rows.Count >= 1)
                {
                    mensaje += "<html>";
                    mensaje += "<body style=\"font-family:Tahoma, Geneva, sans-serif\">";
                    mensaje += "<div class=\"green\" style=\"background-color:#00A69C; width:600px;  margin:0 auto; padding:25px 0px\">";
                    mensaje += "<table width=\"100%\" style=\"color:#fff\">";
                    mensaje += "<tr><td style=\"text-align:center\"><h1>RESTABLECIMIENTO DE CLAVE</h1>";
                    mensaje += "<p style=\"width:60%; margin:0 auto; text-align:justify\">El aplicativo de auditorías ciudadanas le informa, que su solicitud de restablecimiento de clave ha sido iniciada. <br>Por favor ingrese el siguiente código en la página para continuar el proceso:</p><br />";
                    mensaje += "<p style=\"text-decoration:none;color:#fff\">Código de Verificación:" + codigo + "</p>";
                    mensaje += "<p>Gracias por utilizar nuestros servicios</p><br><br>";
                    mensaje += "</td></tr></table></div></body></html>";
                    outTxt = App_Code.CorreoUtilidad.envCorreoNet(mensaje, email, null, null, "Código de verificación", dtConfig);
                }
                else
                {
                    outTxt = "-1<||>Configuracion de correo inválida";
                }
            }
            else
            {
                outTxt = "-1<||>Email destino inválido";
            }

            return outTxt;

        }

        public String notificaCambioClave(string email)
        {
            string outTxt = "";
            string mensaje = "";
            string url_img = obtUrlLocal();
            string txt_password = "";
            string txt_instrucciones = "";
            if (!string.IsNullOrEmpty(email))
            {
                List<DataTable> listaInfo = new List<DataTable>();
                listaInfo = Models.clsEnvioCorreos.obtCuentaCorreo(1);
                DataTable dtConfig = listaInfo[0];
                if (dtConfig.Rows.Count >= 1)
                {
                      txt_password = "";
                      txt_instrucciones = "Su contraseña ha sido cambiada exitosamente. Si olvida su clave, recuerde usar el recuadro de ingreso, opción Olvidé mi clave";

                    mensaje += "<html>";
                    mensaje += "<body style=\"font-family:Tahoma, Geneva, sans-serif\">";
                    mensaje += "<div class=\"green\" style=\"background-color:#00A69C; width:600px;  margin:0 auto; padding:25px 0px\">";
                    mensaje += "<table width=\"100%\" style=\"color:#fff\">";
                    mensaje += "<tr><td style=\"width:200px\"><img src=\"" + url_img + "/Content/img/iconEmail6.gif\" width=\"100%\" alt=\"Cambio clave\"/></td>";
                    mensaje += "<td style=\"text-align:center\"><h1>Notificaci&oacute;n <img src=\"" + url_img + "/Content/img/iconEmail10_1.gif\"/></h1>";
                    mensaje += "<p style=\"width:60%; margin:0 auto; text-align:center\">Cambio de Clave</p><br />";
                    mensaje += "<p style=\"text-decoration:none;color:#fff\">Usuario:" + email + "</p>";
                    mensaje += "<p>" + txt_password + "</p>";
                    mensaje += "<p>" + txt_instrucciones + "</p><br>";
                    mensaje += "<a href=\"" + url_img + "/Principal\" style=\"background-color:#2AA7DF; border-bottom:3px solid #278CB8; padding:5px 25px; color:#fff; font-weight:bold\">Iniciar Sesi&oacute;n</a>";
                    mensaje += "</td></tr></table></div></body></html>";
                    outTxt = App_Code.CorreoUtilidad.envCorreoNet(mensaje, email, null, null, "Cambio Clave", dtConfig);
                }
                else
                {
                    outTxt = "-1<||>Configuracion de correo inválida";
                }

            }
            else
            {
                outTxt = "-1<||>Email destino inválido";
            }


            return outTxt;

        }

    }

    }

