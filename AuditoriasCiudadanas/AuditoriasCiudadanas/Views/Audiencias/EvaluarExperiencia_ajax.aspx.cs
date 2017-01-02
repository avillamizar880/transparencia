using System;
using System.Web.UI;

namespace AuditoriasCiudadanas.Views.AudienciasPublicas
{
  public partial class EvaluarExperiencia_ajax : Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.EvaluarExperienciaController datosEvaluacionExperiencia = new Controllers.EvaluarExperienciaController();
      if (Request.Form != null)
      {
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
                case "GUARDAREVALUACIONEXPERIENCIA":
                Response.Write(datosEvaluacionExperiencia.GuardarEvaluacionExperiencia(Request.Form[i].ToString()));
                break;
            }
      }
    }
  }
}