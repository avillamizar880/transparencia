using AuditoriasCiudadanas.Models;

namespace AuditoriasCiudadanas.Controllers
{
  public class EvaluarExperienciaController
  {

    /// <summary>
    /// Sirve para guardar los resultados de la evaluación de experiencia
    /// </summary>
    /// <param name="parametrosGuardarEvalua">Son algunos de los parámetros necesarios para guardar la evaluación</param>
    /// <returns>Devuelve una cadena de texto que indica si la operación fue exitosa o no</returns>
    public string GuardarEvaluacionExperiencia(string parametrosGuardarEvalua)
    {
      var parametos = parametrosGuardarEvalua.Split('*');//El * es un caracter que usamos para separar los datos provenientes del formulario.
      return clsEvaluacionExperiencia.GuardarEvaluacionExperiencia(parametos);
    }
  }
}