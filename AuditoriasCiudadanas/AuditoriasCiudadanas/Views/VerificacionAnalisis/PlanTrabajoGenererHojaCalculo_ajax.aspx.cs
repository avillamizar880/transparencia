using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.VerificacionAnalisis
{
  public partial class PlanTrabajoGenererHojaCalculo_ajax : System.Web.UI.Page
  {
    protected void Page_Load(object sender, EventArgs e)
    {
      if (HttpContext.Current.Request.HttpMethod == "POST" || HttpContext.Current.Request.HttpMethod == "GET")
      {
        Controllers.PlanTrabajoController datosPlanTrabajo = new Controllers.PlanTrabajoController();
        NameValueCollection pColl = Request.Params;
        var idUsuario = 0;
        var idGac = 0;
        var codigoBpin = string.Empty;
        if (pColl.AllKeys.Contains("hfcodigoBPIN")) codigoBpin= Request.Params.GetValues("hfcodigoBPIN")[0].ToString();
        if (pColl.AllKeys.Contains("hfidGac")) int.TryParse(Request.Params.GetValues("hfidGac")[0].ToString(), out idGac);
        if (pColl.AllKeys.Contains("hfidUsuario")) int.TryParse(Request.Params.GetValues("hfidUsuario")[0].ToString(), out idUsuario);
        #region Generar excel
        //Creando un datatable
        DataTable dtInfo = datosPlanTrabajo.ObtenerPlanesTrabajoReporte(codigoBpin, idGac, idUsuario);
        if (dtInfo.Rows.Count > 0)
        {

          foreach (DataRow drFila in dtInfo.Rows)
          {
            if (drFila[drFila.ItemArray.Length - 1] != DBNull.Value)
            {
              switch (drFila[drFila.ItemArray.Length - 1].ToString().ToUpper())
              {
                case "RED":
                  drFila[drFila.ItemArray.Length - 1] = "Vencido";
                break;
                case "GRIS":
                  drFila[drFila.ItemArray.Length - 1] = "Bien";
                  break;
                case "ORANGE":
                  drFila[drFila.ItemArray.Length - 1] = "Por vencer";
                  break;
                case "GREEN":
                  drFila[drFila.ItemArray.Length - 1] = "A tiempo";
                  break;
                case "BLUE":
                  drFila[drFila.ItemArray.Length - 1] = "Finalizado";
                  break;
                default:
                  drFila[drFila.ItemArray.Length - 1] = "A tiempo";
                  break;
              }
            }
          }
          dtInfo.Columns[0].ColumnName = "IdTarea";
          dtInfo.Columns[1].ColumnName = "Nombre Tarea";
          dtInfo.Columns[2].ColumnName = "Detalle";
          dtInfo.Columns[3].ColumnName = "IdUsuario";
          dtInfo.Columns[4].ColumnName = "Responsable";
          dtInfo.Columns[5].ColumnName = "EstadoAudGac";
          dtInfo.Columns[6].ColumnName = "Fecha";
          dtInfo.Columns[7].ColumnName = "Observaciones Auditor";
          dtInfo.Columns[8].ColumnName = "Fecha Cierre Tarea";
          dtInfo.Columns[9].ColumnName = "Estado Tarea";
          Controllers.ExcelExport datosExcel = new Controllers.ExcelExport();
          List<int> col_delete = new List<int>(new int[] { 0, 3, 5, 7 });
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
    }
  }
}