using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
    public class clsEstadisticas
    {
        static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;

        public static List<DataTable> obtEstadisticas( String opcion)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@opcion", SqlDbType.VarChar, opcion, ParameterDirection.Input, 3));
            Data = DbManagement.getDatos("dbo.pa_obt_estadisticas", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }
    }
}