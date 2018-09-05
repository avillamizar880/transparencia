using AuditoriasCiudadanas.App_Code;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuditoriasCiudadanas.Controllers
{
    public class HtmlToPdfConverterController : Controller
    {

        public ActionResult SubmitAction(String form)
        {
            // instantiate a html to pdf converter object 
            HtmlToPdf converter = new HtmlToPdf();

            // create a new pdf document converting an url 
            string Domain = Request.Url.Scheme + System.Uri.SchemeDelimiter + Request.Url.Host + (Request.Url.IsDefaultPort ? "" : ":" + Request.Url.Port);

            string idUsuario = (string)System.Web.HttpContext.Current.Session["idUsuario"];

            PdfDocument doc = converter.ConvertUrl(Domain + form + "?key=" + System.Web.HttpUtility.UrlEncode(SafeParams.encode(idUsuario)));

            // save pdf document 
            byte[] pdf = doc.Save();

            // close pdf document 
            doc.Close();

            // return resulted pdf document 
            FileResult fileResult = new FileContentResult(pdf, "application/pdf");
            fileResult.FileDownloadName = "CertificadoAuditorDNP.pdf";
            return fileResult;
        }

    }
}