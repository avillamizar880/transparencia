using Hangfire.Server;
using Hangfire.Console;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Web.Hosting;

namespace AuditoriasCiudadanas.App_Code
{
    public class ReportesETLS
    {
        public void createReport(string titulo, string sp, int tipoReporte, PerformContext context)
        {

            context.WriteLine("Iniciando ejecución de SP: " + sp);

            List<DataTable> datos = Models.clsReporteETL.ObtDatos(sp);
            if (datos[0].Rows.Count > 0)
            {
                context.WriteLine("Registros encontrados: " + datos[0].Rows.Count.ToString());

                context.WriteLine("Inicia creación de excel.");
                Controllers.ExcelExport excel = new Controllers.ExcelExport();
                MemoryStream stream = excel.ExportExcelFromDataTable(titulo, datos[0]);

                //write to file
                string rutaReporte = "/Adjuntos/ReportesETLS/"
                                                    + titulo.Replace(' ', '_')
                                                    + DateTime.Now.ToString("_yyyyMMdd")
                                                    + ".xls";
                FileStream file = new FileStream(HostingEnvironment.MapPath("~" + rutaReporte)
                    , FileMode.Create
                    , FileAccess.Write);
                stream.WriteTo(file);
                file.Close();
                stream.Close();
                context.WriteLine("Excel guardado correctamente.");

                string rtaInsRutaReportes = Models.clsReporteETL.addRutaReportes(tipoReporte, rutaReporte);

                context.WriteLine("Insertado registro en RutaReportes.");
            }
            else
            {
                context.WriteLine("No se encontraron registros. No se crea excel.");
            }

            context.WriteLine("Finaliza ejecución de tarea programada!");
        }
    }
}