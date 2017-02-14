using System;
using System.Collections.Generic;
using System.Configuration;
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
              case "GUARDARDIARIONOTASTAREA":
                Response.Write(datosPlanTrabajo.GuardarDetalleTareaDiarioNotas(Request.Form[i]));
                break;
              case "BUSCARDETALLETAREADIARIONOTAS":
                int idTareaDiarioNotas = 0;
                int.TryParse(Request.Form[i], out idTareaDiarioNotas);
                Response.Write(datosPlanTrabajo.ObtenerDetalleTareaDiarioNotas(idTareaDiarioNotas));
                break;
              case "BUSCARDETALLETAREAACTASREUNIONESCOMPROMISOS":
                int idTareaCompromisos = 0;
                int.TryParse(Request.Form[i], out idTareaCompromisos);
                Response.Write(datosPlanTrabajo.ObtenerCompromisosActasReuniones(idTareaCompromisos));
                break;
              case "BUSCARDETALLETAREAACTASREUNIONES":
                int idTareadtar = 0;
                int.TryParse(Request.Form[i], out idTareadtar);
                Response.Write(datosPlanTrabajo.ObtenerTemasTratarActasReuniones(idTareadtar));
                break;
              case "BUSCARDETALLETAREAACTAREUNIONESLISTADOASISTENCIA":
                int idTarealistasist = 0;
                int.TryParse(Request.Form[i], out idTarealistasist);
                string dirupload = ConfigurationManager.AppSettings["ruta_detalle_acta_reunion"];
                if (dirupload == string.Empty) Response.Write(string.Empty);
                else Response.Write(datosPlanTrabajo.ObtenerListaAsistenciaActasReuniones(idTarealistasist, 2, dirupload)); 
                break;
              case  "GUARDARTEMAACTAREUNIONTAREA":
                var datosParaGuardar = Request.Form[i].Split('*');
                int idTareActaReunion = 0;
                int.TryParse(datosParaGuardar[0], out idTareActaReunion);
                Response.Write(datosPlanTrabajo.GuardarTemasActasReuniones(idTareActaReunion, datosParaGuardar[1]));
                break;
              case "GUARDARCOMPROMISOACTAREUNIONTAREA":
                Response.Write(datosPlanTrabajo.GuardarCompromisoActaReunionTarea(Request.Form[i]));
                break;
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
              case "ELIMINARDIARIONOTASTAREA":
                int idNotasTareaEliminar = 0;
                int.TryParse(Request.Form[i], out idNotasTareaEliminar);
                Response.Write(datosPlanTrabajo.EliminarDiarioNotasTarea(idNotasTareaEliminar));
                break;
              case "ELIMINARTAREAREGISTROFOTOGRAFICO":
                int idNotasEliminarRegistroFotografico = 0;
                int.TryParse(Request.Form[i], out idNotasEliminarRegistroFotografico);
                Response.Write(datosPlanTrabajo.EliminarTareaRegistroFotografico(idNotasEliminarRegistroFotografico));
                break;
              case "FINALIZARTAREA":
                Response.Write(datosPlanTrabajo.FinalizarTarea(Request.Form[i].ToString()));
                break;
              case "OBTENERRECURSOSTAREA":
              case "BUSCARDETALLETAREAREGISTROFOTOGRAFICO":
                int idTareaRecursos = 0;
                int.TryParse(Request.Form[i], out idTareaRecursos);
                string diruploadRecFot = ConfigurationManager.AppSettings["ruta_detalle_recurso_fotografico"];
                if (diruploadRecFot == string.Empty) Response.Write(string.Empty);
                else Response.Write(datosPlanTrabajo.ObtenerRecursosFotograficoTarea(idTareaRecursos,diruploadRecFot));
                break;
              case  "GUARDARREGISTROMULTIMEDIA":
                Response.Write(datosPlanTrabajo.GuardarRegistroMultimedia(Request.Form[i].ToString()));
                break;
            }
      }
    }
  }
}