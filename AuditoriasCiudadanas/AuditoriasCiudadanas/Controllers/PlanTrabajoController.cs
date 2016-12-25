using AuditoriasCiudadanas.Models;
using Newtonsoft.Json;
using System.Data;
using System;
using System.Collections.Generic;

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
    /// <summary>
    /// Sirve para actualizar la descripción de un tarea
    /// </summary>
    /// <param name="parametrosGuardar">Son los parámetros actualizar</param>
    /// <returns>Devuelve un texto que indica si se hizo o no el proceso</returns>
    public string ActualizarDescripcionTarea(string parametrosGuardar)
    {
      var parametos = parametrosGuardar.Split('*');//El * es un caracter que usamos para separar los datos de los dos formularios de la encuesta
      return clsPlanTrabajo.ActualizarDescripcionTarea(parametos);
    }
    /// <summary>
    /// Sirve para actualizar el resultado de un tarea
    /// </summary>
    /// <param name="parametrosGuardar">Son los parámetros actualizar</param>
    /// <returns>Devuelve un texto que indica si se hizo o no el proceso</returns>
    public string ActualizarResultadoTarea(string parametrosGuardar)
    {
      var parametos = parametrosGuardar.Split('*');//El * es un caracter que usamos para separar los datos de los dos formularios de la encuesta
      return clsPlanTrabajo.ActualizarResultadoTarea(parametos);
    }
    /// <summary>
    /// Sirve para finalizar una tarea
    /// </summary>
    /// <param name="idTarea">Es el id de la tarea</param>
    /// <returns>Devuelve un texto que indica si se hizo o no el proceso</returns>
    public string FinalizarTarea(string idTarea)
    {
      return clsPlanTrabajo.FinalizarTarea(idTarea);
    }

    /// <summary>
    /// Sirve para eliminar una tarea
    /// </summary>
    /// <param name="idTarea">Es el id de la tarea</param>
    /// <returns>Devuelve un texto que indica si se hizo correctamente o no</returns>
    public string EliminarTarea(int idTarea)
    {
      return clsPlanTrabajo.EliminarTarea(idTarea);
    }

    /// <summary>
    /// Sirve para obtener el detalle de cada tarea
    /// </summary>
    /// <param name="idTarea">Es el id de la tarea</param>
    /// <returns>Devuelve un string con la información detallada de cada tarea</returns>
    public string ObtenerDetalleTarea(int idTarea)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsPlanTrabajo.ObtenerDetalleTarea(idTarea);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida, Formatting.Indented) + "}";
      }
      return rta;
    }
  }
}