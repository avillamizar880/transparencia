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
    /// Sirve para eliminar un archivo de una tarea
    /// </summary>
    /// <param name="parametrosGuardar"></param>
    /// <returns></returns>
    public string EliminarRegistroMultimediaxUrl(string parametrosGuardar)
    {
      var parametos = parametrosGuardar.Split('*');//El * es un caracter que usamos para separar los datos provenientes del formulario.
      return clsPlanTrabajo.EliminarRegistroMultimediaxUrl(parametos);
    }

    /// <summary>
    /// Sirve para traer los planes de trabajo de todos los proyectos
    /// </summary>
    /// <param name="codigoBPIN">Es el código del proyecto</param>
    /// <param name="idUsuario">Es el id del usuario</param>
    /// <param name="idGac">Es el id del Gac</param>
    /// <returns>Todos los planes de trabajo que existan en la base de datos para ese proyecto y usuario</returns>
    public string ObtenerPlanesTrabajo(string codigoBPIN, int idGac, int idUsuario)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsPlanTrabajo.GetPlanesTrabajo(codigoBPIN, idGac, idUsuario);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida, Formatting.Indented) + "}";
      }
      return rta;
    }

    public string EliminarDiarioNotas(int idDiarioNoticias)
    {
      return clsPlanTrabajo.EliminarDiarioNotas(idDiarioNoticias);
    }

    public string GuardarDetalleTareaDiarioNotas(string datosGuardar)
    {
      return clsPlanTrabajo.GuardarDetalleTareaDiarioNotas(datosGuardar);
    }

    public string ValidarUsuarioMiembroGac(string parametros)
    {
      return clsPlanTrabajo.ValidarUsuarioMiembroGac(parametros);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="idTarea"></param>
    /// <returns></returns>
    public string ObtenerDetalleTareaDiarioNotas(int idTarea)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsPlanTrabajo.ObtenerDetalleTareaDiarioNotas(idTarea);
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
    /// <param name="idTareaCompromisos"></param>
    /// <returns></returns>
    public string ObtenerCompromisosActasReuniones(int idTarea)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsPlanTrabajo.ObtenerCompromisosActasReuniones(idTarea);
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
    public string ObtenerListaAsistenciaActasReuniones(int idTarealistasist, int idTipoAdjuntoTarea, string rutaRecurso)
    {
      return clsPlanTrabajo.ObtenerListaAsistenciaActasReuniones(idTarealistasist,idTipoAdjuntoTarea,rutaRecurso);
    }
    public string GuardarCompromisoActaReunionTarea(string datosGuardar)
    {
      return clsPlanTrabajo.GuardarCompromisoActaReunionTarea(datosGuardar);
    }
    public string GuardarTemasActasReuniones(int idTareActaReunion, string temas)
    {
      return clsPlanTrabajo.GuardarTemasActasReuniones(idTareActaReunion, temas);
    }
    public bool ObtenerEstadoTareaXRegistroMultimedia(string url)
    {
      return clsPlanTrabajo.ConsultarEstadoRegistroMultimediaxUrl(url);
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
    /// 
    /// </summary>
    /// <param name="idTarea"></param>
    /// <returns></returns>
    public string BuscarInformacionVisitaCampo(int idTarea)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsPlanTrabajo.BuscarInformacionVisitaCampo(idTarea);
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
    /// <param name="idTarea"></param>
    /// <returns></returns>
    public string EliminarTareaRegistroFotografico(int idTarea)
    {
      return clsPlanTrabajo.EliminarTareaRegistroFotografico(idTarea);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="idTarea"></param>
    /// <returns></returns>
    public string EliminarDiarioNotasTarea(int idTarea)
    {
      return clsPlanTrabajo.EliminarDiarioNotasTarea(idTarea);
    }
    /// <summary>
    /// Sirve para obtener el nombre de los miembros del grupo auditor que hace parte del proyecto
    /// </summary>
    /// <param name="infoGac">Es el id del Gac</param>
    /// <returns>Devulve el nombre de los miembros del GAC</returns>
    public string ObtenerMiembrosGac(string infoGac)
    {
      string rta = string.Empty;
      var idGac = 0;
      int.TryParse(infoGac, out idGac);//
      DataTable dtSalida = clsPlanTrabajo.GetMiembrosGac(idGac);
      if (dtSalida != null) //Se valida que la consulta de la base de datos venga con datos
      {
        dtSalida.TableName = "tabla";
        rta = "{\"Head\":" + JsonConvert.SerializeObject(dtSalida, Formatting.Indented) + "}";
      }
      return rta;
    }

    public string GuardarActividadesVisitaCampoTarea(string parametrosGuardar)
    {
      var parametos = parametrosGuardar.Split('*');//El * es un caracter que usamos para separar los datos provenientes del formulario.
      return clsPlanTrabajo.GuardarActividadesVisitaCampoTarea(parametos);
    }

    public string GuardarFuncionarioPublicoAcompanaVisitaTarea(string parametrosGuardar)
    {
      var parametos = parametrosGuardar.Split('*');//El * es un caracter que usamos para separar los datos provenientes del formulario.
      return clsPlanTrabajo.GuardarFuncionarioPublicoAcompanaVisitaTarea(parametos);
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
    public string ObtenerRecursosFotograficoTarea(int idTarea, string rutaImagen)
    {
      string rta = string.Empty;
      DataTable dtSalida = clsPlanTrabajo.ObtenerRecursosFotografico(idTarea, rutaImagen);
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
    /// Sirve para eliminar un compromiso del acta de reunión
    /// </summary>
    /// <param name="idCompromisoActaReuniones">Es el id del compromiso</param>
    /// <returns>Devuelve un texto que indica si se hizo correctamente o no</returns>
    public string EliminarCompromisoActaReunionesTarea(int idCompromisoActaReuniones)
    {
      return clsPlanTrabajo.EliminarCompromisoActaReunionesTarea(idCompromisoActaReuniones);
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