using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace AuditoriasCiudadanas.Views.Audiencias
{
    public partial class InformeProceso_ajax : System.Web.UI.Page
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
                string xml_txt = Encoding.UTF8.GetString(buffer);
                //separa nodo de otros
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml_txt);
               

                if (!string.IsNullOrEmpty(xml_txt))
                {
                    AuditoriasCiudadanas.Controllers.AudienciasController datos = new AuditoriasCiudadanas.Controllers.AudienciasController();
                    outTxt = datos.insInformeProceso(xml_txt);
                }

                Response.Write(outTxt);
                Response.End();
            }
        }
    }
}