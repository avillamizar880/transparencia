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
    public static String enviarCorreo(int idTipoAudiencia, string codigoBPIN, int numeroGrupo, string destinatario, string asunto)
    {
      string outTxt = "";
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
        if (datos[datos.Count - 1].Rows.Count > 0 && datos[datos.Count - 1].Rows[0]["cod_error"].ToString() != "0")
        {
          outTxt = datos[datos.Count - 1].Rows[0]["cod_error"].ToString() + "<||>" + datos[datos.Count - 1].Rows[0]["mensaje_error"].ToString();
        }
        else
        {
          outTxt = App_Code.CorreoUtilidad.envCorreoNet(datos[datos.Count - 1].Rows[0]["mensajeHTML"].ToString(), destinatario, null, null, asunto, datos[0]);
        }
      }
      else
      {
        outTxt = "-1<||>Error en envío";
      }

      return outTxt;
    }

    public static string obtHTMLCorreo(int idTipoAudiencia, string codigoBPIN, int numeroGrupo)
    {
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

    public string obtUrlLocal()
    {
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
      urlRedir = ConfigurationManager.AppSettings["dominio_app"];


      return urlRedir;

    }

    public String verificaCuentaCorreo(string email, string idUsuario)
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
          mensaje += "<head>";
          mensaje += "<title>Auditorias Ciudadanas - Notificaciones</title>";
          mensaje += "<style>p {color:#fff;font-family:Tahoma, Geneva, sans-serif;font-size:16px;} h1 {font-family:Tahoma, Geneva, sans-serif;}";
          mensaje += "</style>";
          mensaje += "</head>";
          mensaje += "<body style=\"font-family:Tahoma, Geneva, sans-serif\">";
          //mensaje += "<div style=\"background-color:#00A69C; width:600px;  margin:0 auto; padding:25px 0px\">";
          mensaje += "<table style=\"color:#fff;background-color:#00A69C; width:600px;  margin:0 auto; padding:25px 0px\">";
          mensaje += "<tr><td style=\"width:200px\"><img  src=\"" + url_img + "/Content/img/iconEmail6.gif\" width=\"30%\" alt=\"Verifica tu cuenta\"/></td>";
          mensaje += "<td style=\"text-align:center\"><h1>Verifica tu cuenta</h1>";
          mensaje += "<img src=\"" + url_img + "/Content/img/iconEmail6_1.gif\" alt=\"Icono de verificar cuenta\"/>";
          mensaje += "<p style=\"width:60%; margin:0 auto; text-align:center\">Usted se ha registrado para participar en el ";
          mensaje += "aplicativo de auditorías ciudadanas, Para continuar debe verificar su cuenta</p><br />";
          mensaje += "<a href=\"" + url_img + "/Views/Usuarios/verificaCuentaCorreo?keyUsu=" + idUsuario + "\" style=\"background-color:#2AA7DF; border-bottom:3px solid #278CB8; padding:5px 25px; color:#fff; font-weight:bold\">Clic aqu&iacute;</a>";
          mensaje += "</td></tr></table>";
          //mensaje += "</div>";
          mensaje += "</body></html>";
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
        
    public String notificaCredencialesCorreo(string email, string idUsuario, string id_perfil)
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
          if (id_perfil.Equals("1") || id_perfil.Equals("4"))
          {
            //1: administrador 4:tecnico dnp (creados por administrador del sistema)
            txt_password = "Contraseña: auditorias123";
            txt_instrucciones = "Esta contraseña es provisional, recuerde cambiarla en el menú que lleva su nombre, opción: Cambiar clave.";
          }
          else
          {
            txt_password = "Contraseña: La usada en su registro";
            txt_instrucciones = "";
          }

          mensaje += "<html>";
          mensaje += "<head>";
          mensaje += "<title>Auditorias Ciudadanas - Notificaciones</title>";
          mensaje += "<style>p {color:#fff;font-family:Tahoma, Geneva, sans-serif;font-size:16px;} h1 {font-family:Tahoma, Geneva, sans-serif;}";
          mensaje += "</style>";
          mensaje += "</head>";
          mensaje += "<body style=\"font-family:Tahoma, Geneva, sans-serif\">";
          //mensaje += "<div style=\"background-color:#00A69C; width:600px;  margin:0 auto; padding:25px 0px\">";
          mensaje += "<table style=\"color:#fff;background-color:#00A69C; width:600px;  margin:0 auto; padding:25px 0px\">";
          mensaje += "<tr><td style=\"width:200px\"><img src=\"" + url_img + "/Content/img/iconEmail6.gif\" width=\"100%\" alt=\"Verifica tu cuenta\"/></td>";
          mensaje += "<td style=\"text-align:center\"><h1>Inicia Sesi&oacute;n <img src=\"" + url_img + "/Content/img/iconEmail10_1.gif\"/></h1>";
          mensaje += "<p style=\"width:60%; margin:0 auto; text-align:center\">Bienvenido, ahora es parte de nuestro aplicativo.</p><br />";
          mensaje += "<p style=\"text-decoration:none;color:#fff\">Usuario:" + email + "</p>";
          mensaje += "<p>" + txt_password + "</p>";
          mensaje += "<p>" + txt_instrucciones + "</p><br />";
          mensaje += "<a href=\"" + url_img + "/Principal\" style=\"background-color:#2AA7DF; border-bottom:3px solid #278CB8; padding:5px 25px; color:#fff; font-weight:bold\">Iniciar Sesi&oacute;n</a>";
          mensaje += "</td></tr></table>";
          //mensaje += "</div>";
          mensaje += "</body></html>";
          outTxt = App_Code.CorreoUtilidad.envCorreoNet(mensaje, email, null, null, "Credenciales", dtConfig);
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
          mensaje += "<head>";
          mensaje += "<title>Auditorias Ciudadanas - Notificaciones</title>";
          mensaje += "<style>p {color:#fff;font-family:Tahoma, Geneva, sans-serif;font-size:16px;}";
          mensaje += "</style>";
          mensaje += "</head>";
          mensaje += "<body style=\"font-family:Tahoma, Geneva, sans-serif\">";
          //mensaje += "<div style=\"background-color:#00A69C; width:600px;  margin:0 auto; padding:25px 0px\">";
          mensaje += "<table  style=\"color:#fff;background-color:#00A69C; width:600px;  margin:0 auto; padding:25px 0px\">";
          mensaje += "<tr><td style=\"width:200px\"><img src=\"" + url_img + "/Content/img/iconEmail6.gif\" width=\"100%\" alt=\"Credenciales\"/></td>";
          mensaje += "<td style=\"text-align:center\"><h1>Inicia Sesi&oacute;n <img src=\"" + url_img + "/Content/img/iconEmail10_1.gif\"/></h1>";
          mensaje += "<p style=\"width:60%; margin:0 auto; text-align:center\">Bienvenido, ahora es parte de nuestro aplicativo.</p><br />";
          mensaje += "<p style=\"text-decoration:none;color:#fff\">Usuario:" + email + "</p>";
          mensaje += "<p>Contraseña: auditorias123</p><br /><br />";
          mensaje += "<p>Esta contraseña es provisional, recuerde cambiarla en el menú que lleva su nombre, opción: Cambiar clave.</p><br />";
          mensaje += "<a href=\"" + url_img + "/Principal\" style=\"background-color:#2AA7DF; border-bottom:3px solid #278CB8; padding:5px 25px; color:#fff; font-weight:bold\">Iniciar Sesi&oacute;n</a>";
          mensaje += "</td></tr></table>";
          //mensaje += "</div>";
          mensaje += "</body></html>";
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

    public String notificaCodigoOlvido(string email, string codigo)
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
          mensaje += "<head>";
          mensaje += "<title>Auditorias Ciudadanas - Notificaciones</title>";
          mensaje += "<style>p {color:#fff;font-family:Tahoma, Geneva, sans-serif;font-size:16px;} h1 {font-family:Tahoma, Geneva, sans-serif;}";
          mensaje += "</style>";
          mensaje += "</head>";
          mensaje += "<body style=\"font-family:'Tahoma', Geneva, san-serif;font-size:16px;\">";
          //mensaje += "<div style=\"background-color:#00A69C; width:600px;  margin:0 auto; padding:25px 0px\">";
          mensaje += "<table style=\"color:#fff;background-color:#00A69C; width:600px;padding:10px;text-align:center\">";
          mensaje += "<tr><td style=\"text-align:center\"><h1>RESTABLECIMIENTO DE CLAVE</h1></td></tr>";
          mensaje += "<tr><td><p>El aplicativo de auditorías ciudadanas le informa, que su solicitud de restablecimiento de clave ha sido iniciada.</p></td></tr>";
          mensaje += "<tr><td><p>Por favor ingrese el siguiente código en el sitio web para continuar en el proceso:</p></td></tr>";
          mensaje += "<tr><td><table style=\"margin: 0 auto;width:50%;\"><tr><td style=\"text-align:center;color:#0D3B59; margin:0 auto;font-weight:bold; font-size:30px; padding:15px; border:1px solid #d6d6d6\" >" + codigo + "</td></tr></table></td></tr>";
          mensaje += "<tr><td><p>Gracias por utilizar nuestros servicios</p></td></tr>";
          mensaje += "</table>";
          //mensaje += "</div>";
          mensaje += "</body></html>";
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
          mensaje += "<head>";
          mensaje += "<title>Auditorias Ciudadanas - Notificaciones</title>";
          mensaje += "<style>p {color:#fff;font-family:Tahoma, Geneva, sans-serif;font-size:16px;}";
          mensaje += "</style>";
          mensaje += "</head>";
          mensaje += "<body style=\"font-family:Tahoma, Geneva, sans-serif\">";
          //mensaje += "<div style=\"background-color:#00A69C; width:600px;  margin:0 auto; padding:25px 0px\">";
          mensaje += "<table style=\"color:#fff;background-color:#00A69C; width:600px;  margin:0 auto; padding:25px 0px\">";
          mensaje += "<tr><td style=\"width:200px\"><img src=\"" + url_img + "/Content/img/iconEmail6.gif\" width=\"100%\" alt=\"Cambio clave\"/></td>";
          mensaje += "<td style=\"text-align:center\"><h1>Notificaci&oacute;n <img src=\"" + url_img + "/Content/img/iconEmail10_1.gif\"/></h1>";
          mensaje += "<p style=\"width:60%; margin:0 auto; text-align:center\">Cambio de Clave</p><br />";
          mensaje += "<p style=\"text-decoration:none;color:#fff\">Usuario:" + email + "</p>";
          mensaje += "<p>" + txt_password + "</p>";
          mensaje += "<p>" + txt_instrucciones + "</p><br />";
          mensaje += "<a href=\"" + url_img + "/Principal\" style=\"background-color:#2AA7DF; border-bottom:3px solid #278CB8; padding:5px 25px; color:#fff; font-weight:bold\">Iniciar Sesi&oacute;n</a>";
          mensaje += "</td></tr></table>";
          //mensaje += "</div>";
          mensaje += "</body></html>";
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

    /// <summary>
    /// Permite enviar un correo al usuario responsable de ejecutar una tarea
    /// </summary>
    /// <param name="idUsuario">Es el id del usuario responsable de la tarea</param>
    /// <param name="fechaCreacion">Es la fecha en la cual se creó la tarea</param>
    /// <param name="detalleTarea">Es el detalle de la tarea</param>
    /// <returns>Devuelve un mensaje el cual indica si el correo se fue de forma exitosa</returns>
    public String enviarCorreoTareaCreada(int idUsuario, string fechaTarea, string detalleTarea, string tipoTarea)
    {
      string outTxt = "";
      string mensaje = "";
      string url_img = obtUrlLocal();
      string email = string.Empty;
      UsuariosController usuarioController = new UsuariosController();
      DataTable dtUsuarioEnviarCorreo = usuarioController.obtDatosUsuario(idUsuario);
      if (dtUsuarioEnviarCorreo.Rows.Count > 0 && dtUsuarioEnviarCorreo.Columns.Count >= 3)
      {
        email = DBNull.Value != dtUsuarioEnviarCorreo.Rows[0].ItemArray[2] ? dtUsuarioEnviarCorreo.Rows[0].ItemArray[2].ToString() : string.Empty;
        List<DataTable> listaInfo = new List<DataTable>();
        listaInfo = Models.clsEnvioCorreos.obtCuentaCorreo(1);
        DataTable dtConfig = listaInfo[0];
        string fecha_aux = fechaTarea.Substring(0, 10);
        if (dtConfig.Rows.Count >= 1)
        {
          mensaje += "<html>";
          mensaje += "<head>";
          mensaje += "<title>Auditorias Ciudadanas - Notificaciones</title>";
          mensaje += "<style>p {color:#fff;font-family:Tahoma, Geneva, sans-serif;font-size:16px;} h1 {font-family:Tahoma, Geneva, sans-serif;}";
          mensaje += "</style>";
          mensaje += "</head>";
          mensaje += "<body style=\"font-family:Tahoma, Geneva, sans-serif\">";
          mensaje += "<table style=\"color:#fff;background-color:#8CBE43; width:600px;  margin:0 auto; padding:25px 0px\">";
          mensaje += "<tr><td style=\"width:200px\"><img  src=\"" + url_img + "/Content/img/iconEmail1.gif\" width=\"100%\" alt=\"Nueva Tarea\"/></td>";
          mensaje += "<td style=\"text-align:center\"><h1>Tienes una nueva tarea en tu grupo auditor</h1>";
          mensaje += "<p style=\"width:60%; margin:0 auto; text-align:center\">" + tipoTarea + "<br /> " + fecha_aux + "</p><br />" ;
          //Ejemplo de href para enviar a detalle tarea.
          mensaje += "<a href=\"" + url_img + "\"style =\"background-color:#2AA7DF; border-bottom:3px solid #278CB8; padding:5px 25px; color:#fff; font-weight:bold\">VER TAREA</a>";
          mensaje += "</td></tr></table>";
          mensaje += "</body></html>";
          outTxt = App_Code.CorreoUtilidad.envCorreoNet(mensaje, email, null, null, "Transparencia por Colombia: Nueva tarea", dtConfig);
        }
        else outTxt = "-1<||>Configuracion de correo inválida";
      }
      else outTxt = "-1<||>Usuario inválido";
      return outTxt;
    }
    /// <summary>
    /// Permite enviar un correo al usuario responsable un día antes de vencer la tarea
    /// </summary>
    /// <param name=""></param>
    /// <param name=""></param>
    /// <param name=""></param>
    /// <returns></returns>
    //public String enviarCorreoVencimientoTarea(int idUsuario, string fechaCreacion, string detalleTarea)
    //{
    //  string outTxt = "";
    //  string mensaje = "";
    //  string url_img = obtUrlLocal();
    //  string email = string.Empty;
    //  UsuariosController usuarioController = new UsuariosController();
    //  DataTable dtUsuarioEnviarCorreo = usuarioController.obtDatosUsuario(idUsuario);
    //  if (dtUsuarioEnviarCorreo.Rows.Count > 0 && dtUsuarioEnviarCorreo.Columns.Count >= 3)
    //  {
    //    email = DBNull.Value != dtUsuarioEnviarCorreo.Rows[0].ItemArray[2] ? dtUsuarioEnviarCorreo.Rows[0].ItemArray[2].ToString() : string.Empty;
    //    List<DataTable> listaInfo = new List<DataTable>();
    //    listaInfo = Models.clsEnvioCorreos.obtCuentaCorreo(1);
    //    DataTable dtConfig = listaInfo[0];
    //    if (dtConfig.Rows.Count >= 1)
    //    {
    //      mensaje += "<html>";
    //      mensaje += "<head>";
    //      mensaje += "<title>Auditorias Ciudadanas - Notificaciones</title>";
    //      mensaje += "<style>p {color:#fff;font-family:Tahoma, Geneva, sans-serif;font-size:16px;} h1 {font-family:Tahoma, Geneva, sans-serif;}";
    //      mensaje += "</style>";
    //      mensaje += "</head>";
    //      mensaje += "<body style=\"font-family:Tahoma, Geneva, sans-serif\">";
    //      mensaje += "<table style=\"color:#fff;background-color:#8CBE43; width:600px;  margin:0 auto; padding:25px 0px\">";
    //      mensaje += "<tr><td style=\"width:200px\"><img  src=\"" + url_img + "/Content/img/iconEmail1.gif\" width=\"100%\" alt=\"Nueva Tarea\"/></td>";
    //      mensaje += "<td style=\"text-align:center\"><h1>Tienes una nueva tarea en tu grupo auditor</h1>";
    //      mensaje += "<p style=\"width:60%; margin:0 auto; text-align:center\">Visita de campo<br /> " + fechaCreacion + "<br />Hora 3:00 p.m.</p><br /> ";
    //      mensaje += "tenga en cuenta la siguiente información:\nDetalle de la tarea:" + detalleTarea + "\nFecha de creación:" + fechaCreacion + "</p><br />";
    //      //Ejemplo de href para enviar a detalle tarea.
    //      mensaje += "<a href=\"" + url_img + "/Views/Usuarios/verificaCuentaCorreo?keyUsu=" + idUsuario + "\"style =\"background-color:#2AA7DF; border-bottom:3px solid #278CB8; padding:5px 25px; color:#fff; font-weight:bold\">VER TAREA</a>";
    //      mensaje += "</td></tr></table>";
    //      mensaje += "</body></html>";
    //      outTxt = App_Code.CorreoUtilidad.envCorreoNet(mensaje, email, null, null, "Transparencia por Colombia: Nueva tarea", dtConfig);
    //    }
    //    else outTxt = "-1<||>Configuracion de correo inválida";
    //  }
    //  else outTxt = "-1<||>Usuario inválido";
    //  return outTxt;
    //}

  }

}

