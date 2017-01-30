using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace AuditoriasCiudadanas.Models
{
  static public class clsPlanTrabajo
  {
    static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;
    /// <summary>
    /// Sirve para traer los planes de trabajo de todos los proyectos
    /// </summary>
    /// <param name="codigoBPIN">Es el código del proyecto</param>
    /// <param name="idUsuario">Es el id del usuario</param>
    /// <returns>Todos los planes de trabajo que existan en la base de datos para ese proyecto y usuario</returns>
    static public DataTable GetPlanesTrabajo(string codigoBPIN, int idUsuario)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@codigoBPIN", SqlDbType.VarChar, codigoBPIN, ParameterDirection.Input, 15));
      parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_plan_trabajo", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    /// <summary>
    /// Sirve para obtener los tipos de tarea
    /// </summary>
    /// <returns>Devuelve los tipos de tarea</returns>
    public static DataTable GetTiposTareas()
    {
      return DbManagement.getDatosDataTable("dbo.pa_obt_tipos_tarea", CommandType.StoredProcedure, cadTransparencia, new List<PaParams>());
    }

    /// <summary>
    /// Sirve para obtener la información relacionada a los recursos disponibles en la tarea
    /// </summary>
    /// <param name="idTarea">Es el id de la tarea</param>
    /// <returns>Devuelve un texto con la información asociada a los recursos de la tarea</returns>
    public static DataTable ObtenerRecursosTarea(int idTarea)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_recursos_tarea", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    /// <summary>
    /// Sirve para obtener el nombre de los miembros del grupo auditor que hace parte del proyecto
    /// </summary>
    /// <param name="codigoBpin">Es el código del proyecto</param>
    /// <returns>Devulve el nombre de los miembros del GAC</returns>
    public static DataTable GetMiembrosGac(string codigoBpin)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@CodigoBPIN", SqlDbType.VarChar, codigoBpin, ParameterDirection.Input,15));
      return DbManagement.getDatosDataTable("dbo.pa_obt_miembos_gac_codigobpin", CommandType.StoredProcedure, cadTransparencia, parametros);
    }

    public static string VerificarRelacionProyectoAudiencia(string codigoBpin, string tipoAudiencia)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@CodigoBPIN", SqlDbType.VarChar, codigoBpin, ParameterDirection.Input, 15));
      parametros.Add(new PaParams("@TipoAudiencia", SqlDbType.NVarChar, tipoAudiencia, ParameterDirection.Input, 100));
      var dtSalida= DbManagement.getDatosDataTable("dbo.pa_obt_idaudiencia_codigobpin_tipoaudiencia", CommandType.StoredProcedure, cadTransparencia, parametros);
      if (dtSalida.Rows.Count > 0 && dtSalida.Columns.Count>0 && dtSalida.Rows[0].ItemArray[0] != null) return dtSalida.Rows[0].ItemArray[0].ToString();
      else return string.Empty;
    }
    /// <summary>
    /// Sirve para verificar si un usuario pertenece al Gac
    /// </summary>
    /// <param name="parametrosConsulta">Son los parámetros necesarios para la consulta</param>
    /// <returns>Devuelve una cadena de texto que indica si el usuario pertenece o no al GAC</returns>
    public static string VerificarUsuarioGac(string[] parametos)
    {
      try
      {
        if (parametos == null || parametos.Length < 2) return "-1";//Significa que los parámetros no son correctos
        var idUsuario = 0;
        var codigoBpin = "";
        List<PaParams> parametros = new List<PaParams>();
        parametros.Add(new PaParams("@CodigoBPIN", SqlDbType.VarChar, codigoBpin, ParameterDirection.Input, 15));
        parametros.Add(new PaParams("@IdUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
        var dtSalida = DbManagement.getDatosDataTable("dbo.pa_obt_idaudiencia_codigobpin_tipoaudiencia", CommandType.StoredProcedure, cadTransparencia, parametros);
        if (dtSalida.Rows.Count > 0 && dtSalida.Columns.Count > 0 && dtSalida.Rows[0].ItemArray[0] != null) return dtSalida.Rows[0].ItemArray[0].ToString();
        else return string.Empty;
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
      
    }
    /// <summary>
    /// Sirve para guardar los datos básicos de una tarea
    /// </summary>
    /// <param name="parametos">Son algunos de los parámetros necesarios para crear un registro de tarea</param>
    /// <returns>Devuelve una cadena de texto que indica si la operación fue exitosa o no</returns>
    public static string GuardarTarea(string[] parametrosGuardar)
    {
      try
      {
        if (parametrosGuardar == null || parametrosGuardar.Length < 5) return "-2";//Significa que los parámetros no son correctos
        var idTipoTarea = 0;
        var detalle = string.Empty;
        var idUsuario = 0;
        var fechaTarea = DateTime.Now;
        var codigoBPIN = string.Empty;
        var estado = 0;
        detalle = parametrosGuardar[0];
        if (!int.TryParse(parametrosGuardar[1].ToString(), out idTipoTarea)) return "-3";//No se encontró un idTipoTarea para el nombre enviado
        if (!DateTime.TryParse(parametrosGuardar[2].ToString(), out fechaTarea)) return "-4";//El valor de la fecha no es válido
        codigoBPIN = parametrosGuardar[3].ToString();
        if (!int.TryParse(parametrosGuardar[4].ToString(), out idUsuario)) return "-5";//El valor del idUsuario no es un número
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_ins_tareas";
        parametros.Add(new PaParams("@idTipoTarea", SqlDbType.Int, idTipoTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@detalle", SqlDbType.NVarChar, detalle, ParameterDirection.Input, 1000));
        parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
        parametros.Add(new PaParams("@fecha", SqlDbType.DateTime, fechaTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@codigoBPIN", SqlDbType.VarChar, codigoBPIN, ParameterDirection.Input,15));
        parametros.Add(new PaParams("@estado", SqlDbType.Int, estado, ParameterDirection.Input));
        parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
        parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
        Data = DbManagement.getDatos(procedimientoAlmacenado, CommandType.StoredProcedure, cadTransparencia, parametros);
        return cod_error + "<||>" + mensaje_error;
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }
    /// <summary>
    /// Sirve para consultar el detalle de una tarea
    /// </summary>
    /// <param name="idTarea">Es el id de la tarea</param>
    /// <returns>Devuelve una lista con el detalle de cada tarea</returns>
    static public DataTable ObtenerDetalleTarea(int idTarea)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
      return DbManagement.getDatosDataTable("dbo.pa_obt_detalle_tarea", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    /// <summary>
    /// Sirve para actualizar el resultado de una tarea
    /// </summary>
    /// <param name="parametrosGuardar">Son los parámetros empleados en la actualización del registro</param>
    /// <returns>Devuelve un texto que indica si se hizo o no el proceso<</returns>
    public static string ActualizarResultadoTarea(string[] parametrosGuardar)
    {
      try
      {
        if (parametrosGuardar == null || parametrosGuardar.Length <= 2) return "-2";//Significa que los parámetros no son correctos
        var idTarea = 0;
        var fechaDescripcionTarea = DateTime.Now;
        if (!int.TryParse(parametrosGuardar[0].ToString(), out idTarea)) return "-3";//El valor del idTarea no es un número
        if (!DateTime.TryParse(parametrosGuardar[1].ToString(), out fechaDescripcionTarea)) return "-4";//El valor del idTarea no es un número
        var descripcion = parametrosGuardar[2].ToString() != string.Empty ? parametrosGuardar[2].ToString() : string.Empty;
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_upd_resultado_tarea";
        parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@fechaResultadoTarea", SqlDbType.DateTime, fechaDescripcionTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@resultadoTarea", SqlDbType.NVarChar, descripcion, ParameterDirection.Input, 1000));
        parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
        parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
        Data = DbManagement.getDatos(procedimientoAlmacenado, CommandType.StoredProcedure, cadTransparencia, parametros);
        return cod_error + "<||>" + mensaje_error;
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }
    /// <summary>
    /// Sirve para ingresar un registro multimedia
    /// </summary>
    /// <param name="parametos">Son los parámetros correspondientes al adjunto de la tarea</param>
    /// <returns>Devuelve un texto que indica si se hizo o no el proceso</returns>
    public static string IngresarRegistroMultimedia(string[] parametrosGuardar)
    {
      try
      {
        if (parametrosGuardar == null || parametrosGuardar.Length <= 5) return "-2";//Significa que los parámetros no son correctos
        var idTarea = 0;
        var idTipoAdjunto = 0;
        var idUsuario = 0;
        var idMiembroGac = 0;
        var fechaRecursoTarea = DateTime.Now;
        if (!int.TryParse(parametrosGuardar[0].ToString(), out idTarea)) return "-3";//El valor del idTarea no es un número
        if (!int.TryParse(parametrosGuardar[1].ToString(), out idTipoAdjunto)) return "-4";//El valor del idTipoAdjunto no es un número
        if (!DateTime.TryParse(parametrosGuardar[2].ToString(), out fechaRecursoTarea)) return "-5";//El valor de la fecha Recurso no es un datetime
        var url = string.Empty;
        if (parametrosGuardar[3] != null) url = parametrosGuardar[3].ToString();
        else return "-5"; 
        var descripcion = parametrosGuardar[4].ToString() != string.Empty ? parametrosGuardar[4].ToString() : string.Empty;
        if (!int.TryParse(parametrosGuardar[5].ToString(), out idUsuario)) return "-7";//El valor del idUsuario no es un número
        idMiembroGac = ObtenerIdMiembroGac(idUsuario,idTarea);
        if (idMiembroGac < 0) return idMiembroGac.ToString();
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_ins_recurso_tarea";
        parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@idTipoAdjunto", SqlDbType.Int, idTipoAdjunto, ParameterDirection.Input));
        parametros.Add(new PaParams("@url", SqlDbType.NVarChar, url, ParameterDirection.Input,1000));
        parametros.Add(new PaParams("@fechaCreacion", SqlDbType.DateTime, fechaRecursoTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@descripcion", SqlDbType.NVarChar, descripcion, ParameterDirection.Input, 1000));
        parametros.Add(new PaParams("@idMiembroGac", SqlDbType.Int, idMiembroGac, ParameterDirection.Input));
        parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
        parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
        Data = DbManagement.getDatos(procedimientoAlmacenado, CommandType.StoredProcedure, cadTransparencia, parametros);
        return cod_error + "<||>" + mensaje_error;
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }

    private static int ObtenerIdMiembroGac(int idUsuario, int idTarea)
    {
      try
      {
        List<PaParams> parametros = new List<PaParams>();
        parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
        parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
        DataTable dtSalida = DbManagement.getDatosDataTable("dbo.pa_obt_idmiembrogac_idUsuarioIdTarea", CommandType.StoredProcedure, cadTransparencia, parametros);
        if (dtSalida.Rows.Count > 0 && dtSalida.Columns.Count > 0 && dtSalida.Rows[0].ItemArray[0] != null && dtSalida.Rows[0].ItemArray[0].ToString() != string.Empty)
          return Convert.ToInt32(dtSalida.Rows[0].ItemArray[0]);
        else return -9; // Significa que no existe una relación entre idUsuario y miembro gac
      }
      catch (Exception)
      {
        return -8; //Significa hubo un error en la consulta a la base de datos
      }
    }

    /// <summary>
    /// Sirve para finalizar una tarea
    /// </summary>
    /// <param name="idTarea">Es el id de la tarea</param>
    /// <returns>Devuelve un texto que indica si se hizo o no el proceso</returns>
    static public string FinalizarTarea(string parametrosGuardar)
    {
      try
      {
        var idTarea = 0;
        if (!int.TryParse(parametrosGuardar, out idTarea)) return "-3";//El valor del idTarea no es un número
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_upd_finalizar_tarea";
        parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@fechaCierreTarea", SqlDbType.DateTime, DateTime.Now, ParameterDirection.Input));
        parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
        parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
        Data = DbManagement.getDatos(procedimientoAlmacenado, CommandType.StoredProcedure, cadTransparencia, parametros);
        return cod_error + "<||>" + mensaje_error;
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }
    /// <summary>
    /// Sirve para eliminar una tarea
    /// </summary>
    /// <param name="idTarea">Es el id de la tarea</param>
    /// <returns>Devuelve un texto que indica si se hizo correctamente o no</returns>
  static public string EliminarTarea(int idTarea)
    {
      List<PaParams> parametros = new List<PaParams>();
      parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
      parametros.Add(new PaParams("@cod_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, string.Empty, ParameterDirection.Output, 100));
      return DbManagement.EliminarDatos("dbo.pa_del_tarea", CommandType.StoredProcedure, cadTransparencia, parametros);
    }
    /// <summary>
    /// Sirve para actualizar la descripción de una tarea. La opción de ingresar no aplica porque se debe conocer el id de la tarea para hacer las operaciones
    /// </summary>
    /// <param name="parametrosGuardar">Son los parámetros que se utilizarán para guardar los datos</param>
    /// <returns>Una string el cual indica si la operación fue correcta o no</returns>
    static public string ActualizarDescripcionTarea(string[] parametrosGuardar)
    {
      try
      {
        if (parametrosGuardar == null || parametrosGuardar.Length <= 2) return "-2";//Significa que los parámetros no son correctos
        var idTarea = 0;
        var fechaDescripcionTarea = DateTime.Now;
        if (!int.TryParse(parametrosGuardar[0].ToString(), out idTarea)) return "-3";//El valor del idTarea no es un número
        if (!DateTime.TryParse(parametrosGuardar[1].ToString(), out fechaDescripcionTarea)) return "-4";//El valor del idTarea no es un número
        var descripcion = parametrosGuardar[2].ToString() != string.Empty ? parametrosGuardar[2].ToString() : string.Empty;
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_upd_detalle_tarea";
        parametros.Add(new PaParams("@idTarea", SqlDbType.Int, idTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@fechaDescripcionTarea", SqlDbType.DateTime, fechaDescripcionTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@descripcionTarea", SqlDbType.NVarChar, descripcion, ParameterDirection.Input, 1000));
        parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
        parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output));
        Data = DbManagement.getDatos(procedimientoAlmacenado, CommandType.StoredProcedure, cadTransparencia, parametros);
        return cod_error + "<||>" + mensaje_error;
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }
  }
}