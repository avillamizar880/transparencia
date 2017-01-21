using System;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace AuditoriasCiudadanas.Views.Valoracion
{
    public partial class envioEncuesta_ajax : System.Web.UI.Page
    {
        public override void VerifyRenderingInServerForm(System.Web.UI.Control control)
        {
            //No obliga a a la página a tener un form incluido
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection pColl = Request.Params;
            string id_usuario = "";
            int id_usuario_aux = 0;
            if (pColl.AllKeys.Contains("id_usuario"))
            {
                id_usuario = Request.Params.GetValues("id_usuario")[0].ToString();
            }
            string outTxt = "";
            var stream = HttpContext.Current.Request.InputStream;
            byte[] buffer = new byte[stream.Length];
            stream.Read(buffer, 0, buffer.Length);
            string xml_txt = Encoding.UTF8.GetString(buffer);
            //separa nodo de otros
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml_txt);
            //remover nodo asistentes
            XmlElement el = (XmlElement)xmlDoc.SelectSingleNode("/respuestas/id_usuario");
            if (el != null)
            {
                el.ParentNode.RemoveChild(el);

                foreach (XmlNode nodo in el)
                {
                    id_usuario = nodo.InnerText;
                }
            }

            if (!string.IsNullOrEmpty(id_usuario))
            {
                id_usuario_aux = Convert.ToInt16(id_usuario);
            }

            if (!string.IsNullOrEmpty(xml_txt))
            {
                AuditoriasCiudadanas.Controllers.ValoracionController datos = new AuditoriasCiudadanas.Controllers.ValoracionController();
                outTxt = datos.insRespuestas(xml_txt, id_usuario_aux);
            }

            Response.Write(outTxt);
            Response.End();

        }
    }
}