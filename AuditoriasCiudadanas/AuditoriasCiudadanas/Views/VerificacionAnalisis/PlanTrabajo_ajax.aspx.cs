using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
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
                if (parametrosConsulta.Length >= 3)
                {
                  var idUsuario = 0;
                  var idGac = 0;
                  if (!int.TryParse(parametrosConsulta[1].ToString(), out idGac)) return;
                  if (!int.TryParse(parametrosConsulta[2].ToString(), out idUsuario)) return;
                  Response.Write(datosPlanTrabajo.ObtenerPlanesTrabajo(parametrosConsulta[0].ToString(), idGac, idUsuario));
                }
                break;
              case "GENERARREPORTEPLANTRABAJO":
                var parametrosConsultaReporte = Request.Form[i].ToString().Split('*');
                if (parametrosConsultaReporte.Length >= 3)
                {
                  var idUsuario = 0;
                  var idGac = 0;
                  if (!int.TryParse(parametrosConsultaReporte[1].ToString(), out idGac)) return;
                  if (!int.TryParse(parametrosConsultaReporte[2].ToString(), out idUsuario)) return;
                  #region Generar excel
                  //Diccionario para encabezados
                  //Dictionary<string, string> dicCamposTarea = new Dictionary<string, string>();
                  //dicCamposTarea.Add("Tarea", "Tipo de Tarea");
                  //Creando un datatable
                  DataTable dtInfo = datosPlanTrabajo.ObtenerPlanesTrabajoReporte(parametrosConsultaReporte[0], idGac, idUsuario);
                  if (dtInfo.Rows.Count > 0)
                  {
                    dtInfo.Columns[0].ColumnName = "Tipo de Tarea";
                    dtInfo.Columns[1].ColumnName = "Responsable";
                    dtInfo.Columns[2].ColumnName = "Fecha";
                    dtInfo.Columns[3].ColumnName = "Fecha de Cierre";
                    dtInfo.Columns[4].ColumnName = "Detalle";
                    dtInfo.Columns[5].ColumnName = "Estado";
                    //foreach (KeyValuePair<string, string> kvp in dicCamposTarea)
                    //{
                    //  dtInfo.Columns[kvp.Key].ColumnName = kvp.Value.ToString();
                    //}
                    Controllers.ExcelExport datosExcel = new Controllers.ExcelExport();
                    List<int> col_delete = new List<int>(new int[] { 0, 1, 2 });
                    MemoryStream me_datos = datosExcel.ExportExcelFromDataTable("Reporte", dtInfo, col_delete);
                    byte[] str = me_datos.ToArray();
                    Response.ClearContent();
                    Response.ClearHeaders();
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.AddHeader("Content-Disposition", "attachment; filename=" + "Listado_plan_trabajo" + DateTime.Now.Ticks + ".xls");
                    Response.Charset = "UTF-8";
                    Response.BinaryWrite(str);
                    Response.End();
                    Response.Flush();
                    Response.Clear();
                  }
                  else
                  {
                    Response.Write("<script>alert('No existen datos para exportar');</script>");
                  }
                  #endregion Generar Excel


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