using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
    public class clsEnvioCorreos
    {
        static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;

        public static List<DataTable> obtCuentaCorreo(int config)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@configCorreo", SqlDbType.Int, config, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_cuenta_correo", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;

        }
        
        public static List<DataTable> obtenerHTML(int idTipoAudiencia, string codigoBPIN, int numeroGrupo, string urlLocal, int configCorreo)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@idTipoAudiencia", SqlDbType.Int, idTipoAudiencia, ParameterDirection.Input));
            parametros.Add(new PaParams("@codigoBPIN", SqlDbType.VarChar, codigoBPIN, ParameterDirection.Input,15));
            parametros.Add(new PaParams("@numeroGrupo", SqlDbType.Int, numeroGrupo, ParameterDirection.Input));
            parametros.Add(new PaParams("@urlLocal", SqlDbType.VarChar, urlLocal, ParameterDirection.Input,500));
            parametros.Add(new PaParams("@configCorreo", SqlDbType.Int, configCorreo, ParameterDirection.Input));
            parametros.Add(new PaParams("@mensajeHTML", SqlDbType.VarChar, "", ParameterDirection.Output));
            parametros.Add(new PaParams("@cod_error", SqlDbType.Int, 0, ParameterDirection.Output));
            parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, "", ParameterDirection.Output));
            
                Data = DbManagement.getDatos("dbo.[pa_obt_correo_html]", CommandType.StoredProcedure, cadTransparencia, parametros);

            return Data;

           
        }
    }
}