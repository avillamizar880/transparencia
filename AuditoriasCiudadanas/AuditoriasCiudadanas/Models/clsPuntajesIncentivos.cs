using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
    public class clsPuntajesIncentivos
    {
        static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;

        public static string executeSP()
        {
            string retorno = "ERROR EN EJECUCION";
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@mensaje_rta", SqlDbType.VarChar, retorno, ParameterDirection.Output));
            Data = DbManagement.getDatos("dbo.pa_job_puntajes_incentivos", CommandType.StoredProcedure, cadTransparencia, parametros);
            if (Data.Count > 1)
            {
                if (Data[1].Rows.Count > 0)
                {
                    retorno = Data[1].Rows[0]["mensaje_rta"].ToString();
                }
            }
            return retorno;
        }
    }
}