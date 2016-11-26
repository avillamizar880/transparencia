using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;

namespace AuditoriasCiudadanas.Models
{
    public class clsGeneral
    {
        static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;
        public static List<DataTable> listarDepartamentos()
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            Data = DbManagement.getDatos("dbo.pa_listar_departamentos", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

        public static List<DataTable> obtMunicipiosByDep(string id_departamento)
        {
            List<DataTable> Data = new List<DataTable>();
            List<PaParams> parametros = new List<PaParams>();
            parametros.Add(new PaParams("@id_departamento", SqlDbType.VarChar, id_departamento, ParameterDirection.Input,15));
            Data = DbManagement.getDatos("dbo.pa_listar_municipios", CommandType.StoredProcedure, cadTransparencia, parametros);
            return Data;
        }

    }
}