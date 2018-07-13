using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class InformePrevioInicio_pdf : App_Code.PageSession
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                string cod_bpin = "";
                string idGac = "";
                int id_gac = 0;
                string outTxt = "";

                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("cod_bpin"))
                {
                    cod_bpin = Request.Params.GetValues("cod_bpin")[0].ToString();
                }
                if (pColl.AllKeys.Contains("id_gac"))
                {
                    idGac = Request.Params.GetValues("id_gac")[0].ToString();
                    if (!string.IsNullOrEmpty(idGac))
                    {
                        id_gac = Convert.ToInt16(idGac);
                    }
                }

                AuditoriasCiudadanas.Controllers.AudienciasController datos = new AuditoriasCiudadanas.Controllers.AudienciasController();
                outTxt = datos.obtInformePrevioInicio(cod_bpin,id_gac);
                string[] separador = new string[] { "<||>" };
                var result = outTxt.Split(separador, StringSplitOptions.None);
                Controllers.PrintPDF pdf = new Controllers.PrintPDF();
                string nom_pdf = "InformePrevio_" + cod_bpin + ".pdf";
                 
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "Attachment;filename=" + nom_pdf);
                Response.BinaryWrite(pdf.htmlPDF(result[0]).ToArray());
                Response.End();
                Response.Flush();
                Response.Clear();
            }
        }
    }
}