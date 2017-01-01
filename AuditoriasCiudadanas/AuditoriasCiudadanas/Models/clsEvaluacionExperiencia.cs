using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace AuditoriasCiudadanas.Models
{
  static public class clsEvaluacionExperiencia
  {
    static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;

    /// <summary>
    /// Sirve para guardar los datos de la evaluación de experiencia
    /// </summary>
    /// <param name="parametos">Son algunos de los parámetros necesarios para crear un registro de tarea</param>
    /// <returns>Devuelve una cadena de texto que indica si la operación fue exitosa o no</returns>
    public static string GuardarEvaluacionExperiencia(string[] parametos)
    {
      try
      {
        if (parametos == null || parametos.Length < 9) return "-1";//Significa que el # de parámetros necesarios no son correctos
        var audienOrganizada = 0;
        var temasAudiencia = 0;
        var problemasAudiencia = 0;
        var autoPartiAudiencia = 0;
        var idAudiencia = 0;
        var idUsuario = 0;
        if (!int.TryParse(parametos[0].ToString(), out audienOrganizada)) return "-2";//No se encontró un audienOrganizada numérico para el nombre enviado
        if (!int.TryParse(parametos[2].ToString(), out temasAudiencia)) return "-3";//No se encontró un temasAudiencia numérico para el nombre enviado
        if (!int.TryParse(parametos[4].ToString(), out problemasAudiencia)) return "-4";//No se encontró un problemasAudiencia numérico para el nombre enviado
        if (!int.TryParse(parametos[6].ToString(), out autoPartiAudiencia)) return "-5";//No se encontró un autoPartiAudiencia numérico para el nombre enviado
        if (!int.TryParse(parametos[8].ToString(), out idAudiencia)) return "-6";//No se encontró un idAudiencia numérico para el nombre enviado
        if (!int.TryParse(parametos[9].ToString(), out idUsuario)) return "-7";//No se encontró un idUsuario numérico para el nombre enviado
        if (ValidarEvaluacionXIdAudienciaIdUsuario(idAudiencia, idUsuario)) return "-8"; //El usuario ya diligenció la evaluación de experiencia
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_ins_evaluacionexperiencia";
        parametros.Add(new PaParams("@Idusuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
        parametros.Add(new PaParams("@IdAudiencia", SqlDbType.Int, idAudiencia, ParameterDirection.Input));
        parametros.Add(new PaParams("@FechaEvaluacion", SqlDbType.DateTime, DateTime.Now, ParameterDirection.Input));
        parametros.Add(new PaParams("@AudienOrganizada", SqlDbType.Int, audienOrganizada, ParameterDirection.Input));
        parametros.Add(new PaParams("@ObsAudienOrganizada", SqlDbType.NVarChar, parametos[1].ToString(), ParameterDirection.Input,500));
        parametros.Add(new PaParams("@TemasAudiencia", SqlDbType.Int, temasAudiencia, ParameterDirection.Input));
        parametros.Add(new PaParams("@ObsTemasAudiencia", SqlDbType.NVarChar, parametos[3].ToString(), ParameterDirection.Input,500));
        parametros.Add(new PaParams("@ProblemasAudiencia", SqlDbType.Int, problemasAudiencia, ParameterDirection.Input));
        parametros.Add(new PaParams("@ObsProblemasAudiencia", SqlDbType.NVarChar, parametos[5].ToString(), ParameterDirection.Input,500));
        parametros.Add(new PaParams("@AutoPartiAudiencia", SqlDbType.Int, autoPartiAudiencia, ParameterDirection.Input));
        parametros.Add(new PaParams("@ObsAutoPartiAudiencia", SqlDbType.NVarChar, parametos[7].ToString(), ParameterDirection.Input,500));
        parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
        parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output,200));
        Data = DbManagement.getDatos(procedimientoAlmacenado, CommandType.StoredProcedure, cadTransparencia, parametros);
        return cod_error + "<||>" + mensaje_error;
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }
    /// <summary>
    /// Sirve para determinar si un usuario a presentado la evaluación de experiencia de una audiencia
    /// </summary>
    /// <param name="idAudiencia">Es el id de la audiencia</param>
    /// <param name="idUsuario">Es el id del usuario</param>
    /// <returns>Devuelve un verdado o falso indicando si ya presentó o no la evaluación</returns>
    private static bool ValidarEvaluacionXIdAudienciaIdUsuario(int idAudiencia, int idUsuario)
    {
      List<PaParams> parametros = new List<PaParams>();
      string cod_error = string.Empty;
      string mensaje_error = string.Empty;
      string procedimientoAlmacenado = "pa_obt_evalExperienciaXIdAudienciaIdUsuario";
      parametros.Add(new PaParams("@Idusuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
      parametros.Add(new PaParams("@IdAudiencia", SqlDbType.Int, idAudiencia, ParameterDirection.Input));
      if (DbManagement.getDatosDataTable(procedimientoAlmacenado, CommandType.StoredProcedure, cadTransparencia, parametros).Rows.Count > 0) return true;
      else return false;
    }
  }
}