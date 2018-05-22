using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
    public class clsNotificacion
    {
        static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;

        public static List<DataTable> ObtNotificaciones(int IdUsuario, char Estado, char opt)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, IdUsuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@estado", SqlDbType.Char, Estado, ParameterDirection.Input, 1));
            parametros.Add(new PaParams("@opt", SqlDbType.Char, opt, ParameterDirection.Input, 1));
            Data = DbManagement.getDatos("dbo.pa_obt_notificacion", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static string ActualizaEstadoNotificacion(int IdNotificacion, string Estado)
        {
            string outTxt = "";
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@idNotificacion", SqlDbType.Int, IdNotificacion, ParameterDirection.Input));
            parametros.Add(new PaParams("@estado", SqlDbType.Char, Estado, ParameterDirection.Input,1));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_upd_notificacion_estado", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    cod_error = Data[1].Rows[0]["cod_error"].ToString();
                    mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                }
            }

            outTxt = cod_error + "<||>" + mensaje_error;
            return outTxt;
        }
    }
}