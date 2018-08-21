using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace AuditoriasCiudadanas.Controllers
{
    public class NotificacionesProgramadas
    {
        /// <summary>
        /// Proponer fecha de reunión previa con autoridades
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public String proponeFechaCorreo(string email)
        {
            string outTxt = "";
            string mensaje = "";
            EnvioCorreosController datos_func = new EnvioCorreosController();
            string url_local = datos_func.obtUrlLocal();
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
                    //mensaje += "<div style=\"background-color:#8CBE43; width:600px;  margin:0 auto; padding:25px 0px\">";
                    mensaje += "<table  style=\"color:#fff;background-color:#8CBE43; width:600px;  margin:0 auto; padding:25px 0px\">";
                    mensaje += "<tr><td style=\"width:200px\"><img src=\"" + url_local + "/Content/img/iconEmail7.gif\" width=\"100%\" alt=\"Proponer Fecha\"/></td>";
                    mensaje += "<td style=\"text-align:center\"><h1>Reunión Previa con Autoridades</h1>";
                    mensaje += "<p style=\"width:60%; margin:0 auto; text-align:justify\">Agende la reuni&oacute;n previa con autoridades. P&oacute;ngase de acuerdo con su grupo auditor ciudadano y proponga una fecha e inform&eacute;le a las autoridades.</p><br />";
                    mensaje += "<a href=\"" + url_local + "/Views/Audiencias/ProponerFechaReuPrevias" + "\" style=\"background-color:#2AA7DF; border-bottom:3px solid #278CB8; padding:5px 25px; color:#fff; font-weight:bold\">";
                    mensaje += "PROPONER FECHA</a>";
                    mensaje += "</td></tr></table>";
                    //mensaje += "</div>";
                    mensaje += "</body></html>";
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

        /// <summary>
        /// Notificacion semanal al técnico DNP con la lista de experiencias gac publicadas en el sistema
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public String experienciasGacPublicadas(string email)
        {
            string outTxt = "";
            string mensaje = "";
            EnvioCorreosController datos_func = new EnvioCorreosController();
            string url_local = datos_func.obtUrlLocal();
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
                    mensaje += "<table  style=\"color:#fff;background-color:#2AA7DF; width:600px;  margin:0 auto; padding:25px 0px\">";
                    mensaje += "<tr><td style=\"width:200px\"><img src=\"" + url_local + "/Content/img/iconEmail1.gif\" width=\"100%\" alt=\"Experiencias Publicadas\"/></td>";
                    mensaje += "<td style=\"text-align:center\"><h1>Experiencias publicadas</h1>";
                    mensaje += "<p style=\"width:60%; margin:0 auto; text-align:justify\">Revisa las experiencias que han sido publicadas y elige la mejor para publicar en la sección de noticias.</p><br />";
                    mensaje += "<a href=\"" + url_local + "/Views/Audiencias/ProponerFechaReuPrevias" + "\" style=\"background-color:#8CBE43; border-bottom:3px solid #8CBE43; padding:5px 25px; color:#fff; font-weight:bold;text-decoration: none\">";
                    mensaje += "Ver experiencias</a>";
                    mensaje += "</td></tr></table>";
                    mensaje += "</body></html>";
                    outTxt = App_Code.CorreoUtilidad.envCorreoNet(mensaje, email, null, null, "Experiencias publicadas", dtConfig);
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

        /// <summary>
        /// Notificacion semanal al técnico DNP con la lista de buenas prácticas postuladas en el sistema
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public String BuenasPracticasPublicadas(string email)
        {
            string outTxt = "";
            string mensaje = "";
            EnvioCorreosController datos_func = new EnvioCorreosController();
            string url_local = datos_func.obtUrlLocal();
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
                    mensaje += "<table  style=\"color:#fff;background-color:#2AA7DF; width:600px;  margin:0 auto; padding:25px 0px\">";
                    mensaje += "<tr><td style=\"width:200px\"><img src=\"" + url_local + "/Content/img/iconEmail1.gif\" width=\"100%\" alt=\"Buenas prácticas\"/></td>";
                    mensaje += "<td style=\"text-align:center\"><h1>Reconocer Buena Práctica</h1>";
                    mensaje += "<p style=\"width:60%; margin:0 auto; text-align:justify\">Revisa las buenas prácticas que han sido postuladas y elige la mejor para publicar en la sección de noticias.</p><br />";
                    mensaje += "<a href=\"" + url_local + "/Views/Audiencias/ProponerFechaReuPrevias" + "\" style=\"background-color:#8CBE43; border-bottom:3px solid #8CBE43; padding:5px 25px; color:#fff; font-weight:bold;\">";
                    mensaje += "Ver Buenas Prácticas</a>";
                    mensaje += "</td></tr></table>";
                    mensaje += "</body></html>";
                    outTxt = App_Code.CorreoUtilidad.envCorreoNet(mensaje, email, null, null, "Experiencias publicadas", dtConfig);
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


    }
}