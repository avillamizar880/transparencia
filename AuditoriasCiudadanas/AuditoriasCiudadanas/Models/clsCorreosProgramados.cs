using AuditoriasCiudadanas.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
    public class clsCorreosProgramados
    {
        /// <summary>
        /// Proponer fecha de reunión previa con autoridades
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static String proponeFechaCorreo(string email)
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
        public static String experienciasGacPublicadas(string email)
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
                string link = url_local + "/login?params=" + HttpUtility.UrlEncode(App_Code.SafeParams.encode("GestionGAC/AprobacionExperienciasGAC|dvPrincipal|"));
                if (dtConfig.Rows.Count >= 1)
                {
                    mensaje += "<html>";
                    mensaje += "<head>";
                    mensaje += "<title>Auditorias Ciudadanas - Notificaciones</title>";
                    mensaje += "<style>p {color:#fff;font-family:Tahoma, Geneva, sans-serif;font-size:16px;} h1 {font-family:Tahoma, Geneva, sans-serif;font-size:2em;}";
                    mensaje += "</style>";
                    mensaje += "</head>";
                    mensaje += "<body style=\"font-family:Tahoma, Geneva, sans-serif\">";
                    mensaje += "<table  style=\"color:#fff;background-color:#2AAAE2; width:600px;  margin:0 auto; padding:25px 0px;color:#FFFFFF;\">";
                    mensaje += "<tr><td style=\"width:200px\"><img src=\"" + url_local + "/icon_experiencias.gif\" width=\"100%\" alt=\"Experiencias Publicadas\"/></td>";
                    mensaje += "<td style=\"text-align:center\"><h1 style=\"margin: 15px\">Experiencias publicadas</h1>";
                    mensaje += "<p style=\"width:80%; margin:0 auto; text-align:center\">Revisa las experiencias que han sido publicadas y elige la mejor para publicar en la sección de noticias.</p><br />";
                    mensaje += "<a href=\"" + link + "\" style=\"background-color:#8AC844; border-bottom:3px solid #278CB8; padding:5px 25px; color:#fff; font-weight:bold;\">";
                    mensaje += "VER EXPERIENCIAS</a>";
                    mensaje += "</td></tr></table>";
                    mensaje += "</body></html>";
                    outTxt = App_Code.CorreoUtilidad.envCorreoNet(mensaje, email, null, null, "Experiencias Gac registradas", dtConfig);
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
        public static String BuenasPracticasPublicadas(string email)
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
                string link = url_local + "/login?params=" + HttpUtility.UrlEncode(App_Code.SafeParams.encode("GestionGAC/AprobacionBuenasPracticas|dvPrincipal|"));
                if (dtConfig.Rows.Count >= 1)
                {

                    mensaje += "<html>";
                    mensaje += "<head>";
                    mensaje += "<title>Auditorias Ciudadanas - Notificaciones</title>";
                    mensaje += "<style>p {color:#fff;font-family:Tahoma, Geneva, sans-serif;font-size:16px;} h1 {font-family:Tahoma, Geneva, sans-serif;font-size:2em;}";
                    mensaje += "</style>";
                    mensaje += "</head>";
                    mensaje += "<body style=\"font-family:Tahoma, Geneva, sans-serif\">";
                    mensaje += "<table  style=\"color:#fff;background-color:#2AAAE2; width:600px;  margin:0 auto; padding:25px 0px; color:#FFFFFF;\">";
                    mensaje += "<tr><td style=\"width:200px\"><img src=\"" + url_local + "/Content/img/icon_experiencias.gif\" width=\"100%\" alt=\"Buenas prácticas\"/></td>";
                    mensaje += "<td style=\"text-align:center\"><h1 style=\"margin: 15px\">Reconocer Buena Práctica</h1>";
                    mensaje += "<p style=\"width:60%; margin:0 auto; text-align:center\">Revisa las buenas prácticas que han sido postuladas y elige la mejor para publicar en la sección de noticias.</p><br />";
                    mensaje += "<a href=\"" + link + "\" style=\"background-color:#8AC844; border-bottom:3px solid #278CB8; padding:5px 25px; color:#fff; font-weight:bold;\">";
                    mensaje += "VER BUENAS PRÁCTICAS</a>";
                    mensaje += "</td></tr></table>";
                    mensaje += "</body></html>";
                    outTxt = App_Code.CorreoUtilidad.envCorreoNet(mensaje, email, null, null, "Buenas prácticas postuladas", dtConfig);
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
        /// Notificacion mensual sobre ranking de auditores
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public static String RankingAuditores(string email, int id_usuario,DataTable dtRankingUsuarios)
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
                string link = url_local + "/login?params=" + HttpUtility.UrlEncode(App_Code.SafeParams.encode("Usuarios/Ranking|dvPrincipal|"));

                if (dtConfig.Rows.Count >= 1)
                {

                    mensaje += "<html>";
                    mensaje += "<head>";
                    mensaje += "<title>Auditorias Ciudadanas - Notificaciones</title>";
                    mensaje += "<style>p {color:#fff;font-family:Tahoma, Geneva, sans-serif;font-size:16px;} h1 {font-family:Tahoma, Geneva, sans-serif;font-size:2em;} li { font-size:16px;}";
                    mensaje += "</style>";
                    mensaje += "</head>";
                    mensaje += "<body style=\"font-family:Tahoma, Geneva, sans-serif\">";
                    mensaje += "<table  style=\"color:#fff;background-color:#8CBE43; width:600px;  margin:0 auto; padding:25px 0px; color:#fff;\">";
                    mensaje += "<tr><td style=\"width:200px\"><img src=\"" + url_local + "/Content/img/icon_ranking.gif\" width=\"100%\" alt=\"Top 5 del ranking\"/></td>";
                    mensaje += "<td style=\"text-align:center\"><h1 style=\"margin: 15px\">!Top 5 del Ranking!</h1>";
                    mensaje += "<p style=\"width:60%; margin:0 auto; text-align:left;\"><h3>Ranking General</h3>";
                    //mostrar ranking
                    int limite = 5;
                    if (dtRankingUsuarios.Rows.Count > 0)
                    {
                        if (dtRankingUsuarios.Rows.Count < limite)
                        {
                            limite = dtRankingUsuarios.Rows.Count;
                        }
                        mensaje += "<ul style=\"text-align:left;\">";
                        for (int i = 0; i <= limite - 1; i++)
                        {
                            mensaje += "<li style=\"text-align:left;\">" + dtRankingUsuarios.Rows[i]["Nombre"].ToString() + " " + dtRankingUsuarios.Rows[i]["puntaje"].ToString() + "</li>";
                        }
                        mensaje += "</ ul >";
                    }


                    mensaje += "</p><br />";
                    mensaje += "<a href=\"" + link + "\" style=\"background-color:#2AA7DF; border-bottom:3px solid #278CB8; padding:5px 25px; color:#fff; font-weight:bold;\">";
                    mensaje += "VER RANKING</a>";
                    mensaje += "</td></tr></table>";
                    mensaje += "</body></html>";
                    outTxt = App_Code.CorreoUtilidad.envCorreoNet(mensaje, email, null, null, "Top 5 del Ranking", dtConfig);
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