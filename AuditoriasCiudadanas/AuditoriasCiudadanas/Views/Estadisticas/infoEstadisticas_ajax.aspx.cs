using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Estadisticas
{
    public partial class infoEstadisticas_ajax : App_Code.PageSession
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string anyo = DateTime.Now.Year.ToString();
            string fecha_aux = "31/12/" + anyo;
            string fecha_ini = "";
            string fecha_fin = "";
            string tipo = "";
            int tipo_aux = 0;
            DateTime fecha_ini_aux = DateTime.ParseExact("01/01/2017", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime fecha_fin_aux = DateTime.ParseExact(fecha_aux, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            NameValueCollection pColl = Request.Params;

            if (pColl.AllKeys.Contains("tipo_reporte"))
            {
                tipo = Request.Params.GetValues("tipo_reporte")[0].ToString();
                if (!string.IsNullOrEmpty(tipo)) {
                    tipo_aux = Convert.ToInt16(tipo);
                }
            }
                if (pColl.AllKeys.Contains("fecha_ini"))
            {
                fecha_ini = Request.Params.GetValues("fecha_ini")[0].ToString();
                if (!string.IsNullOrEmpty(fecha_ini))
                {
                    DateTime.TryParseExact(fecha_ini, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha_ini_aux);
                }
            }
            if (pColl.AllKeys.Contains("fecha_fin"))
            {
                fecha_fin = Request.Params.GetValues("fecha_fin")[0].ToString();
                if (!string.IsNullOrEmpty(fecha_fin))
                {
                    DateTime.TryParseExact(fecha_fin, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fecha_fin_aux);
                }
                    
            }

            //generacion excel
            AuditoriasCiudadanas.Controllers.EstadisticasController datos = new AuditoriasCiudadanas.Controllers.EstadisticasController();
            List<DataTable> lstInfo = new List<DataTable>();
            lstInfo = datos.obtReporteEstadistica(tipo_aux,fecha_ini_aux, fecha_fin_aux);
            if (lstInfo.Count > 0)
            {
                DataTable dtInfo = new DataTable();
                dtInfo = lstInfo[0];
                AuditoriasCiudadanas.Controllers.ExcelExport datosExcel = new AuditoriasCiudadanas.Controllers.ExcelExport();
                List<int> col_delete = new List<int>(new int[] { });
                MemoryStream me_datos = datosExcel.ExportExcelFromDataTable("", dtInfo, null);
                byte[] str = me_datos.ToArray();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/vnd.ms-excel";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + "detalle_reporte_" + DateTime.Now.Ticks + ".xls");
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
        }
    }
}