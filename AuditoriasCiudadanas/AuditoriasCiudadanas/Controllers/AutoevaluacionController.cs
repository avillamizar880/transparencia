using AuditoriasCiudadanas.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

namespace AuditoriasCiudadanas.Controllers
{
  public class AutoevaluacionController
  {
    /// <summary>
    /// Sirve para guardar los resultados de la Autoevaluación del auditor ciudadano
    /// </summary>
    /// <param name="parametrosGuardarAuto">Son algunos de los parámetros necesarios para guardar la autoevaluación</param>
    /// <returns> Devuelve una cadena de texto que indica si la operación fue exitosa o no </returns>
    public string GuardarAutoevaluacion(string parametrosGuardarAuto)
    {
      var parametos = parametrosGuardarAuto.Split('*');//El * es un caracter que usamos para separar los datos provenientes del formulario.
      return clsAutoevaluacion.GuardarAutoevaluacion(parametos);
    }
  }
}