using AuditoriasCiudadanas.Models;
using Newtonsoft.Json;
using System.Data;

namespace AuditoriasCiudadanas.Controllers
{
  public class PlanTrabajoController
  {
    /// <summary>
    /// Sirve para traer los planes de trabajo de todos los proyectos
    /// </summary>
    /// <returns>Todos los planes de trabajo que existan en la base de datos</returns>
    public string ObtenerPlanesTrabajo()
    {
      string rta = string.Empty;
      DataTable dtSalida = clsPlanTrabajo.GetPlanesTrabajo();
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida, Formatting.Indented) + "}";
      }
      return rta;
    }
  }
}