using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.UI;

namespace AuditoriasCiudadanas.Views.VerificacionAnalisis
{
  public partial class PlanTrabajo_ajax : App_Code.PageSession
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
                if (parametrosConsulta.Length >= 3)
                {
                  var idUsuario = 0;
                  var idGac = 0;
                  if (!int.TryParse(parametrosConsulta[1].ToString(), out idGac)) return;
                  if (!int.TryParse(parametrosConsulta[2].ToString(), out idUsuario)) return;
                  Response.Write(datosPlanTrabajo.ObtenerPlanesTrabajo(parametrosConsulta[0].ToString(), idGac, idUsuario));
                }
                break; 
              case "OBTENERTIPOTAREAS":
                Response.Write(datosPlanTrabajo.ObtenerTipoTareas());
              break;
              case "VALIDARUSUARIOMIEMBROGAC":
                Response.Write(datosPlanTrabajo.ValidarUsuarioMiembroGac(Request.Form[i].ToString()));
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
              case "VERIFICARUSUARIOGAC"://VerificarUsuarioGac
                Response.Write(datosPlanTrabajo.GuardarTarea(Request.Form[i].ToString()));
                break;
            }
      }
    }
  }
}