using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Models
{
  public class clsReporteHallazgo
  {
    static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;
    /// <summary>
    /// Sirve para guardar los datos básicos de una tarea
    /// </summary>
    /// <param name="parametos">Son algunos de los parámetros necesarios para crear un registro de tarea</param>
    /// <returns>Devuelve una cadena de texto que indica si la operación fue exitosa o no</returns>
    public static string GuardarReporteHallazgos(string[] parametrosGuardar)
    {
      try
      {
        if (parametrosGuardar == null || parametrosGuardar.Length < 2) return "-1";//Significa que los parámetros no son correctos
        var detalle = string.Empty;
        var idGac = 0;
        var fechaTarea = DateTime.Now;
        var estado = 0;
        detalle = parametrosGuardar[0];
        if (!int.TryParse(parametrosGuardar[1].ToString(), out idGac)) return "-2";//No se encontró un idGac para el nombre enviado
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_ins_reporte_hallazgo";
        parametros.Add(new PaParams("@detalle", SqlDbType.NVarChar, detalle, ParameterDirection.Input, 1000));
        parametros.Add(new PaParams("@idGac", SqlDbType.Int, idGac, ParameterDirection.Input));
        parametros.Add(new PaParams("@fecha", SqlDbType.DateTime, fechaTarea, ParameterDirection.Input));
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
    /// Sirve para guardar los adjuntos del reporte de hallazgos
    /// </summary>
    /// <param name="parametrosGuardar">Son los parámetros a guardar</param>
    /// <returns>Devuelve una cadena de texto que indica si se guardo correctamente el registro en la base de datos</returns>
    public static string GuardarAdjuntoReporteHallazgos(string[] parametrosGuardar)
    {
      try
      {
        if (parametrosGuardar == null || parametrosGuardar.Length < 2) return "-1";//Significa que los parámetros no son correctos
        var rutaImagen = string.Empty;
        var idUsuario = 0;
        var fechaTarea = DateTime.Now;
        rutaImagen = parametrosGuardar[0];
        if (!int.TryParse(parametrosGuardar[1].ToString(), out idUsuario)) return "-2";//No se encontró un idGac para el nombre enviado
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_ins_adjunto_hallazgo";
        parametros.Add(new PaParams("@url", SqlDbType.NVarChar, rutaImagen, ParameterDirection.Input, 400));
        parametros.Add(new PaParams("@fecha", SqlDbType.DateTime, fechaTarea, ParameterDirection.Input));
        parametros.Add(new PaParams("@idUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
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