using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class ValoracionProyecto_pdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                string cod_bpin = "";
                string outTxt = "";

                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("cod_bpin"))
                {
                    cod_bpin = Request.Params.GetValues("cod_bpin")[0].ToString();
                }

                AuditoriasCiudadanas.Controllers.AudienciasController datos = new AuditoriasCiudadanas.Controllers.AudienciasController();
                outTxt = datos.obtValoracionProyecto(cod_bpin);
                string[] separador = new string[] { "<||>" };
                var result = outTxt.Split(separador, StringSplitOptions.None);
                Controllers.PrintPDF pdf = new Controllers.PrintPDF();

                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "Attachment;filename=ValoracionProyecto.pdf");
                Response.BinaryWrite(pdf.htmlPDF(result[0]).ToArray());
                Response.End();
                Response.Flush();
                Response.Clear();
            }

        }
    }
}