using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
    public class clsForo
    {
        static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;

        public static List<DataTable> ObtForos()
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            Data = DbManagement.getDatos("dbo.pa_obt_foro", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static List<DataTable> obtRespuestas(int IdForo)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@idForo", SqlDbType.Int, IdForo, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_foroMensajes", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static string addRespuesta(int IdForo, int IdUsuario, string Mensaje)
        {
            string outTxt = "";
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            string idMensaje = "";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@idForo", SqlDbType.Int, IdForo, ParameterDirection.Input));
            parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, IdUsuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@mensaje", SqlDbType.VarChar, Mensaje, ParameterDirection.Input, 4000));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@idMensaje", SqlDbType.VarChar, idMensaje, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_foro_mensajes", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    cod_error = Data[1].Rows[0]["cod_error"].ToString();
                    mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                    idMensaje = Data[1].Rows[0]["idMensaje"].ToString();
                }
            }

            outTxt = cod_error + "<||>" + mensaje_error + "<||>" + idMensaje;
            return outTxt;
        }

        public static string addTema(int IdUsuario, string Tema, string Descripcion)
        {
            string outTxt = "";
            string cod_error = "-1";
            string mensaje_error = "@ERROR";
            string idForo = "";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_usuario_cre", SqlDbType.Int, IdUsuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@tema", SqlDbType.VarChar, Tema, ParameterDirection.Input, 4000));
            parametros.Add(new PaParams("@descripcion", SqlDbType.VarChar, Descripcion, ParameterDirection.Input, 4000));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@idForo", SqlDbType.VarChar, idForo, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_foros", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    cod_error = Data[1].Rows[0]["cod_error"].ToString();
                    mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                    idForo = Data[1].Rows[0]["idForo"].ToString();
                }
            }

            outTxt = cod_error + "<||>" + mensaje_error + "<||>" + idForo;
            return outTxt;
        }
    }
}