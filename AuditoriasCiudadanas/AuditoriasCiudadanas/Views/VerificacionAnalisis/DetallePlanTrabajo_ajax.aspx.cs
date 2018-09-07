using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.IO;
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
              case "ELIMINARREGISTRODIARIONOTASTAREA":
                int idEliminarDiarioNotas = 0;
                int.TryParse(Request.Form[i], out idEliminarDiarioNotas);
                Response.Write(datosPlanTrabajo.EliminarDiarioNotas(idEliminarDiarioNotas));
                break;
              case "ELIMINARDIARIONOTASTAREA":
                int idNotasTareaEliminar = 0;
                int.TryParse(Request.Form[i], out idNotasTareaEliminar);
                Response.Write(datosPlanTrabajo.EliminarDiarioNotasTarea(idNotasTareaEliminar));
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
                string dominio = ConfigurationManager.AppSettings["dominio_app"];
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
              //EliminarCompromisoActaReuniones
              case "ELIMINARCOMPROMISOACTAREUNIONES":
                int idCompromisoActaReuniones = 0;
                int.TryParse(Request.Form[i], out idCompromisoActaReuniones);
                Response.Write(datosPlanTrabajo.EliminarCompromisoActaReunionesTarea(idCompromisoActaReuniones));
                break;
              case "ELIMINARTAREA":
                int idTareaEliminar = 0;
                int.TryParse(Request.Form[i], out idTareaEliminar);
                Response.Write(datosPlanTrabajo.EliminarTarea(idTareaEliminar));
                break;
              //BuscarInformacionVisitaCampo
              case "BUSCARINFORMACIONVISITACAMPO":
                int idTareaVisitaCampo = 0;
                int.TryParse(Request.Form[i], out idTareaVisitaCampo);
                Response.Write(datosPlanTrabajo.BuscarInformacionVisitaCampo(idTareaVisitaCampo));
                break;
                //Eliminardetalletarearegistrofotografico
              case "ELIMINARDETALLETAREAREGISTROFOTOGRAFICO":
                string rutaImagen = string.Empty;
                string idUsuario = string.Empty;
                string cod_error = string.Empty;
                string msg_error = string.Empty;
                string sal = string.Empty;
                try
                {
                  if (HttpContext.Current.Request.HttpMethod == "POST")
                  {
                    if (Session["idUsuario"] == null) Response.Write("Usted no cuenta con permiso para eliminar la imagen o su sesión ha caducado");
                    else
                    {
                      idUsuario = Session["idUsuario"].ToString();
                      NameValueCollection pColl = Request.Params;
                      if (pColl.AllKeys.Contains("Eliminardetalletarearegistrofotografico")) rutaImagen = Request.Params.GetValues("Eliminardetalletarearegistrofotografico")[0].ToString();
                      string pathrefer = Request.UrlReferrer.ToString();
                      dirupload = ConfigurationManager.AppSettings["ruta_detalle_recurso_fotografico"];
                      string Serverpath = HttpContext.Current.Server.MapPath("~/" + dirupload);
                      string fileDirectory = Serverpath;
                      if (File.Exists(fileDirectory + "\\" + rutaImagen))
                      {
                        File.Delete(fileDirectory + "\\" + rutaImagen);
                        Response.AddHeader("Vary", "Accept");
                        try
                        {
                          if (Request["HTTP_ACCEPT"].Contains("application/json")) Response.ContentType = "application/json";
                          else Response.ContentType = "text/plain";
                        }
                        catch
                        {
                          Response.ContentType = "text/plain";
                        }
                      }
                      else
                      {
                        sal = "-1<||>Error al borrar el archivo. Se intenta borrar pero no es posible por restricción o acceso o imagen no existe en el servidor.";
                        cod_error = "-1";
                        msg_error = "Error al borrar el archivo";
                      }
                      //if (sal == string.Empty)
                      //{
                        #region Borramos el registro en la bd
                        datosPlanTrabajo = new Controllers.PlanTrabajoController();
                        sal = datosPlanTrabajo.EliminarRegistroMultimediaxUrl(rutaImagen + '*' + idUsuario);
                        string[] separador = new string[] { "<||>" };
                        var result = sal.Split(separador, StringSplitOptions.None);
                        cod_error = result[0];
                        if (result.Length > 1) msg_error = result[1];
                        #endregion Borramos el registro en la bd
                        DataTable dterrores = new DataTable();
                        dterrores.Columns.Add("cod_error", typeof(string));
                        dterrores.Columns.Add("msg_error", typeof(string));
                        dterrores.Rows.Add(cod_error, msg_error);
                        dterrores.TableName = "tabla";
                        sal = "{\"Head\":" + JsonConvert.SerializeObject(dterrores) + "}";
                      //}
                      Response.Write(sal);
                    }
                  }

                }
                catch (Exception exp)
                {
                  Response.Write(exp.Message);
                }
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
              case "BUSCARDETALLETAREAREGISTROFOTOGRAFICOVISITACAMPO":
                int idTareaRecursosVisitaCampo = 0;
                int.TryParse(Request.Form[i], out idTareaRecursosVisitaCampo);
                string diruploadRecFotVisCamp = ConfigurationManager.AppSettings["ruta_detalle_recurso_visita_campo"];
                if (diruploadRecFotVisCamp == string.Empty) Response.Write(string.Empty);
                else Response.Write(datosPlanTrabajo.ObtenerRecursosFotograficoTarea(idTareaRecursosVisitaCampo, diruploadRecFotVisCamp));
                break;
              case  "GUARDARREGISTROMULTIMEDIA":
                Response.Write(datosPlanTrabajo.GuardarRegistroMultimedia(Request.Form[i].ToString()));
                break;
              case "GUARDARFUNCIONARIOPUBLICOACOMPANOVISITATAREA":
                Response.Write(datosPlanTrabajo.GuardarFuncionarioPublicoAcompanaVisitaTarea(Request.Form[i].ToString()));
                break;
              case "GUARDARACTIVIDADESVISITACAMPOTAREA":
                Response.Write(datosPlanTrabajo.GuardarActividadesVisitaCampoTarea(Request.Form[i].ToString()));
                break;
            }
      }
    }
  }
}