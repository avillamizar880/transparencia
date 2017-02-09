using AuditoriasCiudadanas.Models;
using Newtonsoft.Json;
using System.Data;
using System;
using System.Collections.Generic;
using System.Net;

namespace AuditoriasCiudadanas.Controllers
{
  public class PlanTrabajoController
  {
 
    /// <summary>
    /// Sirve para traer los planes de trabajo de todos los proyectos
    /// </summary>
    /// <param name="codigoBPIN">Es el código del proyecto</param>
    /// <param name="idUsuario">Es el id del usuario</param>
    /// <returns>Todos los planes de trabajo que existan en la base de datos para ese proyecto y usuario</returns>
    public string ObtenerPlanesTrabajo(string codigoBPIN, int idUsuario)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsPlanTrabajo.GetPlanesTrabajo(codigoBPIN, idUsuario);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida, Formatting.Indented) + "}";
      }
      return rta;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="idTareadtar"></param>
    /// <returns></returns>
    public string ObtenerTemasTratarActasReuniones(int idTareadtar)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsPlanTrabajo.ObtenerTemasTratarActasReuniones(idTareadtar);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida, Formatting.Indented) + "}";
      }
      return rta;
    }

    public string GuardarTemasActasReuniones(int idTareActaReunion, string temas)
    {
      return clsPlanTrabajo.GuardarTemasActasReuniones(idTareActaReunion, temas);
    }

    /// <summary>
    /// Sirve para traer los tipos de tareas
    /// </summary>
    /// <returns>Devuelve todos los tipos de tareas</returns>
    public string ObtenerTipoTareas()
    {
      string rta = string.Empty;
      DataTable dtSalida = clsPlanTrabajo.GetTiposTareas();
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida, Formatting.Indented) + "}";
      }
      return rta;
    }
    /// <summary>
    /// Sirve para obtener el nombre de los miembros del grupo auditor que hace parte del proyecto
    /// </summary>
    /// <param name="codigoBpin">Es el código del proyecto</param>
    /// <returns>Devulve el nombre de los miembros del GAC</returns>
    public string ObtenerMiembrosGac(string codigoBpin)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsPlanTrabajo.GetMiembrosGac(codigoBpin);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida, Formatting.Indented) + "}";
      }
      return rta;
    }
    /// <summary>
    /// Sirve para guardar los datos básicos de una tarea
    /// </summary>
    /// <param name="parametrosGuardar">Son algunos de los parámetros necesarios para crear un registro de tarea</param>
    /// <returns>Devuelve una cadena de texto que indica si la operación fue exitosa o no</returns>
    public string GuardarTarea(string parametrosGuardar)
    {
      var parametos = parametrosGuardar.Split('*');//El * es un caracter que usamos para separar los datos provenientes del formulario.
      return clsPlanTrabajo.GuardarTarea(parametos);
    }
    /// <summary>
    /// Sirve para verificar si un usuario pertenece al Gac
    /// </summary>
    /// <param name="parametrosConsulta">Son los parámetros necesarios para la consulta</param>
    /// <returns>Devuelve una cadena de texto que indica si el usuario pertenece o no al GAC</returns>
    public string VerificarUsuarioGac(string parametrosConsulta)
    {
      var parametos = parametrosConsulta.Split('*');//El * es un caracter que usamos para separar los datos provenientes del formulario.
      return clsPlanTrabajo.VerificarUsuarioGac(parametos);
    }
    /// <summary>
    /// Sirve para validar si el proyecto ya cuenta con una audiencia antes de crear la tarea
    /// </summary>
    /// <param name="parametrosConsulta">Son los parámetros de la consulta separadas por *</param>
    /// <returns>Devuelve una cadena de texto que indica si hay o no relación</returns>
    public string VerificarRelacionProyectoAudiencia(string parametrosConsulta)
    {
      var datosConsulta = parametrosConsulta.Split('*');
      if (datosConsulta.Length > 1) return clsPlanTrabajo.VerificarRelacionProyectoAudiencia(datosConsulta[0], datosConsulta[1]);
      else return string.Empty;
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
    /// Sirve para obtener la información relacionada a los recursos disponibles en la tarea
    /// </summary>
    /// <param name="idTarea">Es el id de la tarea</param>
    /// <returns>Devuelve un texto con la información asociada a los recursos de la tarea</returns>
    public string ObtenerRecursosTarea(int idTarea)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsPlanTrabajo.ObtenerRecursosTarea(idTarea);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida, Formatting.Indented) + "}";
      }
      return rta;
    }
    /// <summary>
    /// Sirve para guardar el registro de adjunto de un tarea
    /// </summary>
    /// <param name="parametrosGuardar">Son los parámetros a guardar</param>
    /// <returns>Devuelve un texto que indica si se hizo o no el proceso</returns>
    public string GuardarRegistroMultimedia(string parametrosGuardar)
    {
      var parametos = parametrosGuardar.Split('*');//El * es un caracter que usamos para separar los datos de los dos formularios de la encuesta
      return clsPlanTrabajo.IngresarRegistroMultimedia(parametos);
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