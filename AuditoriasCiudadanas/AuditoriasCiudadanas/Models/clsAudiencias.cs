using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace AuditoriasCiudadanas.Models
{
    public class clsAudiencias
    {
        static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;
        public static List<DataTable> insActaReuniones(int id_audiencia, string cod_bpin, DateTime fecha, string descripcion, string ruta_arc, int id_usuario,int id_lugar)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@idAudiencia", SqlDbType.Int, id_audiencia, ParameterDirection.Input));
            parametros.Add(new PaParams("@CodigoBPIN", SqlDbType.VarChar, cod_bpin, ParameterDirection.Input,15));
            parametros.Add(new PaParams("@Fecha", SqlDbType.DateTime, fecha, ParameterDirection.Input));
            parametros.Add(new PaParams("@descripcion", SqlDbType.VarChar, descripcion, ParameterDirection.Input,1000));
            parametros.Add(new PaParams("@ruta", SqlDbType.VarChar, ruta_arc, ParameterDirection.Input,200));
            parametros.Add(new PaParams("@IdUsuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_divipola", SqlDbType.Int, id_lugar, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_ins_acta", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;

        }

        public static List<DataTable> insRegObservaciones(int id_audiencia, string info_clara, string info_completa, string comunidad_benef, string dudas, DateTime fecha_posterior_1, DateTime fecha_posterior_2,int id_usuario)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@idAudiencia", SqlDbType.Int, id_audiencia, ParameterDirection.Input));
            parametros.Add(new PaParams("@info_clara", SqlDbType.VarChar, info_clara, ParameterDirection.Input, 200));
            parametros.Add(new PaParams("@info_completa", SqlDbType.VarChar, info_completa, ParameterDirection.Input, 200));
            parametros.Add(new PaParams("@comunidad_benef", SqlDbType.VarChar, info_completa, ParameterDirection.Input,200));
            parametros.Add(new PaParams("@dudas", SqlDbType.VarChar, comunidad_benef, ParameterDirection.Input, 200));
            parametros.Add(new PaParams("@fecha_posterior_1", SqlDbType.DateTime, dudas, ParameterDirection.Input));
            parametros.Add(new PaParams("@fecha_posterior_2", SqlDbType.DateTime, id_usuario, ParameterDirection.Input));
            parametros.Add(new PaParams("@id_usuario", SqlDbType.Int, id_usuario, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_ins_observaciones_aud", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;

        }
        
    }
}