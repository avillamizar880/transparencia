using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace AuditoriasCiudadanas.Models
{
    public class clsProyectos
    {
        static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;
       
        public static List<DataTable> obtInfoProyecto(string id_proyecto) { 
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@CodigoBPIN", SqlDbType.VarChar, id_proyecto, ParameterDirection.Input, 15));
            Data = DbManagement.getDatos("dbo.pa_obt_proyecto", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }
    }
}