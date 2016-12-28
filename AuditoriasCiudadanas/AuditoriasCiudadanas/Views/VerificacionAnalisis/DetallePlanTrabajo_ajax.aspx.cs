using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.VerificacionAnalisis
{
  public partial class DetallePlanTrabajo_ajax : System.Web.UI.Page
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
              case "BUSCARDETALLETAREA":
                int idTarea = 0;
                int.TryParse(Request.Form[i], out idTarea);
                Response.Write(datosPlanTrabajo.ObtenerDetalleTarea(idTarea));
                break;
              case "GUARDARDESCRIPCIONTAREA":
                Response.Write(datosPlanTrabajo.ActualizarDescripcionTarea(Request.Form[i].ToString()));
                break;
              case "GUARDARRESULTADOTAREA":
                Response.Write(datosPlanTrabajo.ActualizarResultadoTarea(Request.Form[i].ToString()));
                break;
              case "ELIMINARTAREA":
                int idTareaEliminar = 0;
                int.TryParse(Request.Form[i], out idTareaEliminar);
                Response.Write(datosPlanTrabajo.EliminarTarea(idTareaEliminar));
                break;
              case "FINALIZARTAREA":
                Response.Write(datosPlanTrabajo.FinalizarTarea(Request.Form[i].ToString()));
                break;
              case "OBTENERRECURSOSTAREA":
                int idTareaRecursos = 0;
                int.TryParse(Request.Form[i], out idTareaRecursos);
                Response.Write(datosPlanTrabajo.ObtenerRecursosTarea(idTareaRecursos));
                break;
              case  "GUARDARREGISTROMULTIMEDIA":
                Response.Write(datosPlanTrabajo.GuardarRegistroMultimedia(Request.Form[i].ToString()));
                break;
            }
      }
    }
  }
}