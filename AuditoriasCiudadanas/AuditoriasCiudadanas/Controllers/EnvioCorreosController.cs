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
                    return datos[datos.Count - 1].Rows[0]["cod_error"].ToString() + "<||>" + datos[datos.Count - 1].Rows[0]["mensaje_error"].ToString();

                }
                else {

                    return App_Code.CorreoUtilidad.envCorreoNet(datos[datos.Count - 1].Rows[0]["mensajeHTML"].ToString(), destinatario, null, null, asunto, datos[0]);
                }
            }
            else
            {

                return "-1<||>Error Desconocido";
            }
            
            return "";
        }

    }
}