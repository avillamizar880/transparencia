using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

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
                string num_asistentes = "";
                int num_asistentes_aux = 0;
                var stream = HttpContext.Current.Request.InputStream;
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                string xml_txt = Encoding.UTF8.GetString(buffer);
                //separa nodo de otros
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml_txt);
                //remover nodo asistentes
                XmlElement el = (XmlElement)xmlDoc.SelectSingleNode("/compromisos/num_asistentes");
                if (el != null) { 
                    el.ParentNode.RemoveChild(el);
                    
                        foreach (XmlNode nodo in el)
                        {
                            num_asistentes = nodo.InnerText;
                        }
                }

                if (!string.IsNullOrEmpty(num_asistentes)) {
                    num_asistentes_aux = Convert.ToInt16(num_asistentes);
                }

                if(!string.IsNullOrEmpty(xml_txt)){
                  AuditoriasCiudadanas.Controllers.AudienciasController datos = new AuditoriasCiudadanas.Controllers.AudienciasController();
                  outTxt = datos.insCompromisos(xml_txt,num_asistentes_aux);
                }
                
                Response.Write(outTxt);
                Response.End();
            }

        }
    }
}