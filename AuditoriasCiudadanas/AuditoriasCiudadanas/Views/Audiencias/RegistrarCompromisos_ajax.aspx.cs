using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class RegistrarCompromisos_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {

            if (HttpContext.Current.Request.HttpMethod == "POST")
            {
                string outTxt = "";
                var stream = HttpContext.Current.Request.InputStream;
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                string xml = Encoding.UTF8.GetString(buffer);
               
                AuditoriasCiudadanas.Controllers.AudienciasController datos = new AuditoriasCiudadanas.Controllers.AudienciasController();
                outTxt = datos.insCompromisos(xml);
                Response.Write(outTxt);
                Response.End();
            }

        }
    }
}