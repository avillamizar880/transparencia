using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace AuditoriasCiudadanas.Models
{
    public class clsVerificacion
    {
        static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;
        public static string crearCuestionario(int id_tipo,string titulo, string descripcion, int id_usuario)
        {
           
            string outTxt = "";
            string cod_error = "0";
            string mensaje_error = "";
            string idCuestionario = "0";
            DateTime fecha = DateTime.Now;
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_tipo_cuestionario", SqlDbType.Int, id_tipo, ParameterDirection.Input));
            parametros.Add(new PaParams("@fecha_creacion", SqlDbType.DateTime, fecha, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_usuario_cre", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@titulo", SqlDbType.VarChar, fecha, ParameterDirection.Input, 100));
            parametros.Add(new PaParams("@descripcion", SqlDbType.VarChar, fecha, ParameterDirection.Input, 200));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
            parametros.Add(new PaParams("@idCuestionario", SqlDbType.Int, idCuestionario, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.[pa_ins_cuestionario]", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    cod_error = Data[1].Rows[0]["cod_error"].ToString();
                    mensaje_error = Data[1].Rows[0]["mensaje_error"].ToString();
                    idCuestionario = Data[1].Rows[0]["idCuestionario"].ToString();
                }
            }

            outTxt = cod_error + "<||>" + mensaje_error + "<||>" +  idCuestionario;
            return outTxt;
        }
    }
}