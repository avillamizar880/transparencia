using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Drawing;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class DescargaFormato_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            mostrarPDF(crearPDF());
        }

        private void mostrarPDF(byte[] strS)
        {
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + DateTime.Now);

            Response.BinaryWrite(strS);
            Response.End();
            Response.Flush();
            Response.Clear();
        }

        protected byte[] crearPDF()
        {
            try
            {
                HttpContext.Current.Response.ContentType = "application/pdf";
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment; filename=test.pdf");
                using (MemoryStream output = new MemoryStream())
                {
                    // Crear documento, especificar tamaño
                    Document doc = new Document(PageSize.LETTER);
                    PdfWriter PDFWriter = PdfWriter.GetInstance(doc, output);
                    doc.AddHeader("Content-Disposition", "attachment; filename=wissalReport.pdf");
                  
                    // Ruta de creacion fija
                    //PdfWriter writer = PdfWriter.GetInstance(doc,new FileStream(@"C:\prueba.pdf", FileMode.Create));

                    //Título y el autor, no visibles en el documento
                    doc.AddTitle("Lista Asistencia");
                    doc.AddCreator("AuditoriasCiudadanas");
                    // Abrir doc
                    doc.Open();
                    // Tipo de letra
                    iTextSharp.text.Font _standardFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 8, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                    // Encabezado de documento
                    Paragraph p = new Paragraph("LISTA DE ASISTENCIA", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14f, iTextSharp.text.Font.BOLD));
                    p.Alignment = 1;  //this is aligns to center
                    doc.Add(p);
                    doc.Add(Chunk.NEWLINE);

                    // Tabla de datos
                    PdfPTable tblDatos = new PdfPTable(6);
                    tblDatos.WidthPercentage = 100;
                    tblDatos.HorizontalAlignment = 0;
                    float[] cols = new float[] { 80f, 60f, 80f, 40f, 80f, 70f };
                    tblDatos.SetWidths(cols);

                    // Configuramos el título de las columnas de la tabla
                    addCell(tblDatos, "Nombre", 1,true);
                    addCell(tblDatos, "Cargo", 1,true);
                    addCell(tblDatos, "Entidad", 1,true);
                    addCell(tblDatos, "Teléfono", 1,true);
                    addCell(tblDatos, "Correo", 1,true);
                    addCell(tblDatos, "Firma", 1,true);

                    for (int i = 0; i < 25; i++) {
                        for (int j = 0; j < 7; j++) {
                            addCell(tblDatos, " ", 1,false);
                        }
                    }
 
                    // Add Tabla, close doc
                    doc.Add(tblDatos);
                    PDFWriter.Flush();
                    doc.Close();
                    return output.ToArray();
                
                }
            }
            catch (Exception ex){
                throw ex;
            }  
        }

        private static void addCell(PdfPTable tabla, string texto, int rowspan,Boolean negrita)
        {
            BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);
            iTextSharp.text.Font letra = new iTextSharp.text.Font(bfTimes, 8, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);
            if (negrita){
                letra = new iTextSharp.text.Font(bfTimes, 8, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);
            }
            PdfPCell cell = new PdfPCell(new Phrase(texto, letra));
            cell.Rowspan = rowspan;
            cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
            cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
            cell.BorderColor = BaseColor.BLACK;
            cell.BorderWidth = .1f;
            cell.MinimumHeight = 20f;
            tabla.AddCell(cell);
        }
    }
}