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

        public static List<DataTable> obtCategorias()
        {
            DataTable dtCategorias = new DataTable();
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            Data = DbManagement.getDatos("dbo.pa_obt_categorias_reportes", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static List<DataTable> obtReporteEstadistica(int tipo,DateTime fecha_ini, DateTime fecha_fin) {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@tipo_reporte", SqlDbType.Int, tipo, ParameterDirection.Input));
            parametros.Add(new PaParams("@fecha_ini", SqlDbType.DateTime, fecha_ini, ParameterDirection.Input));
            parametros.Add(new PaParams("@fecha_fin", SqlDbType.DateTime, fecha_fin, ParameterDirection.Input));
            Data = DbManagement.getDatos("dbo.pa_obt_estadisticas_reportes", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }
        
    }
}