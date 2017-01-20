using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

namespace AuditoriasCiudadanas.Models
{
  static public class clsAutoevaluacion
  {
    static string cadTransparencia = ConfigurationManager.ConnectionStrings["Transparencia"].ConnectionString;

  /// <summary>
  /// Sirve para guardar los datos de la autoevaluación del auditor ciudadano
  /// </summary>
  /// <param name="parametos">Son algunos de los parámetros necesarios para guardar la autoevaluación</param>
  /// <returns>Devuelve una cadena de texto que indica si la operación fue exitosa o no</returns>
  public static string GuardarAutoevaluacion(string[] parametos)
  {
      try
      {
        if (parametos == null || parametos.Length < 31) return "-1";//Significa que el # de parámetros necesarios no son correctos
        var revisionInfo = 0;
        var tratoAC= 0;
        var compromiso = 0;
        var capacitacion = 0;
        var pertinenciaInfo = 0;
        var tratoEntidadEj = 0;
        var comunicacionInterventor = 0;
        var tratoContratista = 0;
        var convocatoriaAudiencias = 0;
        var animoCiudadano = 0;
        var condicionesSeguridad = 0;
        var idUsuario = 0;
        var idAudiencia = 0;
        
        if (!int.TryParse(parametos[0].ToString(), out revisionInfo)) return "-2";//No se encontró un revisionInfo numérico para el nombre enviado
        if (!int.TryParse(parametos[2].ToString(), out tratoAC)) return "-3";//No se encontró un tratoAC numérico para el nombre enviado
        if (!int.TryParse(parametos[4].ToString(), out compromiso)) return "-4";//No se encontró un compromiso numérico para el nombre enviado
        if (!int.TryParse(parametos[6].ToString(), out capacitacion)) return "-5";//No se encontró un capacitacion numérico para el nombre enviado
        if (!int.TryParse(parametos[8].ToString(), out pertinenciaInfo)) return "-6";//No se encontró un pertinenciaInfo numérico para el nombre enviado
        if (!int.TryParse(parametos[10].ToString(), out tratoEntidadEj)) return "-7";//No se encontró un tratoEntidadEj numérico para el nombre enviado
        if (!int.TryParse(parametos[12].ToString(), out comunicacionInterventor)) return "-8";//No se encontró un comunicacionInterventor numérico para el nombre enviado
        if (!int.TryParse(parametos[14].ToString(), out tratoContratista)) return "-9";//No se encontró un tratoContratista numérico para el nombre enviado
        if (!int.TryParse(parametos[16].ToString(), out convocatoriaAudiencias)) return "-10";//No se encontró un convocatoriaAudiencias numérico para el nombre enviado
        if (!int.TryParse(parametos[18].ToString(), out animoCiudadano)) return "-11";//No se encontró un animoCiudadano numérico para el nombre enviado
        if (!int.TryParse(parametos[20].ToString(), out condicionesSeguridad)) return "-12";//No se encontró un condicionesSeguridad numérico para el nombre enviado
        if (!int.TryParse(parametos[30].ToString(), out idUsuario)) return "-13";//No se encontró un idUsuario numérico para el nombre enviado
        if (ValidarEvaluacionXIdAudienciaIdUsuario(idAudiencia, idUsuario)) return "-8"; //El usuario ya diligenció la evaluación de experiencia
        List<DataTable> Data = new List<DataTable>();
        List<PaParams> parametros = new List<PaParams>();
        string cod_error = string.Empty;
        string mensaje_error = string.Empty;
        string procedimientoAlmacenado = "pa_ins_autoevaluacion";
        parametros.Add(new PaParams("@IdUsuario", SqlDbType.Int, idUsuario, ParameterDirection.Input));
        parametros.Add(new PaParams("@IdAudiencia", SqlDbType.Int, idAudiencia, ParameterDirection.Input));//falta este campo en la bd.
        parametros.Add(new PaParams("@FechaAutoevaluacion", SqlDbType.DateTime, DateTime.Now, ParameterDirection.Input));
        parametros.Add(new PaParams("@RevisarInfo", SqlDbType.Int, revisionInfo, ParameterDirection.Input));
        parametros.Add(new PaParams("@ObsRevisarInfo", SqlDbType.NVarChar, parametos[1].ToString(), ParameterDirection.Input, 500));
        parametros.Add(new PaParams("@TratoAC", SqlDbType.Int, tratoAC, ParameterDirection.Input));
        parametros.Add(new PaParams("@ObsTratoAC", SqlDbType.NVarChar, parametos[3].ToString(), ParameterDirection.Input, 500));
        parametros.Add(new PaParams("@Compromisos", SqlDbType.Int, compromiso, ParameterDirection.Input));
        parametros.Add(new PaParams("@ObsCompromisos", SqlDbType.NVarChar, parametos[5].ToString(), ParameterDirection.Input, 500));
        parametros.Add(new PaParams("@Capacitacion", SqlDbType.Int, capacitacion, ParameterDirection.Input));
        parametros.Add(new PaParams("@ObsCapacitacion", SqlDbType.NVarChar, parametos[7].ToString(), ParameterDirection.Input, 500));
        parametros.Add(new PaParams("@PertinenciaInfo", SqlDbType.Int, pertinenciaInfo, ParameterDirection.Input));
        parametros.Add(new PaParams("@ObsPertinenciaInfo", SqlDbType.NVarChar, parametos[9].ToString(), ParameterDirection.Input, 500));
        parametros.Add(new PaParams("@TratoEntidadEj", SqlDbType.Int, tratoEntidadEj, ParameterDirection.Input));
        parametros.Add(new PaParams("@ObsTratoEntidadEj", SqlDbType.NVarChar, parametos[11].ToString(), ParameterDirection.Input, 500));
        parametros.Add(new PaParams("@ComunicacionInterventor", SqlDbType.Int, comunicacionInterventor, ParameterDirection.Input));
        parametros.Add(new PaParams("@ObsComunicacionInterventor", SqlDbType.NVarChar, parametos[13].ToString(), ParameterDirection.Input, 500));
        parametros.Add(new PaParams("@ConvocatoriaAudiencias", SqlDbType.Int, convocatoriaAudiencias, ParameterDirection.Input));
        parametros.Add(new PaParams("@ObsConvocatoriaAudiencias", SqlDbType.NVarChar, parametos[15].ToString(), ParameterDirection.Input, 500));
        parametros.Add(new PaParams("@AnimoCiudadano", SqlDbType.Int, animoCiudadano, ParameterDirection.Input));
        parametros.Add(new PaParams("@ObsAnimoCiudadano", SqlDbType.NVarChar, parametos[17].ToString(), ParameterDirection.Input, 500));
        parametros.Add(new PaParams("@CondicionesSeguridad", SqlDbType.Int, condicionesSeguridad, ParameterDirection.Input));
        parametros.Add(new PaParams("@ObsCondicionesSeguridad", SqlDbType.NVarChar, parametos[21].ToString(), ParameterDirection.Input, 500));
        parametros.Add(new PaParams("@ReunionesGA", SqlDbType.VarChar, parametos[22].ToString(), ParameterDirection.Input, 2));
        parametros.Add(new PaParams("@ObsReunionesGA", SqlDbType.NVarChar, parametos[23].ToString(), ParameterDirection.Input, 500));
        parametros.Add(new PaParams("@LogroGA", SqlDbType.VarChar, parametos[24].ToString(), ParameterDirection.Input, 2));
        parametros.Add(new PaParams("@ObsLogroGA", SqlDbType.NVarChar, parametos[25].ToString(), ParameterDirection.Input, 500));
        parametros.Add(new PaParams("@AprendizajeAC", SqlDbType.NVarChar, parametos[26].ToString(), ParameterDirection.Input, 500));
        parametros.Add(new PaParams("@DificultadAC", SqlDbType.NVarChar, parametos[27].ToString(), ParameterDirection.Input, 500));
        parametros.Add(new PaParams("@Sugerencias", SqlDbType.NVarChar, parametos[28].ToString(), ParameterDirection.Input, 500));
        parametros.Add(new PaParams("@cod_error", SqlDbType.Int, cod_error, ParameterDirection.Output));
        parametros.Add(new PaParams("@mensaje_error", SqlDbType.VarChar, mensaje_error, ParameterDirection.Output, 200));
        Data = DbManagement.getDatos(procedimientoAlmacenado, CommandType.StoredProcedure, cadTransparencia, parametros);
        return cod_error + "<||>" + mensaje_error;
      }
      catch (Exception ex)
      {
        return ex.Message;
      }
    }
    /// <summary>
    /// Sirve para determinar si un usuario a presentado la autoevaluación después de realizar el ejercicio de auditorias ciudadanas
    /// </summary>
    /// <param name = "idAudiencia" > Es el id de la audiencia</param>
    /// <param name = "idUsuario" > Es el id del usuario</param>
    /// <returns>Devuelve un verdado o falso indicando si ya presentó o no la Autoevaluación</returns>
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