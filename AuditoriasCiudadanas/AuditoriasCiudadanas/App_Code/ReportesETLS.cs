﻿using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace AuditoriasCiudadanas.App_Code
{
    public class ReportesETLS
    {
        public static void createReport(string titulo, string sp)
        {
            List<DataTable> datos = Models.clsReporteETL.ObtDatos(sp);
            if (datos[0].Rows.Count > 0)
            {
                Controllers.ExcelExport excel = new Controllers.ExcelExport();
                MemoryStream stream = excel.ExportExcelFromDataTable(titulo, datos[0]);

                //write to file
                FileStream file = new FileStream(HostingEnvironment.MapPath("~/Adjuntos/ReportesETLS/"
                                                    + titulo.Replace(' ', '_')
                                                    + DateTime.Now.ToString("_yyyyMMdd")
                                                    + ".xls")
                    , FileMode.Create
                    , FileAccess.Write);
                stream.WriteTo(file);
                file.Close();
                stream.Close();
            }


        }
    }
}