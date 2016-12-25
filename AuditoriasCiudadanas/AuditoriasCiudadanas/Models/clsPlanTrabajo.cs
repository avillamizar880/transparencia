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
    /// Sirve para obtener todas los planes de trabajo
    /// </summary>
    /// <returns>Una tabla con los planes de trabajo existentes en la base de datos</returns>
    static public DataTable GetPlanesTrabajo()
    {
      return DbManagement.getDatosDataTable("dbo.pa_obt_tareas", CommandType.StoredProcedure, cadTransparencia, new List<PaParams>());
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