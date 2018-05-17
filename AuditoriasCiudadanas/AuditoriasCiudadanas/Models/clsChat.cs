using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
    public class clsChat
    {
        static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;

        public static List<DataTable> ObtMensajes(int IdRemitente, int IdDestinatario)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@idRemitente", SqlDbType.Int, IdRemitente, ParameterDirection.Input));
            parametros.Add(new PaParams("@idDestinatario", SqlDbType.Int, IdDestinatario, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_chat", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static string addMensaje(int IdRemitente, int IdDestinatario, string Mensaje)
        {
            string outTxt = "";
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@idRemitente", SqlDbType.Int, IdRemitente, ParameterDirection.Input));
            parametros.Add(new PaParams("@idDestinatario", SqlDbType.Int, IdDestinatario, ParameterDirection.Input));
            parametros.Add(new PaParams("@mensaje", SqlDbType.VarChar, Mensaje, ParameterDirection.Input, 500));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_chat", CommandType.StoredProcedure, cadTransparencia, parametros);
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