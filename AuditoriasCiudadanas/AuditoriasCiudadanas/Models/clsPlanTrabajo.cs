using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace AuditoriasCiudadanas.Models
{
  static public class clsPlanTrabajo
  {
    static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;
    /// <summary>
    /// Sirve para obtener todas los planes de trabajo
    /// </summary>
    /// <returns>Una tabla con los planes de trabajo existentes en la base de datos</returns>
    static public DataTable GetPlanesTrabajo()
    {
      return DbManagement.getDatosDataTable("dbo.pa_obt_tareas", CommandType.StoredProcedure, cadTransparencia, new List<PaParams>());
    }
  }
}