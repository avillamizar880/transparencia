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
                int idTarea = 0;
                int.TryParse(Request.Form[i].ToString(), out idTarea);
                hfidTarea.Value = idTarea.ToString();
                break;
            }
      }
    }
  }
}