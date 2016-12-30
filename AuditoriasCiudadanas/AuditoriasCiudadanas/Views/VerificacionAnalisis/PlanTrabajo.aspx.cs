using System;

namespace AuditoriasCiudadanas.Views.VerificacionAnalisis
{
  public partial class PlanTrabajo : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      Controllers.PlanTrabajoController datosPlanTrabajo = new Controllers.PlanTrabajoController();
      if (Request.Form != null)
      {
        for (var i = 0; i < Request.Form.AllKeys.Length; i++)
          if (Request.Form.AllKeys[i] != null)
            switch (Request.Form.AllKeys[i].ToString().ToUpper())
            {
              case "PARAMETROINICIO":
                var parametrosInicio = Request.Form[i].ToString().Split('*');
                if (parametrosInicio.Length >= 2)
                {
                  hfcodigoBPIN.Value = parametrosInicio[0].ToString();
                  hftipoAudiencia.Value = parametrosInicio[1].ToString();
                }
                else if (parametrosInicio.Length == 1)
                {
                  hfcodigoBPIN.Value = parametrosInicio[0].ToString();
                  hftipoAudiencia.Value = "";
                }
                break;
            }
      }
    }
  }
}