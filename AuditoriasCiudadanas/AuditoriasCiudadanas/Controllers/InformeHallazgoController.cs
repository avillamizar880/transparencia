using System;

namespace AuditoriasCiudadanas.Controllers
{
  public class InformeHallazgoController
  {
   /// <summary>
   /// Sirve para guardar el informe de Hallazgo
   /// </summary>
   /// <param name="parametrosGuardar">Son los parámetros a guardar</param>
   /// <returns>Devuelve una cadena de texto que indica si se guardo correctamente el registro en la base de datos </returns>
    public string GuardarInformeHallazgo(string parametrosGuardar)
    {
      var parametros = parametrosGuardar.Split('*');
      return Models.clsReporteHallazgo.GuardarReporteHallazgos(parametros);
    }
    /// <summary>
    /// Sirve para guardar los adjuntos del reporte de hallazgos
    /// </summary>
    /// <param name="parametrosGuardar">Son los parámetros a guardar</param>
    /// <returns>Devuelve una cadena de texto que indica si se guardo correctamente el registro en la base de datos</returns>
    public string GuardarAdjuntoReporteHallazgo(string parametrosGuardar)
    {
      var parametros = parametrosGuardar.Split('*');
      return Models.clsReporteHallazgo.GuardarAdjuntoReporteHallazgos(parametros);
    }
  }
}