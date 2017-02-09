using System;
using System.Web.UI;

namespace AuditoriasCiudadanas.Views.VerificacionAnalisis
{
  public partial class DetallePlanTrabajo : Page
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
              case "DETALLEPLANTRABAJO":
                var parametrosInicio = Request.Form[i].ToString().Split('*');
                int idTarea = 0;
                int.TryParse(parametrosInicio[0], out idTarea);
                hfidTarea.Value = idTarea.ToString();
                if(parametrosInicio.Length>1) hfTitulo.Value = parametrosInicio[1];
                if (parametrosInicio.Length > 2)
                {
                  DateTime fechaTarea = DateTime.Now;
                  DateTime.TryParse(parametrosInicio[2], out fechaTarea);
                  hfFechaTarea.Value = fechaTarea.ToShortDateString();
                  hfHoraTarea.Value = fechaTarea.ToShortTimeString();
                }
                break;
            }
      }
    }
  }
}