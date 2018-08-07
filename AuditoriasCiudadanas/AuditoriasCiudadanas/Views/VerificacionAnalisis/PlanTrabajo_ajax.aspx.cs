using System;
using System.Collections.Generic;
using System.Data;
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
      //dicccionario campos-etiqueta
      Dictionary<string, string> dicCamposTarea = new Dictionary<string, string>();
      dicCamposTarea.Add("Tarea.nombre","Tipo de Tarea");
      //dicCamposTarea.Add("Tarea.nombre", "Tipo de Tarea");


      //generacion excel
      //AuditoriasCiudadanas.Controllers.PlanTrabajoController datos = new AuditoriasCiudadanas.Controllers.PlanTrabajoController();
      // DataTable dtInfo = new DataTable("encuestas");
      /*dtInfo=datos.ObtenerPlanesTrabajo(fecha_ini_aux, fecha_fin_aux);
                  if (dtInfo.Rows.Count > 0) { 
                        foreach (KeyValuePair<string, string> kvp in dicPreguntas){
                          dtInfo.Columns[kvp.Key].ColumnName = kvp.Value.ToString();
                      }
    AuditoriasCiudadanas.Controllers.ExcelExport datosExcel = new AuditoriasCiudadanas.Controllers.ExcelExport();
    List<int> col_delete = new List<int>(new int[] { 0, 1, 2 });
    MemoryStream me_datos = datosExcel.ExportExcelFromDataTable("", dtInfo, col_delete);
    byte[] str = me_datos.ToArray();
    Response.ClearContent();
                      Response.ClearHeaders();
                      Response.ContentType = "application/vnd.ms-excel";
                      Response.AddHeader("Content-Disposition", "attachment; filename=" + "detalle_encuesta_" + DateTime.Now.Ticks + ".xls");
                      Response.Charset = "UTF-8";
                      Response.BinaryWrite(str);
                      Response.End();
                      Response.Flush();
                      Response.Clear();
                  }else{
                      Response.Write("<script>alert('No existen datos para exportar');</script>");
                  }*/

    }

  }
}