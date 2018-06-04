using System;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class RegistrarCompromisos_pdf : App_Code.PageSession
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
                string outTxt = "";
                string id_audiencia = "";
                int id_audiencia_aux =0;

                NameValueCollection pColl = Request.Params;
                if (pColl.AllKeys.Contains("cod_bpin"))
                {
                    cod_bpin = Request.Params.GetValues("cod_bpin")[0].ToString();
                }
                if (pColl.AllKeys.Contains("id_audiencia"))
                {
                    id_audiencia = Request.Params.GetValues("id_audiencia")[0].ToString();
                    if(!string.IsNullOrEmpty(id_audiencia)){
                       id_audiencia_aux=Convert.ToInt16(id_audiencia);
                    }
                }
                Random rnd = new Random();
                int cont = rnd.Next(1000, 1000001);
                AuditoriasCiudadanas.Controllers.AudienciasController datos = new AuditoriasCiudadanas.Controllers.AudienciasController();
                outTxt = datos.obtRegCompromisos(id_audiencia_aux);
                string[] separador = new string[] { "<||>" };
                var result = outTxt.Split(separador, StringSplitOptions.None);
                Controllers.PrintPDF pdf = new Controllers.PrintPDF();

                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                Response.AddHeader("Content-Disposition", "Attachment;filename=RegCompromisos_" + cont.ToString() + ".pdf");
                Response.BinaryWrite(pdf.htmlPDF(result[0]).ToArray());
                Response.End();
                Response.Flush();
                Response.Clear();
            }
        }
    }
}