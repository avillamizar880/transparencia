using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.VerificacionAnalisis
{
    public partial class formatoAsistencia_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int cont = rnd.Next(1000, 1000001);
            string dirupload = System.Configuration.ConfigurationManager.AppSettings["ruta_plantillas"];
            string ruta_archivo = HttpContext.Current.Server.MapPath("~/" + dirupload + "/FormatoAsistencia.pdf");
            System.Web.HttpResponse response = System.Web.HttpContext.Current.Response;

            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=formato_asistencia_" + cont.ToString() + ".pdf");
            Response.TransmitFile(ruta_archivo);
            Response.Flush();
            Response.End();
        }
    }
}