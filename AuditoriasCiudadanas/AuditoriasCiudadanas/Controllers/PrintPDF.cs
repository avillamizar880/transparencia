using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AuditoriasCiudadanas.Controllers
{
    public class PrintPDF
    {

        //// Procedimiento para probar
        //public static void imprimeCarta(string text_carta)
        //{
        //    string vRta = "";
        //    string rutaPlanti = "";
        //    string rutaPDF = "carta.pdf";

        //        //Prepara el contenido de la carta y lo exporta a PDF 
        //        vRta = htmlPDF(rutaPlanti, rutaPDF, text_carta);
        //        if (!string.IsNullOrEmpty(vRta.Trim()))
        //        {

        //        }
        //        else {

        //        }

        //}

        //Este metodo interpreta las etiquetas basicas html y las pasa a objetos itexsharp para generar el pdf con una plantilla
        public string htmlPDF(string rutaPlant, string rutaPDF, string textHTML)
        {
            string functionReturnValue = null;
            string vRta = "";
            try
            {
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                if (File.Exists(rutaPDF))
                    File.Delete(rutaPDF);
                MemoryStream mstream = new MemoryStream();
                Document Documento = new Document(PageSize.LETTER, 60, 50, 70, 60);
                PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(Documento, mstream);

                Documento.Open();
                //Apertura del documento.
                Documento.NewPage();
                //Agregamos una pagina.
                iTextSharp.text.html.simpleparser.HTMLWorker htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(Documento);
                htmlWorker.Parse(new StringReader(textHTML));
                Documento.Close();
                //Cerramos el documento.

                if (!string.IsNullOrEmpty(rutaPlant))
                {
                    //si viene una ruta de una plantilla para utilizar como background realiza la fusion
                    mstream = fusionarPDF(rutaPlant, mstream, ref vRta);
                }

                using (FileStream fs = new FileStream(rutaPDF, FileMode.Create))
                {
                    byte[] arrbyte = mstream.ToArray();
                    fs.Write(arrbyte, 0, arrbyte.Length);
                }

            }
            catch (Exception ex)
            {
                vRta = ex.Message + " " + ex.StackTrace;
            }
            finally
            {
                functionReturnValue = vRta;
                //
            }
            return functionReturnValue;
        }

        //Este metodo interpreta las etiquetas basicas html y las pasa a objetos itexsharp para generar el pdf
        /*           
               this[HtmlTags.A] = A;
               this[HtmlTags.B] = EM_STRONG_STRIKE_SUP_SUP;
               this[HtmlTags.BODY] = DIV;
               this[HtmlTags.BR] = BR;
               this[HtmlTags.DIV] = DIV;
               this[HtmlTags.EM] = EM_STRONG_STRIKE_SUP_SUP;
               this[HtmlTags.FONT] = SPAN;
               this[HtmlTags.H1] = H;
               this[HtmlTags.H2] = H;
               this[HtmlTags.H3] = H;
               this[HtmlTags.H4] = H;
               this[HtmlTags.H5] = H;
               this[HtmlTags.H6] = H;
               this[HtmlTags.HR] = HR;
               this[HtmlTags.I] = EM_STRONG_STRIKE_SUP_SUP;
               this[HtmlTags.IMG] = IMG;
               this[HtmlTags.LI] = LI;
               this[HtmlTags.OL] = UL_OL;
               this[HtmlTags.P] = DIV;
               this[HtmlTags.PRE] = PRE;
               this[HtmlTags.S] = EM_STRONG_STRIKE_SUP_SUP;
               this[HtmlTags.SPAN] = SPAN;
               this[HtmlTags.STRIKE] = EM_STRONG_STRIKE_SUP_SUP;
               this[HtmlTags.STRONG] = EM_STRONG_STRIKE_SUP_SUP;
               this[HtmlTags.SUB] = EM_STRONG_STRIKE_SUP_SUP;
               this[HtmlTags.SUP] = EM_STRONG_STRIKE_SUP_SUP;
               this[HtmlTags.TABLE] = TABLE;
               this[HtmlTags.TD] = TD;
               this[HtmlTags.TH] = TD;
               this[HtmlTags.TR] = TR;
               this[HtmlTags.U] = EM_STRONG_STRIKE_SUP_SUP;
               this[HtmlTags.UL] = UL_OL;
*/
        public MemoryStream htmlPDF(string textHTML, Document Documento = null)
        {
            MemoryStream mstream = new MemoryStream();
            //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            if (Documento == null)
            {
                Documento = new Document(iTextSharp.text.PageSize.LETTER, 60, 50, 70, 60);
            }
            PdfWriter writer = iTextSharp.text.pdf.PdfWriter.GetInstance(Documento, mstream);

            Documento.Open();
            //Apertura del documento.
            Documento.NewPage();
            //Agregamos una pagina.
            iTextSharp.text.html.simpleparser.HTMLWorker htmlWorker = new iTextSharp.text.html.simpleparser.HTMLWorker(Documento);
            htmlWorker.Parse(new StringReader(textHTML));
            Documento.Close();
            //Cerramos el documento.

            return mstream;
        }

        //Este metodo toma cada hoja pdf plano (texto) y utiliza un pdf plantilla como background
        public MemoryStream fusionarPDF(string rutaPlant, MemoryStream msDatos, ref string vRta)
        {
            MemoryStream functionReturnValue = default(MemoryStream);
            MemoryStream streamFinal = new MemoryStream();
            try
            {
                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                PdfReader readerPlant = new PdfReader(rutaPlant);
                //plantilla background
                PdfReader readerDatos = new PdfReader(msDatos.ToArray());

                //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                PdfContentByte contenFinal = default(PdfContentByte);
                Document docFinal = new Document(readerDatos.GetPageSizeWithRotation(1));
                PdfWriter writerFinal = PdfWriter.GetInstance(docFinal, streamFinal);
                PdfImportedPage pagPlant = default(PdfImportedPage);
                PdfImportedPage pagImpor = default(PdfImportedPage);

                docFinal.Open();
                contenFinal = writerFinal.DirectContent;
                pagPlant = writerFinal.GetImportedPage(readerPlant, 1);

                int cantPag = readerDatos.NumberOfPages;
                for (int ii = 1; ii <= cantPag; ii++)
                {
                    docFinal.NewPage();
                    contenFinal.AddTemplate(pagPlant, 0, 0);
                    pagImpor = writerFinal.GetImportedPage(readerDatos, ii);
                    contenFinal.AddTemplate(pagImpor, 0, 0);
                }

                writerFinal.Flush();
                docFinal.Close();
                streamFinal.Close();
                readerDatos.Close();
                readerPlant.Close();
                writerFinal.Close();

            }
            catch (Exception ex)
            {
                vRta = ex.Message + " " + ex.StackTrace;
            }
            finally
            {
                functionReturnValue = streamFinal;
            }
            return functionReturnValue;
        }

        //30/07/2015 - Dubian Sepulveda - Este metodo toma todas las hojas de los 2 pdfs y los devuelve en uno solo
        public MemoryStream unirPDF(MemoryStream ms1, MemoryStream ms2, Document docFinal = null)
        {
            MemoryStream streamFinal = new MemoryStream();
            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            PdfReader reader1 = new PdfReader(ms1.ToArray());
            PdfReader reader2 = new PdfReader(ms2.ToArray());

            //++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
            PdfContentByte contenFinal = default(PdfContentByte);
            PdfImportedPage pagImpor = default(PdfImportedPage);
            if (docFinal == null)
                docFinal = new Document();
            PdfWriter writerFinal = PdfWriter.GetInstance(docFinal, streamFinal);

            docFinal.Open();
            contenFinal = writerFinal.DirectContent;

            for (int ii = 1; ii <= reader1.NumberOfPages; ii++)
            {
                docFinal.SetPageSize(reader1.GetPageSizeWithRotation(ii));
                docFinal.NewPage();
                pagImpor = writerFinal.GetImportedPage(reader1, ii);
                if (reader1.GetPageRotation(ii) == 90 | reader1.GetPageRotation(ii) == 270)
                {
                    contenFinal.AddTemplate(pagImpor, 0, -1, 1, 0, 0, reader1.GetPageSizeWithRotation(ii).Height);
                }
                else {
                    contenFinal.AddTemplate(pagImpor, 0, 0);
                }
            }

            for (int ii = 1; ii <= reader2.NumberOfPages; ii++)
            {
                docFinal.SetPageSize(reader2.GetPageSizeWithRotation(ii));
                docFinal.NewPage();
                pagImpor = writerFinal.GetImportedPage(reader2, ii);
                if (reader2.GetPageRotation(ii) == 90 | reader2.GetPageRotation(ii) == 270)
                {
                    contenFinal.AddTemplate(pagImpor, 0, -1, 1, 0, 0, reader2.GetPageSizeWithRotation(ii).Height);
                }
                else {
                    contenFinal.AddTemplate(pagImpor, 0, 0);
                }
            }

            writerFinal.Flush();
            docFinal.Close();
            streamFinal.Close();
            reader1.Close();
            reader2.Close();
            writerFinal.Close();

            return streamFinal;
        }

        //Imprime en plantilla los campos enviados y deja el archivo en disco
        public string estamparPDF(string rutaPlant, Dictionary<string, string> camposPDF, string nombArc)
        {
            string functionReturnValue = null;
            //As MemoryStream
            MemoryStream streamEstamp = new MemoryStream();
            string vRta = "";
            try
            {
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                System.Text.Encoding enc = System.Text.Encoding.ASCII;
                byte[] myByteArray = enc.GetBytes("123.asd");
                PdfReader readerPlant = new PdfReader(rutaPlant, myByteArray);
                PdfStamper stamper = new PdfStamper(readerPlant, new FileStream(nombArc, FileMode.Create));
                //streamEstamp
                AcroFields fields = stamper.AcroFields;


                //For Each aPair As DictionaryEntry In fields.Fields
                //    vRta &= aPair.Key & " XX " & Chr(13)
                //Next

                foreach (KeyValuePair<string, string> aPair in camposPDF)
                {
                    fields.SetField(aPair.Key, aPair.Value);
                }

                //fields.SetField("t2_trm_ano", "2014")

                //MessageBox.Show(fields.GetField("t2_trm_ano"))

                //Se convierte de archivo plantilla a PDF comun
                stamper.FormFlattening = true;
                stamper.FreeTextFlattening = true;
                stamper.Writer.SetPdfVersion(PdfWriter.PDF_VERSION_1_5);

                stamper.Close();
                readerPlant.Close();
                //streamEstamp.Close()
            }
            catch (Exception ex)
            {
                vRta = ex.Message + " " + ex.StackTrace;
            }
            finally
            {
                functionReturnValue = vRta;
                //streamEstamp
            }
            return functionReturnValue;
        }

        //Imprime en plantilla los campos enviados y deja el archivo en un memorystream
        public MemoryStream estamparPDF(string rutaPlant, Dictionary<string, string> camposPDF)
        {
            MemoryStream functionReturnValue = default(MemoryStream);
            MemoryStream streamEstamp = new MemoryStream();
            string vRta = "";
            try
            {
                //xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
                System.Text.Encoding enc = System.Text.Encoding.ASCII;
                byte[] myByteArray = enc.GetBytes("123.asd");
                PdfReader readerPlant = new PdfReader(rutaPlant);
                PdfStamper stamper = new PdfStamper(readerPlant, streamEstamp);
                AcroFields fields = stamper.AcroFields;

                foreach (KeyValuePair<string, string> aPair in camposPDF)
                {
                    fields.SetField(aPair.Key, aPair.Value);
                }


                //Se convierte de archivo plantilla a PDF comun
                stamper.FormFlattening = true;
                stamper.FreeTextFlattening = true;
                stamper.Writer.SetPdfVersion(PdfWriter.PDF_VERSION_1_5);

                stamper.Close();
                readerPlant.Close();
                //streamEstamp.Close()
            }
            catch (Exception ex)
            {
                vRta = ex.Message + " " + ex.StackTrace;
            }
            finally
            {
                functionReturnValue = streamEstamp;
            }
            return functionReturnValue;
        }
    }
}