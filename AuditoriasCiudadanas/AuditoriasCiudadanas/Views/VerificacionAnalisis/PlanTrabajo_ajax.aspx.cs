using System;
using System.Web.UI;

namespace AuditoriasCiudadanas.Views.VerificacionAnalisis
{
  public partial class PlanTrabajo_ajax : Page
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
              case "BUSCARPLANESTRABAJO":
                var parametrosConsulta = Request.Form[i].ToString().Split('*');
                if (parametrosConsulta.Length >= 2)
                {
                  Response.Write(datosPlanTrabajo.ObtenerPlanesTrabajo(parametrosConsulta[0].ToString(), parametrosConsulta[1].ToString()));
                }
                break; 
              case "OBTENERTIPOTAREAS":
                Response.Write(datosPlanTrabajo.ObtenerTipoTareas());
              break;
              case "OBTENERMIEMBROSGAC":
                Response.Write(datosPlanTrabajo.ObtenerMiembrosGac(Request.Form[i].ToString()));
                break;
              case "VERIFICARRELACIONPROYECTOAUDIENCIA":
                Response.Write(datosPlanTrabajo.VerificarRelacionProyectoAudiencia(Request.Form[i].ToString()));
                break;
              case "GUARDARTAREA":
                Response.Write(datosPlanTrabajo.GuardarTarea(Request.Form[i].ToString()));
                break;
            }
      }
    }
  }
}