using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace AuditoriasCiudadanas.Controllers
{
    public class EnvioCorreosController
    {
        public static String  enviarCorreo(int idTipoAudiencia, string codigoBPIN, int numeroGrupo, string destinatario, string asunto) {
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

        public String verificaCuentaCorreo(string email) {
            string outTxt = "";
            string mensaje = "";
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
                    mensaje += "<tr><td style=\"width:200px\"><img src=\"img/iconEmail6.gif\" width=\"100%\" alt=\"Verifica tu cuenta\"/></td>";
                    mensaje += "<td style=\"text-align:center\"><h1>Verifica tu cuenta</h1>";
                    mensaje += "<img src=\"img/iconEmail6_1.gif\" alt=\"Icono de verificar cuenta\"/>";
                    mensaje += "<p style=\"width:60%; margin:0 auto; text-align:center\">Usted se ha registrado para participar en el";
                    mensaje += "aplicativo de auditorías ciudadanas, Para continuar debe verificar su cuenta</p><br />";
                    mensaje += "<a href=\"\" style=\"background-color:#2AA7DF; border-bottom:3px solid #278CB8; padding:5px 25px; color:#fff; font-weight:bold\">Clic aquí</a>";
                    mensaje += "</td></tr></table></body></html>";

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

    }
}