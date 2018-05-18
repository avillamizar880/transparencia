using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
    public class clsComunicacion
    {
        static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;
        public static itemReturn crearForo(string tema, string descripcion, string mensaje, int id_usuario)
        {

            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            string cod_error = "0";
            string mensaje_error = "";
            int idForo = 0;
            //string outTxt = "";
            parametros.Add(new PaParams("@tema", SqlDbType.NVarChar, tema, ParameterDirection.Input));
            parametros.Add(new PaParams("@descripcion", SqlDbType.NVarChar, descripcion, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_usuario_cre", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@mensaje", SqlDbType.NVarChar, mensaje, ParameterDirection.Input));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@idForo", SqlDbType.Int, idForo, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_ins_foros", CommandType.StoredProcedure, cadTransparencia, parametros);
            var objReturn = new itemReturn
            {
                 cod_error= Data[1].Rows[0]["cod_error"].ToString(),
                 msg_error= Data[1].Rows[0]["mensaje_error"].ToString(),
                 id= Convert.ToInt16(Data[1].Rows[0]["idForo"].ToString())
            };
            return objReturn;
        }
    }
}